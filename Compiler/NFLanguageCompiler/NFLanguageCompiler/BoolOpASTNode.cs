using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFLanguageCompiler
{
    #region Types

    // Describes bool op value type.
    // Can be equal or not equal.
    public enum BOOLOP_TYPE
    {
        BOOLOP_EQUALS,
        BOOLOP_NOT_EQUALS
    }

    #endregion

    // Basic ASTNode type for use in more complicated node structures.
    // Describes a boolean operator of equals or not equals.
    //
    // Base: ASTNode<>
    public class BoolOpASTNode : BooleanExprASTNode, IASTNodeValue<BOOLOP_TYPE>
    {
        #region Data Members

        private BOOLOP_TYPE value;
        protected ExprASTNode exprOne;
        protected ExprASTNode exprTwo;
        protected Token startToken;

        #endregion

        #region Properties

        public Token StartToken
        {
            get { return startToken; }
            set { startToken = value; }
        }

        public BOOLOP_TYPE Value
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

        public ExprASTNode ExprTwo
        {
            get { return exprTwo; }
            set { exprTwo = value; }
        }

        public ExprASTNode ExprOne
        {
            get { return exprOne; }
            set { exprOne = value; }
        }

        #endregion

        #region Constructors

        // Default constructor. Inits values
        public BoolOpASTNode()
            : base(ASTNodeType.ASTTYPE_BOOLOP)
        {
            value = BOOLOP_TYPE.BOOLOP_EQUALS;
            exprOne = null;
            exprTwo = null;
        }

        // Set constructor.
        public BoolOpASTNode(BOOLOP_TYPE value)
            : this()
        {
            this.value = value;
        }

        #endregion
    
        #region Object Overrides

        public override string ToString()
        {
            String ret = null;

            if (value == BOOLOP_TYPE.BOOLOP_EQUALS)
                ret =  "Boolean Op: ==";
            else
                ret = "Boolean Op: !=";

            return ret;
        }

        #endregion

    }
}
