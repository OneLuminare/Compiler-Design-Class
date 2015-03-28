using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFLanguageCompiler
{
    // Block AST node. Just has a pointer to the left most StatmentASTNode sibling. Has one form: { STATEMENTLIST }
    // Signify first block(root AST node) with the IsProgramBlock property.
    //
    // Base: StatementASTNode
    public class BlockASTNode : StatementASTNode
    {
        #region Data Members

        protected StatementASTNode statementList;
        protected bool isProgramBlock;

        #endregion

        #region Properties

        public StatementASTNode StatementList
        {
            get{ return statementList; }
            set { statementList = value; }
        }

        public bool IsProgramBlock
        {
            get { return isProgramBlock;  }
            set { isProgramBlock = value;  }
        }

        #endregion

        #region Constructors

        // Default costructor, inits values
        public BlockASTNode()
            : base(ASTNodeType.ASTTYPE_BLOCK)
        {
            statementList = null;
            isProgramBlock = false;
        }

        // Set constructor.
        public BlockASTNode(StatementASTNode statementList )
            : this()
        {
            this.statementList = statementList;
        }

        #endregion

        #region Object Overrides

        public override string ToString()
        {
            return "Block";
        }

        #endregion
    }
}
