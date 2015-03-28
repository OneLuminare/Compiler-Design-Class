using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DynamicBranchTree;

namespace NFLanguageCompiler
{
    //Parser takes a token stream, and creates a CST.
    //Grammer is checked if valid. Symbol table is created
    //during this process.
    //
    // Errors: 
    // 1.) Invalid grammer.
    public class Parser
    {
        #region Data Members

        //Root node of CST
        private DynamicBranchTreeNode<CSTValue> CSTRoot;
        private DynamicBranchTreeNode<HashSet<SymbolTableEntry>> SymbolTableRoot;
        private DynamicBranchTreeNode<CSTValue> CurCSTNode;
        private DynamicBranchTreeNode<HashSet<SymbolTableEntry>> CurSymbolTableNode;

        //Token stream processed
        private TokenStream CurTokenStream;

        //Token index
        private int CurTokenIndex;

        //Current parse phase
        private GrammarProcess CurPhase;

        //Toggle show entire chain of errors, (or throw an exception on first)
        private bool showErrorChain;

        #endregion

        #region Properties

        //CST Public
        public DynamicBranchTreeNode<CSTValue> CSTRootNode
        {
            get
            {
                return CSTRoot;
            }
        }

        //Symbol Table Public
        public DynamicBranchTreeNode<HashSet<SymbolTableEntry>> SymbolTableRootNode
        {
            get
            {
                return SymbolTableRoot;
            }
        }

        //Warning count
        public int WarningCount
        {
            get;
            set;
        }

        //Error count
        public int ErrorCount
        {
            get;
            set;
        }

        //Toggle show entire warning chain
        public bool ShowErrorChain
        {
            get
            {
                return showErrorChain;
            }

            set
            {
                showErrorChain = value;
            }
        }

        #endregion

        #region Delegates and Events

        //Parser message event
        public event MessageEventHandler ParserMessageEvent;

        //Parser error event
        public event WarningErrorEventHandler ParserErrorEvent;

        //Parser warning event
        public event WarningErrorEventHandler ParserWarningEvent;

        #endregion

        #region Constructors

        //Default constructor. Initializes objects
        public Parser()
        {
            //Init data objects
            CSTRoot = new DynamicBranchTreeNode<CSTValue>(new CSTValue());
            SymbolTableRoot = new DynamicBranchTreeNode<HashSet<SymbolTableEntry>>(new HashSet<SymbolTableEntry>());
            CurCSTNode = CSTRoot;
            CurSymbolTableNode = SymbolTableRoot;
            CurTokenStream = null;
            WarningCount = 0;
            ErrorCount = 0;
            CurTokenIndex = 0;
            CurPhase = GrammarProcess.GP_NONE;
            showErrorChain = false;
        }

        #endregion

        #region Parsing Methods

        public ProcessReturnValue Parse(TokenStream tokenStream)
        {
            //Inits
            ProcessReturnValue ret = ProcessReturnValue.PRV_NONE;

            //Clear CST tree, warning count, and error count
            CSTRoot.Clear();
            SymbolTableRoot.Clear();
            WarningCount = 0;
            ErrorCount = 0;
            CurTokenIndex = 0;
            

            //Reset current node
            CurCSTNode = CSTRoot;

            //Reset cuurent symbol table node
            CurSymbolTableNode = SymbolTableRoot;

            //Set working token stream
            CurTokenStream = tokenStream;

            //Send exception if token stream is null
            if( tokenStream == null )
                throw new NullReferenceException("Token Stream object is null.");

            //Return if no tokens
            if (tokenStream.Count == 0)
                return ProcessReturnValue.PRV_NONE;

            //Start recursize parse functions
            try
            {
                ParseProgram();
            }

            //Catch IndexOutOfBounds
            catch (IndexOutOfRangeException ex)
            {
                //Send error of out of tokens
                SendError("Unexpected end of token stream.", CurPhase, null, tokenStream.Count);
            }

            //Catch parse exception
            catch ( ParseException ex)
            {
                SendMessage("Parse terminated due to error.");
                SendError(ex.Message,CurPhase,GetCurToken(),CurTokenIndex);
            }

            //Determin return value
            if (ErrorCount > 0)
                ret = ProcessReturnValue.PRV_ERRORS;
            else if (WarningCount > 0)
                ret = ProcessReturnValue.PRV_WARNINGS;
            else
                ret = ProcessReturnValue.PRV_OK;

            //Return code
            return ret;
        }

        //Returns current token to be processed. Keeps index internaly.
        //
        //Throws: IndexOutOfRangeException
        private Token GetCurToken()
        {
            //Throw exception if index out of range
            if (CurTokenIndex >= CurTokenStream.Count)
                throw new IndexOutOfRangeException("Token index out of range in token stream.");

            //Return current token
            return CurTokenStream.GetToken(CurTokenIndex);
        }

         //Returns previous token then current. Keeps index internaly.
        //
        //Throws: IndexOutOfRangeException
        private Token GetLastToken()
        {
            //Throw exception if index out of range
            if ((CurTokenIndex - 1) >= CurTokenStream.Count ||
                (CurTokenIndex - 1) < 0 )
                throw new IndexOutOfRangeException("Token index out of range in token stream.");

            //Return current token
            return CurTokenStream.GetToken(CurTokenIndex - 1);
        }

        //Checks next token for excepted token.
        //
        //Throws: IndexOutOfRangeException
        private bool PeekToken(Token.TokenType tokenType)
        {
            //Inits
            bool ret = false;

            //Try block for index out of bound exception
            try
            {
                //Send message
                SendMessage(String.Format("Peeking for {0}...", tokenType.ToString()));

                //Peek token type
                if (CurTokenStream.GetToken(CurTokenIndex ).Type == tokenType)
                {
                    //Send message
                    SendMessage(String.Format("Found {0}.", tokenType.ToString()));

                    //Set return true
                    ret = true;
                }
                //On no peek set return false
                else
                {
                    //Send message
                    SendMessage(String.Format("Peeking for {0} failed, found {1}.", tokenType.ToString()
                        , CurTokenStream.GetToken(CurTokenIndex ).Type.ToString()));

                    ret = false;
                }
            }

            //Catch index out of bounds exception
            catch (IndexOutOfRangeException ex)
            {
                //Rethrow exception
                throw ex;
            }

            //Return results
            return ret;
        }

        //Matches expected token. 
        //
        // Returns: True on type match.
        // Throws: IndexOutOfBoundsException
        private bool MatchToken(Token.TokenType tokenType)
        {
            //Inits
            bool ret = false;

            //Try block for index out of bound exception
            try
            {
                //Send message
                SendMessage(String.Format("Expecting {0}, matching...", tokenType.ToString()));

                //Match token type
                if (GetCurToken().Type == tokenType)
                {
                    //Send message
                    SendMessage(String.Format("Found {0}.", GetCurToken().Type.ToString()));

                    //Incrmeent cur token 
                    CurTokenIndex++;

                    //Set return true
                    ret = true;
                }
                //On no match set return false
                else
                {
                    //Send message
                    SendMessage(String.Format("Error: Match expected {0}, but found {1}.", tokenType.ToString()
                        , GetCurToken().Type.ToString()));

                    //Send error
                    if( showErrorChain )
                        SendError(String.Format("Match expected {0}, but found {1}.", tokenType.ToString()
                            , GetCurToken().Type.ToString()), CurPhase, GetCurToken(), CurTokenIndex);

                    ret = false;
                }
            }

            //Catch index out of bounds exception
            catch (IndexOutOfRangeException ex)
            {
                //Rethrow exception
                throw ex;
            }

            //Return results
            return ret;
        }

        //Parse program grammar
        //:= Block $
        private void ParseProgram()
        {
            //Inits
            DynamicBranchTreeNode<CSTValue> parentNode = CurCSTNode;

            //Send message
            SendMessage("Parsing PROGRAM....");

            //Set current phase
            CurPhase = GrammarProcess.GP_PROGRAM;

            //Set root node value
            parentNode.Data = new CSTValue(GrammarProcess.GP_PROGRAM);

            //Create child node
            CurCSTNode = new DynamicBranchTreeNode<CSTValue>();
            parentNode.AddChild(CurCSTNode);

            //Call parse block
            if (!ParseBlock(true))
                return;

            //Match EOF
            if (MatchToken(Token.TokenType.TK_EOF))
            {
                //Create child node
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>(new CSTValue(GrammarProcess.GP_NONE
                    , CurTokenStream.GetToken(CurTokenIndex - 1)));
                parentNode.AddChild(CurCSTNode);

                SendMessage("Successfully parsed PROGRAM.");
            }
            //Else send uncessfull parse
            else
            {
                //Send error msg
                SendMessage("Error: Parse PROGRAM failed.");

                //Send error
                SendError("Parse Program failed.", CurPhase, GetCurToken(), CurTokenIndex);
            }
        }

        //Parses BLOCK grammar
        //:= { STATEMENTLIST }
        //
        // Params: bool noNewSymbolTableNode : If true does not create a new symbol table node.
        // Notes: This param used to be first block, I most of my code I creae new nodes before
        //        calling a parse function. 
        // Throws: new ParseException
        private bool ParseBlock(bool noNewSymbolTableNode)
        {
            //Inits
            DynamicBranchTreeNode<CSTValue> parentNode = CurCSTNode;
            DynamicBranchTreeNode<HashSet<SymbolTableEntry>> parentSymTblEntry = CurSymbolTableNode;
            GrammarProcess parentPhase = CurPhase;
            bool ret = false;


            //Set current phase
            CurPhase = GrammarProcess.GP_BLOCK;

            //Create current node and set value
            CurCSTNode.Data = new CSTValue(GrammarProcess.GP_BLOCK);

            //Send message
            SendMessage("Parsing BLOCK...");

            //If noNewSymbolTablleNode create a new child node for symbol table
            if (!noNewSymbolTableNode)
            {
                //Create new child node for symbol table
                CurSymbolTableNode = new DynamicBranchTreeNode<HashSet<SymbolTableEntry>>(new HashSet<SymbolTableEntry>());

                //Add child node to symbol table
                parentSymTblEntry.AddChild(CurSymbolTableNode);
            }

            //Match { token and check
            if (MatchToken(Token.TokenType.TK_LBRACE))
            {
                //Create child node for TK_LBRACE
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>(new CSTValue(GrammarProcess.GP_NONE
                    , CurTokenStream.GetToken(CurTokenIndex - 1)));
                parentNode.AddChild(CurCSTNode);

                //Set ret
                ret = true;

            }
            //Else if dont show error chain
            else if (!showErrorChain)
                throw new ParseException("Parse BLOCK failed, expecting '{'. Block is := { STATEMENTLIST }." );
            
   

            //Check ret and parse statemenetlist
            if( ret )
            {
                //Create child node for STATEMENTLIST
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>();
                parentNode.AddChild(CurCSTNode);

                //Parse statementlist
                ret = ParseStatementList();
            }

            //Match } token and check
            if (ret && MatchToken(Token.TokenType.TK_RBRACE))
            {
                //Create child node for TK_BRACE
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>(new CSTValue(GrammarProcess.GP_NONE
                    , CurTokenStream.GetToken(CurTokenIndex - 1)));
                parentNode.AddChild(CurCSTNode);

                //Set ret
                ret = true;
            }
            //Else if dont show error chain
            else if (!showErrorChain)
                throw new ParseException("Parse BLOCK failed, expecting '}'. Block is := { STATEMENTLIST }.");

            // Reset Symbol Table parent
            CurSymbolTableNode = parentSymTblEntry;

            //Send appropriate message
            if (ret)
                SendMessage("Successfully parsed BLOCK.");
            else
            {
                //Send error msg
                SendMessage("Error: Parse BLOCK failed. Block is := { STATEMENTLIST }.");

                //Send error
                SendError("Parse BLOCK failed. Block is := { STATEMENTLIST }.", CurPhase, GetCurToken(), CurTokenIndex); ;

            }

            //Reset current phase
            CurPhase = parentPhase;

            return ret;
        }

        //Parses STATMENTLIST grammar
        //:= STATEMENT STATEMENTLIST
        private bool ParseStatementList()
        {
            //Inits
            DynamicBranchTreeNode<CSTValue> parentNode = CurCSTNode;
            GrammarProcess parentPhase = CurPhase;
            bool ret = false;

            //Set current phase
            CurPhase = GrammarProcess.GP_STATEMENTLIST;

            //Create current node and set value
            CurCSTNode.Data = new CSTValue(GrammarProcess.GP_STATEMENTLIST);

            //Send message
            SendMessage("Parsing STATEMENTLIST...");

            //Peek for STATEMENT
            if (PeekStatement())
            {
                //Create child node for STATEMENT
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>();
                parentNode.AddChild(CurCSTNode);

                //Parse STATEMENT
                ret = ParseStatement();

                //Check ret
                if( ret )
                {
                    //Create child node for parse STATEMENTLIST
                    CurCSTNode = new DynamicBranchTreeNode<CSTValue>();
                    parentNode.AddChild(CurCSTNode);

                    //Parse statementlist
                    ret = ParseStatementList();
                }
            }
            //Else message fail peek
            else
            {
                //Create child node for LAMDA
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>(new CSTValue(GrammarProcess.GP_LAMDA));
                parentNode.AddChild(CurCSTNode);

                //Set cur node value to LAMDA
                //CurCSTNode.Data.Grammar = GrammarProcess.GP_LAMDA;

                //Send message
                SendMessage("STATEMENTLIST is LAMDA.");

                //Set ret
                ret = true;
            }

            //Send message appropriate to succes or failure
            if (ret)
                SendMessage("Successfully parsed STATEMENTLIST.");
            else
            {
                //Send mesage
                SendMessage("Error: Parse STATEMENTLIST failed.");

                //Send error 
                SendError("Parse STATEMENTLIST failed. Expecting := STATEMENT STATEMENTLIST | LAMDA", CurPhase, GetCurToken(), CurTokenIndex);
            }

            //Set parent phase
            CurPhase = parentPhase;

            return true;
        }
        
        //Parse STATEMENT grammar
        //:=    PRINTSTATEMENT | ASSIGNMENTSTATEMENT | VARDEC | WHILESTATEMENT | IFSTATEMENT | BLOCK
        //
        // THROWS: new ParseException
        private bool ParseStatement()
        {
            //Inits
            DynamicBranchTreeNode<CSTValue> parentNode = CurCSTNode;
            GrammarProcess parentPhase = CurPhase;
            bool ret = false;

            //Set current phase
            CurPhase = GrammarProcess.GP_STATEMENT;

            //Create current node and set value
            CurCSTNode.Data = new CSTValue(CurPhase);

            //Send message
            SendMessage("Parsing STATEMENT...");

            //Peek for PRINTSTATEMENT
            if (PeekPrintStatement())
            {
                //Create child node
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>();
                parentNode.AddChild(CurCSTNode);

                //Parse print statement
                ret = ParsePrintStatement();
            }

            //Peek for ASSIGNMENTSTATEMENT
            else if (PeekAssignmentStatement())
            {
                //Create child node
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>();
                parentNode.AddChild(CurCSTNode);

                //Parse assignment statement
                ret = ParseAssignmentStatement();
            }

            //Peek for VARDEC
            else if (PeekVarDec())
            {
                //Create child node
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>();
                parentNode.AddChild(CurCSTNode);

                //Parse var dec
                ret = ParseVarDec();
            }

            //Peek for WHILESTATEMENT
            else if (PeekWhileStatement())
            {
                //Create child node
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>();
                parentNode.AddChild(CurCSTNode);

                //Parse WHILE statement
                ret = ParseWhileStatement();
            }

            //Peek for IFSTATEMENT
            else if (PeekIfStatement())
            {
                //Create child node
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>();
                parentNode.AddChild(CurCSTNode);

                //Parse IF statement
                ret = ParseIfStatement();
            }

            //Peek for BLOCK
            else if (PeekBlock())
            {
                //Create child node
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>();
                parentNode.AddChild(CurCSTNode);

                //Parse BLOCK statement
                ret = ParseBlock(false);
            }

            //Send message appropriate to succes or failure
            if (ret)
                SendMessage("Successfully parsed STATEMENT.");
            else
            {
                //Send error msg
                SendMessage("Error: Parse STATEMENT failed.");

                //Verify show all errors
                if (!showErrorChain)
                    //Send exception
                    throw new ParseException("Parse STATEMENT failed. STATEMENT is := PRINTSTATEMENT | ASSIGNMENTSTATEMENT | VARDEC | WHILESTATEMENT | IFSTATEMENT | BLOCK");
                else
                    //Send error 
                    SendError("Parse STATEMENT failed. STATEMENT is := PRINTSTATEMENT | ASSIGNMENTSTATEMENT | VARDEC | WHILESTATEMENT | IFSTATEMENT | BLOCK", CurPhase, GetCurToken(), CurTokenIndex);
            }

            //Set parent phase
            CurPhase = parentPhase;

            return ret;
        }

        //Parses PRINTSTATMENT
        //:= print ( EXPR )
        //
        // Throws: new ParseException
        private bool ParsePrintStatement()
        {
            //Inits
            DynamicBranchTreeNode<CSTValue> parentNode = CurCSTNode;
            GrammarProcess parentPhase = CurPhase;
            bool ret = false;

            //Set current phase
            CurPhase = GrammarProcess.GP_PRINTSTATEMENT;

            //Create current node and set value
            CurCSTNode.Data = new CSTValue(CurPhase);

            //Send message
            SendMessage("Parsing PRINTSTATEMENT...");

            //Match TK_PRINT
            if (MatchToken(Token.TokenType.TK_PRINT))
            {
                //Creat childe for TK_PRINT
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>(new CSTValue(GrammarProcess.GP_NONE, GetLastToken()));
                parentNode.AddChild(CurCSTNode);

                //Set ret
                ret = true;
            }
            //Else if dont show error chain
            else if (!showErrorChain)
                throw new ParseException("Parse PRINTSTATEMENT failed, expecting \"print\". PRINTSTATMENT is := print ( exp ).");

            //Match TK_LPARAM
            if (ret && MatchToken(Token.TokenType.TK_LPARAM))
            {
                //Create child for TK_LPARAM
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>(new CSTValue(GrammarProcess.GP_NONE, GetLastToken()));
                parentNode.AddChild(CurCSTNode);
                ret = true;
            }
            //Else if dont show error chain
            else if (!showErrorChain)
                throw new ParseException("Parse PRINTSTATEMENT failed, expecting '('. PRINTSTATMENT is := print ( exp ).");

            //Parse EXPRESSION
            if (ret)
            {
                //Create child for EXPR
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>();
                parentNode.AddChild(CurCSTNode);

                //Parse expr
                ret = ParseExpr();
            }

            //Match TK_RPARAM
            if (ret && MatchToken(Token.TokenType.TK_RPARAM))
            {
                //Create child of TK_RPARM
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>(new CSTValue(GrammarProcess.GP_NONE, GetLastToken()));
                parentNode.AddChild(CurCSTNode);

                //Set ret
                ret = true;
            }
            //Else if dont show error chain
            else if (!showErrorChain)
                throw new ParseException("Parse PRINTSTATEMENT failed, expecting ')'. PRINTSTATMENT is := print ( exp ).");

            //Send message appropriate to succes or failure
            if (ret)
                SendMessage("Successfully parsed PRINTSTATEMENT.");
            else
            {
                //Send error msg
                SendMessage("Error: Parse PRINTSTATEMENT failed. PRINTSTATMENT is := print ( exp ).");

                //Send error 
                SendError("Parse PRINTSTATEMENT failed. PRINTSTATMENT is := print ( exp ).", CurPhase, GetCurToken(), CurTokenIndex);
            }

            //Set parent phase
            CurPhase = parentPhase;

            return ret;
        }

        //Parse EXPR
        //:= INTEXPR | STRINGEXPR | BOOLEANEXPR | ID.
        //
        //Throws: new ParseException
        private bool ParseExpr()
        {
            //Inits
            DynamicBranchTreeNode<CSTValue> parentNode = CurCSTNode;
            GrammarProcess parentPhase = CurPhase;
            bool ret = false;

            //Set current phase
            CurPhase = GrammarProcess.GP_EXPR;

            //Create current node and set value
            CurCSTNode.Data = new CSTValue(CurPhase);

            //Send message
            SendMessage("Parsing EXPR...");

            //Peek for INTEXPR
            if (PeekIntExpr())
            {
                //Create child node for INTEXPR
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>();
                parentNode.AddChild(CurCSTNode);

                //Parse int expr
                ret = ParseIntExpr();
            }

            //Peek for STRINGEXPR
            else if (PeekStringExpr())
            {
                //Create child node for STRINGEXPR
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>();
                parentNode.AddChild(CurCSTNode);

                //Parse string expr
                ret = ParseStringExpr();
            }

            //Peek for BOOLEXPR
            else if (PeekBoolExpr())
            {
                //Create child node for BOOLEANEXPR
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>();
                parentNode.AddChild(CurCSTNode);

                //Parse bool expr
                ret = ParseBooleanExpr();
            }

            //Else must be ID
            else 
            {
                //Match TK_ID
                if (MatchToken(Token.TokenType.TK_ID))
                {
                    //Create child node for TK_ID
                    CurCSTNode = new DynamicBranchTreeNode<CSTValue>(new CSTValue(GrammarProcess.GP_NONE, GetLastToken()));
                    parentNode.AddChild(CurCSTNode);

                    //Set ret 
                    ret = true;
                }
                //Else if dont show error chain
                else if (!showErrorChain)
                    throw new ParseException("Parse EXPR failed, expecting ID. EXPR := INTEXPR | STRINGEXPR | BOOLEANEXPR | ID.");
            }

            //Send message appropriate to succes or failure
            if (ret)
                SendMessage("Successfully parsed EXPR.");
            else
            {
                //Send error msg
                SendMessage("Error: Parse EXPR failed. EXPR := INTEXPR | STRINGEXPR | BOOLEANEXPR | ID.");

                //Send error 
                SendError("Parse EXPR failed. EXPR := INTEXPR | STRINGEXPR | BOOLEANEXPR | ID.", CurPhase, GetCurToken(), CurTokenIndex);
            }

            //Set parent phase
            CurPhase = parentPhase;

            return ret;
        }

        //Parse INTEXPR
        //:= digit INTOP EXPR | digit
        //
        //Throws: new ParseException
        private bool ParseIntExpr()
        {
            //Inits
            DynamicBranchTreeNode<CSTValue> parentNode = CurCSTNode;
            GrammarProcess parentPhase = CurPhase;
            bool ret = false;

            //Set current phase
            CurPhase = GrammarProcess.GP_INTEXPR;

            //Create current node and set value
            CurCSTNode.Data = new CSTValue(CurPhase);

            //Send message
            SendMessage("Parsing INTEXPR...");

            //Match digit
            if (MatchToken(Token.TokenType.TK_INT_LITERAL))
            {
                //Create child node for TK_INT_LITERAL
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>(new CSTValue(GrammarProcess.GP_NONE, GetLastToken()));
                parentNode.AddChild(CurCSTNode);

                //Set ret
                ret = true;
            }
            //Else if dont show error chain
            else if (!showErrorChain)
                throw new ParseException("Parse INTEXPR failed, expecting digit. INTEXPR := digit INTOP EXPR | digit .");

            // Peek intop
            if (ret && PeekIntOp())
            {

                //Create child node for INTOP
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>();
                parentNode.AddChild(CurCSTNode);

                ret = ParseIntOp();

                //Verify ret
                if (ret)
                {

                    //Create child node for EXPR
                    CurCSTNode = new DynamicBranchTreeNode<CSTValue>();
                    parentNode.AddChild(CurCSTNode);

                    //Parse expr
                    ret = ParseExpr();
                }
            }

            //Send message appropriate to succes or failure
            if (ret)
                SendMessage("Successfully parsed INTEXPR.");
            else
            {
                //Send error msg
                SendMessage("Error: Parse INTEXPR failed. INTEXPR := digit INTOP EXPR | digit .");

                //Send error 
                SendError("Parse INTEXPR failed. INTEXPR := digit INTOP EXPR | digit .", CurPhase, GetCurToken(), CurTokenIndex);
            }

            //Set parent phase
            CurPhase = parentPhase;

            return ret;
        }

        //Parse STRINGEXPR
        //:= \" charlist \" 
        //
        //Throws: new ParseException
        private bool ParseStringExpr()
        {
            //Inits
            DynamicBranchTreeNode<CSTValue> parentNode = CurCSTNode;
            GrammarProcess parentPhase = CurPhase;
            bool ret = false;

            //Set current phase
            CurPhase = GrammarProcess.GP_STRINGEXPR;

            //Create current node and set value
            CurCSTNode.Data = new CSTValue(CurPhase);

            //Send message
            SendMessage("Parsing STRINGEXPR...");

            //Match quote
            if (MatchToken(Token.TokenType.TK_QUOTE))
            {
                //Add child for TK_QUOTE
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>(new CSTValue(GrammarProcess.GP_NONE, GetLastToken()));
                parentNode.AddChild(CurCSTNode);

                //Set parent
                ret = true;
            }
            //Else if dont show error chain
            else if (!showErrorChain)
                throw new ParseException("Parse STRINGEXPR failed, expecting '\"'. STRINGEXPR := \" charlist \" .");

            //Check ret
            if( ret )
            {
                //Add child node for CHARLIST
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>();
                parentNode.AddChild(CurCSTNode);

                //Parse char list
                ret = ParseCharList();
            }

            //Match quote
            if (ret && MatchToken(Token.TokenType.TK_QUOTE))
            {
                //Add child for TK_QUOTE
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>(new CSTValue(GrammarProcess.GP_NONE, GetLastToken()));
                parentNode.AddChild(CurCSTNode);

                //Set parent
                ret = true;
            }
            //Else if dont show error chain
            else if (!showErrorChain)
                throw new ParseException("Parse STRINGEXPR failed, expecting '\"'. STRINGEXPR := \" charlist \" .");

            //Send message appropriate to succes or failure
            if (ret)
                SendMessage("Successfully parsed STRINGEXPR.");
            else
            {
                //Send error msg
                SendMessage("Error: Parse STRINGEXPR failed. STRINGEXPR := \" charlist \" .");

                //Send error 
                SendError("Parse STRINGEXPR failed. STRINGEXPR := \" charlist \" .", CurPhase, GetCurToken(), CurTokenIndex);
            }

            //Set parent phase
            CurPhase = parentPhase;

            return ret;
        }

        //Parse CHARLIST
        //:= char CHARLIST | LAMDA
        //
        //Throws: new ParseException
        private bool ParseCharList()
        {
            //Inits
            DynamicBranchTreeNode<CSTValue> parentNode = CurCSTNode;
            GrammarProcess parentPhase = CurPhase;
            bool ret = false;

            //Set current phase
            CurPhase = GrammarProcess.GP_CHARLIST;

            //Create current node and set value
            CurCSTNode.Data = new CSTValue(CurPhase);

            //Send message
            SendMessage("Parsing CHARLIST...");

            //Peek char
            if( PeekToken(Token.TokenType.TK_CHAR_LITERAL) )
            {
                //Match char
                MatchToken(Token.TokenType.TK_CHAR_LITERAL);

                //Create child for TK_CHAR_LIT
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>(new CSTValue(GrammarProcess.GP_NONE,GetLastToken()));
                parentNode.AddChild(CurCSTNode);

                //Create child for CHARLIST
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>();
                parentNode.AddChild(CurCSTNode);

                //ParseCharList
                ret = ParseCharList();
            }

            //Peek space
            else if( PeekToken(Token.TokenType.TK_SPACE) )
            {
                //Match char for TK_SPACE
                MatchToken(Token.TokenType.TK_SPACE);

                //Create child for TK_SPACE
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>(new CSTValue(GrammarProcess.GP_NONE,GetLastToken()));
                parentNode.AddChild(CurCSTNode);

                //Create child for CHARLIST
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>();
                parentNode.AddChild(CurCSTNode);

                //ParseCharList
                ret = ParseCharList();
            }

            //Else lamda
            else
            {
                //Add child for Lamda
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>(new CSTValue(GrammarProcess.GP_LAMDA));
                parentNode.AddChild(CurCSTNode);

                ret = true;
            }

            //Send message appropriate to succes or failure
            if (ret)
                SendMessage("Successfully parsed CHARLIST.");
            else
            {
                //Send error msg
                SendMessage("Error: Parse CHARLIST failed. CHARLIST := char CHARLIST | LAMDA");

                //Send error 
                SendError("Parse CHARLIST failed. CHARLIST := char CHARLIST | LAMDA", CurPhase, GetCurToken(), CurTokenIndex);
            }

            //Set parent phase
            CurPhase = parentPhase;

            return ret;
        }

        //Parse BOOLEANEXPR
        //:= ( EXPR BOOLOP EXPR ) | BOOLVAL
        //
        //Throws: new ParseException
        private bool ParseBooleanExpr()
        {
            //Inits
            DynamicBranchTreeNode<CSTValue> parentNode = CurCSTNode;
            GrammarProcess parentPhase = CurPhase;
            bool ret = false;

            //Set current phase
            CurPhase = GrammarProcess.GP_BOOLEANEXPR;

            //Create current node and set value
            CurCSTNode.Data = new CSTValue(CurPhase);

            //Send message
            SendMessage("Parsing BOOLEXPR...");

            //Peek LPARAM
            if( PeekToken(Token.TokenType.TK_LPARAM) )
            {
                //Math LPARAM (just peeked)
                MatchToken(Token.TokenType.TK_LPARAM);

                //Create child for lparam
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>(new CSTValue(GrammarProcess.GP_NONE,GetLastToken()));
                parentNode.AddChild(CurCSTNode);

                //Create child for expr
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>();
                parentNode.AddChild(CurCSTNode);

                //Parse expr
                ret = ParseExpr();

                //Verify ret
                if (ret)
                {
                    //Create child for bool op
                    CurCSTNode = new DynamicBranchTreeNode<CSTValue>();
                    parentNode.AddChild(CurCSTNode);

                    //Parse bool op
                    ret = ParseBoolOp();
                }


                //Verify ret
                if (ret)
                {
                    //Create child for expr
                    CurCSTNode = new DynamicBranchTreeNode<CSTValue>();
                    parentNode.AddChild(CurCSTNode);

                    // Parse expersion
                    ret = ParseExpr();
                }

                // Verify success
                if( ret )
                {
                    //Match RPARAM
                    if (MatchToken(Token.TokenType.TK_RPARAM))
                    {
                        //Create child for TK_RPARAM
                        CurCSTNode = new DynamicBranchTreeNode<CSTValue>(new CSTValue(GrammarProcess.GP_NONE, GetLastToken()));
                        parentNode.AddChild(CurCSTNode);

                        //Set ret true
                        ret = true;
                    }
                    //Else if dont show error chain
                    else if (!showErrorChain)
                        throw new ParseException("Parse BOOLEANEXPR failed, expecting ')'. BOOLEANEXPR := ( EXPR BOOLOP EXPR ) | BOOLVAL .");
                    //Else set ret
                    else
                        ret = false;
                }
            }

            //Else if peek for bool value
            else if (PeekBoolVal())
            {
                //Create child for parse bool value
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>(new CSTValue());
                parentNode.AddChild(CurCSTNode);

                //Set ret
                ret = ParseBoolVal();
            }
            //Else if dont show error chain
            else
            {
                if (!showErrorChain)
                    throw new ParseException("Parse BOOLEANEXPR failed. BOOLEANEXPR := ( EXPR BOOLOP EXPR ) | BOOLVAL .");
            }

            //Send message appropriate to succes or failure
            if (ret)
                SendMessage("Successfully parsed BOOLEXPR. BOOLEANEXPR := ( EXPR BOOLOP EXPR ) | BOOLVAL .");
            else
            {
                SendMessage("Errror: Parse BOOLEXPR failed. BOOLEANEXPR := ( EXPR BOOLOP EXPR ) | BOOLVAL .");

                //Send error
                SendError("Parse BOOLEXPR failed.", CurPhase, GetCurToken(), CurTokenIndex);
            }

            //Set parent phase
            CurPhase = parentPhase;

            return ret;
        }

        //Parse ASSIGNMENTSTATEMENT 
        //:= ID = EXPR .
        //
        //Throws: new ParseException
        private bool ParseAssignmentStatement()
        {
            //Inits
            DynamicBranchTreeNode<CSTValue> parentNode = CurCSTNode;
            GrammarProcess parentPhase = CurPhase;
            bool ret = false;

            //Set current phase
            CurPhase = GrammarProcess.GP_ASSIGNMENTSTATEMENT;

            //Create current node and set value
            CurCSTNode.Data = new CSTValue(CurPhase);

            //Send message
            SendMessage("Parsing ASSIGNMENTSTATEMENT..");

            //Match ID
            if( MatchToken(Token.TokenType.TK_ID) )
            {
                //Create child node for ID
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>(new CSTValue(GrammarProcess.GP_NONE,GetLastToken()));
                parentNode.AddChild(CurCSTNode);

                //Set ret
                ret = true;
            }
            //Else if dont show error chain
            else if (!showErrorChain)
                throw new ParseException("Parse ASSIGNMENTSTATEMENT failed, expecting ID. ASSIGNMENTSTATEMENT := ID = EXPR .");

            // Match = 
            if (ret && MatchToken(Token.TokenType.TK_ASSIGN))
            {
                //Create child node for =
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>(new CSTValue(GrammarProcess.GP_NONE, GetLastToken()));
                parentNode.AddChild(CurCSTNode);

                //Set ret
                ret = true;
            }
            //Else if dont show error chain
            else if (!showErrorChain)
                throw new ParseException("Parse ASSIGNMENTSTATEMENT failed, expecting '='. ASSIGNMENTSTATEMENT := ID = EXPR .");

            // Parse expression
            if( ret )
            {
                //Create child node for expr
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>();
                parentNode.AddChild(CurCSTNode);

                //Parse expr
                ret = ParseExpr();
            }

            //Send message appropriate to succes or failure
            if (ret)
                SendMessage("Successfully parsed ASSIGNMENTSTATEMENT. ");
            else
            {
                //Send error msg
                SendMessage("Parse ASSIGNMENTSTATEMENT failed. ASSIGNMENTSTATEMENT := ID = EXPR .");

                //Send error 
                SendError("Parse ASSIGNMENTSTATEMENT failed. ASSIGNMENTSTATEMENT := ID = EXPR .", CurPhase, GetCurToken(), CurTokenIndex);
            }

            //Set parent phase
            CurPhase = parentPhase;

            return ret;
        }

        //Parse VARDEC
        //:= type ID 
        //
        //Throws: new ParseException
        private bool ParseVarDec()
        {
            //Inits
            DynamicBranchTreeNode<CSTValue> parentNode = CurCSTNode;
            GrammarProcess parentPhase = CurPhase;
            Token backToken = null;
            DataType dt = DataType.DT_NONE;
            bool ret = false;

            //Set current phase
            CurPhase = GrammarProcess.GP_VARDEC;

            //Create current node and set value
            CurCSTNode.Data = new CSTValue(CurPhase);

            //Send message
            SendMessage("Parsing VARDEC...");

            //Create child for type
            CurCSTNode = new DynamicBranchTreeNode<CSTValue>();
            parentNode.AddChild(CurCSTNode);

            //Parse type
            ret = ParseType();

            //Match id
            if( ret && MatchToken(Token.TokenType.TK_ID) )
            {
                //Create child node for ID
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>(new CSTValue(GrammarProcess.GP_NONE,GetLastToken()));
                parentNode.AddChild(CurCSTNode);

                //Add symbol table entry
                backToken = CurTokenStream[CurTokenIndex - 2];

                if( backToken.Type == Token.TokenType.TK_INT )
                    dt = DataType.DT_INT;
                else if ( backToken.Type == Token.TokenType.TK_STRING )
                    dt = DataType.DT_STRING;
                else if( backToken.Type == Token.TokenType.TK_BOOLEAN )
                    dt = DataType.DT_BOOLEAN;

                CurSymbolTableNode.Data.Add(new SymbolTableEntry(CurTokenStream[CurTokenIndex - 1].Value,dt,0,0));

                //Send message
                SendMessage(String.Format("Added var {0} {1} to symbol table.", CurTokenStream[CurTokenIndex - 1], dt));

                //Set ret
                ret = true;
            }
            //Else if dont show error chain
            else if (!showErrorChain)
                throw new ParseException("Parse VARDEC failed, expecting ID. VARDEC := type ID .");


            //Send message appropriate to succes or failure
            if (ret)
                SendMessage("Successfully parsed VARDEC.");
            else
            {
                //Send error msg
                SendMessage("Error: Parse VARDEC failed. VARDEC := type ID .");

                //Send error 
                SendError("Parse VARDEC failed. VARDEC := type ID .", CurPhase, GetCurToken(), CurTokenIndex);
            }

            //Set parent phase
            CurPhase = parentPhase;

            return ret;
        }

        //Parse TYPE 
        //:= int | boolean | string 
        //
        //Throws: new ParseException
        private bool ParseType()
        {
            //Inits
            DynamicBranchTreeNode<CSTValue> parentNode = CurCSTNode;
            GrammarProcess parentPhase = CurPhase;
            bool ret = false;

            //Set current phase
            CurPhase = GrammarProcess.GP_TYPE;

            //Create current node and set value
            CurCSTNode.Data = new CSTValue(CurPhase);

            //Send message
            SendMessage("Parsing TYPE...");

            //Peek for TK_INT
            if( PeekToken(Token.TokenType.TK_INT) )
            {
                //Match TK_INT (peeked)
                MatchToken(Token.TokenType.TK_INT);

                //Create child node for TK_INT
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>(new CSTValue(GrammarProcess.GP_NONE,GetLastToken()));
                parentNode.AddChild(CurCSTNode);

                //Set ret
                ret = true;
            }

            //Pek for TK_STRING
            else if( PeekToken(Token.TokenType.TK_STRING) )
            {
                //Match TK_STRING (peeked)
                MatchToken(Token.TokenType.TK_STRING);

                //Create child node for TK_STRING
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>(new CSTValue(GrammarProcess.GP_NONE,GetLastToken()));
                parentNode.AddChild(CurCSTNode);

                //Set ret
                ret = true;
            }

            //Peek for TK_BOOLEAN
            else if( PeekToken(Token.TokenType.TK_BOOLEAN) )
            {
                //Match TK_BOOLEAN (peeked)
                MatchToken(Token.TokenType.TK_BOOLEAN);

                //Create child node for TK_BOOLEAN
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>(new CSTValue(GrammarProcess.GP_NONE,GetLastToken()));
                parentNode.AddChild(CurCSTNode);

                //Set ret
                ret = true;
            }
            //Else if dont show error chain
            else if (!showErrorChain)
                throw new ParseException("Parse TYPE failed. TYPE := int | boolean | string .");

            //Send message appropriate to succes or failure
            if (ret)
                SendMessage("Successfully parsed TYPE.");
            else
            {
                //Send error msg
                SendMessage("Error: Parse TYPE failed. TYPE := int | boolean | string ");

                //Send error 
                SendError("Parse TYPE failed. TYPE := int | boolean | string ", CurPhase, GetCurToken(), CurTokenIndex);
            }

            //Set parent phase
            CurPhase = parentPhase;

            return ret;
        }

        //Parse WHILESTATEMENT 
        //:= while BOOLEANEXPR BLOCK.
        //
        //Throws: new ParseException
        private bool ParseWhileStatement()
        {
            //Inits
            DynamicBranchTreeNode<CSTValue> parentNode = CurCSTNode;
            GrammarProcess parentPhase = CurPhase;
            bool ret = false;

            //Set current phase
            CurPhase = GrammarProcess.GP_WHILESTATEMENT;

            //Create current node and set value
            CurCSTNode.Data = new CSTValue(CurPhase);

            //Send message
            SendMessage("Parsing WHILESTATEMENT...");

            //Match TK_WHILE
            if( MatchToken(Token.TokenType.TK_WHILE) )
            {
                //Create child for TK_WHILE
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>(new CSTValue(GrammarProcess.GP_NONE,GetLastToken()));
                parentNode.AddChild(CurCSTNode);

                //Set ret
                ret = true;
            }
            //Else if dont show error chain
            else if (!showErrorChain)
                throw new ParseException("Parse WHILESTATEMENT failed, expecting \"while\". WHILESTATEMENT := while BOOLEANEXPR BLOCK.");

            //Check ret
            if( ret )
            {
                //Create child for BOOLEANEXPR
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>();
                parentNode.AddChild(CurCSTNode);

                //Parse BOOLEANEXPR
                ret = ParseBooleanExpr();
            }

            //Check ret
            if( ret )
            {
                //Create child for BLOCK
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>();
                parentNode.AddChild(CurCSTNode);

                //Parse BLOCK
                ret = ParseBlock(false);
            }

            //Send message appropriate to succes or failure
            if (ret)
                SendMessage("Successfully parsed WHILESTATEMENT.");
            else
            {
                //Send error msg
                SendMessage("Error: Parse WHILESTATEMENT failed. WHILESTATEMENT := while BOOLEANEXPR BLOCK.");

                //Send error 
                SendError("Parse WHILESTATEMENT failed. WHILESTATEMENT := while BOOLEANEXPR BLOCK.", CurPhase, GetCurToken(), CurTokenIndex);
            }

            //Set parent phase
            CurPhase = parentPhase;

            return ret;
        }

        //Parse IFSTATEMENT
        //:= if BOOLEANEXPR BLOCK
        //
        //Throws: new ParseException
        private bool ParseIfStatement()
        {
            //Inits
            DynamicBranchTreeNode<CSTValue> parentNode = CurCSTNode;
            GrammarProcess parentPhase = CurPhase;
            bool ret = false;

            //Set current phase
            CurPhase = GrammarProcess.GP_IFSTATEMENT;

            //Create current node and set value
            CurCSTNode.Data = new CSTValue(CurPhase);

            //Send message
            SendMessage("Parsing IFSTATEMENT...");

            //Match TK_IF
            if( MatchToken(Token.TokenType.TK_IF) )
            {
                //Create child for TK_IF
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>(new CSTValue(GrammarProcess.GP_NONE,GetLastToken()));
                parentNode.AddChild(CurCSTNode);

                //Set ret
                ret = true;
            }
            //Else if dont show error chain
            else if (!showErrorChain)
                throw new ParseException("Parse IFSTATEMENT failed, expecting \"if\". IFSTATEMENT := if BOOLEANEXPR BLOCK.");


            //Check ret
            if( ret )
            {
                //Create child for BOOLEANEXPR
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>();
                parentNode.AddChild(CurCSTNode);

                //Parse BOOLEANEXPR
                ret = ParseBooleanExpr();
            }

            //Check ret
            if( ret )
            {
                //Create child for BLOCK
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>();
                parentNode.AddChild(CurCSTNode);

                //Parse BLOCK
                ret = ParseBlock(false);
            }

            //Send message appropriate to succes or failure
            if (ret)
                SendMessage("Successfully parsed IFSTATEMENT.");
            else
            {
                //Send error msg
                SendMessage("Error: Parse IFSTATEMENT failed. IFSTATEMENT := if BOOLEANEXPR BLOCK");

                //Send error 
                SendError("Parse IFSTATEMENT failed. IFSTATEMENT := if BOOLEANEXPR BLOCK", CurPhase, GetCurToken(), CurTokenIndex );
            }

            //Set parent phase
            CurPhase = parentPhase;

            return ret;
        }

        //Parse BOOLOP
        // := == | !=
        //
        //Throws: new ParseException
        private bool ParseBoolOp()
        {
            //Inits
            DynamicBranchTreeNode<CSTValue> parentNode = CurCSTNode;
            GrammarProcess parentPhase = CurPhase;
            bool ret = false;

            //Set current phase
            CurPhase = GrammarProcess.GP_BOOLOP;

            //Create current node and set value
            CurCSTNode.Data = new CSTValue(CurPhase);

            //Send message
            SendMessage("Parsing BOOLOP...");

            //Peek for equals == 
            if (PeekToken(Token.TokenType.TK_BOOL_OP_EQUALS))
            {
                //Match token(already peeked)
                MatchToken(Token.TokenType.TK_BOOL_OP_EQUALS);

                //Create child for TK_IF
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>(new CSTValue(GrammarProcess.GP_NONE, GetLastToken()));
                parentNode.AddChild(CurCSTNode);

                //Set ret
                ret = true;
            }

            //Peek for not equals !=
            else if (PeekToken(Token.TokenType.TK_BOOL_OP_NOT_EQUALS))
            {
                //Match token(already peeked)
                MatchToken(Token.TokenType.TK_BOOL_OP_NOT_EQUALS);

                //Create child for TK_IF
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>(new CSTValue(GrammarProcess.GP_NONE, GetLastToken()));
                parentNode.AddChild(CurCSTNode);

                //Set ret
                ret = true;
            }
            //Else if dont show error chain
            else if (!showErrorChain)
                throw new ParseException("Parse BOOLOP failed, expecting '==' or '!='. BOOLOP := == | != .");


            //Send message appropriate to succes or failure
            if (ret)
                SendMessage("Successfully parsed BOOLOP.");
            else
            {
                //Send error msg
                SendMessage("Error: Parse BOOLOP failed. BOOLOP := == | !=.");

                //Send error 
                SendError("Parse BOOLOP failed. BOOLOP := == | !=", CurPhase, GetCurToken(), CurTokenIndex);
            }

            //Set parent phase
            CurPhase = parentPhase;

            return ret;
        }

        //Parses BOOLOP
        //BOOLOP := true | false
        //
        //Throws: new ParseException
        private bool ParseBoolVal()
        {
            //Inits
            DynamicBranchTreeNode<CSTValue> parentNode = CurCSTNode;
            GrammarProcess parentPhase = CurPhase;
            bool ret = false;

            //Set current phase
            CurPhase = GrammarProcess.GP_BOOLOP;

            //Create current node and set value
            CurCSTNode.Data = new CSTValue(CurPhase);

            //Send message
            SendMessage("Parsing BOOLVAL...");

            //Peek for 'true'
            if (PeekToken(Token.TokenType.TK_BOOL_TRUE))
            {
                //Match token(already peeked)
                MatchToken(Token.TokenType.TK_BOOL_TRUE);

                //Create child for TK_IF
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>(new CSTValue(GrammarProcess.GP_NONE, GetLastToken()));
                parentNode.AddChild(CurCSTNode);

                //Set ret
                ret = true;
            }

            //Peek for 'false'
            else if (PeekToken(Token.TokenType.TK_BOOL_FALSE))
            {
                //Match token(already peeked)
                MatchToken(Token.TokenType.TK_BOOL_FALSE);

                //Create child for TK_IF
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>(new CSTValue(GrammarProcess.GP_NONE, GetLastToken()));
                parentNode.AddChild(CurCSTNode);

                //Set ret
                ret = true;
            }
            //Else if dont show error chain
            else if (!showErrorChain)
                throw new ParseException("Parse BOOLVAL failed, expecting \"true\" or \"false\". BOOLOP := true | false");

            //Send message appropriate to succes or failure
            if (ret)
                SendMessage("Successfully parsed BOOLVAL.");
            else
            {
                //Send error msg
                SendMessage("Error: Parse BOOLVAL failed. BOOLOP := true | false .");

                //Send error 
                SendError("Parse BOOLVAL failed. BOOLOP := true | false .", CurPhase, GetCurToken(), CurTokenIndex);
            }

            //Set parent phase
            CurPhase = parentPhase;

            return ret;
        }

        //Parse int operation, which in this case
        //is only add. I made a seperate parse so
        //I can add values later
        //INTOP := +
        //
        //Throws: new ParseException
        private bool ParseIntOp()
        {
            //Inits
            DynamicBranchTreeNode<CSTValue> parentNode = CurCSTNode;
            GrammarProcess parentPhase = CurPhase;
            bool ret = false;

            //Set current phase
            CurPhase = GrammarProcess.GP_BOOLOP;

            //Create current node and set value
            CurCSTNode.Data = new CSTValue(CurPhase);

            //Send message
            SendMessage("Parsing INTOP...");

            //Match TK_OP_ADD
            if (MatchToken(Token.TokenType.TK_OP_ADD))
            {
                //Create child for TK_IF
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>(new CSTValue(GrammarProcess.GP_NONE, GetLastToken()));
                parentNode.AddChild(CurCSTNode);

                //Set ret
                ret = true;
            }
            //Else if dont show error chain
            else if (!showErrorChain)
                throw new ParseException("Parse INTOP failed, expecting '+'. INTOP := +");


            //Send message appropriate to succes or failure
            if (ret)
                SendMessage("Successfully parsed INTOP.");
            else
            {
                //Send error msg
                SendMessage("Error: Parse INTOP failed. INTOP := + .");

                //Send error 
                SendError("Parse INTOP failed. INTOP := + .", CurPhase, GetCurToken(), CurTokenIndex);
            }

            //Set parent phase
            CurPhase = parentPhase;

            return ret;
        }

        #endregion

        #region Peek Statements

        //Peek for all statement types
        private bool PeekStatement()
        {
            //Inits
            bool ret = false;

            SendMessage("Peeking for STATEMENT...");

            //Peek for PRINTSTATEMENT
            if (PeekPrintStatement())
                ret = true;

            //Peek for ASSIGNMENTSTATEMENT
            else if (PeekAssignmentStatement())
                ret = true;

            //Peek for VARDEC
            else if (PeekVarDec())
                ret = true;

            //Peek for WHILESTATEMENT
            else if (PeekWhileStatement())
                ret = true;

            //Peek for IFSTATEMENT
            else if (PeekIfStatement())
                ret = true;

            //Peek for BLOCK
            else if (PeekBlock())
                ret = true;

            //Message success of peek
            if (ret)
                SendMessage("Peek found STATEMENT.");
            else
                SendMessage("Peek did not find STATEMENT.");

            //Return set value
            return ret;
        }

        //Peek for print statment. First token is TK_PRINT
        private bool PeekPrintStatement()
        {
            //Inits
            bool ret = false;

            //Send message
            SendMessage("Peeking for PRINTSTATEMENT...");

            //Check for TK_PRINT
            if (PeekToken(Token.TokenType.TK_PRINT))
            {
                SendMessage("Peek found PRINTSTATEMENT.");
                ret = true;
            }
            else
            {
                SendMessage("Peek did not find PRINTSTATEMENT.");
                ret = false;
            }

            //Return set value
            return ret;
        }

        //Peek for assignmentstatment. First token is tk_id
        private bool PeekAssignmentStatement()
        {
            //Inits
            bool ret = false;

            //Send message
            SendMessage("Peeking for ASSIGNMENTSTATEMENT...");

            //Peek of TK_ID
            if (PeekToken(Token.TokenType.TK_ID))
            {
                //Send msg
                SendMessage("Peek found ASSIGNMENTSTATEMENT.");

                //Set return value
                ret = true;
            }
            else
            {
                //Send msg
                SendMessage("Peek did not find ASSIGNMENTSTATEMENT.");

                //Set return value
                ret = false;
            }

            //Return set value
            return ret;
        }

        //Peek for VARDEC
        private bool PeekVarDec()
        {
            //Inits
            bool ret = false;

            //Send message
            SendMessage("Peeking for VARDEC...");

            //Peek for TYPE
            if (PeekType())
            {
                //Send msg
                SendMessage("Peek found VARDEC.");

                //Set return value
                ret = true;
            }
            else
            {
                //Send msg
                SendMessage("Peek did not find VARDEC.");

                //Set return value
                ret = false;
            }

            //Return set value
            return ret;
        }

        //Peek for TYPE. First set is {TK_INT,TK_STRING,TK_BOOLEAN}
        private bool PeekType()
        {
            //Inits
            bool ret = false;

            //Send message
            SendMessage("Peeking for TYPE...");

            // Peek for TK_INT, TK_STRING, TK_BOOLEAN
            if (PeekToken(Token.TokenType.TK_INT) ||
                PeekToken(Token.TokenType.TK_STRING) ||
                PeekToken(Token.TokenType.TK_BOOLEAN))
            {
                //Send msg
                SendMessage("Peek found TYPE.");

                //Set return value
                ret = true;
            }
            else
            {
                //Send msg
                SendMessage("Peek did not find TYPE.");

                //Set return value
                ret = false;
            }

            //Return set value
            return ret;
        }

        //Peek for WHILESTATEMENT. First token is TK_WHILE
        private bool PeekWhileStatement()
        {
            //Inits
            bool ret = false;

            //Send message
            SendMessage("Peeking for WHILESTATEMENT...");

            // Peek for TK_WHILE
            if (PeekToken(Token.TokenType.TK_WHILE))
            {
                //Send msg
                SendMessage("Peek found WHILESTATEMENT.");

                //Set return value
                ret = true;
            }
            else
            {
                //Send msg
                SendMessage("Peek did not find WHILESTATEMENT.");

                //Set return value
                ret = false;
            }

            //Return set value
            return ret;
        }

        //Peek for IFSTATEMENT. First token is TK_IF
        private bool PeekIfStatement()
        {
            //Inits
            bool ret = false;

            //Send message
            SendMessage("Peeking for IFSTATEMENT...");

            // Peek for TK_IF
            if (PeekToken(Token.TokenType.TK_IF))
            {
                //Send msg
                SendMessage("Peek found IFSTATEMENT.");

                //Set return value
                ret = true;
            }
            else
            {
                //Send msg
                SendMessage("Peek did not find IFSTATEMENT.");

                //Set return value
                ret = false;
            }

            //Return set value
            return ret;
        }

        //Peek for block. First token is TK_LBACE
        private bool PeekBlock()
        {
            //Inits
            bool ret = false;

            //Send message
            SendMessage("Peeking for BLOCK...");

            // Peek for TK_LBRACE
            if (PeekToken(Token.TokenType.TK_LBRACE))
            {
                //Send msg
                SendMessage("Peek found BLOCK.");

                //Set return value
                ret = true;
            }
            else
            {
                //Send msg
                SendMessage("Peek did not find BLOCK.");

                //Set return value
                ret = false;
            }

            //Return set value
            return ret;
        }

        //Peek for INTEXPR. First token is TK_INT_LIT
        private bool PeekIntExpr()
        {
            //Inits
            bool ret = false;

            //Send message
            SendMessage("Peeking for INTEXPR...");

            // Peek for TK_INT_LITERAL
            if (PeekToken(Token.TokenType.TK_INT_LITERAL))
            {
                //Send msg
                SendMessage("Peek found INTEXPR.");

                //Set return value
                ret = true;
            }
            else
            {
                //Send msg
                SendMessage("Peek did not find INTEXPR.");

                //Set return value
                ret = false;
            }

            //Return set value
            return ret;
        }

        //Peek for STRINGEXPR. First token is TK_QUOTE
        private bool PeekStringExpr()
        {
            //Inits
            bool ret = false;

            //Send message
            SendMessage("Peeking for STRINGEXPR...");

            // Peek for TK_QUOTE
            if (PeekToken(Token.TokenType.TK_QUOTE))
            {
                //Send msg
                SendMessage("Peek found STRINGEXPR.");

                //Set return value
                ret = true;
            }
            else
            {
                //Send msg
                SendMessage("Peek did not find STRINGEXPR.");

                //Set return value
                ret = false;
            }

            //Return set value
            return ret;
        }

        //Peek for BOOLEXPR. First set is {TK_LPARAM,TK_BOOLTRUE,TK_BOOL_FALSE}
        private bool PeekBoolExpr()
        {
            //Inits
            bool ret = false;

            //Send message
            SendMessage("Peeking for BOOLEXPR...");

            // Peek for TK_LPARAM,TK_BOOL_TRUE,TK_BOOL_FALSE
            if (PeekToken(Token.TokenType.TK_LPARAM) ||
                PeekToken(Token.TokenType.TK_BOOL_TRUE) ||
                PeekToken(Token.TokenType.TK_BOOL_FALSE))
            {
                //Send msg
                SendMessage("Peek found BOOLEXPR.");

                //Set return value
                ret = true;
            }
            else
            {
                //Send msg
                SendMessage("Peek did not find BOOLEXPR.");

                //Set return value
                ret = false;
            }

            //Return set value
            return ret;
        }

        //Peek for BOOLOP. First set is {TK_OP_EQUALS, TK_OP_NOT_EQUALS}
        private bool PeekBoolOp()
        {
            //Inits
            bool ret = false;

            //Send message
            SendMessage("Peeking for BOOLOP...");

            // Peek forTK_bool_op_EQUALS TK_BOOL_OP_NOT_EQUALS
            if (PeekToken(Token.TokenType.TK_BOOL_OP_EQUALS) ||
                PeekToken(Token.TokenType.TK_BOOL_OP_NOT_EQUALS) )
            {
                //Send msg
                SendMessage("Peek found BOOLOP.");

                //Set return value
                ret = true;
            }
            else
            {
                //Send msg
                SendMessage("Peek did not find BOOLOP.");

                //Set return value
                ret = false;
            }

            //Return set value
            return ret;
        }

        //Peek for INTOP. First token is TK_OP_ADD
        private bool PeekIntOp()
        {
            //Inits
            bool ret = false;

            //Send message
            SendMessage("Peeking for INTOP...");

            // Peek for TK_LPARAM,TK_BOOL_TRUE,TK_BOOL_FALSE
            if (PeekToken(Token.TokenType.TK_OP_ADD))
            {
                //Send msg
                SendMessage("Peek found INTOP.");

                //Set return value
                ret = true;
            }
            else
            {
                //Send msg
                SendMessage("Peek did not find INTOP.");

                //Set return value
                ret = false;
            }

            //Return set value
            return ret;
        }

        //Peek for BOOLVAL. First set is TK_BOOL_TRUE, TK_BOOL_FALSE
        private bool PeekBoolVal()
        {
            //Inits
            bool ret = false;

            //Send message
            SendMessage("Peeking for BOOLVAL...");

            // Peek for TK_BOOL_TRUE,TK_BOOL_FALSE
            if (PeekToken(Token.TokenType.TK_BOOL_TRUE) ||
                PeekToken(Token.TokenType.TK_BOOL_FALSE))
            {
                //Send msg
                SendMessage("Peek found BOOLVAL.");

                //Set return value
                ret = true;
            }
            else
            {
                //Send msg
                SendMessage("Peek did not find BOOLVAL.");

                //Set return value
                ret = false;
            }

            //Return set value
            return ret;
        }

        #endregion

        #region Helper Methods

        //Sends message event
        private void SendMessage(String msg)
        {
            if (ParserMessageEvent != null)
                ParserMessageEvent(msg);
        }

        //Sends warning event
        private void SendWarning(String msg,GrammarProcess grammar, Token token, int tokenIndex)
        {
            if (ParserWarningEvent != null)
            {
                if (token != null)
                    ParserWarningEvent(new Message(msg, token.Line, token.Column, SystemType.ST_PARSER, grammar
                        , token, tokenIndex));
                else
                    ParserWarningEvent(new Message(msg, SystemType.ST_PARSER, grammar, token, tokenIndex));
            }

            //Increment warning count
            WarningCount++;
        }

        //Sends error event
        private void SendError(String msg, GrammarProcess grammar, Token token, int tokenIndex)
        {
            if (ParserErrorEvent != null)
            {
                if( token != null )
                    ParserErrorEvent(new Message(msg, token.Line,token.Column, SystemType.ST_PARSER, grammar
                        , token, tokenIndex));
                else
                    ParserErrorEvent(new Message(msg, SystemType.ST_PARSER, grammar, token, tokenIndex));
            }

            //Incrment error count
            ErrorCount++;
        }


        #endregion


    }
}
