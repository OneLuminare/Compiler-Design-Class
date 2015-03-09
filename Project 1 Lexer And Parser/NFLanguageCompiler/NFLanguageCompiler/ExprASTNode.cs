using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFLanguageCompiler
{
    #region Types

    // Describes expression type.
    public enum EXPR_TYPE
    {
        ET_INTEXPR,
        ET_STRINGEXPR,
        ET_BOOLEANEXPR,
        ET_ID,
        ET_NONE
    }

    #endregion

    // Abstract base class for expression type ASTNodes.
    //
    // Base: ASTNode
    public abstract class ExprASTNode : ASTNode<EXPR_TYPE>
    {
        #region Constructors

        // Default constructor
        public ExprASTNode()
        {
            type = ASTNodeType.ASTTYPE_EXPR;
            value = EXPR_TYPE.ET_NONE;
        }

        // Set constructor
        public ExprASTNode(EXPR_TYPE value)
            : this()
        {
            this.value = value;
        }

        #endregion
    }
}
