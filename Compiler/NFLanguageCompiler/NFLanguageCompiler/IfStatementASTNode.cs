using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFLanguageCompiler
{
    // If statement AST node. Only has one form: if (EXPR) BLOCK
    //
    // Base: StatementASTNode
    public class IfStatementASTNode : StatementASTNode
    {
        #region Data Members

        protected ExprASTNode expr;
        protected BlockASTNode block;

        #endregion

        #region Properties

        public ExprASTNode Expr
        {
            get{ return expr; }
            set{ expr = value; }
        }

        public BlockASTNode Block
        {
            get { return block; }
            set { this.block = value; }
        }

        #endregion

        #region Constructors

        // Default costructor, inits values
        public IfStatementASTNode()
            : base(ASTNodeType.ASTTYPE_IFSTATEMENT)
        {
            expr = null;
            block = null;
        }

        // Set constructor.
        public IfStatementASTNode(ExprASTNode expr, BlockASTNode block )
            : this()
        {
            this.expr = expr;
            this.block = block;
        }

        #endregion

        #region Object Overrides

        public override string ToString()
        {
            String ret = null;

            ret = "If";

            return ret;
        }

        #endregion

        #region ASTNode Overides

        // Gens op codes for if statement, and following block.
        //
        // Returns: Number of bytes generated.
        public override int GenOpCodes(OpCodeGenParam param)
        {
            // Inits
            int bytes = 0;
            int bytes2 = 0;
            VarTableEntry varEntry = null;

            // Gen op codes for boolean exp ( results in accum )
            bytes += expr.GenOpCodes(param);

            // Create new temp var
            varEntry = param.tables.CreateTempVarTableEntry();

            // Set in use flag
            varEntry.InUse = true;

            // Increment in use count
            param.tables.IncVarIsUseCount();

            // Move results into temp memory
            //param.opCodes.AppendFormat("8D V{0} 00 ", varEntry.VarID);
            param.AddBytes(0x8D);
            param.AddByteForUpdate('V', varEntry.VarID);
            param.AddBytes(0x00);

            // Load 1 into accum
            //param.opCodes.Append("A2 01 ");
            param.AddBytes(0xA2, 0x01);

            // Compare temp (res of expr) to true (1)
            //param.opCodes.AppendFormat("EC V{0} 00 ", varEntry.VarID);
            param.AddBytes(0xEC);
            param.AddByteForUpdate('V', varEntry.VarID);
            param.AddBytes(0x00);

            // Branch to end of block (using curBlockID, as gen op
            // will use this id and incremement it. The current 
            // block at any time is really curBlockID - 1 ).
            //param.opCodes.AppendFormat("D0 B{0} ", param.curBlockID);
            param.AddBytes(0xD0);
            param.AddByteForUpdate('B', param.curBlockID);

            // Incrmeent bytes
            bytes += 10;

            // Update bytes
            //param.curByte += 10;

            // Set temp var not in use
            varEntry.InUse = false;

            // Decremeent in use count
            param.tables.DecVarInUseCount();

            // Gen op codes for block
            bytes += block.GenOpCodes(param);

            // Return bytes added
            return bytes;

        }

        #endregion
    }
}
