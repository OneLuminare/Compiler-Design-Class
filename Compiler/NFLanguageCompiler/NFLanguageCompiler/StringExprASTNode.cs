using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFLanguageCompiler
{
    // Describes a string expression ASTNode.
    //
    // Base: ASTNode<>
    public class StringExprASTNode : ExprASTNode, IASTNodeValue<String>
    {
        #region Data Members

        private String value;

        #endregion

        #region Properties

        public String Value
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

        #endregion

        #region Constructors

        // Default constructor. Inits values
        public StringExprASTNode()
            : base(ASTNodeType.ASTTYPE_STRINGEXPR)
        {
            value = "";
        }

        // Set constructor.
        public StringExprASTNode(String value)
            : this()
        {
            this.value = value;
        }

        #endregion

        #region Helper Functions

        // Creates a string from a sibling chain of CharASTNodes
        public void CreateValue(CharASTNode nodeFamily)
        {
            // Inits gets left most sibling
            CharASTNode curNode = (CharASTNode)nodeFamily.LeftMostSibling;
            StringBuilder sb = new StringBuilder(20);

            // Cycle through sybling and get their value
            while(curNode != null )
            {
                sb.Append(curNode.Value);
            }

            value = sb.ToString();
        }

        #endregion

        #region Object Overrides

        public override string ToString()
        {
            String ret = null;

            ret = String.Format("String: {0}", value);

            return ret;
        }

        #endregion

        #region ASTNode Overides

        // Gens op codes to create string on heap,
        // and load address in accumulator.
        //
        // Returns: Number of bytes generated.
        public override int GenOpCodes(OpCodeGenParam param)
        {
            // Inits
            HeapTableEntry heapEntry = null; 
            
            // Check if heap entry exists
            heapEntry = param.tables.AddHeapTableEntry(param, Value);

            try
            {
                // Load accumulator with heap address
                //param.opCodes.AppendFormat("A9 H{0} ", heapEntry.HeapID);
                param.AddBytes(0xA9);
                param.AddByteForUpdate('H', heapEntry.HeapID);
            }

            catch (IndexOutOfRangeException ex)
            {
                throw ex;
            }

            // Increment bytes
            //param.curByte += 2;

            // Return cur num bytes
            return 2;
        }

        #endregion
    }
}
