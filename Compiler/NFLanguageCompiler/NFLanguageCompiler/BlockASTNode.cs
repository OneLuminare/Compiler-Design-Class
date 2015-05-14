using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DynamicBranchTree;

namespace NFLanguageCompiler
{
    // Block AST node. Just has a pointer to the left most StatmentASTNode sibling. Has one form: { STATEMENTLIST }
    // Signify first block(root AST node) with the IsProgramBlock property.
    //
    // Base: StatementASTNode
    public class BlockASTNode : StatementASTNode
    {
        #region Data Members

        protected StatementASTNode statementList;
        protected bool isProgramBlock;

        #endregion

        #region Properties

        public StatementASTNode StatementList
        {
            get{ return statementList; }
            set { statementList = value; }
        }

        public bool IsProgramBlock
        {
            get { return isProgramBlock;  }
            set { isProgramBlock = value;  }
        }

        #endregion

        #region Constructors

        // Default costructor, inits values
        public BlockASTNode()
            : base(ASTNodeType.ASTTYPE_BLOCK)
        {
            statementList = null;
            isProgramBlock = false;
        }

        // Set constructor.
        public BlockASTNode(StatementASTNode statementList )
            : this()
        {
            this.statementList = statementList;
        }

        #endregion

        #region Object Overrides

        public override string ToString()
        {
            return "Block";
        }

        #endregion

        // Gens op codes for all statments in block.
        // Manges which symbol table is current.
        // Keeps table of start and end of blocks.
        // All vars allocated on stack in this block
        // are set to not in use.
        //
        // Returns: Number of bytes generated.
        public override int GenOpCodes(OpCodeGenParam param)
        {
            // Inits
            int nextSymbIndex = 0;
            int bytesAdded = 0;
            ASTNode curNode = null;
            BlockSizeTableEntry entry = null;
            VarTableEntry varEntry = null;
            SymbolHashTable curSymbTable = null;
            SymbolTableEntry[] symbEntries = null;
            DynamicBranchTreeNode<SymbolHashTable> startSymbolTable = null;
            
            // Get start symbol table
            startSymbolTable = param.curSymbTable;

            // Check if not root symbol table
            if (!param.firstBlock)
            {
                // Move into next symbol table child
                param.curSymbTable = param.curSymbTable.GetChild(param.curSymbTableIndex);


                // Record last symb index
                nextSymbIndex = param.curSymbTableIndex + 1;

                // Set current symbol table index to 0
                param.curSymbTableIndex = 0;
            }
            // Else root table
            else
            {
                // Set first block flag false
                param.firstBlock = false;
            }

            // Record current symbol table
            curSymbTable = param.curSymbTable.Data;

            // Add new entry to block size table
            entry = new BlockSizeTableEntry(param.curBlockID, param.curByte);
            param.tables.AddBlockSizeTableEntry(entry);
            param.curBlockID++;

            // Cycle through stmts calling their gen op code
            curNode = this.leftMostChild;
            while (curNode != null)
            {
                try
                {
                    // Call child statment gen op code method
                    bytesAdded += curNode.GenOpCodes(param);
                }

                catch (IndexOutOfRangeException ex)
                {
                    throw ex;
                }

                // Get next symbling
                curNode = curNode.RightSibling;
            }

            // Reset cur symbol table index
            param.curSymbTableIndex = nextSymbIndex;

            // Reset cur symbol table
            param.curSymbTable = startSymbolTable;

            // Set end byte of block
            entry.EndByte = param.curByte - 1;

            // Cycle through symbol table
            symbEntries = curSymbTable.GetAllItems();
            for (int i = 0; i < symbEntries.Length; i++)
            {
                // Get item from temp var table
                varEntry = param.tables.GetVarTableEntry(symbEntries[i].EntryID);

                // Check if exists
                if (varEntry != null )
                {
                    // Set not in use flag
                    varEntry.InUse = false;

                    // Decrement var in use count
                    param.tables.DecVarInUseCount();
                }
            }

            // Update bytes added
            //param.curByte += bytesAdded;

            // Return number of bytes 
 	        return bytesAdded;
        }
    }
}
