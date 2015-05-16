using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFLanguageCompiler
{
    // Assignemnt statement ASTNode. Only has one form: ID = EXPR .
    //
    // Base: StatementASTNode
    public class AssignmentStatementASTNode : StatementASTNode
    {
        #region Data Members

        protected IDASTNode id;
        protected ExprASTNode expr;
        protected Token startToken;

        #endregion

        #region Properties

        public IDASTNode Id
        {
            get{ return id; }
            set{ id = value; }
        }

        public ExprASTNode Expr
        {
            get { return expr; }
            set { this.expr = value; }
        }

        public Token StartToken
        {
            get { return startToken; }
            set { startToken = value; }
        }

        #endregion

        #region Constructors

        // Default costructor, inits values
        public AssignmentStatementASTNode()
            : base(ASTNodeType.ASTTYPE_ASSIGNSTATEMENT)
        {
            id = null;
            expr = null;
        }

        // Set constructor
        public AssignmentStatementASTNode(IDASTNode id, ExprASTNode expr)
            : this()
        {
            this.id = id;
            this.expr = expr;
        }

        #endregion

        #region Object Overrides

        public override string ToString()
        {
            String ret = null;

            ret = "Assignment";

            return ret;
        }

        #endregion

        #region ASTNode Overrides

        // Generates op codes for expr, which is put in accum.
        // This value is then loaded into var's value.
        //
        // Returns: Number of op code bytes added.
        public override int GenOpCodes(OpCodeGenParam param)
        {
            // Inits
            VarTableEntry varEntry = null;
            InitValueEntry initEntry = null;
            int bytes = 0;
            int curByte = param.curByte;
            bool value = false;
            StringExprASTNode stringNode = null;
            HeapTableEntry heapEntry = null;
            bool initVar = false;

            // Try for over 256 bytes
            try
            {

                // Get init value entry
                initEntry = param.tables.GetLastInitValueEntry(id.Value, id.SymbolTableEntry.DataType);

                // Check if value was already init
                if (initEntry != null)
                {
                    // Set init var
                    initVar = true;

                    // Check if int value 
                    if (expr is IntValASTNode)
                    {
                        // Set byte with value
                        param.SetByte(initEntry.Index, (byte)((IntValASTNode)expr).Value);

                        // Set inital value in symbol table
                        id.SymbolTableEntry.IntValue = ((IntValASTNode)expr).Value;
                    }
                    else if (expr is BoolValASTNode)
                    {
                        // Get bool value
                        if (((BoolValASTNode)expr).Value == BOOLVAL_TYPE.BOOLVAL_TRUE)
                            value = true;
                        else
                            value = false;

                        // Set byte with value
                        param.SetByte(initEntry.Index, (byte)(value == true ? 1 : 0));

                        // Set inital value in symbol table
                        id.SymbolTableEntry.IntValue = (value == true ? 1 : 0);
                    }
                    else if (expr is StringExprASTNode)
                    {
                        stringNode = ((StringExprASTNode)expr);
                        heapEntry = param.tables.AddHeapTableEntry(param,stringNode.Value);
                        param.AddInsertByte(initEntry.Index, 'H', heapEntry.HeapID, 0);

                        id.SymbolTableEntry.StringValue = stringNode.Value;
                    }
                    else
                        initVar = false;

                    // Remove from table if iniitalized
                    if (initVar)
                    {
                        param.tables.RemoveLastInitValueEntry(initEntry);
                        param.initVars++;
                    }
                }
                

                // Check if initialized optimization
                if (!initVar)
                {
                    // Gen op codes for expr , value in accum
                    bytes += expr.GenOpCodes(param);

                    // Retreive temp placehold from var table
                    varEntry = param.tables.GetVarTableEntry(id.SymbolTableEntry.EntryID);

                    // Move accumlator to memory "8D V{0} 00 "
                    param.AddBytes(0x8D);
                    param.AddByteForUpdate('V', varEntry.VarID);
                    param.AddBytes(0x00);

                    // Increment bytes
                    bytes += 3;
                }
            }

            // Catch over 256 bytes
            catch (IndexOutOfRangeException ex)
            {
                throw ex;
            }

            // Return bytesa added
            return bytes;
        }

        #endregion
    }
}
