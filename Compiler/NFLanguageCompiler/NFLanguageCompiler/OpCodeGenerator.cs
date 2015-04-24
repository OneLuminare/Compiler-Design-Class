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


        #endregion

        #region Delegates and Events

        //Message event
        public event MessageEventHandler OpCodeGenMessageEvent;

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

            // Create op code gen param
            param = new OpCodeGenParam(tempOpCodeData, rootSymbolTableNode, tempTables);

            // Gen op codes
            rootASTNode.GenOpCodes(param);

            // Add final 00
            param.opCodes.Append("00 ");
            param.curByte++;

            // Fill in memory locations and jump sizes
            programData = FillInTempOpCodeValues(param);

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
            VarTableEntry varEntry = null;
            HeapTableEntry heapEntry = null;
            BlockSizeTableEntry blockEntry = null;
            OpCodeData programData = new OpCodeData();

            // Determin stack size
            programData.stackSize = param.tables.MaxVarUsage;
            programData.stackStart = param.curByte + 1;

            // Determine heap size
            programData.heapSize = param.tables.TotalHeapSize();
            programData.heapStart = param.curByte + programData.stackSize + 1;

            // Dertermine number of 00 to write
            zeros = programData.stackSize + programData.heapSize;

            
            // Update size of file
            param.curByte += zeros;

            // Set program data size
            programData.totalBytes = param.curByte;

            // Fill in memory locations for heap
            for (int i = 0; i < param.tables.HeapTableCount(); i++)
            {
                heapEntry = param.tables.GetHeapTableEntryByIndex(i);

                heapEntry.MemoryLocation = programData.heapStart + curByte;

                curByte += heapEntry.Length;
            }


            // Split string
            strings = param.opCodes.ToString().Split(' ');

            // Cycle through codes
            for (int i = 0; i < strings.Length; i++)
            {
                // Set string
                s = strings[i];

                // Verify valid string
                if (s.Length > 0)
                {
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
                            strings[i] = String.Format("{0}", (programData.stackStart + varEntry.Offset).ToString("X"));
                        }
                    }
                    // Check for H (heap)
                    else if (s[0] == 'H')
                    {
                        // Get number off string
                        num = int.Parse(s.Substring(1, s.Length - 1));


                        // Find entry
                        heapEntry = param.tables.GetHeapTableEntry(num);

                        // Split of F
                        offStrings = s.Split('S');


                        // Get offf num if valid
                        if (offStrings.Length > 1)
                        {
                            o = offStrings[1];

                            localOffSet = int.Parse(o.Substring(1, o.Length - 1));
                        }
                        else
                            localOffSet = 0;


                        // Replace entry with address
                        if (heapEntry != null)
                        {
                            strings[i] = String.Format("{0}", (heapEntry.MemoryLocation + localOffSet).ToString("X"));
                        }
                    }
                    // Else if block parse flag
                    else if (s[0] == 'B')
                    {
                        // Get number off string
                        num = int.Parse(s.Substring(1, s.Length - 1));


                        // Find entry ( happens to work out that block id = index )
                        blockEntry = param.tables.GetBlockSizeTableEntry(num);


                        // Split of F
                        offStrings = s.Split('S');


                        // Get offf num if valid
                        if (offStrings.Length > 1)
                        {
                            o = offStrings[1];

                            localOffSet = int.Parse(o.Substring(1, o.Length - 1));
                        }
                        else
                            localOffSet = 0;

                        // Replace entry with address
                        if (blockEntry != null)
                        {
                            strings[i] = String.Format("{0}", (blockEntry.EndByte + 1 + localOffSet).ToString("X"));
                        }
                    }
                }
            }

            // Reset op codes
            param.opCodes = new StringBuilder(256);

            // Reassemble string
            for (int i = 0; i < strings.Length; i++)
            {
                s = strings[i];
                if (s.Length > 0)
                {
                    param.opCodes.Append(s);
                    param.opCodes.Append(" ");
                }
            }

            // Add 00 to op codes
            for (int i = 0; i < zeros; i++)
            {
                param.opCodes.Append("00 ");
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
