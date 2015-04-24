using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using DynamicBranchTree;

namespace NFLanguageCompiler
{
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
            set { opCodeBytes = value; }
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

            // Fill in memory locations and jump sizes
            FillInTempOpCodeValues();

            // Set op code from string builder
            opCodeData = tempOpCodeData.ToString();

            // Set op code total bytes
            opCodeBytes = TotalOpCodeBytes();

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
       
        private void FillInTempOpCodeValues()
        {
        }

        private int TotalOpCodeBytes()
        {
            return 0;
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
