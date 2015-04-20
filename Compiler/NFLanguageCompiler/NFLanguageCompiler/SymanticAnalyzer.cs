using DynamicBranchTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFLanguageCompiler
{
    // Symantic anayzer first builds a AST from the CST generated from parse.
    // It then builds a symbol table, checks scope, and type.
    //
    // Warnings: 1. Uninitialized variables.
    // Errors:  1. Type mistmatch.
    //          2. Undeclared variables.
    //          3. Redeclared variables.
    public class SymanticAnalyzer
    {
        #region Data Members

        DynamicBranchTreeNode<CSTValue> curCSTNode;
        DynamicBranchTreeNode<SymbolHashTable> rootSymbolTableNode;
        DynamicBranchTreeNode<SymbolHashTable> curSymbolTableNode;
        BlockASTNode rootASTNode;

        #endregion

        #region Properties

        public BlockASTNode RootASTNode
        {
            get { return rootASTNode;  }
            set { rootASTNode = value; }
        }

        public DynamicBranchTreeNode<SymbolHashTable> RootSymbolTableNode
        {
            get { return rootSymbolTableNode; }
            set { rootSymbolTableNode = value; }
        }

        public int ErrorCount
        {
            get;
            set;
        }

        public int WarningCount
        {
            get;
            set;
        }

        #endregion

        #region Delegates and Events

        //Symantic Analyzer message event
        public event MessageEventHandler SymanticAnalyzerMessageEvent;

        //Symantic Analyzer error event
        public event WarningErrorEventHandler SymanticAnalyzerErrorEvent;

        //Symantic Analyzer warning event
        public event WarningErrorEventHandler SymanticAnalyzerWarningEvent;

        #endregion

        #region Constructors

        // Default constructor, inits values
        public SymanticAnalyzer()
        {
           curCSTNode = null;
           rootSymbolTableNode = new DynamicBranchTreeNode<SymbolHashTable>(new SymbolHashTable());
           curSymbolTableNode = null;
           rootASTNode = new BlockASTNode();

            WarningCount = 0;
            ErrorCount = 0;
        }

        #endregion

        #region Symantic Analysis Methods

        // Starts symantic alnalysis process. Builds an AST from CST, 
        // then checks var decs, type, and scope.
        //
        // Returns: Process return value.
        public ProcessReturnValue AnalyzeSymantics(DynamicBranchTreeNode<CSTValue> rootCSTNode)
        {
            // Inits
            ProcessReturnValue ret = ProcessReturnValue.PRV_NONE;


            // Send Message
            SendMessage("Creating AST...");

            // Create AST from CST
            CreateAST(rootCSTNode);

            // Send Message
            SendMessage("Completed AST. Starting symantic analysis...");

            // Anaylze scope, types, and existance
            CheckVars();

            // Check for unreachable code

            // Send Message
            SendMessage("Symantic analysis complete.");

            // Set return value
            if (ErrorCount > 0)
                ret = ProcessReturnValue.PRV_ERRORS;
            else if (WarningCount > 0)
                ret = ProcessReturnValue.PRV_WARNINGS;
            else
                ret = ProcessReturnValue.PRV_OK;

            // Return value
            return ret;
        }

        // Checks variable declarations, type, and scope. Starts a recursive process.
        private void CheckVars()
        {
            // Set root to null
            rootSymbolTableNode = null;

            //Check ast recursivly
            rootSymbolTableNode = CheckVarsRecursive(rootASTNode, rootSymbolTableNode, 0, 0);
        }

        // Recursive check vars method. Checks var decs, type, and scope.
        // 
        // Returns: Current symbol table node.
        private DynamicBranchTreeNode<SymbolHashTable> CheckVarsRecursive(ASTNode curASTNode, DynamicBranchTreeNode<SymbolHashTable> curSymbolTable, int blockStmtCount, int totalBlockStmts)
        {
            // Inits
            DynamicBranchTreeNode<SymbolHashTable> newSymbolTable = null;
            DynamicBranchTreeNode<SymbolHashTable> parentSymbolTable = curSymbolTable;
            SymbolTableEntry entry = null;
            SymbolTableEntry entry2 = null;
            ASTNode curChild = null;
            VarDecStatementASTNode varDecASTNode = null;
            AssignmentStatementASTNode assignmentASTNode = null;
            BoolOpASTNode boolOpASTNode = null;
            IntOpASTNode intOpASTNode = null;
            IDASTNode idASTNode = null;
            IDASTNode idASTNode2 = null;
            bool error = false;


            bool found = false;
            int line = 0;
            int col = 0;

            // Check if end of parent blcok
            if (totalBlockStmts == blockStmtCount)
            {
                if (curSymbolTable != null && curSymbolTable.Parent != null)
                    parentSymbolTable = curSymbolTable = curSymbolTable.Parent;
            }

            // Increment block count if statment
            if (curASTNode is StatementASTNode)
                blockStmtCount++;

            // Check if block
            switch (curASTNode.NodeType)
            {
                case ASTNodeType.ASTTYPE_BLOCK:

                    // Get total statments
                    totalBlockStmts = curASTNode.TotalChildren();

                    // Reset cur statment count
                    blockStmtCount = 0;

                    if (curSymbolTable != null)
                    {
                        newSymbolTable = new DynamicBranchTreeNode<SymbolHashTable>(new SymbolHashTable());
                        curSymbolTable.AddChild(newSymbolTable);
                        curSymbolTable = newSymbolTable;


                    }
                    else
                        rootSymbolTableNode = parentSymbolTable = curSymbolTable = new DynamicBranchTreeNode<SymbolHashTable>(new SymbolHashTable());


                    break;

                case ASTNodeType.ASTTYPE_VARDEC:
                    // Create new symbol table entry
                    entry = new SymbolTableEntry();

                    // Get var dec node
                    varDecASTNode = (VarDecStatementASTNode)curASTNode;

                    // Get data from node
                    if (varDecASTNode.Type.Value == VAR_TYPE.VARTYPE_BOOLEAN)
                        entry.DataType = DataType.DT_BOOLEAN;
                    else if (varDecASTNode.Type.Value == VAR_TYPE.VARTYPE_INT)
                        entry.DataType = DataType.DT_INT;
                    else if (varDecASTNode.Type.Value == VAR_TYPE.VARTYPE_STRING)
                        entry.DataType = DataType.DT_STRING;
                    entry.ID = varDecASTNode.Id.Value;

                    // Check if exists in symbol table
                    found = curSymbolTable.Data.CheckCollision(entry.ID);
                   


                    // Check if found and add to symbol table
                    if (!found)
                    {
                        curSymbolTable.Data.AddItem(entry);
                    }
                    // Else send error as their was a collision
                    else
                    {
                        line = varDecASTNode.StartToken.Line;
                        col = varDecASTNode.StartToken.Column;
                        SendError(new Message(String.Format("Variable redeclaration. Variable {0} on line {1} column {2} was already declared.", entry.ID, line, col), line, col, GrammarProcess.GP_VARDEC, SystemType.ST_SYMANTICS));
                    }

                    break;


                case ASTNodeType.ASTTYPE_ASSIGNSTATEMENT:


                    // Get var dec node
                    assignmentASTNode = (AssignmentStatementASTNode)curASTNode;

                    // Check if variable exits
                    parentSymbolTable = curSymbolTable;
                    while (parentSymbolTable != null && !found)
                    {
                        // Get entry
                        entry = parentSymbolTable.Data.GetItem(assignmentASTNode.Id.Value);
                        if (entry != null)
                        {
                            // Set found flag true
                            found = true;
                        }

                        parentSymbolTable = parentSymbolTable.Parent;
                    }

                    // If not found in symbol table, send error
                    if (!found)
                    {
                        line = assignmentASTNode.StartToken.Line;
                        col = assignmentASTNode.StartToken.Column;
                        SendError(new Message(String.Format("Undeclared variable. Variable {0} on line {1} column {2} was never declared.", entry.ID, line, col), line, col, GrammarProcess.GP_ASSIGNMENTSTATEMENT, SystemType.ST_SYMANTICS));
                        error = true;
                    }
                    else
                    {
                        // Check if int expression is int expr
                        if (assignmentASTNode.Expr is IntExprASTNode)
                        {
                            // check if data type of entry is not int
                            if (entry.DataType != DataType.DT_INT)
                            {
                                // Send error
                                line = assignmentASTNode.StartToken.Line;
                                col = assignmentASTNode.StartToken.Column;
                                SendError(new Message(String.Format("Type mismatch. Assignment to variable {0} {1}, on line {2} column {3} was assigned to a {4} expression.", GetTypeString(entry.DataType), entry.ID, line, col, GetExpressionTypeString(assignmentASTNode.Expr)), line, col, GrammarProcess.GP_ASSIGNMENTSTATEMENT, SystemType.ST_SYMANTICS));
                                error = true;
                            }
                        }
                        // Else if expr is boolean
                        else if (assignmentASTNode.Expr is BooleanExprASTNode)
                        {
                            // check if data type of entry is not boolean
                            if (entry.DataType != DataType.DT_BOOLEAN)
                            {
                                // Send error
                                line = assignmentASTNode.StartToken.Line;
                                col = assignmentASTNode.StartToken.Column;
                                SendError(new Message(String.Format("Type mismatch. Assignment to variable {0} {1}, on line {2} column {3} was assigned to a {4} expression.", GetTypeString(entry.DataType), entry.ID, line, col, GetExpressionTypeString(assignmentASTNode.Expr)), line, col, GrammarProcess.GP_ASSIGNMENTSTATEMENT, SystemType.ST_SYMANTICS));
                                error = true;
                            }
                        }

                        /// if not boolean and int check if its a string expression
                        else if (assignmentASTNode.Expr is StringExprASTNode)
                        {
                            // check if data type of entry is not string
                            if (entry.DataType != DataType.DT_STRING)
                            {
                                // Send error
                                line = assignmentASTNode.StartToken.Line;
                                col = assignmentASTNode.StartToken.Column;
                                SendError(new Message(String.Format("Type mismatch. Assignment to variable {0} {1}, on line {2} column {3} was assigned to a {4} expression.", GetTypeString(entry.DataType), entry.ID, line, col, GetExpressionTypeString(assignmentASTNode.Expr)), line, col, GrammarProcess.GP_ASSIGNMENTSTATEMENT, SystemType.ST_SYMANTICS));
                                error = true;
                            }
                        }
                        // finally, check if id statement
                        else if (assignmentASTNode.Expr is IDASTNode)
                        {
                            // Get id node
                            idASTNode = (IDASTNode)assignmentASTNode.Expr;

                            // Try to find in symbol table or parents symbol table
                            found = false;
                            parentSymbolTable = curSymbolTable;
                            while (parentSymbolTable != null && !found)
                            {
                                // Get entry and check if found
                                entry2 = parentSymbolTable.Data.GetItem(idASTNode.Value);
                                if (entry2 != null)
                                    found = true;

                                parentSymbolTable = parentSymbolTable.Parent;
                            }

                            // Check if entry was found in symbol table
                            if (found)
                            {
                                // send warning if using var before initialized
                                if (!entry2.Initialized)
                                {
                                    line = assignmentASTNode.StartToken.Line;
                                    col = assignmentASTNode.StartToken.Column;
                                    SendWarning(new Message(String.Format("Unitialized variable. Assignment to variable {0} {1}, on line {2} column {3}, was assigned the value of uninitialized variable {4} {5}."
                                        , GetTypeString(entry.DataType), entry.ID, line, col, GetTypeString(entry2.DataType), entry2.ID), line, col, GrammarProcess.GP_ASSIGNMENTSTATEMENT, SystemType.ST_SYMANTICS));

                                }

                                // check if data type of entry is same as ID
                                if (entry2.DataType != entry.DataType)
                                {
                                    // Send error
                                    line = assignmentASTNode.StartToken.Line;
                                    col = assignmentASTNode.StartToken.Column;
                                    SendError(new Message(String.Format("Type mismatch. Assignment to variable {0} {1}, on line {2} column {3}, was assigned the value of variable {4} {5}.", GetTypeString(entry.DataType), entry.ID, line, col, GetTypeString(entry2.DataType), entry2.ID), line, col, GrammarProcess.GP_ASSIGNMENTSTATEMENT, SystemType.ST_SYMANTICS));
                                    error = true;
                                }

                            }
                            // If not found send error
                            else
                            {
                                // Send error
                                line = assignmentASTNode.StartToken.Line;
                                col = assignmentASTNode.StartToken.Column;
                                SendError(new Message(String.Format("Undeclared variable. Assignment to variable {0} {1}, on line {2} column {3}, was assigned to a variable {4} that does not exits.", GetTypeString(entry.DataType), entry.ID, line, col, idASTNode.Value), line, col, GrammarProcess.GP_ASSIGNMENTSTATEMENT, SystemType.ST_SYMANTICS));
                                error = true;
                            }
                        }
                    }

                    // If not error set the init flag if not already set
                    if (!error && entry != null && entry.Initialized == false)
                    {
                        entry.Initialized = true;
                    }


                    break;

                case ASTNodeType.ASTTYPE_BOOLOP:
                    // Inits

                    // Get bool op node ref
                    boolOpASTNode = (BoolOpASTNode)curASTNode;

                    // Check if first expressions is boolean
                    if (boolOpASTNode.ExprOne is BooleanExprASTNode)
                    {
                        // Check if next expressions is not boolean
                        if (!(boolOpASTNode.ExprTwo is BooleanExprASTNode))
                        {
                            // check if expression is var of type boolean
                            if (boolOpASTNode.ExprTwo is IDASTNode)
                            {
                                // Get id ast node
                                idASTNode = (IDASTNode)boolOpASTNode.ExprTwo;

                                // Find value in symbol table
                                parentSymbolTable = curSymbolTable;
                                while (parentSymbolTable != null && !found)
                                {
                                    entry = parentSymbolTable.Data.GetItem(idASTNode.Value);
                                    if (entry != null)
                                        found = true;

                                    parentSymbolTable = parentSymbolTable.Parent;
                                }

                                // Check if found
                                if (found)
                                {
                                    // send warning if using var before initialized
                                    if (!entry.Initialized)
                                    {
                                        line = boolOpASTNode.StartToken.Line;
                                        col = boolOpASTNode.StartToken.Column;
                                        SendWarning(new Message(String.Format("Unitialized variable. In boolean operation on line {0} column {1}, was assigned the value of uninitialized variable {2} {3}."
                                            , line, col, GetTypeString(entry.DataType), entry.ID), line, col, GrammarProcess.GP_BOOLOP, SystemType.ST_SYMANTICS));

                                    }

                                    // Check if id is of not of boolean type and send error
                                    if (entry.DataType != DataType.DT_BOOLEAN)
                                    {
                                        line = boolOpASTNode.StartToken.Line;
                                        col = boolOpASTNode.StartToken.Column;
                                        SendError(new Message(String.Format("Type mismatch. In boolean operation on line {0} column {1}, a boolean expression was compared to variable {2} {3}.", line, col, GetTypeString(entry.DataType), entry.ID), line, col, GrammarProcess.GP_BOOLOP, SystemType.ST_SYMANTICS));
                                    }
                                }
                                // Else send error
                                else
                                {

                                    line = boolOpASTNode.StartToken.Line;
                                    col = boolOpASTNode.StartToken.Column;
                                    SendError(new Message(String.Format("Undeclared variable. In boolean operation on line {0} column {1}, a boolean expression was compared to undeclared variable {2}.", line, col, idASTNode.Value), line, col, GrammarProcess.GP_BOOLOP, SystemType.ST_SYMANTICS));

                                }
                            }
                            // Else send error on expression type mismatch
                            else
                            {
                                line = boolOpASTNode.StartToken.Line;
                                col = boolOpASTNode.StartToken.Column;
                                SendError(new Message(String.Format("Type mismatch. In boolean operation on line {0} column {1}, a boolean expression was compared to an {2} expression.", line, col, GetExpressionTypeString(boolOpASTNode.ExprTwo)), line, col, GrammarProcess.GP_BOOLOP, SystemType.ST_SYMANTICS));

                            }
                        }
                    }
                    // Check if first expressions is int expression
                    else if (boolOpASTNode.ExprOne is IntExprASTNode)
                    {
                        // Check if next expressions is not int
                        if (!(boolOpASTNode.ExprTwo is IntExprASTNode))
                        {
                            // check if expression is var of type int
                            if (boolOpASTNode.ExprTwo is IDASTNode)
                            {
                                // Get id ast node
                                idASTNode = (IDASTNode)boolOpASTNode.ExprTwo;

                                // Find value in symbol table
                                parentSymbolTable = curSymbolTable;
                                while (parentSymbolTable != null && !found)
                                {
                                    entry = parentSymbolTable.Data.GetItem(idASTNode.Value);
                                    if (entry != null)
                                        found = true;

                                    parentSymbolTable = parentSymbolTable.Parent;
                                }

                                // Check if found
                                if (found)
                                {
                                    // send warning if using var before initialized
                                    if (!entry.Initialized)
                                    {
                                        line = boolOpASTNode.StartToken.Line;
                                        col = boolOpASTNode.StartToken.Column;
                                        SendWarning(new Message(String.Format("Unitialized variable. In boolean operation on line {0} column {1}, was assigned the value of uninitialized variable {2} {3}."
                                            , line, col, GetTypeString(entry.DataType), entry.ID), line, col, GrammarProcess.GP_BOOLOP, SystemType.ST_SYMANTICS));

                                    }

                                    // Check if id is of not of int type and send error
                                    if (entry.DataType != DataType.DT_INT)
                                    {
                                        line = boolOpASTNode.StartToken.Line;
                                        col = boolOpASTNode.StartToken.Column;
                                        SendError(new Message(String.Format("Type mismatch. In boolean operation on line {0} column {1}, an integer expression was compared to variable {2} {3}.", line, col, GetTypeString(entry.DataType), entry.ID), line, col, GrammarProcess.GP_BOOLOP, SystemType.ST_SYMANTICS));
                                    }
                                }
                                // Else send error
                                else
                                {

                                    line = boolOpASTNode.StartToken.Line;
                                    col = boolOpASTNode.StartToken.Column;
                                    SendError(new Message(String.Format("Undeclared variable. In boolean operation on line {0} column {1}, an integer expression was compared to undeclared variable {2}.", line, col, idASTNode.Value), line, col, GrammarProcess.GP_BOOLOP, SystemType.ST_SYMANTICS));

                                }
                            }
                            // Else send error on expression type mismatch
                            else
                            {
                                line = boolOpASTNode.StartToken.Line;
                                col = boolOpASTNode.StartToken.Column;
                                SendError(new Message(String.Format("Type mismatch. In boolean operation on line {0} column {1}, an integer expression was compared to an {2} expression.", line, col, GetExpressionTypeString(boolOpASTNode.ExprTwo)), line, col, GrammarProcess.GP_BOOLOP, SystemType.ST_SYMANTICS));

                            }
                        }
                    }
                    // Check if first expressions is string
                    else if (boolOpASTNode.ExprOne is StringExprASTNode)
                    {
                        // Check if next expressions is not string
                        if (!(boolOpASTNode.ExprTwo is StringExprASTNode))
                        {
                            // check if expression is var of type string
                            if (boolOpASTNode.ExprTwo is IDASTNode)
                            {
                                // Get id ast node
                                idASTNode = (IDASTNode)boolOpASTNode.ExprTwo;

                                // Find value in symbol table
                                parentSymbolTable = curSymbolTable;
                                while (parentSymbolTable != null && !found)
                                {
                                    entry = parentSymbolTable.Data.GetItem(idASTNode.Value);
                                    if (entry != null)
                                        found = true;

                                    parentSymbolTable = parentSymbolTable.Parent;
                                }

                                // Check if found
                                if (found)
                                {
                                    // send warning if using var before initialized
                                    if (!entry.Initialized)
                                    {
                                        line = boolOpASTNode.StartToken.Line;
                                        col = boolOpASTNode.StartToken.Column;
                                        SendWarning(new Message(String.Format("Unitialized variable. In boolean operation on line {0} column {1}, was assigned the value of uninitialized variable {2} {3}."
                                            , line, col, GetTypeString(entry.DataType), entry.ID), line, col, GrammarProcess.GP_BOOLOP, SystemType.ST_SYMANTICS));

                                    }

                                    // Check if id is of not of boolean type and send error
                                    if (entry.DataType != DataType.DT_STRING)
                                    {
                                        line = boolOpASTNode.StartToken.Line;
                                        col = boolOpASTNode.StartToken.Column;
                                        SendError(new Message(String.Format("Type mismatch. In boolean operation on line {0} column {1}, a string expression was compared to variable {2} {3}.", line, col, GetTypeString(entry.DataType), entry.ID), line, col, GrammarProcess.GP_BOOLOP, SystemType.ST_SYMANTICS));
                                    }
                                }
                                // Else send error
                                else
                                {

                                    line = boolOpASTNode.StartToken.Line;
                                    col = boolOpASTNode.StartToken.Column;
                                    SendError(new Message(String.Format("Undeclared variable. In boolean operation on line {0} column {1}, a string expression was compared to undeclared variable {2}.", line, col, idASTNode.Value), line, col, SystemType.ST_SYMANTICS));

                                }
                            }
                            // Else send error on expression type mismatch
                            else
                            {
                                line = boolOpASTNode.StartToken.Line;
                                col = boolOpASTNode.StartToken.Column;
                                SendError(new Message(String.Format("Type mismatch. In boolean operation on line {0} column {1}, a string expression was compared to an {2} expression.", line, col, GetExpressionTypeString(boolOpASTNode.ExprTwo)), line, col, GrammarProcess.GP_BOOLOP, SystemType.ST_SYMANTICS));

                            }
                        }
                    }
                    // Else check if first expression is var dec
                    else if (boolOpASTNode.ExprOne is IDASTNode)
                    {
                        // Get id ast node
                        idASTNode = (IDASTNode)boolOpASTNode.ExprOne;

                        // Check if id exists in symbol table
                        parentSymbolTable = curSymbolTable;
                        while (parentSymbolTable != null && !found)
                        {
                            entry = parentSymbolTable.Data.GetItem(idASTNode.Value);
                            if (entry != null)
                                found = true;

                            parentSymbolTable = parentSymbolTable.Parent;
                        }

                        // Check if var found
                        if (found)
                        {
                            // send warning if using var before initialized
                            if (!entry.Initialized)
                            {
                                line = boolOpASTNode.StartToken.Line;
                                col = boolOpASTNode.StartToken.Column;
                                SendWarning(new Message(String.Format("Unitialized variable. In boolean operation on line {0} column {1}, was assigned the value of uninitialized variable {2} {3}."
                                    , line, col, GetTypeString(entry.DataType), entry.ID), line, col, GrammarProcess.GP_BOOLOP, SystemType.ST_SYMANTICS));

                            }

                            // Check if expression two is an id
                            if (boolOpASTNode.ExprTwo is IDASTNode)
                            {
                                // get second id ast node
                                idASTNode2 = (IDASTNode)boolOpASTNode.ExprTwo;

                                // Check if id exists in symbol table
                                found = false;
                                parentSymbolTable = curSymbolTable;
                                while (parentSymbolTable != null && !found)
                                {
                                    entry2 = parentSymbolTable.Data.GetItem(idASTNode2.Value);
                                    if (entry2 != null)
                                        found = true;

                                    parentSymbolTable = parentSymbolTable.Parent;
                                }

                                // If found check if types are same
                                if (found)
                                {
                                    // send warning if using var before initialized
                                    if (!entry2.Initialized)
                                    {
                                        line = boolOpASTNode.StartToken.Line;
                                        col = boolOpASTNode.StartToken.Column;
                                        SendWarning(new Message(String.Format("Unitialized variable. In boolean operation on line {0} column {1}, was assigned the value of uninitialized variable {2} {3}."
                                            , line, col, GetTypeString(entry2.DataType), entry2.ID), line, col, GrammarProcess.GP_BOOLOP, SystemType.ST_SYMANTICS));

                                    }

                                    //Check if types are wrong and send error
                                    if (entry.DataType != entry2.DataType)
                                    {
                                        line = boolOpASTNode.StartToken.Line;
                                        col = boolOpASTNode.StartToken.Column;
                                        SendError(new Message(String.Format("Type mismatch. In boolean operation on line {0} column {1}, the variable {2} {3} was compared to variable {4} {5}.", line, col, GetTypeString(entry.DataType), entry.ID, GetTypeString(entry2.DataType), entry2.ID), line, col, GrammarProcess.GP_BOOLOP, SystemType.ST_SYMANTICS));

                                    }
                                }
                                // Else send undeclared varabile mismatch
                                else
                                {
                                    line = boolOpASTNode.StartToken.Line;
                                    col = boolOpASTNode.StartToken.Column;
                                    SendError(new Message(String.Format("Undeclared variable. In boolean operation on line {0} column {1}, the variable {2} {3} was compared to an undeclared variable {4}.", line, col, GetTypeString(entry.DataType), entry.ID, idASTNode2.Value), line, col, GrammarProcess.GP_BOOLOP, SystemType.ST_SYMANTICS));

                                }
                            }
                            // Else expression two is an int, boolean, or string expr
                            else
                            {
                                // Check if types are not the same, and send error
                                if (GetTypeString(entry.DataType) != GetExpressionTypeString(boolOpASTNode.ExprTwo))
                                {
                                    line = boolOpASTNode.StartToken.Line;
                                    col = boolOpASTNode.StartToken.Column;
                                    SendError(new Message(String.Format("Type mismatch. In boolean operation on line {0} column {1}, the variable {2} {3} was compared to an {4} expression.", line, col, GetTypeString(entry.DataType), entry.ID, GetExpressionTypeString(boolOpASTNode.ExprTwo)), line, col, GrammarProcess.GP_BOOLOP, SystemType.ST_SYMANTICS));

                                }
                            }
                        }
                        // Else if not found send error
                        else
                        {
                            line = boolOpASTNode.StartToken.Line;
                            col = boolOpASTNode.StartToken.Column;
                            SendError(new Message(String.Format("Undeclared variable {0}, in boolean operation on line {1} col {2}.", idASTNode.Value, line, col), line, col, GrammarProcess.GP_BOOLOP, SystemType.ST_SYMANTICS));

                            // Also check if expression two is id ( just to catch a further undeclared var error )
                            if (boolOpASTNode.ExprTwo is IDASTNode)
                            {
                                // Get id ast node
                                idASTNode2 = (IDASTNode)boolOpASTNode.ExprTwo;

                                // Check if declared
                                found = false;
                                parentSymbolTable = curSymbolTable;
                                while (parentSymbolTable != null && !found)
                                {
                                    entry2 = parentSymbolTable.Data.GetItem(idASTNode2.Value);
                                    if (entry2 != null)
                                        found = true;
                                }

                                // Send error if not declared
                                if (!found)
                                {
                                    line = intOpASTNode.StartToken.Line;
                                    col = intOpASTNode.StartToken.Column;
                                    SendError(new Message(String.Format("Undeclared variable {0}, in boolean operation on line {1} col {2}.", entry.ID, line, col), line, col, GrammarProcess.GP_BOOLOP, SystemType.ST_SYMANTICS));

                                }
                                else
                                {
                                    // send warning if using var before initialized
                                    if (!entry2.Initialized)
                                    {
                                        line = boolOpASTNode.StartToken.Line;
                                        col = boolOpASTNode.StartToken.Column;
                                        SendWarning(new Message(String.Format("Unitialized variable. In boolean operation on line {0} column {1}, was assigned the value of uninitialized variable {2} {3}."
                                            , line, col, GetTypeString(entry2.DataType), entry2.ID), line, col, GrammarProcess.GP_BOOLOP, SystemType.ST_SYMANTICS));

                                    }

                                }
                            }
                        }
                    }


                    break;

                case ASTNodeType.ASTTYPE_INTOP:

                    // Get int op node
                    intOpASTNode = (IntOpASTNode)curASTNode;

                    // Check if expression is id
                    if (intOpASTNode.Expr is IDASTNode)
                    {
                        // Get id ast node
                        idASTNode = (IDASTNode)intOpASTNode.Expr;

                        // Find var in symbol table
                        parentSymbolTable = curSymbolTable;
                        while (parentSymbolTable != null && !found)
                        {
                            entry = parentSymbolTable.Data.GetItem(idASTNode.Value);
                            if (entry != null)
                                found = true;

                            parentSymbolTable = parentSymbolTable.Parent;
                        }

                        // Check if declared
                        if (found)
                        {
                            // send warning if using var before initialized
                            if (!entry.Initialized)
                            {
                                line = intOpASTNode.StartToken.Line;
                                col = intOpASTNode.StartToken.Column;
                                SendWarning(new Message(String.Format("Unitialized variable. In int operation on line {0} column {1}, was assigned the value of uninitialized variable {2} {3}."
                                    , line, col, GetTypeString(entry.DataType), entry.ID), line, col, GrammarProcess.GP_INTOP, SystemType.ST_SYMANTICS));

                            }

                            // Check if type is not int and send error
                            if (entry.DataType != DataType.DT_INT)
                            {
                                line = intOpASTNode.StartToken.Line;
                                col = intOpASTNode.StartToken.Column;
                                SendError(new Message(String.Format("Type mismatch. Variable {0} {1} in int operation on line {2} col {3}, was not an integer.", GetTypeString(entry.DataType), entry.ID, line, col), line, col, GrammarProcess.GP_INTOP, SystemType.ST_SYMANTICS));

                            }
                        }

                        // If not declared send error
                        else
                        {
                            line = intOpASTNode.StartToken.Line;
                            col = intOpASTNode.StartToken.Column;
                            SendError(new Message(String.Format("Undeclared variable. Varible {0} was undeclared in int operation on line {1} col {2}.", idASTNode.Value, line, col), line, col, GrammarProcess.GP_INTOP, SystemType.ST_SYMANTICS));

                        }

                    }
                    // Else if check if its not an int expression
                    else if (!(intOpASTNode.Expr is IntExprASTNode))
                    {
                        line = intOpASTNode.StartToken.Line;
                        col = intOpASTNode.StartToken.Column;
                        SendError(new Message(String.Format("Type mistmatch. Integer operation on line {0} column {1} contains an {2} expression.", line, col, GetExpressionTypeString(intOpASTNode.Expr)), line, col, GrammarProcess.GP_INTOP, SystemType.ST_SYMANTICS));

                    }
                    break;


                case ASTNodeType.ASTTYPE_PRINTSTATEMENT:
                    // Inits
                    PrintStatementASTNode printASTNode = (PrintStatementASTNode)curASTNode;

                    // Check if undeclared identifier int print statment
                    if (printASTNode.Expr is IDASTNode)
                    {
                        // Get id ast node
                        idASTNode = (IDASTNode)printASTNode.Expr;

                        // Find var in symbol table
                        parentSymbolTable = curSymbolTable;
                        while (parentSymbolTable != null && !found)
                        {
                            entry = parentSymbolTable.Data.GetItem(idASTNode.Value);
                            if (entry != null)
                                found = true;

                            parentSymbolTable = parentSymbolTable.Parent;
                        }

                        // If not declared send error
                        if (!found)
                        {
                            line = printASTNode.StartToken.Line;
                            col = printASTNode.StartToken.Column;
                            SendError(new Message(String.Format("Undeclared variable. Varible {0} was undeclared in print operation on line {1} col {2}.", idASTNode.Value, line, col), line, col, GrammarProcess.GP_PRINTSTATEMENT, SystemType.ST_SYMANTICS));

                        }
                        else
                        {
                            // send warning if using var before initialized
                            if (!entry.Initialized)
                            {
                                line = printASTNode.StartToken.Line;
                                col = printASTNode.StartToken.Column;
                                SendWarning(new Message(String.Format("Unitialized variable. In print statement on line {0} column {1}, was assigned the value of uninitialized variable {2} {3}."
                                    , line, col, GetTypeString(entry.DataType), entry.ID), line, col, GrammarProcess.GP_PRINTSTATEMENT, SystemType.ST_SYMANTICS));

                            }
                        }
                    }

                    break;

            }

            curChild = curASTNode.LeftMostChild;
            while (curChild != null)
            {

                CheckVarsRecursive(curChild, curSymbolTable, blockStmtCount, totalBlockStmts);
                curChild = curChild.RightSibling;
            }

            // Reset parent symbol table
            curSymbolTable = parentSymbolTable;

            // Return parent symbol table
            return parentSymbolTable;
        }

        #endregion

        #region AST Creation Methods

        // Creates AST from CST.
        public void CreateAST(DynamicBranchTreeNode<CSTValue> rootCSTNode)
        {
            
            //Set current and parent CST node values
            curCSTNode = rootCSTNode;
            //parentCSTNode = null;

            //Parse first program block, and set as root AST
            rootASTNode = CreateBlockASTNode(true);
        }

        // Create block ast node
        //
        // Returns: Created block AST node.
        public BlockASTNode CreateBlockASTNode( bool firstBlock)
        {
            // Inits
            StatementASTNode retASTNode = null;
            StatementASTNode firstRetASTNode = null;
            DynamicBranchTreeNode<CSTValue> statementListCSTNode = null;
            BlockASTNode curASTNode = null;
            DynamicBranchTreeNode<CSTValue> parentCSTNode;
                        

            // If first block, move from PROGRAM cst node to BLOCK
            if (firstBlock)
                parentCSTNode = curCSTNode.GetChild(0);

            // Else set parent to current node
            else
                parentCSTNode = curCSTNode;

            // Create new AST node for block
            curASTNode = new BlockASTNode();

            // Set program flag
            curASTNode.IsProgramBlock = firstBlock;

            // Get first statement list
            statementListCSTNode = parentCSTNode.GetChild(1);

            // Get statement
            curCSTNode = statementListCSTNode.GetChild(0);

            // Loop through statement lists until lamda
            while (curCSTNode.Data.Grammar != GrammarProcess.GP_LAMDA)
            {
                //Create statement grammar
                retASTNode = CreateStatementASTNode();
                
                // Make sybling if not first statment
                if (firstRetASTNode != null)
                    firstRetASTNode.MakeSybling(retASTNode);
                // Else set first returned statement
                else
                {
                    firstRetASTNode = retASTNode;

                    // Set first statement as statement list
                    curASTNode.StatementList = retASTNode;
                }

                // Get next statment list
                statementListCSTNode = statementListCSTNode.GetChild(1);

                // Get next statement or lamda
                curCSTNode = statementListCSTNode.GetChild(0);
            }

            // Adopt statement family
            if (firstRetASTNode != null)
                curASTNode.AdoptChild(firstRetASTNode);

            // Reset current CST node
            curCSTNode = parentCSTNode;

            // Return created block
            return curASTNode;
        }

        // Create statement ast node
        //
        // Returns: Created statement AST node.
        private StatementASTNode CreateStatementASTNode()
        {
            // Inits
            StatementASTNode retASTNode = null;
            DynamicBranchTreeNode<CSTValue> parentCSTNode;

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

        // Create print ast node
        //
        // Returns: Created print AST node.
        private PrintStatementASTNode CreatePrintStatementASTNode()
        {
            // Inits
            ExprASTNode retASTNode = null;
            PrintStatementASTNode curASTNode = null;
            DynamicBranchTreeNode<CSTValue> parentCSTNode;

            // Set parent node to current
            parentCSTNode = curCSTNode;

            // Create print ast node
            curASTNode = new PrintStatementASTNode();

            // Get start token
            ((PrintStatementASTNode)curASTNode).StartToken = parentCSTNode.Data.Token;

            // Set current ast node to exprsion
            curCSTNode = parentCSTNode.GetChild(2);

            // Create expression
            retASTNode = CreateExprASTNode();

            // Set expr value
            curASTNode.Expr = retASTNode;

            // Adopt child
            curASTNode.AdoptChild(retASTNode);

            // Set static links
            curASTNode.Expr = retASTNode;

            // Reset current CST node
            curCSTNode = parentCSTNode;

            // Return created print statment
            return curASTNode;
        }

        // Create assignment ast node
        //
        // Returns: Created assignment AST node.
        private AssignmentStatementASTNode CreateAssignmentStatementASTNode()
        {
            // Inits
            IDASTNode retIDASTNode = null;
            ExprASTNode retExprASTNode = null;
            AssignmentStatementASTNode curASTNode = null;
            DynamicBranchTreeNode<CSTValue> parentCSTNode;
            Token startToken = null;

            // Set parent node to current
            parentCSTNode = curCSTNode;

            // Create assignment statment
            curASTNode = new AssignmentStatementASTNode();

            // Set current node to id expr
            curCSTNode = parentCSTNode.GetChild(0);

            // Get startt token
            startToken = curCSTNode.Data.Token;

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

            // Set static refs
            curASTNode.Id = retIDASTNode;
            curASTNode.Expr = retExprASTNode;
            curASTNode.StartToken = startToken;

            // Reset current CST node
            curCSTNode = parentCSTNode;

            // Return created assignment statment ast node
            return curASTNode;
        }

        // Create var dec ast node
        //
        // Returns: Created  AST node.
        private VarDecStatementASTNode CreateVarDecStatementASTNode()
        {
            // Inits
            TypeASTNode retTypeASTNode = null;
            IDASTNode retIDASTNode = null;
            VAR_TYPE varType = VAR_TYPE.VARTYPE_INT;
            VarDecStatementASTNode curASTNode = null;
            DynamicBranchTreeNode<CSTValue> parentCSTNode;
            Token startToken = null;

            // Set parent node to current
            parentCSTNode = curCSTNode;

            // Create print statement ast node
            curASTNode = new VarDecStatementASTNode();

            // Get start token
            startToken = curCSTNode.GetChild(0).GetChild(0).Data.Token;

            // Get var type
            if (startToken.Type == Token.TokenType.TK_INT)
                varType = VAR_TYPE.VARTYPE_INT;
            else if (startToken.Type == Token.TokenType.TK_STRING)
                varType = VAR_TYPE.VARTYPE_STRING;
            else if (startToken.Type == Token.TokenType.TK_BOOLEAN)
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

            // Set static refs
            curASTNode.Type = retTypeASTNode;
            curASTNode.Id = retIDASTNode;
            curASTNode.StartToken = startToken;

            // Reset current CST node
            curCSTNode = parentCSTNode;

            // Return created var dec statement
            return curASTNode;
        }

        // Create while statement ast node
        //
        // Returns: Created  AST node.
        private WhileStatementASTNode CreateWhileStatementASTNode()
        {
            // Inits
            ExprASTNode retExprASTNode = null;
            BlockASTNode retBlockASTNode = null;
            WhileStatementASTNode curASTNode = null;
            DynamicBranchTreeNode<CSTValue> parentCSTNode;

            // Set parent node to current
            parentCSTNode = curCSTNode;

            // Create while statement ast node
            curASTNode = new WhileStatementASTNode();

            // Set current node to expr
            curCSTNode = parentCSTNode.GetChild(1);

            // Create expr
            retExprASTNode = CreateBooleanExprASTNode(); 

            // Set current node to block
            curCSTNode = parentCSTNode.GetChild(2);

            // Create block
            retBlockASTNode = CreateBlockASTNode(false);

            // Make syblings
            retExprASTNode.MakeSybling(retBlockASTNode);

            // Adopt family
            curASTNode.AdoptChild(retExprASTNode);

            // Set static refs
            curASTNode.Expr = retExprASTNode;
            curASTNode.Block = retBlockASTNode;

            // Reset current CST node
            curCSTNode = parentCSTNode;

            // Return created while statment node
            return curASTNode;
        }

        // Create if statment ast node
        //
        // Returns: Created  AST node.
        private IfStatementASTNode CreateIfStatementASTNode()
        {  // Inits
            ExprASTNode retExprASTNode = null;
            BlockASTNode retBlockASTNode = null;
            IfStatementASTNode curASTNode = null;
            DynamicBranchTreeNode<CSTValue> parentCSTNode;

            // Set parent node to current
            parentCSTNode = curCSTNode;

            // Create while statement ast node
            curASTNode = new IfStatementASTNode();

            // Set current node to expr
            curCSTNode = parentCSTNode.GetChild(1);

            // Create expr
            retExprASTNode = CreateBooleanExprASTNode();

            // Set current node to block
            curCSTNode = parentCSTNode.GetChild(2);

            // Create block
            retBlockASTNode = CreateBlockASTNode(false);

            // Make syblings
            retExprASTNode.MakeSybling(retBlockASTNode);

            // Adopt family
            curASTNode.AdoptChild(retExprASTNode);

            // Set static refs
            curASTNode.Expr = retExprASTNode;
            curASTNode.Block = retBlockASTNode;

            // Reset current CST node
            curCSTNode = parentCSTNode;

            // Return created if statment node
            return curASTNode;
        }

        // Create expression ast node
        //
        // Returns: Created  AST node.
        private ExprASTNode CreateExprASTNode()
        {
            // Inits
            ExprASTNode retASTNode = null;
            DynamicBranchTreeNode<CSTValue> parentCSTNode;

            // Set parent node to current
            parentCSTNode = curCSTNode;

            // Get child node
            curCSTNode = curCSTNode.GetChild(0);

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
            else if (curCSTNode.Data.Token.Type == Token.TokenType.TK_ID)
            {
                // Create while statement
                retASTNode = CreateIDExprASTNode();
            }

            // Reset current CST node
            curCSTNode = parentCSTNode;

            // Return created statement
            return retASTNode;
        }

        // Create int expr ast node
        //
        // Returns: Created  AST node.
        private IntExprASTNode CreateIntExprASTNode()
        {
            // Inits
            IntValASTNode retIntValASTNode = null;
            IntOpASTNode retIntOpASTNode = null;
            ExprASTNode retExprASTNode = null;
            IntExprASTNode curASTNode = null;
            DynamicBranchTreeNode<CSTValue> parentCSTNode;
            Token startToken = null;

            // Set parent node to current
            parentCSTNode = curCSTNode;

            // Check if type one (digit intop digit)
            if( parentCSTNode.NodeCount == 3 )
            {
                // Create int op ast node ( node at this time their is only one value
                if (parentCSTNode.GetChild(1).GetChild(0).Data.Token.Type == Token.TokenType.TK_OP_ADD)
                    curASTNode = new IntOpASTNode(INTOP_TYPE.INTOP_ADD);
               
                // Get start token
                startToken = parentCSTNode.GetChild(0).Data.Token;
               
                // Create int val ast node and get digit
                retIntValASTNode = new IntValASTNode(Int32.Parse(startToken.Value.ToString()));

                // Set start token
                retIntValASTNode.StartToken = startToken;

                // Set current node to expression
                curCSTNode = parentCSTNode.GetChild(2);

                // Create expression ast node
                retExprASTNode = CreateExprASTNode();

                // Make sybling
                retIntValASTNode.MakeSybling(retExprASTNode);

                // Set static refs
                ((IntOpASTNode)curASTNode).IntVal = retIntValASTNode;
                ((IntOpASTNode)curASTNode).Expr = retExprASTNode;
                ((IntOpASTNode)curASTNode).StartToken = startToken;
            }
            // Else type two (digit)
            else
            {
                // Get start token
                startToken = parentCSTNode.GetChild(0).Data.Token;
                // Create new int expr ast node
                curASTNode = new IntValASTNode(Int32.Parse(startToken.Value.ToString()));

                ((IntValASTNode)curASTNode).StartToken = startToken;
            }

            // Adopt family
            if( parentCSTNode.NodeCount == 3 )
                curASTNode.AdoptChild(retIntValASTNode);

            // Reset current CST node
            curCSTNode = parentCSTNode;

            // Return created int expr ast node
            return curASTNode;
        }

        // Create string ast node
        //
        // Returns: Created  AST node.
        private StringExprASTNode CreateStringExprASTNode()
        {
            // Inits
            StringBuilder sb = new StringBuilder(20);
            StringExprASTNode curASTNode = null;
            DynamicBranchTreeNode<CSTValue> charListCSTNode = null;
            DynamicBranchTreeNode<CSTValue> parentCSTNode;

            // Set parent node to current
            parentCSTNode = curCSTNode;

            // Create new string expr ast node
            curASTNode = new StringExprASTNode();

            // Get first charlist CST node
            charListCSTNode = parentCSTNode;

            // Set current node to first child, either char or lamda
            curCSTNode = charListCSTNode.GetChild(0);

            // Loop through char nodes adding to string value
            while (curCSTNode.Data.Grammar != GrammarProcess.GP_LAMDA)
            {
                // Add char value to string
                sb.Append(curCSTNode.Data.Token.Value);

                // Get next charlist
                charListCSTNode = charListCSTNode.GetChild(1);

                // Get next char node
                curCSTNode = charListCSTNode.GetChild(0);
            }

            // Set string value to ast node
            curASTNode.Value = sb.ToString();

            // Reset current CST node
            curCSTNode = parentCSTNode;

            // Return created string expr ast node
            return curASTNode;
        }

        // Create boolean expr ast node
        //
        // Returns: Created  AST node.
        private BooleanExprASTNode CreateBooleanExprASTNode()
        {
            // Inits
            ExprASTNode retExprASTNode1 = null;
            BoolOpASTNode retBoolOpASTNode = null;
            ExprASTNode retExprASTNode2 = null;
            BoolValASTNode retBoolValASTNode = null;
            BooleanExprASTNode curASTNode = null;
            DynamicBranchTreeNode<CSTValue> parentCSTNode;
            Token startToken = null;

            // Set parent node to current
            parentCSTNode = curCSTNode;

         
                // Check if boolean expr type one : ( EXPR BOoLOP EXPR )
                if (parentCSTNode.NodeCount != 1 && parentCSTNode.GetChild(0).Data.Token.Type == Token.TokenType.TK_LPARAM)
                {

                    // Get start token
                    startToken = parentCSTNode.GetChild(2).GetChild(0).Data.Token;

                    // Determine bool op and create ast node
                    if (startToken.Type == Token.TokenType.TK_BOOL_OP_EQUALS)
                        curASTNode = new BoolOpASTNode(BOOLOP_TYPE.BOOLOP_EQUALS);
                    else
                        curASTNode = new BoolOpASTNode(BOOLOP_TYPE.BOOLOP_NOT_EQUALS);


                    // Set current node to expr
                    curCSTNode = parentCSTNode.GetChild(1);

                    // Create expr 1 ast node
                    retExprASTNode1 = CreateExprASTNode();



                    // Set current node to expr
                    curCSTNode = parentCSTNode.GetChild(3);

                    // Create expr 2 ast node
                    retExprASTNode2 = CreateExprASTNode();

                    // Make syblings
                    retExprASTNode1.MakeSybling(retExprASTNode2);

                    // Adopt family
                    curASTNode.AdoptChild(retExprASTNode1);

                    // Set static refs
                    ((BoolOpASTNode)curASTNode).ExprOne = retExprASTNode1;
                    ((BoolOpASTNode)curASTNode).ExprTwo = retExprASTNode2;
                    ((BoolOpASTNode)curASTNode).StartToken = startToken;
                }
                // Else boolean expr type : BOOLVAL
                else
                {
                    // Get start token
                    startToken = parentCSTNode.GetChild(0).GetChild(0).Data.Token;
                    // Create bool val ast node
                    if (startToken.Type == Token.TokenType.TK_BOOL_TRUE)
                        curASTNode = new BoolValASTNode(BOOLVAL_TYPE.BOOLVAL_TRUE);
                    else
                        curASTNode = new BoolValASTNode(BOOLVAL_TYPE.BOOLVAL_FALSE);

                    // Set static refs
                    ((BoolValASTNode)curASTNode).StartToken = startToken;
                }
            

            // Reset current CST node
            curCSTNode = parentCSTNode;

            // Return created boolean expr ast node
            return curASTNode;
        }

        // Create id ast node
        //
        // Returns: Created  AST node.
        private IDASTNode CreateIDExprASTNode()
        {
            // Inits
            IDASTNode curASTNode = null;

            // Create new ID ast node with char value
            curASTNode = new IDASTNode(curCSTNode.Data.Token.Value);

            // Set static refs
            curASTNode.Value = curCSTNode.Data.Token.Value;

            // Return created id ast node
            return curASTNode;
        }

        #endregion

        #region Helper Methods

        //Sends message event
        private void SendMessage(String msg)
        {
            if (SymanticAnalyzerMessageEvent != null)
                SymanticAnalyzerMessageEvent(msg);
        }

        // Send warning event
        private void SendWarning(Message msg)
        {
            if (SymanticAnalyzerWarningEvent != null)
                SymanticAnalyzerWarningEvent(msg);

            WarningCount++;
        }

        // Send error event
        private void SendError(Message msg)
        {
            if (SymanticAnalyzerErrorEvent != null)
                SymanticAnalyzerErrorEvent(msg);

            ErrorCount++;
        }

        // Converts data type enum to string
        //
        // Returns: String representing type
        public String GetTypeString(DataType dt)
        {
            String ret = null;

            switch (dt)
            {
                case DataType.DT_INT:
                    ret = "int";
                    break;

                case DataType.DT_STRING:
                    ret = "string";
                    break;

                case DataType.DT_BOOLEAN:
                    ret = "boolean";
                    break;

                default:
                    ret = "none";
                    break;
            }

            return ret;
        }

        // Converts var type enum to string
        //
        // Returns: String representing type
        public String GetTypeString(VAR_TYPE vt)
        {
            String ret = null;

            switch (vt)
            {
                case VAR_TYPE.VARTYPE_INT:
                    ret = "int";
                    break;

                case VAR_TYPE.VARTYPE_STRING:
                    ret = "string";
                    break;

                case VAR_TYPE.VARTYPE_BOOLEAN:
                    ret = "boolean";
                    break;
            }

            return ret;
        }

        // Converts expression type to string
        //
        // Returns: String representing expression type
        private String GetExpressionTypeString(ExprASTNode expr)
        {
            String ret = "none";

            if (expr is IntExprASTNode)
                ret = "int";
            else if (expr is BooleanExprASTNode)
                ret = "boolean";
            else if (expr is StringExprASTNode)
                ret = "string";
            else if (expr is IDASTNode)
                ret = "id";


            return ret;
        }
   

        #endregion
    }
}
