using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFLanguageCompiler
{
    // If statement AST node. Only has one form: if (EXPR) BLOCK
    //
    // Base: StatementASTNode
    public class IfStatementASTNode : StatementASTNode
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
        public IfStatementASTNode()
            : base(ASTNodeType.ASTTYPE_IFSTATEMENT)
        {
            expr = null;
            block = null;
        }

        // Set constructor.
        public IfStatementASTNode(ExprASTNode expr, BlockASTNode block )
            : this()
        {
            this.expr = expr;
            this.block = block;
        }

        #endregion
    }
}
