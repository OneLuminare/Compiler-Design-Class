using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFLanguageCompiler
{
    // Basic node for more complex strucutres.
    // Describes a single character, no puncuation,
    // or a space.
    //
    // Base: ASTNode<>
    public class CharASTNode : ASTNode<char>
    {
        #region Constructors

        // Default constructor. Inits values
        public CharASTNode()
        {
            type = ASTNodeType.ASTTYPE_BOOLOP;
            value = ' ';
        }

        // Set constructor.
        public CharASTNode(char value)
            : this()
        {
            this.value = value;
        }

        #endregion
    }
}
