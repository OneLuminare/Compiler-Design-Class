using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFLanguageCompiler
{
    #region Type

    // Describes boolean grammar type
    public enum BOOLEXPR_TYPE
    {
        BET_ONE,
        BET_TWO
    }

    #endregion
    
    // Describes BooleanExpression ASTNode. 
    // Has two forms:
    //  BET_ONE:  ( EXPR BOOLOP EXPR )
    //  BET_TWO:  BOOLVAL
    //
    // Base: ExprASTNode
    // Interfaces: IASTNodeValue<>
    public class BooleanExprASTNode : ExprASTNode
    {

        #region Constructors

        // Default constructor. Inits values
        public BooleanExprASTNode()
            : base(ASTNodeType.ASTTYPE_BOOLEANEXPR)
        {
        }

        // Set construcor
        public BooleanExprASTNode(ASTNodeType type)
            : base(type)
        {
        }

        #endregion

        #region Object Overrides

        // Overide of to string
        public override string ToString()
        {
            String ret = null;

            ret = "Boolean Expression";

            return ret;
        }

        #endregion

       
    }
}
