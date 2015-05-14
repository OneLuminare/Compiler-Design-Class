using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;

namespace NFLanguageCompiler
{
    // Lexer system turns source code into tokens. 
    // The token stream is kept in memore in the OutputTokenStream object.
    // Warnings and errors are sent to the parent Compiler object.
    //
    // Warnings: (Repairs warnings)
    //  1.) EOF previously found, or no EOF at end of source. 
    //
    // Errors: (Does not repair. Changes meaning of code.)
    //  1.) Run on strings. String cannot run over a line.
    //  2.) Invalid symbols. 
    //  3.) Integers or punctuation in string literals.
    public class Lexer
    {
        #region Data Members

        public TokenStream OutputTokenStream;

        #endregion

        #region Properties

        //Total warnings in run
        public int WarningCount
        {
            get;
            set;
        }

        //Total errors in run
        public int ErrorCount
        {
            get;
            set;
        }

        #endregion

        #region Events and Delegates

        // Event handling lexer output messages
        public event MessageEventHandler LexerMessageEvent;

        // Event handling lexer output messages
        public event MessageEventHandler LexerGeneralMessageEvent;

        // Event handling warning messages
        public event WarningErrorEventHandler LexerWarningEvent;

        // Event handling error messages
        public event WarningErrorEventHandler LexerErrorEvent;

        #endregion

        #region Constructors

        // Default constructor. Initializes data members.
        public Lexer()
        {
            OutputTokenStream = new TokenStream();
            WarningCount = 0;
            ErrorCount = 0;
        }

        #endregion

        #region Lexing Process Methods

        // Opens source file and reads into one long string.
        // Then calls LexFromString.
        //
        // Throws : IOException
        //
        // Returns :    ProcessReturnValue.PRV_OK,
        //              ProcessReturnValue.PRV_WARNINGS,
        //              ProcessReturnValue.PRV_ERRORS
        //              ProcessReturnValue.PRV_NONE (On no tokens but EOF)
        public ProcessReturnValue LexFromFile(String sourceFilePath)
        {
            //Inits
            StreamReader sr = null;
            String file = null;
            ProcessReturnValue ret = ProcessReturnValue.PRV_OK;

            // Try code for IOException
            try
            {
                //Open FileStream and StreamReader
                FileStream fs = new FileStream(sourceFilePath, FileMode.Open);
                sr = new StreamReader(fs);

                //Read file to end into string
                file = sr.ReadToEnd();

                //Lex from string
                ret = LexFromString(file);
            }
            // Throws up IOException
            catch (IOException e)
            {

                throw e;
            }

            //Close file reader and stream
            finally
            {
                if (sr != null)
                    sr.Close();
            }

            //Return value
            return ret;
        }

        // Lex source file as long string.
        // Splits lines by line feed, and trims carraige return if exits.
        // This is to handle text files with different new line constants.
        // Attempts to turn source into a stream of Tokens. 
        // Stores tokens in OutputTokenStream object.
        //
        // Events:  LexerMessageEvent
        //          LexerWarningEvent
        //          LexerErrorEvent
        //
        // Returns :    ProcessReturnValue.PRV_OK,
        //              ProcessReturnValue.PRV_WARNINGS,
        //              ProcessReturnValue.PRV_ERRORS
        public ProcessReturnValue LexFromString(String source)
        {
            // Inits
            int lineNum = 0;
            int index = 0;
            int stringStart = 0;
            int col = 0;
            int eofTokenLine = 0;
            int eofTokenCol = 0;
            int eofTokenIndex = 0;
            bool match = false;
            bool eofFound = false;
            bool inString = false;
            bool codeAfterEOF = false;
            String line = null;
            Char curChar;
            ProcessReturnValue ret;

            // Send message
            SendGeneralMessage("Starting compilation...");

            // Send message
            SendGeneralMessage("Starting lex...");

            //Splits on lines(line feed). Carriage return if exists is stripped 
            //later. Different text files use different combos of line feed
            //and carriage return, but all use atleast line feed.
            String[] lines = source.Split('\n');

            //Reset internal values such as token stream, warning count, and error count
            ResetData();

            //Cycle through split lines
            for( int i = 0; i < lines.Length; i++ )
            {
                //Trim carraige return from line
                line = lines[i].Trim('\r');

                //Increment line number
                lineNum++;

                //Check if in string mode and new line occurred. 
                //This indicates a run on string, and sends an error event.
                if (inString)
                {
                    //Trigger lexer output event
                    if (LexerMessageEvent != null)
                        LexerMessageEvent("Error: String ran over line. Exiting string mode to search for more errors.");

                    //Trigger error event
                    if( LexerErrorEvent != null)
                        LexerErrorEvent(new Message(
                        String.Format("String ran over line {0} starting on column {1}. Cannot parse.",lineNum -1
                        ,stringStart),lineNum - 1,stringStart,SystemType.ST_LEXER));

                    //Increment error count
                    ErrorCount++;

                    //Set in string toggle off
                    inString = false;
                }
                
                //Cycle through characters in line 
                for (index = 0; index < line.Length; index++)
                {
                    //Set current column
                    col = index + 1;

                    //Turn of match toggle
                    match = false;
                
                    //Get current char
                    curChar = line[index];

                    //Check if EOF found and char is a non space character
                    if (eofFound && curChar != ' ')
                    {
                        codeAfterEOF = true;

                        //Send output event
                        if (LexerMessageEvent != null)
                            LexerMessageEvent("Warning: Code found after EOF.");

                        //Send warning event
                        if (LexerWarningEvent != null)
                            LexerWarningEvent(new Message(String.Format("Code found after EOF starting on line {0} column {1}."
                                , lineNum, col), lineNum, col, SystemType.ST_LEXER));

                        //Increment warning count
                        WarningCount++;
                        
                        //Break char loop
                        break;
                    }
                    //Check if char is an alphebetical character
                    else if (Char.IsLetter(curChar))
                    {
                        //Check if in string mode, add char literal token, and set found match to true
                        if (inString)
                        {
                            if (Char.IsLower(curChar))
                            {
                                OutputTokenStream.AddToken(new Token(Token.TokenType.TK_CHAR_LITERAL, lineNum, col, line[index]));
                            }
                            else
                            {
                                //Send output event
                                if (LexerMessageEvent != null)
                                    LexerMessageEvent(String.Format("Error: Indentified upper case character literal '{0}' while in string literal"
                                        , line[index]));

                                //Send error event that integers cannot be in strings. Integer is not sent as token
                                if (LexerErrorEvent != null)
                                    LexerErrorEvent(new Message(
                                        String.Format("Indentifed upper case character literal {0} in string literal on line {1} , column {2}. Strings can only contain characters or white space."
                                        , line[index], lineNum, col), lineNum, col, SystemType.ST_LEXER));

                                //Increment error count
                                ErrorCount++;
                            }

                            match = true;
                            
                        }
                        //Check for keywords starting with I
                        else if (curChar == 'i' || curChar == 'I')
                        {
                            //Check for INT keyword
                            if (line.Length - index >= 3 && line.Substring(index, 3).ToUpper() == "INT")
                            {
                                //Send int token
                                OutputTokenStream.AddToken(new Token(Token.TokenType.TK_INT, lineNum, col));

                                //Increment index one less then used, as loop incrments by one at end
                                index += 2;

                                //Send output event
                                if( LexerMessageEvent != null)
                                    LexerMessageEvent("Indentified int keyword.");

                                //Set found match
                                match = true;
                            }
                            //Check for IF keyword
                            else if (line.Length - index >= 2 && line.Substring(index, 2).ToUpper() == "IF")
                            {
                                //Send if token
                                OutputTokenStream.AddToken(new Token(Token.TokenType.TK_IF, lineNum, col));

                                //Increment index one less then used, as loop incrments by one at end
                                index += 1;

                                //Send output event
                                if (LexerMessageEvent != null)
                                    LexerMessageEvent("Indentified if keyword.");

                                //Set found match
                                match = true;
                            }
                        }
                        //Check for keywords starting with P
                        else if (curChar == 'p' || curChar == 'P')
                        {
                            //Check for PRINT keyword
                            if (line.Length - index >= 5 && line.Substring(index, 5).ToUpper() == "PRINT")
                            {
                                //Set found match
                                match = true;

                                //Send print token
                                OutputTokenStream.AddToken(new Token(Token.TokenType.TK_PRINT, lineNum, col));

                                //Increment index one less then used, as loop incrments by one at end
                                index += 4;

                                //Send output event
                                if (LexerMessageEvent != null)
                                    LexerMessageEvent("Indentified print keyword.");
                            }
                        }
                        //Check for keyword starting with W
                        else if (curChar == 'w' || curChar == 'W')
                        {
                            //Check for WHILE keyword
                            if (line.Length - index >= 5 && line.Substring(index, 5).ToUpper() == "WHILE")
                            {
                                //Set found match
                                match = true;

                                //Send print token
                                OutputTokenStream.AddToken(new Token(Token.TokenType.TK_WHILE, lineNum, col));

                                //Increment index one less then used, as loop incrments by one at end
                                index += 4;

                                //Send output event
                                if (LexerMessageEvent != null)
                                    LexerMessageEvent("Indentified while keyword.");
                            }
                        }
                        //Check for keywords starting with S
                        else if (curChar == 's' || curChar == 'S')
                        {
                            //Check for STRING keyword
                            if (line.Length - index >= 6 && line.Substring(index, 6).ToUpper() == "STRING")
                            {
                                //Set found match
                                match = true;

                                //Send string token
                                OutputTokenStream.AddToken(new Token(Token.TokenType.TK_STRING, lineNum, col));

                                //Increment index one less then used, as loop incrments by one at end
                                index += 5;

                                //Send output event
                                if (LexerMessageEvent != null)
                                    LexerMessageEvent("Indentified string keyword.");
                            }
                        }
                        //Check for keywords starting with B
                        else if (curChar == 'b' || curChar == 'B')
                        {
                            //Check for boolean keyword
                            if (line.Length - index >= 7 && line.Substring(index, 7).ToUpper() == "BOOLEAN")
                            {
                                //Set found match
                                match = true;

                                //Send boolean token
                                OutputTokenStream.AddToken(new Token(Token.TokenType.TK_BOOLEAN, lineNum, col));

                                //Increment index one less then used, as loop incrments by one at end
                                index += 6;

                                //Send output event
                                if (LexerMessageEvent != null)
                                    LexerMessageEvent("Indentified boolean keyword.");
                            }
                        }
                        //Check for keyword starting with F
                        else if (curChar == 'f' || curChar == 'F')
                        {
                            //Check for FALSE keyword
                            if (line.Length - index >= 5 && line.Substring(index, 5).ToUpper() == "FALSE")
                            {
                                //Set found match
                                match = true;

                                //Send boolean token
                                OutputTokenStream.AddToken(new Token(Token.TokenType.TK_BOOL_FALSE, lineNum, col));

                                //Increment index one less then used, as loop incrments by one at end
                                index += 4;

                                //Send output event
                                if (LexerMessageEvent != null)
                                    LexerMessageEvent("Indentified false keyword.");
                            }
                        }
                        //Check for keywords starting with T
                        else if (curChar == 't' || curChar == 'T')
                        {
                            //Check for true keyword
                            if (line.Length - index >= 4 && line.Substring(index, 4).ToUpper() == "TRUE")
                            {
                                //Set found match
                                match = true;

                                //Send bool true token
                                OutputTokenStream.AddToken(new Token(Token.TokenType.TK_BOOL_TRUE, lineNum, col));

                                //Increment index one less then used, as loop incrments by one at end
                                index += 3;

                                //Send output event
                                if (LexerMessageEvent != null)
                                    LexerMessageEvent("Indentified true keyword.");
                            }
                        }

                        //If not match found for keywords, alphabetical character is an one char ID
                        if (!match)
                        {
                            //Set found match
                            match = true;

                            //Send ID token
                            OutputTokenStream.AddToken(new Token(Token.TokenType.TK_ID, lineNum, col, curChar));

                            //Send output event
                            if (LexerMessageEvent != null)
                                LexerMessageEvent("Indentified id value " + curChar.ToString() + ".");
                        }
                    }
                    //Check if character is a digit
                    else if (Char.IsDigit(curChar))
                    {
                        //Check if in string mode. Intergers are not allowed in string literals
                        //Sends warning and removes character from string
                        if (inString)
                        {
                            /*
                            //Send output event
                            if (LexerMessageEvent != null)
                                LexerMessageEvent(String.Format("Warning: Indentified integer literal '{0}' while in string literal"
                                    , line[index]));

                            //Send warning event that integers cannot be in strings. Integer is not sent as token
                            if (LexerWarningEvent != null)
                                LexerWarningEvent(new Message(
                                    String.Format("Indentifed integer literal {0} in string literal on line {1} , column {2}. Strings can only contain characters or white space."
                                    , line[index], lineNum, col), lineNum, col, SystemType.ST_LEXER));

                            //Increment warning count
                            WarningCount++;
                             * */
                            //Send output event
                            if (LexerMessageEvent != null)
                                LexerMessageEvent(String.Format("Error: Indentified integer literal '{0}' while in string literal"
                                    , line[index]));

                            //Send error event that integers cannot be in strings. Integer is not sent as token
                            if (LexerErrorEvent != null)
                                LexerErrorEvent(new Message(
                                    String.Format("Indentifed integer literal {0} in string literal on line {1} , column {2}. Strings can only contain characters or white space."
                                    , line[index], lineNum, col), lineNum, col, SystemType.ST_LEXER));

                            //Increment error count
                            ErrorCount++;
                        }
                        //If not in string mode, sent integer literal token
                        else
                        {

                            //If not in string mode, send interger literal token. Intergers are only allowed to be one length
                            OutputTokenStream.AddToken(new Token(Token.TokenType.TK_INT_LITERAL, lineNum, col, line[index]));

                            //Send output event
                            if (LexerMessageEvent != null)
                                LexerMessageEvent(String.Format("Indentified integer literal {0}.", line[index]));
                        }

                        //Set found match
                        match = true;
              
                        //------------
                        //OPT OUT CODE
                        //------------
                        //This code allows interger literals to be of any length, but the grammer states
                        //they can only be of length one.
                        /*
                        for (headIndex = index + 1; (!match && (headIndex < line.Length)); headIndex++)
                        {
                            if (!Char.IsDigit(line[headIndex]))
                            {
                                match = true;
                                OutputTokenStream.AddToken(new Token(Token.TokenType.TK_INT_LITERAL, lineNum, col, line.Substring(index, (headIndex - index))));
                                if (LexerMessageEvent != null)
                                    LexerMessageEvent("Indentified interger value " + line.Substring(index, (headIndex - index)) + ".");
                                index = headIndex - 1;

                            }
                        }
                        
                        if (!match)
                        {
                            OutputTokenStream.AddToken(new Token(Token.TokenType.TK_INT_LITERAL, lineNum, col, line[index].ToString()));
                            if (LexerMessageEvent != null)
                                LexerMessageEvent("Indentified interger value " + line.Substring(index, (headIndex - index)) + ".");
                        }
                         */
                        
                    }
                    //Check for quote char
                    else if (curChar == '"')
                    {
                        //Toggle in string mode
                        inString = !inString;

                        //If in string mode, record column  of string start for messages
                        if( inString )
                            stringStart = col;

                        //Send quote token
                        OutputTokenStream.AddToken(new Token(Token.TokenType.TK_QUOTE,lineNum,col));

                        //Set found match
                        match = true;

                        //Send output event, stating enter or exiting string mode
                        if( LexerMessageEvent != null )
                            if( inString )
                                LexerMessageEvent("Exiting string mode.");
                            else
                                LexerMessageEvent("Entering string mode.");

                        //------------
                        //OPT OUT CODE
                        //------------
                        //This code was for using string literals as one token. 
                        /*
                        for (headIndex = index + 1; (!match && (headIndex < line.Length)); headIndex++)
                        {
                            if (line[headIndex] == '"')
                            {
                                match = true;
                                OutputTokenStream.AddToken(new Token(Token.TokenType.TK_STRING_LITERAL, lineNum, col, line.Substring((index + 1), (headIndex - index - 1))));
                                if (LexerMessageEvent != null)
                                    LexerMessageEvent("Indentified interger value \"" + line.Substring((index + 1), (headIndex - index - 1)) + "\".");
                                index = headIndex;
                                
                            }
                        }

                        if (!match)
                        {
                            if (LexerMessageEvent != null)
                                LexerMessageEvent("Warning: String not terminated with closing quotes.");
                        }
                         */

                    }
                    //Check for space char
                    else if (curChar == ' ')
                    {
                        //Check if in string mode. Only sends space token if in string literal
                        if (inString)
                        {
                            //Send space token
                            OutputTokenStream.AddToken(new Token(Token.TokenType.TK_SPACE, lineNum, col));

                            //Send output event
                            if (LexerMessageEvent != null)
                                LexerMessageEvent("Indentified space character in string.");
                        }

                        //Set found match
                        match = true;
                    }
                    //Check if in string mode, and no acceptible options have been chosen.
                    //This stops any puncation or non alphbetical characters to be in string literals.
                    else if (inString)
                    {
                        //Send output event
                        if (LexerMessageEvent != null)
                            LexerMessageEvent(String.Format("Warning: Indentified symbol '{0}' while in string literal"
                                , line[index]));

                        //Send warning. Removes invalid character from string
                        if( LexerWarningEvent != null)
                            LexerWarningEvent(new Message(
                                String.Format("Indentifed symbol {0} in string literal on line {1} , column {2}. Strings can only contain characters or white space."
                                , line[index],lineNum, col), lineNum, col, SystemType.ST_LEXER));

                        //Increment warning count
                        WarningCount++;

                        //Set found match
                        match = true;
                    }
                    //Check for open bracket
                    else if (curChar == '{')
                    {
                        //Set found match
                        match = true;

                        //Send open brackt token
                        OutputTokenStream.AddToken(new Token(Token.TokenType.TK_LBRACE, lineNum, col));

                        //Send output event
                        if (LexerMessageEvent != null)
                            LexerMessageEvent("Indentified opening brace.");
                    }
                    //Check for close bracket
                    else if (curChar == '}')
                    {
                        //Set found match
                        match = true;

                        //Send close bracket token
                        OutputTokenStream.AddToken(new Token(Token.TokenType.TK_RBRACE, lineNum, col));

                        //Send output event
                        if (LexerMessageEvent != null)
                            LexerMessageEvent("Indentified closing brace.");
                    }
                    //Check for open param
                    else if (curChar == '(')
                    {
                        //Set found match
                        match = true;

                        //Send open param token
                        OutputTokenStream.AddToken(new Token(Token.TokenType.TK_LPARAM, lineNum, col));

                        //Send output message
                        if (LexerMessageEvent != null)
                            LexerMessageEvent("Indentified left parameter.");
                    }
                    //Check for close param
                    else if (curChar == ')')
                    {
                        //Set found match
                        match = true;

                        //Send close param token
                        OutputTokenStream.AddToken(new Token(Token.TokenType.TK_RPARAM, lineNum, col));

                        //Send output event
                        if (LexerMessageEvent != null)
                            LexerMessageEvent("Indentified right parameter.");
                    }
                    //Check for EOF char
                    else if (curChar == '$')
                    {
                        //Check if eof already found, and remove old one
                        if (!eofFound)
                        {
                            /*
                            //Send output event
                            if (LexerMessageEvent != null)
                                LexerMessageEvent("Warning: End of file already found. Removing previous EOF.");

                            //Remove token from stream
                            OutputTokenStream.RemoveToken(eofTokenIndex);

                            //Send warning event. Removes old EOF token.
                            if( LexerWarningEvent != null)
                                LexerWarningEvent(new Message(String.Format("End of file already found on line {0} column {1}. Removing previous EOF token."
                                , eofTokenLine, eofTokenCol), lineNum, col, SystemType.ST_LEXER));

                            //Increment warning count
                            WarningCount++;
                             * */


                            //Set found match
                            match = true;

                            //Add EoF token
                            eofTokenIndex = OutputTokenStream.AddToken(new Token(Token.TokenType.TK_EOF, lineNum, col));

                            //Send output event
                            if (LexerMessageEvent != null)
                                LexerMessageEvent("Indentified end of file.");

                            //Set found EOF 
                            eofFound = true;

                            //Record eof line
                            eofTokenLine = lineNum;

                            //Record eof col
                            eofTokenCol = col;
                        }
                    }
                    //Check for addition operator
                    else if (curChar == '+')
                    {
                        //Set found match
                        match = true;

                        //Send add token
                        OutputTokenStream.AddToken(new Token(Token.TokenType.TK_OP_ADD, lineNum, col));

                        //Send output event
                        if (LexerMessageEvent != null)
                            LexerMessageEvent("Indentified addition operator.");
                    }
                    //Check for assign(=) and equals(==)
                    else if (curChar == '=')
                    {
                        //Check for boolean equals(==)
                        if ((index + 1) < line.Length && line[index + 1] == '=')
                        {
                            //Set found match
                            match = true;

                            //Send equals token
                            OutputTokenStream.AddToken(new Token(Token.TokenType.TK_BOOL_OP_EQUALS, lineNum, col));

                            //Increment index one less then used, as its incremented at end of loop
                            index++;

                            //Send output event
                            if (LexerMessageEvent != null)
                                LexerMessageEvent("Indentified boolean equals operator.");
                        }
                        //If not equals(==), then its assign(=)
                        else
                        {
                            //Set found match
                            match = true;

                            //Send assign token
                            OutputTokenStream.AddToken(new Token(Token.TokenType.TK_ASSIGN, lineNum, col));

                            //Send output event
                            if (LexerMessageEvent != null)
                                LexerMessageEvent("Indentified assignment operator.");
                        }
                    }
                    //Check for less then op
                    else if (curChar == '<')
                    {
                        //Set found match
                        match = true;

                        //Send less the ntoken
                        OutputTokenStream.AddToken(new Token(Token.TokenType.TK_BOOL_OP_LESS_THAN, lineNum, col));

                        //Send output event
                        if (LexerMessageEvent != null)
                            LexerMessageEvent("Indentified boolean less than operator.");
                    }
                    //Check for greater than op
                    else if (curChar == '>')
                    {
                        //Set found match
                        match = true;

                        //Send greater than token
                        OutputTokenStream.AddToken(new Token(Token.TokenType.TK_BOOL_OP_GREATER_THAN, lineNum, col));

                        //Send output event
                        if (LexerMessageEvent != null)
                            LexerMessageEvent("Indentified boolean greater than operator.");
                    }
                    //Check for not equals token
                    else if (curChar == '!')
                    {
                        //Check for not equals !=
                        if ((index + 1) < line.Length && line[index + 1] == '=')
                        {
                            //Set found match
                            match = true;

                            //Send not equals token
                            OutputTokenStream.AddToken(new Token(Token.TokenType.TK_BOOL_OP_NOT_EQUALS, lineNum, col));

                            //Increase index, one less then used as index is increased at end of loop
                            index++;

                            //Send output event
                            if (LexerMessageEvent != null)
                                LexerMessageEvent("Indentified bolean not equals operator.");
                        }
                    }
                   
                    //If no acceptiable matches have been made, its an invalid character.
                    //Sends an error message, and an invalid token.
                    if (!match)
                    {
                        //Set found match
                        match = true;

                        //Set invalid symbol token
                        OutputTokenStream.AddToken(new Token(Token.TokenType.TK_INVALID, lineNum, col, curChar));

                        //Send output event of error
                        if (LexerMessageEvent != null)
                            LexerMessageEvent(String.Format("Error: Unreconized symbol \"unicode:{0}\" on line {1} column {2}"
                                , (int)curChar, lineNum, col));

                        //Send error event
                        if( LexerErrorEvent != null)
                            LexerErrorEvent(new Message(String.Format("Inavalid symbol {0}, unicode {1}, was found on line {2}, column {3}. Cannot parse."
                                ,curChar,(int)curChar,lineNum,col),lineNum,col,SystemType.ST_LEXER));

                        //Increment error count
                        ErrorCount++;
                    }
                }

                //Break line loop if code afer eof
                if (codeAfterEOF)
                    break;
            }



            //After all lines are process, if in string mode send error
            if (inString)
            {
                //Trigger lexer output event
                if (LexerMessageEvent != null)
                    LexerMessageEvent("Error: String ran over line.");

                //Trigger error event
                if (LexerErrorEvent != null)
                    LexerErrorEvent(new Message(
                    String.Format("String ran over line {0} starting on column {1}. Cannot parse.", lineNum - 1
                    , stringStart), lineNum - 1, stringStart, SystemType.ST_LEXER));

                //Increment error count
                ErrorCount++;
            }

            //After all lines are process, check if eof was not added at end of source
            if( !eofFound )
            {
                //Send output event
                if (LexerMessageEvent != null)
                    LexerMessageEvent("No end of file found. Adding EOF token.");

                //Add EoF token at end of stream
                eofTokenIndex = OutputTokenStream.AddToken(new Token(Token.TokenType.TK_EOF, lineNum, col + 1));

                //Send warning event
                if( LexerWarningEvent != null )
                    LexerWarningEvent(new Message("No EOF found. Adding EOF token.", lineNum, col + 1, SystemType.ST_LEXER));

                //Increment warning count
                WarningCount++;
            }

            // Send message
            SendGeneralMessage("Lex complete.");

            //Determine return value
            if (OutputTokenStream.Count == 1)
                ret = ProcessReturnValue.PRV_NONE;
            else if (ErrorCount > 0)
                ret = ProcessReturnValue.PRV_ERRORS;
            else if (WarningCount > 0)
                ret = ProcessReturnValue.PRV_WARNINGS;
            else
                ret = ProcessReturnValue.PRV_OK;

            //Return value
            return ret;
        }

        //Resets data for new lex
        private void ResetData()
        {
            OutputTokenStream.ClearTokens();
            WarningCount = 0;
            ErrorCount = 0;
        }

        // Sends general message
        private void SendGeneralMessage(String msg)
        {
            //Send output event
            if (LexerGeneralMessageEvent != null)
                LexerGeneralMessageEvent(msg);
            
            //Send output event
            if (LexerMessageEvent != null)
                LexerMessageEvent(msg);
        }

        #endregion
    }
}
