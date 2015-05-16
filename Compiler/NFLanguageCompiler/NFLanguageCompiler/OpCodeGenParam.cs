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
        public byte[] opCodeDataBytes;
        public DynamicBranchTreeNode<SymbolHashTable> curSymbTable;
        public OpCodeGenTempTables tables;
        public int curByte;
        public int curSymbTableIndex;
        public int curBlockID;
        public int curHeapID;
        public bool firstBlock;
        public ArrayList insertBytes;
        public int initVars;

        #endregion

        #region Constructors

        // Default constructor. Must be created with necessary components.
        public OpCodeGenParam(StringBuilder opCodes, byte[] opCodeDataBytes, DynamicBranchTreeNode<SymbolHashTable> curSymbTable
            , OpCodeGenTempTables tables)
        {
            this.opCodes = opCodes;
            this.opCodeDataBytes = opCodeDataBytes;
            this.tables = tables;
            this.curSymbTable = curSymbTable;
            this.initVars = 0;
            curByte = 0;
            curSymbTableIndex = 0;
            curBlockID = 0;
            curHeapID = 50;
            firstBlock = true;
            insertBytes = new ArrayList(20);

        }

        #endregion

        #region Helper Methods

        public int AddBytes(params byte[] bytes) 
        {
            // Cycle through bytes
            for (int i = 0; i < bytes.Length; i++)
            {
                // Throw exception on over 255
                if ((curByte + i) > 255)
                    throw new IndexOutOfRangeException("Over 256 bytes in program bytes.");

                // Add byte to array
                opCodeDataBytes[curByte + i] = bytes[i];
            }

            // Increment cur bytes
            curByte += bytes.Length;


            // Return added bytes
            return bytes.Length;
        }
            
        public int AddByteForUpdate(char symbol, int id)
        {
            // Add symbol to insert table
            insertBytes.Add(new TempByteData(curByte, String.Format("{0}{1}",symbol,id)));

            // Throw exception on error
            if (curByte > 255)
                throw new IndexOutOfRangeException("Over 256 bytes in program bytes.");

            // Add byte
            opCodeDataBytes[curByte] = 0xEA;

            // Increment cur bytes
            curByte++;

            // Return 1
            return 1;
        }

        public int AddByteForUpdate(char symbol, int id, int shift)
        {
            // Add symbol to insert table
            if( shift > 0 )
                insertBytes.Add(new TempByteData(curByte, String.Format("{0}{1}S{2}", symbol, id, shift)));
            else
                insertBytes.Add(new TempByteData(curByte, String.Format("{0}{1}",symbol,id)));

            // Add byte
            opCodeDataBytes[curByte] = 0xEA;

            // Increment cur bytes
            curByte++;

            // Return 1
            return 1;
        }

        public void AddInsertByte( int index, char  symbol, int id, int shift )
        {
            // Add symbol to insert table
            if (shift > 0)
                insertBytes.Add(new TempByteData(index, String.Format("{0}{1}S{2}", symbol, id, shift)));
            else
                insertBytes.Add(new TempByteData(index, String.Format("{0}{1}", symbol, id)));
        }

        public byte GetByte(int index)
        {
            if (index < 0 || index >= opCodeDataBytes.Length)
                throw new IndexOutOfRangeException("Op code byte index out of range.");
            
            return opCodeDataBytes[index];
        }

        public void SetByte(int index, byte value)
        {
            if (index < 0 || index >= opCodeDataBytes.Length)
                throw new IndexOutOfRangeException("Op code byte index out of range.");

            opCodeDataBytes[index] = value;
        }


        #endregion

    }
}
