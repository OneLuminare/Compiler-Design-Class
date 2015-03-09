using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFLanguageCompiler
{
    // Describes variable types.
    public enum VAR_TYPE
    {
        VARTYPE_INT,
        VARTYPE_STRING,
        VARTYPE_BOOLEAN
    }

    // Basic node used for more complex structures.
    // Describes a varaible type.
    //
    // Base: ASTNode<>
    public class TypeASTNode : ASTNode<VAR_TYPE>
    {
        #region Constructors

        // Default constructor. Inits values
        public TypeASTNode()
        {
            type = ASTNodeType.ASTTYPE_TYPE;
            value = VAR_TYPE.VARTYPE_INT;
        }

        // Set constructor.
        public TypeASTNode(VAR_TYPE value)
            : this()
        {
            this.value = value;
        }

        #endregion
    }
}
