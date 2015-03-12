using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFLanguageCompiler
{
    #region Types

    // Describes Int Op type.
    // For uses of later additions such
    // as subtraction, multiplication, and division.
    public enum INTOP_TYPE
    {
        INTOP_ADD
    }

    #endregion

    // Basic node type representing the int mathmatical operations.
    // For ASTNode types used in more complex structures.
    // 
    // Base: ASTNode<>
    public class IntOpASTNode : ASTNode, IASTNodeValue<INTOP_TYPE>
    {
        #region Data Members

        private INTOP_TYPE value;

        #endregion

        #region Properties

        public INTOP_TYPE Value
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
        public IntOpASTNode()
            : base(ASTNodeType.ASTTYPE_INTOP)
        {
            value = INTOP_TYPE.INTOP_ADD;
        }

        //Set constructor
        public IntOpASTNode(INTOP_TYPE value)
            : this()
        {
            this.value = value;
        }

        #endregion
    }
}
