using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFLanguageCompiler
{
    // Varaible declaration statement ASTNode. Only has one form: TYPE ID .
    //
    // Base: StatementASTNode
    public class VarDecStatementASTNode : StatementASTNode
    {
        #region Data Members

        protected TypeASTNode type;
        protected IDASTNode id;
        protected Token startToken;

        #endregion

        #region Properties

        public TypeASTNode Type
        {
            get{ return type; }
            set{ type = value; }
        }

        public IDASTNode Id
        {
            get { return id; }
            set { this.id = value; }
        }

        public Token StartToken
        {
            get{ return startToken; }
            set{ startToken = value; }
        }

        #endregion

        #region Constructors

        // Default costructor, inits values
        public VarDecStatementASTNode()
            : base(ASTNodeType.ASTTYPE_VARDEC)
        {
            id = null;
            type = null;
        }

        // Set constructor.
        public VarDecStatementASTNode(TypeASTNode type, IDASTNode id)
            : this()
        {
            this.type = type;
            this.id = id;
        }

        #endregion

        #region Object Overrides

        public override string ToString()
        {
            String ret = null;

            ret = "Variable Declaration";

            return ret;
        }

        #endregion

        #region ASTNode Overides

        // Gens code that allocates 00 to a location in memory,
        // tracked in var table.
        //
        // Returns: Number of bytes generated.
        public override int GenOpCodes(OpCodeGenParam param)
        {
            // Inits
            VarTableEntry varEntry = null;
            

            // Create var table entry for this 
            varEntry = param.tables.CreateVarTableEntry(id.SymbolTableEntry);

            // Increment current vars in use
            param.tables.IncVarIsUseCount();

            // Check if entry found incase of some wierd error
            if (varEntry != null)
            {
                try
                {
                    // Load accumlator with 0
                    //param.opCodes.Append("A9 00 ");
                    param.AddBytes(0xA9, 0x00);

                    // Copy to temp location in memory
                    //param.opCodes.AppendFormat("8D V{0} 00 ",varEntry.VarID);
                    param.AddBytes(0x8D);
                    param.AddByteForUpdate('V', varEntry.VarID);
                    param.AddBytes(0x00);
                }

                catch (IndexOutOfRangeException ex)
                {
                    throw ex;
                }

                // Add number of bytes
               // param.curByte += 5;
            }

            // Return cur bytes
            return 5;
        }

        #endregion

    }
}
