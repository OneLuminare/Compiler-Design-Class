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

        #endregion

        #region Object Overrides

        public override string ToString()
        {
            String ret = null;
            ret = "Int Expression";
            return ret;
        }

        #endregion

       
    }
}
