using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFLanguageCompiler
{
    // Varaible declaration statement ASTNode. Only has one form: TYPE ID .
    //
    // Base: StatementASTNode
    public class VarDecStatementASTNode : StatementASTNode
    {
        #region Data Members

        protected TypeASTNode type;
        protected IDASTNode id;
        protected Token startToken;

        #endregion

        #region Properties

        public TypeASTNode Type
        {
            get{ return type; }
            set{ type = value; }
        }

        public IDASTNode Id
        {
            get { return id; }
            set { this.id = value; }
        }

        public Token StartToken
        {
            get{ return startToken; }
            set{ startToken = value; }
        }

        #endregion

        #region Constructors

        // Default costructor, inits values
        public VarDecStatementASTNode()
            : base(ASTNodeType.ASTTYPE_VARDEC)
        {
            id = null;
            type = null;
        }

        // Set constructor.
        public VarDecStatementASTNode(TypeASTNode type, IDASTNode id)
            : this()
        {
            this.type = type;
            this.id = id;
        }

        #endregion

        #region Object Overrides

        public override string ToString()
        {
            String ret = null;

            ret = "Variable Declaration";

            return ret;
        }

        #endregion
    }
}
