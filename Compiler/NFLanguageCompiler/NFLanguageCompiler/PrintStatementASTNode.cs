using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFLanguageCompiler
{
    // Print statment AST node. Only has one form, print ( EXPR ).
    //
    // Base: StatementASTNode
    public class PrintStatementASTNode : StatementASTNode
    {
        #region Data Members

        protected ExprASTNode expr;
        protected Token startToken;

        #endregion

        #region Properties

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
        public PrintStatementASTNode()
            : base(ASTNodeType.ASTTYPE_PRINTSTATEMENT)
        {
            expr = null;
            startToken = null;
        }

        // Set cosntructor
        public PrintStatementASTNode( ExprASTNode expr )
            : this()
        {
            this.expr = expr;
        }

        #endregion

        #region Object Overrides

        public override string ToString()
        {
            String ret = null;

            ret = "Print";

            return ret;
        }

        #endregion

        #region ASTNode Overides

        // Gens op codes for print statment.
        // Calls system to print based on type of expr.
        //
        // Returns: Number of bytes generated.
        public override int GenOpCodes(OpCodeGenParam param)
        {
            // Inits
            int bytes = 0;
            VarTableEntry varEntry = null;
            VarTableEntry varEntryTrue = null;
            VarTableEntry varEntryFalse = null;
            HeapTableEntry heapEntryTrue = null;
            HeapTableEntry heapEntryFalse = null;
            IDASTNode idASTNode = null;

            try
            {
                // Gen op codes for expr. Results in accum
                bytes += expr.GenOpCodes(param);

                // Create temp var on stack
                varEntry = param.tables.CreateTempVarTableEntry();
                varEntry.InUse = true;
                param.tables.IncVarIsUseCount();

                // Load accumlator to memory (results from expr )
                //param.opCodes.AppendFormat("8D V{0} 00 ", varEntry.VarID);
                param.AddBytes(0x8D);
                param.AddByteForUpdate('V', varEntry.VarID);
                param.AddBytes(0x00);

                bytes += 3;

                // Inc cur bytes
                //param.curByte += 3;

                // Check if int expr, or var dec of type int
                if ((expr is IntExprASTNode) ||
                    ((expr is IDASTNode) && (((IDASTNode)expr).SymbolTableEntry.DataType == DataType.DT_INT)))
                {
                    // Load 1 int x reg
                    //param.opCodes.Append("A2 01 ");
                    param.AddBytes(0xA2, 0x01);

                    // Load into y register
                    //param.opCodes.AppendFormat("AC V{0} 00 ",varEntry.VarID);
                    param.AddBytes(0xAC);
                    param.AddByteForUpdate('V', varEntry.VarID);
                    param.AddBytes(0x00);

                    // Make system call
                    //param.opCodes.Append("FF ");
                    param.AddBytes(0xFF);

                    // Inc bytes
                    bytes += 6;

                    // Inc cur bytes
                    // param.curByte += 6;
                }
                // Else check if bool expr, or var dec with boolean type
                else if ((expr is BooleanExprASTNode) ||
                         ((expr is IDASTNode) && (((IDASTNode)expr).SymbolTableEntry.DataType == DataType.DT_BOOLEAN)))
                {
                    // Create strings for true and false on heap.
                    // If already on their it wont allocate new 
                    // ones, but use the same.

                    heapEntryTrue = param.tables.AddHeapTableEntry(param, "true");
                    heapEntryFalse = param.tables.AddHeapTableEntry(param, "false");


                    // Create temp vars on stack for true
                    varEntryTrue = param.tables.CreateTempVarTableEntry();
                    varEntryTrue.InUse = true;
                    param.tables.IncVarIsUseCount();

                    // Create temp var on stack for false
                    varEntryFalse = param.tables.CreateTempVarTableEntry();
                    varEntryFalse.InUse = true;
                    param.tables.IncVarIsUseCount();

                    // Load true string address in acc               
                    //param.opCodes.AppendFormat("A9 H{0} ", heapEntryTrue.HeapID);
                    param.AddBytes(0xA9);
                    param.AddByteForUpdate('H', heapEntryTrue.HeapID);

                    // Move to temp var
                    //param.opCodes.AppendFormat("8D V{0} 00 ", varEntryTrue.VarID);
                    param.AddBytes(0x8D);
                    param.AddByteForUpdate('V', varEntryTrue.VarID);
                    param.AddBytes(0x00);


                    // Load true add in acc
                    //param.opCodes.AppendFormat("A9 H{0} ", heapEntryFalse.HeapID);
                    param.AddBytes(0xA9);
                    param.AddByteForUpdate('H', heapEntryFalse.HeapID);

                    // Move to temp var
                    //param.opCodes.AppendFormat("8D V{0} 00 ", varEntryFalse.VarID);
                    param.AddBytes(0x8D);
                    param.AddByteForUpdate('V', varEntryFalse.VarID);
                    param.AddBytes(0x00);




                    // Load false into y reg
                    //param.opCodes.AppendFormat("AC V{0} 00 ", varEntryFalse.VarID);
                    param.AddBytes(0xAC);
                    param.AddByteForUpdate('V', varEntryFalse.VarID);
                    param.AddBytes(0x00);

                    // Load 01 int x reg
                    //param.opCodes.Append("A2 01 ");
                    param.AddBytes(0xA2, 0x01);

                    // Compare results with results from acc
                    //param.opCodes.AppendFormat("EC V{0} 00 ", varEntry.VarID);
                    param.AddBytes(0xEC);
                    param.AddByteForUpdate('V', varEntry.VarID);
                    param.AddBytes(0x00);

                    // Branch on not equal x bytes
                    //param.opCodes.Append("D0 04 ");
                    param.AddBytes(0xD0, 0x03);

                    // Load true into y reg
                    //param.opCodes.AppendFormat("AC V{0} 00 ", varEntryTrue.VarID);
                    param.AddBytes(0xAC);
                    param.AddByteForUpdate('V', varEntryTrue.VarID);
                    param.AddBytes(0x00);

                    // Load 2 int x reg
                    //param.opCodes.Append("A2 02 ");
                    param.AddBytes(0xA2, 0x02);

                    // Make system call
                    //param.opCodes.Append("FF ");
                    param.AddBytes(0xFF);

                    // Inc bytes
                    bytes += 26;

                    // Inc cur bytes
                    //param.curByte += 26;

                    /*
                    // Set temp vars not in use
                    varEntryTrue.InUse = false;
                    varEntryFalse.InUse = false;
                    param.tables.DecVarInUseCount();
                    param.tables.DecVarInUseCount();
                     * */

                }

                // Else check if string expr or var of string type
                else if ((expr is StringExprASTNode) ||
                         ((expr is IDASTNode) && (((IDASTNode)expr).SymbolTableEntry.DataType == DataType.DT_STRING)))
                {
                    // Load into temp var
                    //param.opCodes.AppendFormat("8D 
                    // Load expr res into y reg
                    //param.opCodes.AppendFormat("AC V{0} 00 ", varEntry.VarID);
                    param.AddBytes(0xAC);
                    param.AddByteForUpdate('V', varEntry.VarID);
                    param.AddBytes(0x00);

                    // Load 2 int x reg
                    //param.opCodes.Append("A2 02 ");
                    param.AddBytes(0xA2, 0x02);

                    // Make system call
                    //param.opCodes.Append("FF ");
                    param.AddBytes(0xFF);

                    // Increment bytes
                    bytes += 6;

                    // Inc cur bytes
                    //param.curByte += 6;
                }

                // Reset temp var
                varEntry.InUse = false;
                param.tables.DecVarInUseCount();
            }

            catch (IndexOutOfRangeException ex)
            {
                throw ex;
            }

            // Return bytes added
            return bytes;
        }

        #endregion
    }
}
