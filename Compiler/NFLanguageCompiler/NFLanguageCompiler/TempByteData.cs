using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFLanguageCompiler
{
    // A table entry for inserting addresses of stack and heap
    // locations in op code byte array.
    public class TempByteData
    {
        #region Data Members

        private int index;
        private String varSymbol;

        #endregion

        #region Properties

        // Index in byte array to update
        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        // Parse value identifiying what location
        // to update in byte array.
        public String VarSymbol
        {
            get { return varSymbol; }
            set { varSymbol = value; }

        }

        #endregion

        #region Constructors

        // Default constructor, sets values
        public TempByteData(int index, String varSymbol)
        {
            this.index = index;
            this.varSymbol = varSymbol;
        }

        #endregion
    }
}
