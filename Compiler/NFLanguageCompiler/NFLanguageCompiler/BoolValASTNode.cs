using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFLanguageCompiler
{
    #region Types

    // Describes bool value type.
    // Can be true or false
    public enum BOOLVAL_TYPE
    {
        BOOLVAL_TRUE,
        BOOLVAL_FALSE
    }

    #endregion

    // Basic ASTNode type for use in more complicated node structures.
    // Describes a boolean value of true or false.
    //
    // Base: BooleanExprASTNode<>
    public class BoolValASTNode : BooleanExprASTNode, IASTNodeValue<BOOLVAL_TYPE>
    {
        #region Data Members

        private BOOLVAL_TYPE value;
        private Token startToken;

        #endregion

        #region Properties

        public Token StartToken
        {
            get { return startToken; }
            set { startToken = value; }
        }

        public BOOLVAL_TYPE Value
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
        public BoolValASTNode()
            : base(ASTNodeType.ASTTYPE_BOOLVAL)
        {
            value = BOOLVAL_TYPE.BOOLVAL_FALSE;
        }

        // Set constructor.
        public BoolValASTNode(BOOLVAL_TYPE boolValType)
            : this()
        {
            value = boolValType;
        }

        #endregion

        #region Object Overrides

        public override string ToString()
        {
            String ret = null;

            if (value == BOOLVAL_TYPE.BOOLVAL_TRUE)
                ret =  "Boolean Value: true";
            else
                ret = "Boolean Value: false";

            return ret;
        }

        #endregion
    }
}
