using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFLanguageCompiler
{
    // Print statment AST node. Only has one form, print ( EXPR ).
    //
    // Base: StatementASTNode
    public class PrintStatementASTNode : StatementASTNode
    {
        #region Data Members

        protected ExprASTNode expr;

        #endregion

        #region Properties

        public ExprASTNode Expr
        {
            get { return expr; }
            set { this.expr = value; }
        }

        #endregion

        #region Constructors

        // Default costructor, inits values
        public PrintStatementASTNode()
            : base(ASTNodeType.ASTTYPE_PRINTSTATEMENT)
        {
            expr = null;
        }

        // Set cosntructor
        public PrintStatementASTNode( ExprASTNode expr )
            : this()
        {
            this.expr = expr;
        }

        #endregion
    }
}
