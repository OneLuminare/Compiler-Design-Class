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
    public class CharASTNode : ASTNode, IASTNodeValue<char>
    {
        #region Data Members

        private char value;

        #endregion

        #region Properties

        public char Value
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
        public CharASTNode()
            : base(ASTNodeType.ASTTYPE_BOOLOP)
        {
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
