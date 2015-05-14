using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFLanguageCompiler
{
    // Entry for vars table used in op code gen. Allows me to 
    // track a symbol table entry by ID.
    public class VarTableEntry
    {
        #region Data Members

        private int varID;
        private SymbolTableEntry varEntry;
        private int offset;
        private bool inUse;

        #endregion

        #region Properties

        public int VarID
        {
            get { return varID; }
            set { varID = value; }
        }

        public SymbolTableEntry VarEntry
        {
            get { return varEntry; }
            set { varEntry = value; }
        }

        public int Offset
        {
            get { return offset; }
            set { offset = value; }
        }

        public bool InUse
        {
            get { return inUse; }
            set { inUse = value; }
        }

        #endregion

        #region Constructors

        // Default constructor
        public VarTableEntry()
        {
            varID = 0;
            varEntry = null;
            offset = -1;
            inUse = true;
 
        }

        // Set constructor
        public VarTableEntry(int varID, SymbolTableEntry varEntry)
        {
            this.varID = varID;
            this.varEntry = varEntry;
            this.offset = -1;
            this.inUse = true;
        }

        #endregion
    }
}
