﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFLanguageCompiler
{
    #region Types

    // Describes bool op value type.
    // Can be equal or not equal.
    public enum BOOLOP_TYPE
    {
        BOOLOP_EQUALS,
        BOOLOP_NOT_EQUALS
    }

    #endregion

    // Basic ASTNode type for use in more complicated node structures.
    // Describes a boolean operator of equals or not equals.
    //
    // Base: ASTNode<>
    public class BoolOpASTNode : BooleanExprASTNode, IASTNodeValue<BOOLOP_TYPE>
    {
        #region Data Members

        private BOOLOP_TYPE value;
        protected ExprASTNode exprOne;
        protected ExprASTNode exprTwo;
        protected Token startToken;

        #endregion

        #region Properties

        public Token StartToken
        {
            get { return startToken; }
            set { startToken = value; }
        }

        public BOOLOP_TYPE Value
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

        public ExprASTNode ExprTwo
        {
            get { return exprTwo; }
            set { exprTwo = value; }
        }

        public ExprASTNode ExprOne
        {
            get { return exprOne; }
            set { exprOne = value; }
        }

        #endregion

        #region Constructors

        // Default constructor. Inits values
        public BoolOpASTNode()
            : base(ASTNodeType.ASTTYPE_BOOLOP)
        {
            value = BOOLOP_TYPE.BOOLOP_EQUALS;
            exprOne = null;
            exprTwo = null;
        }

        // Set constructor.
        public BoolOpASTNode(BOOLOP_TYPE value)
            : this()
        {
            this.value = value;
        }

        #endregion
    
        #region Object Overrides

        public override string ToString()
        {
            String ret = null;

            if (value == BOOLOP_TYPE.BOOLOP_EQUALS)
                ret =  "Boolean Op: ==";
            else
                ret = "Boolean Op: !=";

            return ret;
        }

        #endregion

        #region ASTNode Overides

        // Gens op codes for comparision of boolean expr == or !=,
        // and puts results in accum. 1 for true, 0 for false.
        //
        // Returns: Number of bytes generated.
        public override int GenOpCodes(OpCodeGenParam param)
        {

            // Inits
            VarTableEntry varEntryTemp = null;
            int bytes = 0;
            int index = 0;

            // ### Checking Expr 1 ### //

            // try for error
            try
            {

                // Gen op codes for expr one
                bytes += exprOne.GenOpCodes(param);

                // ### Check if not only bool val, as if it was  ### //
                // ### the value is just left in the accumulator ### //

                // Check if expr 2 is not null
                if (exprTwo != null)
                {
                    // ### Add acc results from expr 1 ### //

                    // Add temp var for expr one results
                    varEntryTemp = param.tables.CreateTempVarTableEntry();


                    // Set in use
                    varEntryTemp.InUse = true;
  

                    // Increment var in use
                    param.tables.IncVarIsUseCount();

                    // Move value of accumulator to temp var
                    param.AddBytes(0x8D);
                    param.AddByteForUpdate('V', varEntryTemp.VarID);
                    param.AddBytes(0x00);

                    // ### Generate expr 2 value and put in accumm ### //

                    // Gen op codes for expr two
                    bytes += exprTwo.GenOpCodes(param);


                    // ### Compare values of temp var (expr 1), and accum (expr2) ### //
                    // ### Put results in accumulator.                            ### //

                    // Load temp value from first expr into reg x
                    param.AddBytes(0xAE);
                    param.AddByteForUpdate('V', varEntryTemp.VarID);
                    param.AddBytes(0x00);

                    // Move accum into same temp val
                    param.AddBytes(0x8D);
                    param.AddByteForUpdate('V', varEntryTemp.VarID);
                    param.AddBytes(0x00);

                    // Increment bytes
                    bytes += 9;

                    // Check if equals
                    if (value == BOOLOP_TYPE.BOOLOP_EQUALS)
                    {
                        // Set false in accum "A9 00 "
                        param.AddBytes(0xA9, 0x00);

                    }
                    else
                    {
                        // Set true in accum 
                        param.AddBytes(0xA9, 0x01);
                    }

                    // Compare x to temp var
                    param.AddBytes(0xEC);
                    param.AddByteForUpdate('V', varEntryTemp.VarID);
                    param.AddBytes(0x00);

                    // Branch 2 bytes if equl
                    param.AddBytes(0xD0, 0x02);

                    // Check if equals
                    if (value == BOOLOP_TYPE.BOOLOP_EQUALS)
                    {
                        // Set true in accum (skip in nnot equal)

                        param.AddBytes(0xA9, 0x01);
                    }
                    else
                    {
                        // Set false in accum (skip in nnot equal)
                        param.AddBytes(0xA9, 0x00);
                    }

                    // Increment bytes
                    bytes += 9;

                    // Reset in use flag for temp var
                    varEntryTemp.InUse = false;

                    // Decremeent in use flag
                    param.tables.DecVarInUseCount();
                }

            }

            // Throw error up
            catch (IndexOutOfRangeException ex)
            {
                throw ex;
            }

            // Return number of bytes 
            return bytes;
        }

        #endregion
    }
}
