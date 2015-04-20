using System;
using System.Collections.Generic;
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
        private String opCodeData;
        private bool outputOpCodesToFile;

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
        }

        #endregion

        #region Op Code Generation Methods

        public ProcessReturnValue GenerateOpCodes(ASTNode rootASTNode, DynamicBranchTreeNode<SymbolHashTable> rootSymbolTableNode)
        {
            // Inits
            ProcessReturnValue ret = ProcessReturnValue.PRV_NONE;

            // Generate op codes recursively
            GenerateOpCodesRecursive(rootASTNode, rootSymbolTableNode);

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

        // Recursive generate opcode method. Travels AST generating op codes to OpCodeData string
        public void GenerateOpCodesRecursive(ASTNode curASTNode, DynamicBranchTreeNode<SymbolHashTable> curSymbolTable)
        {
            // Switch on node type
            /*
            switch (curASTNode.GetType())
            {
                case ASTNodeType.ASTTYPE_BLOCK:
                    // Move into 
                    break;

                case ASTNodeType.ASTTYPE_VARDEC:

                    break;
            }
             */
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
