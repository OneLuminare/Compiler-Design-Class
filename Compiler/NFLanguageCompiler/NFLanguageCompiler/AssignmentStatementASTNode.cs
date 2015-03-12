using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFLanguageCompiler
{
    // Assignemnt statement ASTNode. Only has one form: ID = EXPR .
    //
    // Base: StatementASTNode
    public class AssignmentStatementASTNode : StatementASTNode
    {
        #region Data Members

        protected IDASTNode id;
        protected ExprASTNode expr;

        #endregion

        #region Properties

        public IDASTNode Id
        {
            get{ return id; }
            set{ id = value; }
        }

        public ExprASTNode Expr
        {
            get { return expr; }
            set { this.expr = value; }
        }

        #endregion

        #region Constructors

        // Default costructor, inits values
        public AssignmentStatementASTNode()
            : base(ASTNodeType.ASTTYPE_ASSIGNSTATEMENT)
        {
            id = null;
            expr = null;
        }

        // Set constructor
        public AssignmentStatementASTNode(IDASTNode id, ExprASTNode expr)
            : this()
        {
            this.id = id;
            this.expr = expr;
        }

        #endregion
    }
}
