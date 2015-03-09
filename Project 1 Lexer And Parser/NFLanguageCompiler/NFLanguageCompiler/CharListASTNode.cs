using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFLanguageCompiler
{
    // Describes a char list AST node. Value is a string.
    //
    // Base: ASTNode<>
    public class CharListASTNode : ASTNode<String>
    {
        #region Constructors

        // Default constructor. Inits values
        public CharListASTNode()
        {
            type = ASTNodeType.ASTTYPE_CHARLIST;
            value = "";
        }

        // Set constructor.
        public CharListASTNode(String value)
            : this()
        {
            this.value = value;
        }

        #endregion
    }
}
