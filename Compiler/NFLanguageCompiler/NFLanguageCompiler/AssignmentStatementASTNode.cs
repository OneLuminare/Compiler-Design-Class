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
        protected Token startToken;

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

        public Token StartToken
        {
            get { return startToken; }
            set { startToken = value; }
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

        #region Object Overrides

        public override string ToString()
        {
            String ret = null;

            ret = "Assignment";

            return ret;
        }

        #endregion

        #region ASTNode Overrides

        // Generates op codes for expr, which is put in accum.
        // This value is then loaded into var's value.
        //
        // Returns: Number of op code bytes added.
        public override int GenOpCodes(OpCodeGenParam param)
        {
            // Inits
            VarTableEntry varEntry = null;
            int bytes = 0;

            // Gen op codes for expr , value in accum
            bytes += expr.GenOpCodes(param);
            
            // Retreive temp placehold from var table
            varEntry = param.tables.GetVarTableEntry(id.SymbolTableEntry.EntryID);

            // Move accumlator to memory
            param.opCodes.AppendFormat("8D V{0} 00 ", varEntry.VarID);

            // Increment bytes
            bytes += 3;

            // Update total bytes
            param.curByte += bytes;

            // Return bytesa added
            return bytes;
        }

        #endregion
    }
}
