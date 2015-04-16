using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFLanguageCompiler
{
    // Basic node type representing the int values.
    // In this grammar can only be digits 0 - 9.
    // For ASTNode types used in more complex structures.
    // 
    // Base: ASTNode<>
    public class IntValASTNode : IntExprASTNode, IASTNodeValue<int>
    {
        #region Data Members

        private int value;
        private Token startToken;

        #endregion

        #region Properties

        public Token StartToken
        {
            get { return startToken; }
            set { startToken = value; }
        }

        public int Value
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

        #endregion

        #region Constructors

        // Default constructor. Inits values
        public IntValASTNode()
            : base(ASTNodeType.ASTTYPE_INTVAL)
        {
 
            value = 0;
        }

        // Set constructor.
        public IntValASTNode(int value)
            : this()
        {
            this.value = value;
        }

        #endregion

        #region Object Overrides

        public override string ToString()
        {
            String ret = null;

            ret = String.Format("Int Value: {0}", value.ToString());

            return ret;
        }

        #endregion
    }
}
