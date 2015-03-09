using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFLanguageCompiler
{
    // Describes an ID AST node. Value can 
    // be any lower case char, a - z.
    //
    // Base: ASTNode<>
    public class IDASTNode : ASTNode<char>
    {
        #region Constructors

        // Default constructor. Inits values
        public IDASTNode()
        {
            type = ASTNodeType.ASTTYPE_ID;
            value = ' ';
        }

        // Set constructor.
        public IDASTNode(char value)
            : this()
        {
            this.value = value;
        }

        #endregion
    }
}
