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
    }
}
