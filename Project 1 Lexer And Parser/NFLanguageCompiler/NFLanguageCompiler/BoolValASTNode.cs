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
    // Base: ASTNode<>
    public class BoolValASTNode : ASTNode<BOOLVAL_TYPE>
    {

        #region Constructors

        // Default constructor. Inits values
        public BoolValASTNode()
        {
            type = ASTNodeType.ASTTYPE_BOOLVAL;
            value = BOOLVAL_TYPE.BOOLVAL_FALSE;
        }

        // Set constructor.
        public BoolValASTNode(BOOLVAL_TYPE boolValType)
            : this()
        {
            value = boolValType;
        }

        #endregion
    }
}
