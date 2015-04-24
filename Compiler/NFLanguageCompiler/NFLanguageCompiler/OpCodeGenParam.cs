using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using DynamicBranchTree;

namespace NFLanguageCompiler
{
    // Params for ASTNodes GenOpCode method.
    public class OpCodeGenParam
    {
        #region Data Memembers

        public StringBuilder opCodes;
        public DynamicBranchTreeNode<SymbolHashTable> curSymbTable;
        public OpCodeGenTempTables tables;
        public int curByte;
        public int curSymbTableIndex;
        public int curBlockID;
        public int curHeapID;

        #endregion

        #region Constructors

        // Default constructor. Must be created with necessary components.
        public OpCodeGenParam(StringBuilder opCodes, DynamicBranchTreeNode<SymbolHashTable> curSymbTable
            , OpCodeGenTempTables tables)
        {
            this.opCodes = opCodes;
            this.tables = tables;
            this.curSymbTable = curSymbTable;
            curByte = 0;
            curSymbTableIndex = 0;
            curBlockID = 0;
            curHeapID = 50;
        }

        #endregion

        #region Helper Methods

        // Generates op codes for loading string into 
        // a heap location. Returns heap entry. If 
        // same string already in heap, returns pointer
        // to that one.
        //
        // Returns: Heap entry for string.
        public HeapTableEntry GenOpCodes_LoadString(String str)
        {
            // Inits
            HeapTableEntry heapEntry = null;

            // Check if str is already in heap
            heapEntry = tables.GetHeapTableEntry(str);

            // Verify entry not already in heap
            if (heapEntry == null)
            {

                // Create new heap entry
                heapEntry = new HeapTableEntry(curHeapID, str);
                curHeapID++;
                tables.AddHeapTableEntry(heapEntry);

                // Load values into heap entry
                for (int i = 0; i < str.Length; i++)
                {
                    // Move value into accum
                    opCodes.AppendFormat("A9 {0} ", (int)str[i]);

                    // Move accum to heap location
                    opCodes.AppendFormat("8D H{0}S{1} 00 ", heapEntry.HeapID, i);
                }

                // Add finishing 0
                opCodes.Append("A9 00 ");
                opCodes.AppendFormat("8D H{0}S{1} 00 ", heapEntry.HeapID, str.Length);

                // Increment bytes
                curByte += (str.Length + 1) * 5;
            }

            // Return heap entry for string
            return heapEntry;
        }

        #endregion

    }
}
