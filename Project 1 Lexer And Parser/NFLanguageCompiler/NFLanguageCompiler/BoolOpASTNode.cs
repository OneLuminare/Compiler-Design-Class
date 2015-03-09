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
    public class BoolOpASTNode : ASTNode<BOOLOP_TYPE>
    {
        #region Constructors

        // Default constructor. Inits values
        public BoolOpASTNode()
        {
            type = ASTNodeType.ASTTYPE_BOOLOP;
            value = BOOLOP_TYPE.BOOLOP_EQUALS;
        }

        // Set constructor.
        public BoolOpASTNode(BOOLVAL_TYPE value)
            : this()
        {
            this.value = value;
        }

        #endregion
    }
}
