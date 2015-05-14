using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using DynamicBranchTree;

namespace NFLanguageCompiler
{
    public struct OpCodeData
    {
        public int totalBytes;
        public int stackStart;
        public int stackSize;
        public int heapStart;
        public int heapSize;
    }

    // Final state of compilation, turns AST into a sequence of 
    // op codes executable on the 6502 chipset.
    public class OpCodeGenerator
    {
        #region Data Members

        private int errorCount;
        private int warningCount;
        private int opCodeBytes;
        private String opCodeData;
        private bool outputOpCodesToFile;
        private OpCodeGenTempTables tempTables;
        private StringBuilder tempOpCodeData;
        private OpCodeData programData;
        private byte[] opCodeDataBytes;

        #endregion

        #region Properties

        // Warning count property
        public int WarningCount
        {
            get{ return warningCount; }
            set{ warningCount = value; }
        }

        // Erro count property
        public int ErrorCount
        {
            get { return errorCount; }
            set { errorCount = value; }
        }

        // Op code data
        public String OpCodeData
        {
            get { return opCodeData; }
            set { opCodeData = value; }
        }

        // Ouput to file option
        public bool OutputOpCodesToFile
        {
            get { return outputOpCodesToFile; }
            set { outputOpCodesToFile = value; }
        }

        // Op code total bytes
        public int OpCodeBytes
        {
            get { return opCodeBytes; }
        }

        // Get program data
        public OpCodeData ProgramData
        {
            get { return programData; }
        }

        // Get op code byte array
        public byte[] OpCodeDataBytes
        {
            get { return opCodeDataBytes; }
        }

        #endregion

        #region Delegates and Events

        //Message event
        public event MessageEventHandler OpCodeGenMessageEvent;

        // General Message Event
        public event MessageEventHandler OpCodeGenGeneralMessageEvent;

        //Error event
        public event WarningErrorEventHandler OpCodeGenErrorEvent;

        //Warning event
        public event WarningErrorEventHandler OpCodeGenWarningEvent;

        #endregion

        #region Constructors

        // Default constructor. Inits values.
        public OpCodeGenerator()
        {
            warningCount = 0;
            errorCount = 0;
            opCodeData = "";
            opCodeDataBytes = null;
            outputOpCodesToFile = false;
            tempOpCodeData = null;
            tempTables = null;
            opCodeBytes = 0;
        }

        #endregion

        #region Op Code Generation Methods

        public ProcessReturnValue GenerateOpCodes(ASTNode rootASTNode, DynamicBranchTreeNode<SymbolHashTable> rootSymbolTableNode)
        {
            // Inits
            ProcessReturnValue ret = ProcessReturnValue.PRV_NONE;
            OpCodeGenParam param;

            // Create temp tables
            tempTables = new OpCodeGenTempTables();
            tempOpCodeData = new StringBuilder(250);

            // Create new byte array
            opCodeDataBytes = new byte[256];

            // Reset error and warning count
            errorCount = 0;
            warningCount = 0;

            // Create op code gen param
            param = new OpCodeGenParam(tempOpCodeData, opCodeDataBytes, rootSymbolTableNode, tempTables);

            // Send message
            SendGeneralMessage("Starting code generation phase...");

            // Send message
            SendGeneralMessage("Generating op codes...");

            // Gen op codes
            rootASTNode.GenOpCodes(param);

            // Send message
            SendGeneralMessage("Op code generation complete.");


            // Add final 00
            //param.opCodes.Append("00 ");
            //param.curByte++;
            param.AddBytes(0x00);

            // Send message
            SendGeneralMessage("Inserting memory locations...");

            // Fill in memory locations and jump sizes
            programData = FillInTempOpCodeValues(param);

            // Send message
            SendGeneralMessage("Completed inserting memory locations.");

            // Send message
            SendGeneralMessage("Code generation phase complete.");

            // Send message
            SendGeneralMessage("Compilation complete.");

            // Set op code from string builder
            opCodeData = param.opCodes.ToString();

            // Set op code total bytes
            opCodeBytes = programData.totalBytes;

            //Determine return value
            if (ErrorCount > 0)
                ret = ProcessReturnValue.PRV_ERRORS;
            else if (WarningCount > 0)
                ret = ProcessReturnValue.PRV_WARNINGS;
            else
                ret = ProcessReturnValue.PRV_OK;

            //Return code
            return ret;
        }
       
        // Fills in variable locations, heap locations, and jump size for 
        // blocks in one pase. Collected some meta data about program.
        //
        // Returns: OpCodeData describing memory of program.
        private OpCodeData FillInTempOpCodeValues(OpCodeGenParam param)
        {
            // Inits          
            int zeros = 0;
            int num = 0;
            int localOffSet = 0;
            int curByte = 0;
            String[] strings = null;
            String s = null;
            String[] offStrings = null;
            String o = null;
            int len = 0;   
            VarTableEntry varEntry = null;
            HeapTableEntry heapEntry = null;
            BlockSizeTableEntry blockEntry = null;
            OpCodeData programData = new OpCodeData();
            TempByteData byteData = null;

            // Determin stack size
            programData.stackSize = param.tables.MaxVarUsage;
            programData.stackStart = param.curByte ;

            // Determine heap size
            programData.heapSize = param.tables.TotalHeapSize();
            programData.heapStart = param.curByte + programData.stackSize;



            // Write 00 over stack
            zeros = programData.stackSize;
            for (int i = 0; i < zeros; i++)
            {
                //param.opCodes.Append("00 ");
                param.AddBytes(0x00);
            }
            
            // Update size of file
            //param.curByte += zeros;

            // Send message
            SendGeneralMessage("Creating strings in memory...");

            // Fill in memory locations for heap
            for (int i = 0; i < param.tables.HeapTableCount(); i++)
            {
                heapEntry = param.tables.GetHeapTableEntryByIndex(i);

                heapEntry.MemoryLocation = programData.heapStart + curByte ;

                // Write char
                for (int n = 0; n < heapEntry.StringValue.Length; n++)
                {
                    //param.opCodes.AppendFormat("{0} ", ((int)heapEntry.StringValue[n]).ToString("X2"));
                    param.AddBytes((byte)heapEntry.StringValue[n]);
                }
                //param.opCodes.Append("00 ");
                param.AddBytes(0x00);
                //param.curByte += heapEntry.Length + 1;

                curByte += heapEntry.Length;
            }

            // Send message
            SendGeneralMessage("String creation complete.");

            // Set program data size
            programData.totalBytes = param.curByte;


            // Cycle through codes
            for (int i = 0; i < param.insertBytes.Count; i++)
            {
                // Get byte data
                byteData = (TempByteData)param.insertBytes[i];

                // Get place holder string
                s = byteData.VarSymbol;

                // Check for V (var table
                if (s[0] == 'V')
                {
                    // Get number off string
                    num = int.Parse(s.Substring(1, s.Length - 1));

                    // Find entry
                    varEntry = param.tables.GetVarTableEntry(num);

                    // Replace entry with address
                    if (varEntry != null)
                    {
                        //strings[i] = String.Format("{0}", (programData.stackStart + varEntry.Offset).ToString("X2"));
                        param.SetByte(byteData.Index, (byte)(programData.stackStart + varEntry.Offset));
                    }
                }
                // Check for H (heap)
                else if (s[0] == 'H')
                {
                    // Find length to s or end
                    len = s.Length;
                    for (int n = 1; n < s.Length; n++)
                    {
                        if (s[n] == 'S')
                            len = n;
                    }


                    // Get number off string
                    num = int.Parse(s.Substring(1, len - 1));


                    // Find entry
                    heapEntry = param.tables.GetHeapTableEntry(num);

                    // Split of F
                    offStrings = s.Split('S');


                    // Get offf num if valid
                    if (offStrings.Length > 1)
                    {
                        o = offStrings[1];

                        localOffSet = int.Parse(o.Substring(0, o.Length));
                    }
                    else
                        localOffSet = 0;


                    // Replace entry with address
                    if (heapEntry != null)
                    {
                       // strings[i] = String.Format("{0}", (heapEntry.MemoryLocation + localOffSet).ToString("X2"));
                        param.SetByte(byteData.Index, (byte)(heapEntry.MemoryLocation + localOffSet));
                    }
                }
                // Else if block parse flag
                else if (s[0] == 'B')
                {
                    // Find length to s or end
                    len = s.Length;
                    for (int n = 1; n < s.Length; n++)
                    {
                        if (s[n] == 'S')
                            len = n;
                    }

                    // Get number off string
                    num = int.Parse(s.Substring(1, len - 1));


                    // Find entry ( happens to work out that block id = index )
                    blockEntry = param.tables.GetBlockSizeTableEntry(num);


                    // Split of F
                    offStrings = s.Split('S');


                    // Get offf num if valid
                    if (offStrings.Length > 1)
                    {
                        o = offStrings[1];

                        localOffSet = int.Parse(o.Substring(0, o.Length));
                    }
                    else
                        localOffSet = 0;

                    // Replace entry with address
                    if (blockEntry != null)
                    {
                        //strings[i] = String.Format("{0}", (blockEntry.BlockSize + localOffSet).ToString("X2"));
                        param.SetByte(byteData.Index,(byte)(blockEntry.BlockSize + localOffSet));
                    }
                }
            }
   
            // Return program data
            return programData;
        }



        #endregion

        #region Helper Methods

        //Sends message event
        private void SendMessage(String msg)
        {
            if (OpCodeGenMessageEvent != null)
                OpCodeGenMessageEvent(msg);
        }

        // Send general message event
        private void SendGeneralMessage(String msg)
        {
            if (OpCodeGenGeneralMessageEvent != null)
                OpCodeGenGeneralMessageEvent(msg);

            SendMessage(msg);
        }

        //Sends warning event
        private void SendWarning(String msg)
        {
            if (OpCodeGenWarningEvent != null)
            {
                OpCodeGenWarningEvent(new Message(msg, -1, -1, SystemType.ST_OPCODEGEN));
            }

            //Increment warning count
            WarningCount++;
        }

        //Sends error event
        private void SendError(String msg)
        {
            if (OpCodeGenErrorEvent != null)
            {
                OpCodeGenErrorEvent(new Message(msg,-1,-1,SystemType.ST_OPCODEGEN));
            }

            //Incrment error count
            ErrorCount++;
        }


        #endregion
    }
}
