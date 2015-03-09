using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFLanguageCompiler
{
    // Basic node type representing the int values.
    // In this grammar can only be digits 0 - 9.
    // For ASTNode types used in more complex structures.
    // 
    // Base: ASTNode<>
    public class IntValASTNode : ASTNode<int>
    {
        #region Constructors

        // Default constructor. Inits values
        public IntValASTNode()
        {
            type = ASTNodeType.ASTTYPE_INTVAL;
            value = 0;
        }

        // Set constructor.
        public IntValASTNode(int value)
            : this()
        {
            this.value = value;
        }

        #endregion
    }
}
