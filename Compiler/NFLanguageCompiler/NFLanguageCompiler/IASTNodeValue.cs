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
        #region Property

        // Value proptery
        T Value { get; set; }

        #endregion
    }
}
