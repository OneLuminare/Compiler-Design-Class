using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFLanguageCompiler
{
    // Describes an ID AST node. Value can 
    // be any lower case char, a - z.
    //
    // Base: ExprASTNode
    // Interfaces: IASTNodeValue<>
    public class IDASTNode : ExprASTNode, IASTNodeValue<char>
    {
        #region Data Members

        private char value;
        private SymbolTableEntry symbEntry;

        #endregion

        #region Properties

        public char Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }

        public SymbolTableEntry SymbolTableEntry
        {
            get { return symbEntry; }
            set { symbEntry = value; }
        }

        #endregion

        #region Constructors

        // Default constructor. Inits values
        public IDASTNode()
            : base(ASTNodeType.ASTTYPE_ID)
        {
            
            value = ' ';
            symbEntry = null;
        }

        // Set constructor.
        public IDASTNode(char value)
            : this()
        {
            this.value = value;
        }

        #endregion

        #region Object Overrides

        public override string ToString()
        {
            String ret = null;

            ret = String.Format("ID: {0}",value.ToString());

            return ret;
        }

        #endregion

        #region ASTNode Overides

        // Gens op codes to find address from var table,
        // and store value in accumulator.
        //
        // Returns: Number of bytes generated.
        public override int GenOpCodes(OpCodeGenParam param)
        {
            // Inits
            VarTableEntry varEntry = null;

            // Find var in var table
            varEntry = param.tables.GetVarTableEntry(SymbolTableEntry.EntryID);

            // Verify var entry exists
            if (varEntry != null)
            {
                try
                {

                    // Load value into accumlator
                    param.opCodes.AppendFormat("AD V{0} 00 ", varEntry.VarID);
                    param.AddBytes(0xAD);
                    param.AddByteForUpdate('V', varEntry.VarID);
                    param.AddBytes(0x00);

                }

                // Catch over 256 byte error,
                // and throw up
                catch (IndexOutOfRangeException ex)
                {
                    throw ex;
                }
            }

            // Return number of bytes
            return 3;
        }

        #endregion


    }
}
