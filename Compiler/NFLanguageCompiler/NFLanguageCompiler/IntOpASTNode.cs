using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFLanguageCompiler
{
    #region Types

    // Describes Int Op type.
    // For uses of later additions such
    // as subtraction, multiplication, and division.
    public enum INTOP_TYPE
    {
        INTOP_ADD
    }

    #endregion

    // Basic node type representing the int mathmatical operations.
    // For Describes int expression of type INTVAL INTOP EXPR
    // 
    // Base: IntExprASTNode<>
    public class IntOpASTNode : IntExprASTNode, IASTNodeValue<INTOP_TYPE>
    {
        #region Data Members

        private INTOP_TYPE value;
        protected IntValASTNode intVal;
        protected ExprASTNode expr;
        protected Token startToken;

        #endregion

        #region Properties

        public Token StartToken
        {
            get { return startToken; }
            set { startToken = value; }
        }

        public INTOP_TYPE Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }

        public IntValASTNode IntVal
        {
            get { return intVal; }
            set { intVal = value; }
        }


        public ExprASTNode Expr
        {
            get { return expr; }
            set { expr = value; }
        }

        #endregion

        #region Constructors

        // Default constructor. Inits values
        public IntOpASTNode()
            : base(ASTNodeType.ASTTYPE_INTOP)
        {
            value = INTOP_TYPE.INTOP_ADD;
            intVal = null;
            expr = null;
        }

        //Set constructor
        public IntOpASTNode(INTOP_TYPE value)
            : this()
        {
            this.value = value;
        }

        #endregion

        #region Object Overrides

        public override string ToString()
        {
            String ret = null;

            if (value == INTOP_TYPE.INTOP_ADD)
                ret =  "Int Op: +";

            return ret;
        }

        #endregion

        #region ASTNode Overides

        // Gens opp codes for int operation add. 
        // Results are in the accum.
        //
        // Returns: Number of bytes generated.
        public override int GenOpCodes(OpCodeGenParam param)
        {
            // Inits
            VarTableEntry varEntry = null;
            int bytes = 0;
            int bytes2 = 0;

            try
            {
                // Load accummulator with constant
                param.AddBytes(0xA9, (byte)intVal.Value);


                // Get avaialbe stack location
                varEntry = param.tables.CreateTempVarTableEntry();

                // Set in use flag
                varEntry.InUse = true;

                // Increment var in use flag
                param.tables.IncVarIsUseCount();

                // Store accumulator in stack location
                param.AddBytes(0x8D);
                param.AddByteForUpdate('V', varEntry.VarID);
                param.AddBytes(0x00);

                // Increment bytes
                bytes += 5;

                // Check if expr is not null
                if (expr != null)
                {
                    // Gen op codes for expr
                    bytes2 += expr.GenOpCodes(param);
                }
                // Else expr is null
                else
                {
                    // Move 0 to accumulator
                    param.AddBytes(0xA9, 0x00);

                    // Increment bytes
                    bytes2 += 2;
                }

                // Add temp var to accumulator
                param.AddBytes(0x6D);
                param.AddByteForUpdate('V', varEntry.VarID);
                param.AddBytes(0x00);

                // Increment bytes
                bytes2 += 3;

                // Set temp var not in use
                varEntry.InUse = false;

                // Decrement counter
                param.tables.DecVarInUseCount();
            }

            // Catch over 256 byte error,
            // and throw up
            catch (IndexOutOfRangeException ex)
            {
                throw ex;
            }

            // Return bytes added
            return bytes + bytes2;
        }

        #endregion
    }
}
