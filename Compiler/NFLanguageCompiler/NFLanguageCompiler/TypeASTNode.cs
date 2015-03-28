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
    public class TypeASTNode : ASTNode,IASTNodeValue<VAR_TYPE>
    {
        #region Data Members

        private VAR_TYPE value;

        #endregion

        #region Properties

        public VAR_TYPE Value
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
        public TypeASTNode()
        {
            nodeType = ASTNodeType.ASTTYPE_TYPE;
            value = VAR_TYPE.VARTYPE_INT;
        }

        // Set constructor.
        public TypeASTNode(VAR_TYPE value)
            : this()
        {
            this.value = value;
        }

        #endregion

        #region Object Overrides

        public override string ToString()
        {
            String ret = null;

            if (value == VAR_TYPE.VARTYPE_BOOLEAN)
                ret =  "Type: boolean";
            else if( value == VAR_TYPE.VARTYPE_INT)
                ret = "Type: int";
            else
                ret = "Type: string";

            return ret;
        }

        #endregion
    }
}
