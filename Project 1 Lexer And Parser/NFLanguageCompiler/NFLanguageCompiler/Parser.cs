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
        private DynamicBranchTreeNode<CSTValue> CurCSTNode;

        //Token stream processed
        private TokenStream CurTokenStream;

        //Token index
        private int CurTokenIndex;

        //Current parse phase
        private GrammarProcess CurPhase;

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
            CSTRoot = new DynamicBranchTreeNode<CSTValue>();
            CurCSTNode = CSTRoot;
            CurTokenStream = null;
            WarningCount = 0;
            ErrorCount = 0;
            CurTokenIndex = 0;
            CurPhase = GrammarProcess.GP_NONE;
        }

        #endregion

        #region Parsing Methods

        public ProcessReturnValue Parse(TokenStream tokenStream)
        {
            //Inits
            ProcessReturnValue ret = ProcessReturnValue.PRV_NONE;

            //Clear CST tree, warning count, and error count
            CSTRoot.Clear();
            WarningCount = 0;
            ErrorCount = 0;
            CurTokenIndex = 0;
            

            //Reset current node
            CurCSTNode = CSTRoot;

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
                    SendMessage(String.Format("Error: Expected {0}, but found {1}.", tokenType.ToString()
                        , GetCurToken().Type.ToString()));

                    //Send error
                    SendError(String.Format("Expected {0}, but found {1}.", tokenType.ToString()
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
                SendError("Parse Program failed.", CurPhase, GetLastToken(), CurTokenIndex - 1);
            }
        }

        private bool ParseBlock(bool firstBlock)
        {
            //Inits
            DynamicBranchTreeNode<CSTValue> parentNode = CurCSTNode;
            GrammarProcess parentPhase = CurPhase;
            bool ret = false;


            //Set current phase
            CurPhase = GrammarProcess.GP_BLOCK;

            //Create current node and set value
            CurCSTNode.Data = new CSTValue(GrammarProcess.GP_BLOCK);

            //Send message
            SendMessage("Parsing BLOCK...");

            //Match { if not first block
            if (!firstBlock)
            {
                //Match token and check
                if (MatchToken(Token.TokenType.TK_LBRACE))
                {
                    //Create child node for TK_LBRACE
                    CurCSTNode = new DynamicBranchTreeNode<CSTValue>(new CSTValue(GrammarProcess.GP_NONE
                        , CurTokenStream.GetToken(CurTokenIndex - 1)));
                    parentNode.AddChild(CurCSTNode);

                    //Set ret
                    ret = true;

                }

            }
   

            //Check ret
            if( firstBlock || ret )
            {
                //Create child node for STATEMENTLIST
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>();
                parentNode.AddChild(CurCSTNode);

                //Parse statementlist
                ret = ParseStatementList();
            }


            //Match { if not first block
            if (!firstBlock)
            {
                //Match token and check
                if (ret && !MatchToken(Token.TokenType.TK_RBRACE))
                {
                    //Create child node for TK_BRACE
                    CurCSTNode = new DynamicBranchTreeNode<CSTValue>(new CSTValue(GrammarProcess.GP_NONE
                        , CurTokenStream.GetToken(CurTokenIndex - 1)));
                    parentNode.AddChild(CurCSTNode);

                    //Set ret
                    ret = true;
                }

            }

            //Send appropriate message
            if (ret)
                SendMessage("Successfully parsed BLOCK.");
            else
            {
                //Send error msg
                SendMessage("Error: Parse BLOCK failed.");

                //Send error
                SendError("Parse BLOCK failed.", CurPhase, GetLastToken(), CurTokenIndex - 1);

            }

            //Reset current phase
            CurPhase = parentPhase;

            return ret;
        }

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
                //Set cur node value to LAMDA
                CurCSTNode.Data.Grammar = GrammarProcess.GP_LAMDA;

                //Send message
                SendMessage("STATEMENT is LAMDA.");

                //Set ret
                ret = true;
            }

            //Send message appropriate to succes or failure
            if (ret)
                SendMessage("Successfully parsed STATEMENT.");
            else
            {
                //Send mesage
                SendMessage("Error: Parse STATEMENT failed.");

                //Send error 
                SendError("Parse STATEMENT failed.", CurPhase, GetLastToken(), CurTokenIndex - 1);
            }

            //Set parent phase
            CurPhase = parentPhase;

            return true;
        }
        
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

                //Send error 
                SendError("Parse STATEMENT failed.", CurPhase, GetLastToken(), CurTokenIndex - 1);
            }

            //Set parent phase
            CurPhase = parentPhase;

            return ret;
        }

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

            //Match TK_LPARAM
            if (ret && MatchToken(Token.TokenType.TK_LPARAM))
            {
                //Create child for TK_LPARAM
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>(new CSTValue(GrammarProcess.GP_NONE, GetLastToken()));
                parentNode.AddChild(CurCSTNode);
                ret = true;
            }

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

            //Send message appropriate to succes or failure
            if (ret)
                SendMessage("Successfully parsed PRINTSTATEMENT.");
            else
            {
                //Send error msg
                SendMessage("Error: Parse PRINTSTATEMENT failed.");

                //Send error 
                SendError("Parse PRINTSTATEMENT failed.", CurPhase, GetLastToken(), CurTokenIndex - 1);
            }

            //Set parent phase
            CurPhase = parentPhase;

            return ret;
        }

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
            }

            //Send message appropriate to succes or failure
            if (ret)
                SendMessage("Successfully parsed EXPR.");
            else
            {
                //Send error msg
                SendMessage("Error: Parse EXPR failed.");

                //Send error 
                SendError("Parse EXPR failed.", CurPhase, GetLastToken(), CurTokenIndex - 1);
            }

            //Set parent phase
            CurPhase = parentPhase;

            return ret;
        }

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

            // Peek TK_OP_ADD
            if (ret && PeekToken(Token.TokenType.TK_OP_ADD))
            {
                //Match tk op add
                MatchToken(Token.TokenType.TK_OP_ADD);
                
                //Create child node for TK_OP_ADD
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>(new CSTValue(GrammarProcess.GP_NONE, GetLastToken()));
                parentNode.AddChild(CurCSTNode);

                //Create child node for EXPR
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>();
                parentNode.AddChild(CurCSTNode);

                //Parse expr
                ret = ParseExpr();
            }

            //Send message appropriate to succes or failure
            if (ret)
                SendMessage("Successfully parsed INTEXPR.");
            else
            {
                //Send error msg
                SendMessage("Error: Parse INTEXPR failed.");

                //Send error 
                SendError("Parse INTEXPR failed.", CurPhase, GetLastToken(), CurTokenIndex - 1);
            }

            //Set parent phase
            CurPhase = parentPhase;

            return ret;
        }

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

            //Send message appropriate to succes or failure
            if (ret)
                SendMessage("Successfully parsed STRINGEXPR.");
            else
            {
                //Send error msg
                SendMessage("Error: Parse STRINGEXPR failed.");

                //Send error 
                SendError("Parse STRINGEXPR failed.", CurPhase, GetLastToken(), CurTokenIndex - 1);
            }

            //Set parent phase
            CurPhase = parentPhase;

            return ret;
        }

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
            }

            //Send message appropriate to succes or failure
            if (ret)
                SendMessage("Successfully parsed CHARLIST.");
            else
            {
                //Send error msg
                SendMessage("Error: Parse CHARLIST failed.");

                //Send error 
                SendError("Parse CHARLIST failed.", CurPhase, GetLastToken(), CurTokenIndex - 1);
            }

            //Set parent phase
            CurPhase = parentPhase;

            return ret;
        }

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

                //Peek for BOOL OPS == AND !=
                if( ret && PeekToken(Token.TokenType.TK_BOOL_OP_EQUALS) )
                {
                    //Math == (just peeked)
                    MatchToken(Token.TokenType.TK_BOOL_OP_EQUALS);

                    //Create child for ==
                    CurCSTNode = new DynamicBranchTreeNode<CSTValue>(new CSTValue(GrammarProcess.GP_NONE,GetLastToken()));
                    parentNode.AddChild(CurCSTNode);

                    //Set ret true
                    ret = true;
                }
                else if( ret && PeekToken(Token.TokenType.TK_BOOL_OP_NOT_EQUALS) )
                {
                    //Math != (just peeked)
                    MatchToken(Token.TokenType.TK_BOOL_OP_NOT_EQUALS);

                    //Create child for !=
                    CurCSTNode = new DynamicBranchTreeNode<CSTValue>(new CSTValue(GrammarProcess.GP_NONE,GetLastToken()));
                    parentNode.AddChild(CurCSTNode);

                    //Set ret true
                    ret = true;
                }

                //Create child for expr
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>();
                parentNode.AddChild(CurCSTNode);

                // Parse expersion
                ret = ParseExpr();

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
                    //Else set ret
                    else
                        ret = false;
                }
            }

            //Else if look for bool value false
            else if( PeekToken(Token.TokenType.TK_BOOL_FALSE) )
            {
                //Math false (just peeked)
                MatchToken(Token.TokenType.TK_BOOL_FALSE);

                //Create child for false
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>(new CSTValue(GrammarProcess.GP_NONE,GetLastToken()));
                parentNode.AddChild(CurCSTNode);

                //Set ret
                ret = true;
            }

            //Else if look for bool value TRUE
            else if( PeekToken(Token.TokenType.TK_BOOL_TRUE) )
            {
                //Math true (just peeked)
                MatchToken(Token.TokenType.TK_BOOL_TRUE);

                //Create child for true for tk_bool_true
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>(new CSTValue(GrammarProcess.GP_NONE,GetLastToken()));
                parentNode.AddChild(CurCSTNode);

                //Set ret
                ret = true;
            }

            //Send message appropriate to succes or failure
            if (ret)
                SendMessage("Successfully parsed BOOLEXPR.");
            else
            {
                SendMessage("Errror: Parse BOOLEXPR failed.");

                //Send error
                SendError("Parse BOOLEXPR failed.", CurPhase, GetLastToken(), CurTokenIndex - 1);
            }

            //Set parent phase
            CurPhase = parentPhase;

            return ret;
        }

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

            // Match = 
            if( ret && MatchToken(Token.TokenType.TK_ASSIGN) )
            {
                //Create child node for =
                CurCSTNode = new DynamicBranchTreeNode<CSTValue>(new CSTValue(GrammarProcess.GP_NONE,GetLastToken()));
                parentNode.AddChild(CurCSTNode);

                //Set ret
                ret = true;
            }

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
                SendMessage("Successfully parsed ASSIGNMENTSTATEMENT.");
            else
            {
                //Send error msg
                SendMessage("Parse ASSIGNMENTSTATEMENT failed.");

                //Send error 
                SendError("Parse ASSIGNMENTSTATEMENT failed.", CurPhase, GetLastToken(), CurTokenIndex - 1);
            }

            //Set parent phase
            CurPhase = parentPhase;

            return ret;
        }

        private bool ParseVarDec()
        {
            //Inits
            DynamicBranchTreeNode<CSTValue> parentNode = CurCSTNode;
            GrammarProcess parentPhase = CurPhase;
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

                //Set ret
                ret = true;
            }

            //Send message appropriate to succes or failure
            if (ret)
                SendMessage("Successfully parsed VARDEC.");
            else
            {
                //Send error msg
                SendMessage("Error: Parse VARDEC failed.");

                //Send error 
                SendError("Parse VARDEC failed.", CurPhase, GetLastToken(), CurTokenIndex - 1);
            }

            //Set parent phase
            CurPhase = parentPhase;

            return ret;
        }

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

            //Send message appropriate to succes or failure
            if (ret)
                SendMessage("Successfully parsed TYPE.");
            else
            {
                //Send error msg
                SendMessage("Error: Parse TYPE failed.");

                //Send error 
                SendError("Parse TYPE failed.", CurPhase, GetLastToken(), CurTokenIndex - 1);
            }

            //Set parent phase
            CurPhase = parentPhase;

            return ret;
        }

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
                SendMessage("Error: Parse WHILESTATEMENT failed.");

                //Send error 
                SendError("Parse WHILESTATEMENT failed.", CurPhase, GetLastToken(), CurTokenIndex - 1);
            }

            //Set parent phase
            CurPhase = parentPhase;

            return ret;
        }

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
                SendMessage("Error: Parse IFSTATEMENT failed.");

                //Send error 
                SendError("Parse IFSTATEMENT failed.", CurPhase, GetLastToken(), CurTokenIndex - 1);
            }

            //Set parent phase
            CurPhase = parentPhase;

            return ret;
        }

        #endregion

        #region Peek Statements

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
                ParserWarningEvent(new Message(msg, SystemType.ST_PARSER,grammar, token, tokenIndex));
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
