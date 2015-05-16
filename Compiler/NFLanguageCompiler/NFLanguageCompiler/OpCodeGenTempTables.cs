using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace NFLanguageCompiler
{
    // Contains temporary tables for code gen creation.
    // Also has some look up helper methods. Keeps track
    // of max stack size for data allocation.
    public class OpCodeGenTempTables
    {
        #region Data Members

        private ArrayList blockSizeTable;
        private ArrayList varTable;
        private ArrayList heapTable;
        private ArrayList initValueTable;
        private int varsInUse;
        private int maxVarUsage;
        private int curTempVarID;

        #endregion

        #region Properties

        public int VarsInUse
        {
            get { return varsInUse; }
            set { varsInUse = value; }
        }

        public int MaxVarUsage
        {
            get { return maxVarUsage; }
            set { maxVarUsage = value; }
        }

        #endregion

        #region Constructors

        // Default constructor
        public OpCodeGenTempTables()
        {
            blockSizeTable = new ArrayList();
            varTable = new ArrayList();
            heapTable = new ArrayList();
            initValueTable = new ArrayList();
            curTempVarID = 50;
            varsInUse = 0;
            maxVarUsage = 0;
        }

        #endregion

        #region Block Size Table Methods

        // Gets block size table entry by block id
        // 
        // Returns: BlockSizeTableEntry associated with block ID or null
        public BlockSizeTableEntry GetBlockSizeTableEntry(int blockID)
        {
            // Inits
            bool found = false;
            BlockSizeTableEntry entry = null;
            BlockSizeTableEntry ret = null;

            // Cycle through block size table entries
            for (int i = 0; (i < blockSizeTable.Count) && !found; i++)
            {
                // Get current entry
                entry = (BlockSizeTableEntry)blockSizeTable[i];

                // Check if Ids match and set found
                if (entry.BlockID == blockID)
                    found = true;
            }

            // Check if found entry
            if (found)
            {
                // Set return value
                ret = entry;
            }

            // Return entry or null
            return ret;
        }

        // Adds entry to block size table
        public void AddBlockSizeTableEntry(BlockSizeTableEntry entry)
        {
            // Add to blcok size table
            blockSizeTable.Add(entry);
        }

        // Returns count of block size table
        //
        // Returns: Block size table count.
        public int BlockSizeTableCount()
        {
            return blockSizeTable.Count;
        }

        // Clears block size table
        public void ClearBlockSizeTable()
        {
            blockSizeTable.Clear();
        }

        #endregion

        #region Var Table Methods

        // Finds var table entry by VarID
        //
        // Returns: VarTableEntry or null on no find
        public VarTableEntry GetVarTableEntry(int varID)
        {
            // Inits
            bool found = false;
            VarTableEntry entry = null;
            VarTableEntry ret = null;

            // Cycle through block size table entries
            for (int i = 0; (i < varTable.Count) && !found; i++)
            {
                // Get current entry
                entry = (VarTableEntry)varTable[i];

                // Check if Ids match and set found
                if (entry.VarID == varID)
                    found = true;
            }

            // Check if found entry
            if (found)
            {
                // Set return value
                ret = entry;
            }

            // Return entry or null
            return ret;
        }

        // Get var table entry by index
        //
        // Throws: IndexOutOfRangeException
        // Returns: Entry at given index.
        public VarTableEntry GetVarTableEntryByIndex(int index)
        {
            //Inits
            VarTableEntry ret = null;

            if (index >= varTable.Count || index < 0)
            {
                throw new IndexOutOfRangeException("OpCodeVarTable entry idex out of range.");
            }
            else
                ret = (VarTableEntry)varTable[index];

            // Return var table entry
            return ret;
        }

        // Creates a var table entry based on symbol table entry,
        // and calculates current in use off set (position).
        //
        // Returns: New entry created.
        public VarTableEntry CreateVarTableEntry(SymbolTableEntry entry)
        {
            // Inits
            VarTableEntry varEntry = new VarTableEntry(entry.EntryID, entry);

            // Set off set
            varEntry.Offset = FindNextAvaialbleOffset();

            // Add to table
            varTable.Add(varEntry);

            // Return entry
            return varEntry;
        }

        // Creates a new temp var ref, with a new calculated offset.
        //
        // Returns: Temp var entry.
        public VarTableEntry CreateTempVarTableEntry()
        {
            // Inits
            VarTableEntry entry = null;

            // Create new entry
            entry = new VarTableEntry(curTempVarID, null);

            // Increment cur temp var id
            curTempVarID++;

            // Set off set
            entry.Offset = FindNextAvaialbleOffset();

            // Add to table
            varTable.Add(entry);

            // Return found var or newly created one
            return entry;
        }

        // Returns var table count
        //
        // Returns: Count of var table entries
        public int VarTableCount()
        {
            return varTable.Count;
        }

        // Clears var table
        public void ClearVarTable()
        {
            varTable.Clear();
        }

        // Finds next avaialble offset to maximize stack size
        //
        // Returns: Next avaialbe (un used) mem location offset from start
        public int FindNextAvaialbleOffset()
        {
            // Inits
            bool foundOffset = false;
            bool found = false;
            VarTableEntry varEntry = null;
            int offset = 0;
            int tableCount = varTable.Count;

            // Cycle through all possible offsets
            for (int i = 0; ((i < tableCount) && !found); i++)
            {
                // Reset found off set flag
                foundOffset = false;

                // Cycle through all entries
                for (int n = 0; ((n < tableCount) && !foundOffset); n++)
                {
                    // Get var entry
                    varEntry = (VarTableEntry)varTable[n];

                    // Check if in use and right offet
                    if (varEntry.InUse && varEntry.Offset == i)
                    {
                        // Set found off set flag
                        foundOffset = true;
                    }
                }

                // Check if did not find off set
                if (!foundOffset)
                {
                    // Record offset
                    offset = i;

                    // Set found next offset flag
                    found = true;
                }
            }

            // Check if not found, than add 1 to count
            if (!found)
                offset = tableCount;

            // Return next off set
            return offset;
        }

        #endregion

        #region Heap Table Methods

        // Find heap entry by index.
        //
        // Throws: IndexOutOfRangeException
        // Returns: Entry for given index.
        public HeapTableEntry GetHeapTableEntryByIndex(int index)
        {
            // Inits
            HeapTableEntry ret = null;

            // Check for errors
            if ((index >= heapTable.Count) || index < 0)
                throw new IndexOutOfRangeException("OpCodeGen heap table out of range.");
            else
                ret = (HeapTableEntry)heapTable[index];

            // Return entry
            return ret;
        }

        // Finds heap table entry by id.
        //
        // Returns: Heap table entry with id or null if not found
        public HeapTableEntry GetHeapTableEntry(int heapID)
        {
            // Inits
            HeapTableEntry entry = null;
            HeapTableEntry ret = null;
            bool found = false;

            // Cycle through entries
            for (int i = 0; ((i < heapTable.Count) && !found); i++)
            {
                // Get entry
                entry = (HeapTableEntry)heapTable[i];

                // Check if str are equal
                if (entry.HeapID == heapID)
                {
                    // Set ret
                    ret = entry;

                    // Set found flag
                    found = true;
                }
            }

            // Return entry or null if not found
            return ret;
        }

        // Finds heap table entry based on string value.
        // 
        // Returns: Heap entry with str value, or null if not in heap.
        public HeapTableEntry GetHeapTableEntry(String str)
        {
            // Inits
            HeapTableEntry entry = null;
            HeapTableEntry ret = null;
            bool found = false;

            // Cycle through entries
            for (int i = 0; ((i < heapTable.Count) && !found); i++)
            {
                // Get entry
                entry = (HeapTableEntry)heapTable[i];

                // Check if str are equal
                if (entry.StringValue == str)
                {
                    // Set ret
                    ret = entry;

                    // Set found flag
                    found = true;
                }
            }

            // Return entry or null if not found
            return ret;
        }

        // Adds heap table entry if one doesn't exist with same string.
        // If one does exits, returns heap table entry.
        //
        // Returns: New or existing heap table entry.
        public HeapTableEntry AddHeapTableEntry(OpCodeGenParam param,String str)
        {
            // Inits
            HeapTableEntry heapEntry = null;
            
            // Check if entry exists for that string in heap
            heapEntry = GetHeapTableEntry(str);

            // Check if entry doesn't exist
            if (heapEntry == null)
            {
                // Create new heap table entry
                heapEntry = new HeapTableEntry(param.curHeapID, str);

                // Incrment cur heap id
                param.curHeapID++;

                // Add heap entry to table
                heapTable.Add(heapEntry);
            }

            // Return heap table entry
            return heapEntry;
        }


        // Returns count of heap table.
        //
        // Returns: Count of heap entries.
        public int HeapTableCount()
        {
            return heapTable.Count;
        }

        // Clears heap table
        public void ClearHeapTable()
        {
            heapTable.Clear();
        }

        // Gets total heap size.
        //
        // Returns: Total heap size.
        public int TotalHeapSize()
        {
            // Inits
            int heapSize = 0;
            HeapTableEntry entry = null;

            // Cycle through heap table
            for (int i = 0; i < heapTable.Count; i++)
            {
                // Get heap entry
                entry = (HeapTableEntry)heapTable[i];

                // Calc total
                heapSize += entry.Length;
            }

            // Return heap size
            return heapSize;
        }
   
        #endregion

        #region Init Value Table Methods

        public void AddInitValueEntry(char id, int index, int blockID, DataType dataType)
        {
            initValueTable.Add(new InitValueEntry(id, index, blockID, dataType));
        }

        public bool RemoveLastInitValueEntry(char id, DataType dataType)
        {
            // Inits
            bool found = false;
            InitValueEntry entry = null;

            // Cycle backwards through table
            for (int i = initValueTable.Count - 1; (i >= 0) && !found; i--)
            {
                // Get entry
                entry = (InitValueEntry)initValueTable[i];

                // Check if equal id
                if (entry.ID == id && entry.DataType == dataType)
                {

                    // Remove entry
                    initValueTable.RemoveAt(i);

                    // Set found flag
                    found = true;
                }
            }

            // Return true if removed
            return found;
        }

        public bool RemoveLastInitValueEntry(InitValueEntry entry)
        {
            // Inits
            bool found = false;
            InitValueEntry entry2 = null;

            // Cycle backwards through table
            for (int i = initValueTable.Count - 1; (i >= 0) && !found; i--)
            {
                // Get entry
                entry2 = (InitValueEntry)initValueTable[i];

                // Check if equal id
                if (entry2.ID == entry.ID && entry2.DataType == entry.DataType)
                {

                    // Remove entry
                    initValueTable.RemoveAt(i);

                    // Set found flag
                    found = true;
                }
            }

            // Return true if removed
            return found;
        }

        public void RemoveBlockVarEntries(int blockID)
        {
            // Inits
            InitValueEntry entry = null;

            // Cycle backwards through table
            for (int i = initValueTable.Count - 1; i >= 0; i--)
            {
                // Get entry
                entry = (InitValueEntry)initValueTable[i];

                // Check if equal id
                if (entry.BlockID == blockID)
                {

                    // Remove entry
                    initValueTable.RemoveAt(i);
                }
            }
        }

        public InitValueEntry GetLastInitValueEntry(char id, DataType dataType)
        {
            // Inits
            bool found = false;
            InitValueEntry entry = null;

            // Cycle backwards through table
            for (int i = initValueTable.Count - 1; (i >= 0) && !found; i--)
            {
                // Get entry
                entry = (InitValueEntry)initValueTable[i];

                // Check if equal id
                if (entry.ID == id && entry.DataType == dataType)
                {
                    // Set found flag
                    found = true;
                }
            }

            // Check if not found, if not set to null
            if (!found)
                entry = null;

            // Retur entry or null if not found
            return entry;
        }

        public void ClearInitValueTable()
        {
            initValueTable.Clear();
        }

        #endregion

        #region Helper Methods

        // Increments stack var in use. Keeps track of max.
        public void IncVarIsUseCount()
        {
            varsInUse++;

            if (varsInUse > maxVarUsage)
                maxVarUsage = varsInUse;
        }

        // Decrements stack var in use count.
        public void DecVarInUseCount()
        {
            varsInUse--;
        }

        #endregion

    }
}
