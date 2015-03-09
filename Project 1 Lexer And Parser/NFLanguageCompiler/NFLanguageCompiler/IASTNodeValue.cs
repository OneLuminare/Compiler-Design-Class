using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFLanguageCompiler
{
    // Interface that describes an ASTNode's value.
    // All node have a value, so this interface describes
    // this in a generic mannor.
    public interface IASTNodeValue<T>
    {
        #region Data Members

        // Value data member, exposed by follwing property
        public T value;

        #endregion

        #region Property

        // Value proptery
        public T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        #endregion
    }
}
