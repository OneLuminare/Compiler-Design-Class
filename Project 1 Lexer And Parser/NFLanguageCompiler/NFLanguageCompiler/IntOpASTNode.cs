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
    public class IntOpASTNode : ASTNode<INTOP_TYPE>
    {
        #region Constructors

        // Default constructor. Inits values
        public IntOpASTNode()
        {
            type = ASTNodeType.ASTTYPE_INTOP;
            value = INTOP_TYPE.INTOP_ADD;
        }

        #endregion
    }
}
