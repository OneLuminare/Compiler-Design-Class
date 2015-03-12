using DynamicBranchTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFLanguageCompiler
{
    public class SymanticAnalyzer
    {
        #region Data Members

        DynamicBranchTreeNode<CSTValue> curCSTNode;
        DynamicBranchTreeNode<CSTValue> parentCSTNode;
        BlockASTNode rootASTNode;

        #endregion

        #region Properties

        public BlockASTNode RootASTNode
        {
            get { return rootASTNode;  }
            set { rootASTNode = value; }
        }

        #endregion

        #region Constructors

        // Default constructor, inits values
        public SymanticAnalyzer()
        {
           curCSTNode = null;
           parentCSTNode = null;
            rootASTNode = null;

        }

        #endregion

        #region AST Creation Methods

        public void CreateAST(DynamicBranchTreeNode<CSTValue> rootCSTNode)
        {
            //Set current and parent CST node values
            curCSTNode = rootCSTNode;
            parentCSTNode = null;

            //Parse first program block, and set as root AST
            rootASTNode = CreateBlockASTNode(true);
        }

        public BlockASTNode CreateBlockASTNode( bool firstBlock)
        {
            // Inits
            StatementASTNode retASTNode = null;
            StatementASTNode firstRetASTNode = null;
            BlockASTNode curASTNode = null;

            // Set parent node to current
            parentCSTNode = curCSTNode;

            // Create new AST node for block
            curASTNode = new BlockASTNode();

            // Set program flag
            curASTNode.IsProgramBlock = firstBlock;

            // Get first statement list
            curCSTNode = parentCSTNode.GetChild(1);

            // Loop through statement lists until lamda
            while (curCSTNode.Data.Grammar != GrammarProcess.GP_LAMDA)
            {
                // Set current node to statement
                curCSTNode = curCSTNode.GetChild(0);

                //Create statement grammar
                retASTNode = CreateStatementASTNode();
                
                // Make sybling if not first statment
                if (firstRetASTNode != null)
                    firstRetASTNode.MakeSybling(retASTNode);
                // Else set first returned statement
                else
                    firstRetASTNode = retASTNode;

                // Get next statment list
                curCSTNode = parentCSTNode.GetChild(1);
            }

            // Adopt statement family
            if (firstRetASTNode != null)
                curASTNode.AdoptChild(firstRetASTNode);

            // Reset current CST node
            curCSTNode = parentCSTNode;

            // Return created block
            return curASTNode;
        }

        private StatementASTNode CreateStatementASTNode()
        {
            // Inits
            StatementASTNode retASTNode = null;

            // Set parent node to current
            parentCSTNode = curCSTNode;

            // Set current node to statement
            curCSTNode = parentCSTNode.GetChild(0);

            // Check if print Statment
            if (curCSTNode.Data.Grammar == GrammarProcess.GP_PRINTSTATEMENT)
            {
                // Create print statment
                retASTNode = CreatePrintStatementASTNode();
            }
            // Else check if assignment
            else if (curCSTNode.Data.Grammar == GrammarProcess.GP_ASSIGNMENTSTATEMENT)
            {
                // Create assignment statmeent
                retASTNode = CreateAssignmentStatementASTNode();
            }
            // Else check var dec
            else if (curCSTNode.Data.Grammar == GrammarProcess.GP_VARDEC)
            {
                // Create var dec statement
                retASTNode = CreateVarDecStatementASTNode();
            }
            // Check if while
            else if (curCSTNode.Data.Grammar == GrammarProcess.GP_WHILESTATEMENT)
            {
                // Create while statement
                retASTNode = CreateWhileStatementASTNode();
            }
            // Check if IF statement
            else if (curCSTNode.Data.Grammar == GrammarProcess.GP_IFSTATEMENT)
            {
                // Create if statement
                retASTNode = CreateIfStatementASTNode();
            }
            // Check if block
            else if (curCSTNode.Data.Grammar == GrammarProcess.GP_BLOCK)
            {
                // Create block
                retASTNode = CreateBlockASTNode(false);
            }

            // Reset current CST node
            curCSTNode = parentCSTNode;

            // Return created statement
            return retASTNode;
        }

        private PrintStatementASTNode CreatePrintStatementASTNode()
        {
            // Inits
            ExprASTNode retASTNode = null;
            PrintStatementASTNode curASTNode = null;

            // Set parent node to current
            parentCSTNode = curCSTNode;

            // Create print ast node
            curASTNode = new PrintStatementASTNode();

            // Set current ast node to exprsion
            curCSTNode = parentCSTNode.GetChild(2);

            // Create expression
            retASTNode = CreateExprASTNode();

            // Set expr value
            curASTNode.Expr = retASTNode;

            // Reset current CST node
            curCSTNode = parentCSTNode;

            // Return created print statment
            return curASTNode;
        }

        private AssignmentStatementASTNode CreateAssignmentStatementASTNode()
        {
            // Inits
            IDASTNode retIDASTNode = null;
            ExprASTNode retExprASTNode = null;
            AssignmentStatementASTNode curASTNode = null;

            // Set parent node to current
            parentCSTNode = curCSTNode;

            // Create assignment statment
            curASTNode = new AssignmentStatementASTNode();

            // Set current node to id expr
            curCSTNode = parentCSTNode.GetChild(0);

            // Create id expr ast node
            retIDASTNode = CreateIDExprASTNode();

            // Set current node to expression
            curCSTNode = parentCSTNode.GetChild(2);

            // Get expression
            retExprASTNode = CreateExprASTNode();

            // Make syblings
            retIDASTNode.MakeSybling(retExprASTNode);

            // Adopt child family
            curASTNode.AdoptChild(retIDASTNode);

            // Reset current CST node
            curCSTNode = parentCSTNode;

            // Return created assignment statment ast node
            return curASTNode;
        }

        private VarDecStatementASTNode CreateVarDecStatementASTNode()
        {
            // Inits
            TypeASTNode retTypeASTNode = null;
            IDASTNode retIDASTNode = null;
            VAR_TYPE varType = VAR_TYPE.VARTYPE_INT;
            VarDecStatementASTNode curASTNode = null;

            // Set parent node to current
            parentCSTNode = curCSTNode;

            // Create print statement ast node
            curASTNode = new VarDecStatementASTNode();

            // Get var type
            if( curCSTNode.GetChild(0).Data.Token.Type == Token.TokenType.TK_INT )
                varType = VAR_TYPE.VARTYPE_INT;
            else if ( curCSTNode.GetChild(0).Data.Token.Type == Token.TokenType.TK_STRING )
                varType = VAR_TYPE.VARTYPE_STRING;
            else if ( curCSTNode.GetChild(0).Data.Token.Type == Token.TokenType.TK_BOOLEAN  )
                varType = VAR_TYPE.VARTYPE_BOOLEAN;

            // Create new type ast node
            retTypeASTNode = new TypeASTNode(varType);

            // Set cur cst node to id
            curCSTNode = parentCSTNode.GetChild(1);

            // Create new id ast node
            retIDASTNode = CreateIDExprASTNode();

            // Make syblings
            retTypeASTNode.MakeSybling(retIDASTNode);

            // Adopt family
            curASTNode.AdoptChild(retTypeASTNode);

            // Reset current CST node
            curCSTNode = parentCSTNode;

            // Return created var dec statement
            return curASTNode;
        }

        private WhileStatementASTNode CreateWhileStatementASTNode()
        {
            // Inits
            ExprASTNode retExprASTNode = null;
            BlockASTNode retBlockASTNode = null;
            WhileStatementASTNode curASTNode = null;

            // Set parent node to current
            parentCSTNode = curCSTNode;

            // Create while statement ast node
            curASTNode = new WhileStatementASTNode();

            // Set current node to expr
            curCSTNode = parentCSTNode.GetChild(2);

            // Create expr
            retExprASTNode = CreateExprASTNode();

            // Set current node to block
            curCSTNode = parentCSTNode.GetChild(4);

            // Create block
            retBlockASTNode = CreateBlockASTNode(false);

            // Make syblings
            retExprASTNode.MakeSybling(retBlockASTNode);

            // Adopt family
            curASTNode.AdoptChild(retExprASTNode);

            // Reset current CST node
            curCSTNode = parentCSTNode;

            // Return created while statment node
            return curASTNode;
        }

        private IfStatementASTNode CreateIfStatementASTNode()
        {  // Inits
            ExprASTNode retExprASTNode = null;
            BlockASTNode retBlockASTNode = null;
            IfStatementASTNode curASTNode = null;

            // Set parent node to current
            parentCSTNode = curCSTNode;

            // Create while statement ast node
            curASTNode = new IfStatementASTNode();

            // Set current node to expr
            curCSTNode = parentCSTNode.GetChild(2);

            // Create expr
            retExprASTNode = CreateExprASTNode();

            // Set current node to block
            curCSTNode = parentCSTNode.GetChild(4);

            // Create block
            retBlockASTNode = CreateBlockASTNode(false);

            // Make syblings
            retExprASTNode.MakeSybling(retBlockASTNode);

            // Adopt family
            curASTNode.AdoptChild(retExprASTNode);

            // Reset current CST node
            curCSTNode = parentCSTNode;

            // Return created if statment node
            return curASTNode;
        }

        private ExprASTNode CreateExprASTNode()
        {
            // Inits
            ExprASTNode retASTNode = null;

            // Set parent node to current
            parentCSTNode = curCSTNode;

            // Check if print Statment
            if (curCSTNode.Data.Grammar == GrammarProcess.GP_INTEXPR)
            {
                // Create print statment
                retASTNode = CreateIntExprASTNode();
            }
            // Else check if assignment
            else if (curCSTNode.Data.Grammar == GrammarProcess.GP_STRINGEXPR)
            {
                // Create assignment statmeent
                retASTNode = CreateStringExprASTNode();
            }
            // Else check var dec
            else if (curCSTNode.Data.Grammar == GrammarProcess.GP_BOOLEANEXPR)
            {
                // Create var dec statement
                retASTNode = CreateBooleanExprASTNode();
            }
            // Check if while
            else if (curCSTNode.Data.Grammar == GrammarProcess.GP_ID)
            {
                // Create while statement
                retASTNode = CreateIDExprASTNode();
            }

            // Reset current CST node
            curCSTNode = parentCSTNode;

            // Return created statement
            return retASTNode;
        }

        private IntExprASTNode CreateIntExprASTNode()
        {
            // Inits
            IntValASTNode retIntValASTNode = null;
            IntOpASTNode retIntOpASTNode = null;
            ExprASTNode retExprASTNode = null;
            IntExprASTNode curASTNode = null;

            // Set parent node to current
            parentCSTNode = curCSTNode;

            // Check if type one (digit intop digit)
            if( parentCSTNode.NodeCount == 3 )
            {

                // Create new int expr ast node
                curASTNode = new IntExprASTNode(INTEXPR_TYPE.IET_ONE);
               
                // Create int val ast node and get digit
                retIntValASTNode = new IntValASTNode( Int32.Parse(parentCSTNode.GetChild(0).Data.Token.Value.ToString()) );

                // Create int op ast node ( node at this time their is only one value
                if( parentCSTNode.GetChild(1).Data.Token.Type == Token.TokenType.TK_OP_ADD )
                    retIntOpASTNode = new IntOpASTNode(INTOP_TYPE.INTOP_ADD);

                // Set current node to expression
                curCSTNode = parentCSTNode.GetChild(2);

                // Create expression ast node
                retExprASTNode = CreateExprASTNode();

                // Make sybling
                retIntValASTNode.MakeSybling(retIntOpASTNode);
                retIntValASTNode.MakeSybling(retExprASTNode);
            }
            // Else type two (digit)
            else
            {
                // Create new int expr ast node
                curASTNode = new IntExprASTNode(INTEXPR_TYPE.IET_TWO);

                // Create int val ast node and get digit
                retIntValASTNode = new IntValASTNode(Int32.Parse(parentCSTNode.GetChild(0).Data.Token.Value.ToString()));

            }

            // Adopt family
            curASTNode.AdoptChild(retIntValASTNode);

            // Reset current CST node
            curCSTNode = parentCSTNode;

            // Return created int expr ast node
            return curASTNode;
        }

        private StringExprASTNode CreateStringExprASTNode()
        {
            // Inits
            StringBuilder sb = new StringBuilder(20);
            StringExprASTNode curASTNode = null;
            int charNode = 0;

            // Set parent node to current
            parentCSTNode = curCSTNode;

            // Create new string expr ast node
            curASTNode = new StringExprASTNode();

            // Set current node to first child
            curCSTNode = parentCSTNode.GetChild(0);

            // Loop through char nodes adding to string value
            while (curCSTNode.Data.Grammar != GrammarProcess.GP_LAMDA)
            {
                // Add char value to string
                sb.Append(curCSTNode.Data.Token.Value);

                // Increment node count
                charNode++;

                // Get next char node
                curCSTNode = parentCSTNode.GetChild(charNode);
            }

            // Set string value to ast node
            curASTNode.Value = sb.ToString();

            // Reset current CST node
            curCSTNode = parentCSTNode;

            // Return created string expr ast node
            return curASTNode;
        }

        private BooleanExprASTNode CreateBooleanExprASTNode()
        {
            // Inits
            ExprASTNode retExprASTNode1 = null;
            BoolOpASTNode retBoolOpASTNode = null;
            ExprASTNode retExprASTNode2 = null;
            BoolValASTNode retBoolValASTNode = null;
            BooleanExprASTNode curASTNode = null;

            // Set parent node to current
            parentCSTNode = curCSTNode;

            // Check if boolean expr type one : ( EXPR BOoLOP EXPR )
            if (parentCSTNode.GetChild(0).Data.Token.Type == Token.TokenType.TK_LPARAM)
            {
                // Create new boolean expr ast node
                curASTNode = new BooleanExprASTNode(BOOLEXPR_TYPE.BET_ONE);

                // Set current node to expr
                curCSTNode = parentCSTNode.GetChild(1);

                // Create expr 1 ast node
                retExprASTNode1 = CreateExprASTNode();

                // Determine bool op
                if (parentCSTNode.GetChild(2).Data.Token.Type == Token.TokenType.TK_BOOL_OP_EQUALS)
                    retBoolOpASTNode = new BoolOpASTNode(BOOLOP_TYPE.BOOLOP_EQUALS);
                else
                    retBoolOpASTNode = new BoolOpASTNode(BOOLOP_TYPE.BOOLOP_NOT_EQUALS);

                // Set current node to expr
                curCSTNode = parentCSTNode.GetChild(3);

                // Create expr 2 ast node
                retExprASTNode2 = CreateExprASTNode();

                // Make syblings
                retExprASTNode1.MakeSybling(retBoolOpASTNode);
                retExprASTNode1.MakeSybling(retExprASTNode2);

                // Adopt family
                curASTNode.AdoptChild(retExprASTNode1);
            }
            // Else boolean expr type : BOOLVAL
            else
            {
                // Create bool val ast node
                if (parentCSTNode.GetChild(0).Data.Token.Type == Token.TokenType.TK_BOOL_TRUE) 
                    retBoolValASTNode = new BoolValASTNode(BOOLVAL_TYPE.BOOLVAL_TRUE);
                else
                    retBoolValASTNode = new BoolValASTNode(BOOLVAL_TYPE.BOOLVAL_FALSE);

                // Adopt family
                curASTNode.AdoptChild(retBoolValASTNode);
            }

            // Reset current CST node
            curCSTNode = parentCSTNode;

            // Return created boolean expr ast node
            return curASTNode;
        }

        private IDASTNode CreateIDExprASTNode()
        {
            // Inits
            IDASTNode curASTNode = null;

            // Create new ID ast node with char value
            curASTNode = new IDASTNode(curCSTNode.Data.Token.Value);

            // Return created id ast node
            return curASTNode;
        }

        #endregion
    }
}
