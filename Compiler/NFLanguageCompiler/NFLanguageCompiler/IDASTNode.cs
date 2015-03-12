using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFLanguageCompiler
{
    // Describes an ID AST node. Value can 
    // be any lower case char, a - z.
    //
    // Base: ExprASTNode
    // Interfaces: IASTNodeValue<>
    public class IDASTNode : ExprASTNode, IASTNodeValue<char>
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
        public IDASTNode()
            : base(ASTNodeType.ASTTYPE_ID)
        {
            
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
