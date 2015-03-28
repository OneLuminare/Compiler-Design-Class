using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFLanguageCompiler
{
    // While statment AST node. Only has one form: while( EXPR ) BLOCK .
    //
    // Base: StatementASTNode
    public class WhileStatementASTNode : StatementASTNode
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
        public WhileStatementASTNode()
            : base(ASTNodeType.ASTTYPE_WHILESTATEMENT)
        {
            expr = null;
            block = null;
        }

        // Set constructor.
        public WhileStatementASTNode(ExprASTNode expr, BlockASTNode block )
            : this()
        {
            this.expr = expr;
            this.block = block;
        }

        #endregion

        #region Object Overrides

        public override string ToString()
        {
            String ret = null;

            ret = "While";

            return ret;
        }

        #endregion
    }
}
