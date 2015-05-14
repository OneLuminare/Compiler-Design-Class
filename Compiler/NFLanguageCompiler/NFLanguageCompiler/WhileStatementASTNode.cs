using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFLanguageCompiler
{
    // While statment AST node. Only has one form: while( EXPR ) BLOCK .
    //
    // Base: StatementASTNode
    public class WhileStatementASTNode : StatementASTNode
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
        public WhileStatementASTNode()
            : base(ASTNodeType.ASTTYPE_WHILESTATEMENT)
        {
            expr = null;
            block = null;
        }

        // Set constructor.
        public WhileStatementASTNode(ExprASTNode expr, BlockASTNode block )
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

            ret = "While";

            return ret;
        }

        #endregion

        #region ASTNode Overides

        // Gens op codes for while loop.
        //
        // Returns: Number of bytes generated.
        public override int GenOpCodes(OpCodeGenParam param)
        {
            // Inits
            int bytes = 0;
            int bytes2 = 0;
            int jumpByte = 0;
            int startByte = param.curByte;
            VarTableEntry varEntry = null;
            VarTableEntry varEntry2 = null;


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

            // Incrmeent bytes
            bytes += 3;

            // Capture current byte (where to jump to at end of loop)
            jumpByte = param.curByte + bytes;

            // Load 1 into accum
            //param.opCodes.Append("A2 01 ");
            param.AddBytes(0xA2, 0x01);

            // Compare temp (res of expr) to true (1)
            //param.opCodes.AppendFormat("EC V{0} 00 ", varEntry.VarID);
            param.AddBytes(0xEC);
            param.AddByteForUpdate('V', varEntry.VarID);
            param.AddBytes(0x00);

            // Branch to end of block, and 12 more to skip
            // forced jump to begining of while
            //param.opCodes.AppendFormat("D0 B{0}S{1} ", param.curBlockID, 12);
            param.AddBytes(0xD0);
            param.AddByteForUpdate('B', param.curBlockID, 12);

            // Incrmeent bytes
            bytes += 7;

            // Set current byte (for calling gen op)
            //param.curByte += 10;

            // Set temp var not in use
            varEntry.InUse = false;

            // Decremeent in use count
            param.tables.DecVarInUseCount();

            // Gen op codes for block
            bytes2 += block.GenOpCodes(param);

            // ### Force NE Jump ### //

            // Create another new temp var
            varEntry2 = param.tables.CreateTempVarTableEntry();

            // Set in use
            varEntry2.InUse = true;

            // Inc var in use count
            param.tables.IncVarIsUseCount();

            // Load 0 into acc
            //param.opCodes.Append("A9 00 ");
            param.AddBytes(0xA9, 0x00);

            // Load acc to temp var
            //param.opCodes.AppendFormat("8D V{0} 00 ", varEntry2.VarID);
            param.AddBytes(0x8D);
            param.AddByteForUpdate('V', varEntry2.VarID);
            param.AddBytes(0x00);

            // Load 1 into x reg
            //param.opCodes.Append("A2 01 ");
            param.AddBytes(0xA2, 0x01);

            // Compare temp to x (which will always be not equal )
            //param.opCodes.AppendFormat("EC V{0} 00 ", varEntry2.VarID);
            param.AddBytes(0xEC);
            param.AddByteForUpdate('V', varEntry2.VarID);
            param.AddBytes(0x00);

            // Incremeent bytes
            bytes2 += 12;

            // Update bytes ( I do it before next statmement for 
            // caculation of accurate curByte )
            //param.curByte += 12;
            
            // Branch to top of while loop ( note these two bytes already
            // added to curByte )
            //param.opCodes.AppendFormat("D0 {0} ",(256 - param.curByte + startByte + 1).ToString("X2"));
            param.AddBytes(0xD0, (byte)(255 - ( param.curByte - startByte + 1 ) ));


            // Set temp var not in use
            varEntry2.InUse = false;

            // Decremeent in use count
            param.tables.DecVarInUseCount();

           

            // Return bytes added
            return bytes + bytes2;

        }

        #endregion
    }
}
