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
    public class IntExprASTNode : ExprASTNode
    {
        #region Data Members

        //private INTEXPR_TYPE value;

        #endregion

        #region Properties

        /*
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
         * */

        #endregion

        #region Data Members


        #endregion

        #region Properties


        #endregion

        #region Constructors

        // Default constructor. Inits values
        public IntExprASTNode()
            : base(ASTNodeType.ASTTYPE_INTEXPR)
        {
           

        }

        public IntExprASTNode(ASTNodeType type)
            : base(type)
        {

        }

        /*
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
         * 

        // Set constructor for type two: digit intop expr
        public IntExprASTNode(IntValASTNode intVal, IntOpASTNode intOp, ExprASTNode expr)
            : this()
        {
            value = INTEXPR_TYPE.IET_TWO;
            this.intVal = intVal;
            this.intOp = intOp;
            this.expr = expr;
        }
         * */

        #endregion

        #region Object Overrides

        public override string ToString()
        {
            String ret = null;
            /*
            if (value == INTEXPR_TYPE.IET_ONE)
                ret =  String.Format("Int Expression: {0}",intVal.ToString());
            else
                ret = String.Format("Int Expression: {0} {1} {2}",intVal.ToString(),intOp.ToString(),expr.ToString());
            */
            ret = "Int Expression";
            return ret;
        }

        #endregion
    }
}
