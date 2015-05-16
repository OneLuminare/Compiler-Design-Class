using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFLanguageCompiler
{
    // Contains initial value entry data
    public class InitValueEntry
    {
        #region Data Members

        private char id;
        private int index;
        private int blockID;
        private DataType dataType;

        #endregion

        #region Properties

        public char ID
        {
            get { return id; }
            set { id = value; }
        }

        public DataType DataType
        {
            get { return dataType; }
            set { dataType = value; }
        }

        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        public int BlockID
        {
            get { return blockID; }
            set { blockID = value; }
        }

        #endregion

        #region Constructors

        // Default constructor
        public InitValueEntry()
            : this(' ', -1, -1,DataType.DT_NONE)
        {
        }

        // Master set constructor
        public InitValueEntry(char id, int index, int blockID, DataType dataType)
        {
            this.id = id;
            this.index = index;
            this.blockID = blockID;
            this.dataType = dataType;
        }

        #endregion
    }
}
