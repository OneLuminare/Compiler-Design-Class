using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFLanguageCompiler
{
    // Describes int expression type.
    // Tell which data members will be used.
    public enum INTEXPR_TYPE
    {
        IET_ONE,
        IET_TWO
    }

    // ASTNode for an int expression.
    // Can be in two formats:
    // IET_ONE: DIGIT 
    // IET_TWO: DIGIT INTOP EXPR
    //
    // Base: ExprASTNode
    public class IntExprASTNode : ExprASTNode, IASTNodeValue<INTEXPR_TYPE>
    {
        #region Data Members

        private INTEXPR_TYPE value;

        #endregion

        #region Properties

        public INTEXPR_TYPE Value
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

        #endregion

        #region Data Members

        protected IntValASTNode intVal;
        protected IntOpASTNode intOp;
        protected ExprASTNode expr;

        #endregion

        #region Properties

        public IntValASTNode IntVal
        {
            get { return intVal; }
            set { intVal = value; }
        }

        public IntOpASTNode IntOp
        {
            get { return intOp; }
            set { intOp = value; }
        }

        public ExprASTNode Expr
        {
            get { return expr; }
            set { expr = value; }
        }

        #endregion

        #region Constructors

        // Default constructor. Inits values
        public IntExprASTNode()
            : base(ASTNodeType.ASTTYPE_INTEXPR)
        {
            value = INTEXPR_TYPE.IET_ONE;
            intVal = null;
            intOp = null;
            expr = null;
        }

        // Basic set constructor.
        public IntExprASTNode(INTEXPR_TYPE value)
            : this()
        {
            this.value = value;
        }

        // Set constructor for type one: digit
        public IntExprASTNode(IntValASTNode intVal)
            : this()
        {
            value = INTEXPR_TYPE.IET_ONE;
            this.intVal = intVal;
        }

        // Set constructor for type two: digit intop expr
        public IntExprASTNode(IntValASTNode intVal, IntOpASTNode intOp, ExprASTNode expr)
            : this()
        {
            value = INTEXPR_TYPE.IET_TWO;
            this.intVal = intVal;
            this.intOp = intOp;
            this.expr = expr;
        }

        #endregion
    }
}
