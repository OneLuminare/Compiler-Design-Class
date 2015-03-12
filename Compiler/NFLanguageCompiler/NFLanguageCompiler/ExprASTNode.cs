using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFLanguageCompiler
{
    // Abstract base class for expression type ASTNodes.
    //
    // Base: ASTNode
    public abstract class ExprASTNode : ASTNode
    {

        #region Constructors

        // Default constructor
        public ExprASTNode()
            :base(ASTNodeType.ASTTYPE_EXPR)
        {

        }

        public ExprASTNode(ASTNodeType nodeType)
            : base(nodeType)
        {
        }

        #endregion
    }
}
