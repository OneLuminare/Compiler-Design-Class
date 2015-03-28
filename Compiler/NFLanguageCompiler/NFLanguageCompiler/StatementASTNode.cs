using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFLanguageCompiler
{

    // Abstract class to base statement ASTNodes. Has six forms:
    //
    // ST_PRINT:      Print statement
    // ST_ASSIGN:      Assingment statement
    // ST_VARDEC:    Var declaration statement
    // ST_WHILE:     While statement
    // ST_IF:     If statement
    // ST_BLOCK:      Block
    public abstract class StatementASTNode : ASTNode 
    {

        #region Constructors

        // Default constructor
        public StatementASTNode()
            : base(ASTNodeType.ASTTYPE_STATEMENT)
        {

        }

        // Set constructor
        public StatementASTNode(ASTNodeType nodeType)
            : base(nodeType)
        {
        }

        #endregion

        #region Object Overrides

        public override string ToString()
        {
            String ret = null;

            ret = "Base Statement AST node.";

            return ret;
        }

        #endregion
    }
}
