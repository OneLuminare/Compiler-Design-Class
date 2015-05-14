using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFLanguageCompiler
{
    // Contrains data for heap table.
    public class HeapTableEntry
    {
        #region Data Members

        private int heapID;
        private int memoryLocation;
        private String stringValue;
        private int length;

        #endregion

        #region Properties

        public int HeapID
        {
            get { return heapID; }
            set { heapID = value; }
        }

        public int Length
        {
            get { return length; }
            set { length = value; }
        }

        public int MemoryLocation
        {
            get { return memoryLocation; }
            set { memoryLocation = value; }
        }

        public String StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }

        #endregion

        #region Constructors

        // Default constructor
        public HeapTableEntry()
            : this(0,"")
        {
        }

        // Master set constructor
        public HeapTableEntry(int heapID, String strValue)
        {
            this.heapID = heapID;
            // Set length to 1 greater than, 
            // as '00' is added to end of string
            this.length = strValue.Length + 1;
            this.stringValue = strValue.ToString();
            this.memoryLocation = 0;
        }

        #endregion
    }
}
