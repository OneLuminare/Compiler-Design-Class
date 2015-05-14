using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFLanguageCompiler
{
    // Contains data for block size table. This allows me to
    // look up a blocks start byte and end byte by id
    public class BlockSizeTableEntry
    {
        #region Data Members

        private int blockID;
        private int startByte;
        private int endByte;

        #endregion

        #region Properties

        public int BlockID
        {
            get { return blockID; }
            set { blockID = value; }
        }

        public int StartByte
        {
            get { return startByte; }
            set { startByte = value; }
        }

        public int EndByte
        {
            get { return endByte; }
            set { endByte = value; }
        }

        public int BlockSize
        {
            get{ return endByte - startByte + 1; }
        }

        #endregion

        #region Constructors

        // Default constructor
        public BlockSizeTableEntry()
        {
            blockID = 0;
            startByte = 0;
            endByte = 0;
        }

        // Set constructor
        public BlockSizeTableEntry(int blockID, int startByte)
        {
            this.blockID = blockID;
            this.startByte = startByte;
            endByte = 0;
        }

        #endregion
    }
}
