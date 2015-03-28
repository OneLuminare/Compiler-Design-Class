using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFLanguageCompiler
{
    #region Type

    // Describes boolean grammar type
    public enum BOOLEXPR_TYPE
    {
        BET_ONE,
        BET_TWO
    }

    #endregion
    
    // Describes BooleanExpression ASTNode. 
    // Has two forms:
    //  BET_ONE:  ( EXPR BOOLOP EXPR )
    //  BET_TWO:  BOOLVAL
    //
    // Base: ExprASTNode
    // Interfaces: IASTNodeValue<>
    public class BooleanExprASTNode : ExprASTNode, IASTNodeValue<BOOLEXPR_TYPE>
    {
        #region Data Members

        protected ExprASTNode exprOne;
        protected BoolOpASTNode boolOp;
        protected ExprASTNode exprTwo;
        protected BoolValASTNode boolVal;
        private BOOLEXPR_TYPE value;

        #endregion

        #region Properties

        public ExprASTNode ExprTwo
        {
            get { return exprTwo; }
            set { exprTwo = value; }
        }

        public BoolOpASTNode BoolOp
        {
            get { return boolOp; }
            set { boolOp = value; }
        }

        public ExprASTNode ExprOne
        {
            get { return exprOne; }
            set { exprOne = value; }
        }

        public BoolValASTNode BoolVal
        {
            get{ return boolVal; }
            set{ boolVal = value; }
        }
  
        public BOOLEXPR_TYPE Value
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
        public BooleanExprASTNode()
            : base(ASTNodeType.ASTTYPE_BOOLEANEXPR)
        {
            value = BOOLEXPR_TYPE.BET_ONE;
            exprOne = null;
            exprTwo = null;
            boolOp = null;
            boolVal = null;
        }

        // Basic set constructor.
        public BooleanExprASTNode(BOOLEXPR_TYPE value)
            : this()
        {
            this.value = value;
        }

        // Set constructor for type one: ( EXPR BOOLOP EXPR )
        public BooleanExprASTNode(ExprASTNode expr1, BoolOpASTNode boolOp, ExprASTNode expr2)
            : this()
        {
            value = BOOLEXPR_TYPE.BET_ONE;
            this.exprOne = expr1;
            this.boolOp = boolOp;
            this.exprTwo = expr2;
        }

        // Set constructor for type two: BOOLVAL
        public BooleanExprASTNode(BoolValASTNode boolVal)
            : this()
        {
            value = BOOLEXPR_TYPE.BET_TWO;
            this.boolVal = boolVal;
        }

        #endregion

        #region Object Overrides

        public override string ToString()
        {
            String ret = null;

            if (value == BOOLEXPR_TYPE.BET_ONE)
                ret =  String.Format("Boolean Expression: {0} {1} {2}", exprOne.ToString(), boolOp.ToString(), exprTwo.ToString());
            else
                ret = String.Format("Boolean Expression: {0}",boolVal.ToString());

            return ret;
        }

        #endregion
    }
}
