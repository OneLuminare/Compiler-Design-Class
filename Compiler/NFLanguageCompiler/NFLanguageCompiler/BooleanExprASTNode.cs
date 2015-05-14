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
        #region Data Members

     
        //private BOOLEXPR_TYPE value;

        #endregion

        #region Properties

  /*
        public BOOLEXPR_TYPE Value
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

        #region Constructors

        // Default constructor. Inits values
        public BooleanExprASTNode()
            : base(ASTNodeType.ASTTYPE_BOOLEANEXPR)
        {
            //value = BOOLEXPR_TYPE.BET_ONE;

        }

        public BooleanExprASTNode(ASTNodeType type)
            : base(type)
        {
        }

        #endregion

        #region Object Overrides

        public override string ToString()
        {
            String ret = null;

            ret = "Boolean Expression";

            return ret;
        }

        #endregion
    }
}
