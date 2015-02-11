using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlanLanguageCompiler
{
    public class Lexer
    {
        public delegate void LexerEventHandler(String message);
        public event LexerEventHandler LexerOutputEvent;

        public TokenStream OutputTokenStream;

        public Lexer()
        {
            OutputTokenStream = new TokenStream();
        }

        public void Lex(String sourceFilePath)
        {
        }

        public void LexFromString(String source)
        {
            int lineNum = 0;
            int index = 0;
            int headIndex = 0;
            int col = 0;
            int eofTokenIndex = 0;
            bool match = false;
            bool eofFound = false;
            Char curChar;

            //Splits on lines(line feed). Carriage return is ignored in lexer.
            //This frustrated me I was splittling on line feed but it left
            //carraige returns in string, and didn't count them in the
            //length property.
            String[] lines = source.Split('\n');
            OutputTokenStream.ClearTokens();

            foreach (String line in lines)
            {
                lineNum++;
                                 
                for (index = 0; index < line.Length; index++)
                {
                    col = index + 1;
                    match = false;

                    curChar = line[index];

                    if (Char.IsLetter(curChar))
                    {
                        if (curChar == 'i' || curChar == 'I')
                        {
                            if (line.Length - index >= 3 && line.Substring(index, 3).ToUpper() == "INT")
                            {
                                match = true;
                                OutputTokenStream.AddToken(new Token(Token.TokenType.TK_INT, lineNum, col));
                                index += 2;
                                if( LexerOutputEvent != null)
                                    LexerOutputEvent("Indentified int keyword.");
                            }
                            else if (line.Length - index >= 2 && line.Substring(index, 2).ToUpper() == "IF")
                            {
                                match = true;
                                OutputTokenStream.AddToken(new Token(Token.TokenType.TK_IF, lineNum, col));
                                index += 1;
                                if (LexerOutputEvent != null)
                                    LexerOutputEvent("Indentified if keyword.");
                            }
                        }
                        else if (curChar == 'p' || curChar == 'P')
                        {
                            if (line.Length - index >= 5 && line.Substring(index, 5).ToUpper() == "PRINT")
                            {
                                match = true;
                                OutputTokenStream.AddToken(new Token(Token.TokenType.TK_PRINT, lineNum, col));
                                index += 4;
                                if (LexerOutputEvent != null)
                                    LexerOutputEvent("Indentified print keyword.");
                            }
                        }
                        else if (curChar == 'w' || curChar == 'W')
                        {
                            if (line.Length - index >= 5 && line.Substring(index, 5).ToUpper() == "WHILE")
                            {
                                match = true;
                                OutputTokenStream.AddToken(new Token(Token.TokenType.TK_PRINT, lineNum, col));
                                index += 4;
                                if (LexerOutputEvent != null)
                                    LexerOutputEvent("Indentified while keyword.");
                            }
                        }
                        else if (curChar == 's' || curChar == 'S')
                        {
                            if (line.Length - index >= 6 && line.Substring(index, 6).ToUpper() == "STRING")
                            {
                                match = true;
                                OutputTokenStream.AddToken(new Token(Token.TokenType.TK_STRING, lineNum, col));
                                index += 5;
                                if (LexerOutputEvent != null)
                                    LexerOutputEvent("Indentified string keyword.");
                            }
                        }
                        else if (curChar == 'b' || curChar == 'B')
                        {
                            if (line.Length - index >= 7 && line.Substring(index, 7).ToUpper() == "BOOLEAN")
                            {
                                match = true;
                                OutputTokenStream.AddToken(new Token(Token.TokenType.TK_BOOLEAN, lineNum, col));
                                index += 6;
                                if (LexerOutputEvent != null)
                                    LexerOutputEvent("Indentified boolean keyword.");
                            }
                        }
                        else if (curChar == 'f' || curChar == 'F')
                        {
                            if (line.Length - index >= 5 && line.Substring(index, 5).ToUpper() == "FALSE")
                            {
                                match = true;
                                OutputTokenStream.AddToken(new Token(Token.TokenType.TK_BOOL_FALSE, lineNum, col));
                                index += 4;
                                if (LexerOutputEvent != null)
                                    LexerOutputEvent("Indentified false keyword.");
                            }
                        }
                        else if (curChar == 't' || curChar == 'T')
                        {
                            if (line.Length - index >= 4 && line.Substring(index, 4).ToUpper() == "TRUE")
                            {
                                match = true;
                                OutputTokenStream.AddToken(new Token(Token.TokenType.TK_BOOL_TRUE, lineNum, col));
                                index += 3;
                                if (LexerOutputEvent != null)
                                    LexerOutputEvent("Indentified true keyword.");
                            }
                        }


                        if (!match)
                        {
                            match = true;
                            OutputTokenStream.AddToken(new Token(Token.TokenType.TK_ID, lineNum, col, curChar.ToString()));
                            if (LexerOutputEvent != null)
                                LexerOutputEvent("Indentified id value " + curChar.ToString() + ".");
                        }
                    }
                    else if (Char.IsDigit(curChar))
                    {
                        for (headIndex = index + 1; (!match && (headIndex < line.Length)); headIndex++)
                        {
                            if (!Char.IsDigit(line[headIndex]))
                            {
                                match = true;
                                OutputTokenStream.AddToken(new Token(Token.TokenType.TK_INT_LITERAL, lineNum, col, line.Substring(index, (headIndex - index))));
                                if (LexerOutputEvent != null)
                                    LexerOutputEvent("Indentified interger value " + line.Substring(index, (headIndex - index)) + ".");
                                index = headIndex - 1;
                         
                            }
                        }

                        if (!match)
                        {
                            OutputTokenStream.AddToken(new Token(Token.TokenType.TK_INT_LITERAL, lineNum, col, line[index].ToString()));
                            if (LexerOutputEvent != null)
                                LexerOutputEvent("Indentified interger value " + line.Substring(index, (headIndex - index)) + ".");
                        }
                    }
                    else if (curChar == '"')
                    {
                        for (headIndex = index + 1; (!match && (headIndex < line.Length)); headIndex++)
                        {
                            if (line[headIndex] == '"')
                            {
                                match = true;
                                OutputTokenStream.AddToken(new Token(Token.TokenType.TK_STRING_LITERAL, lineNum, col, line.Substring((index + 1), (headIndex - index - 1))));
                                if (LexerOutputEvent != null)
                                    LexerOutputEvent("Indentified interger value \"" + line.Substring((index + 1), (headIndex - index - 1)) + "\".");
                                index = headIndex;
                                
                            }
                        }

                        if (!match)
                        {
                            if (LexerOutputEvent != null)
                                LexerOutputEvent("Warning: String not terminated with closing quotes.");
                        }
                    }
                    else if (curChar == '{')
                    {
                        match = true;
                        OutputTokenStream.AddToken(new Token(Token.TokenType.TK_LBRACE, lineNum, col));
                        if (LexerOutputEvent != null)
                            LexerOutputEvent("Indentified opening brace.");
                    }
                    else if (curChar == '}')
                    {
                        match = true;
                        OutputTokenStream.AddToken(new Token(Token.TokenType.TK_RBRACE, lineNum, col));
                        if (LexerOutputEvent != null)
                            LexerOutputEvent("Indentified closing brace.");
                    }
                    else if (curChar == '(')
                    {
                        match = true;
                        OutputTokenStream.AddToken(new Token(Token.TokenType.TK_LPARAM, lineNum, col));
                        if (LexerOutputEvent != null)
                            LexerOutputEvent("Indentified left parameter.");
                    }
                    else if (curChar == ')')
                    {
                        match = true;
                        OutputTokenStream.AddToken(new Token(Token.TokenType.TK_RPARAM, lineNum, col));
                        if (LexerOutputEvent != null)
                            LexerOutputEvent("Indentified right parameter.");
                    }
                    else if (curChar == '$')
                    {
                        if (eofFound)
                        {
                            if (LexerOutputEvent != null)
                                LexerOutputEvent("Warning: End of file already found. Removing previous EOF.");
                            OutputTokenStream.RemoveToken(eofTokenIndex);
                        }

                        match = true;
                        eofTokenIndex = OutputTokenStream.AddToken(new Token(Token.TokenType.TK_EOF, lineNum, col));
                        if (LexerOutputEvent != null)
                            LexerOutputEvent("Indentified end of file.");
                        eofFound = true;
                    }
                    else if (curChar == '=')
                    {
                        if ((index + 1) < line.Length && line[index + 1] == '=')
                        {
                            match = true;
                            OutputTokenStream.AddToken(new Token(Token.TokenType.TK_BOOL_OP_EQUALS, lineNum, col));
                            index++;
                            if (LexerOutputEvent != null)
                                LexerOutputEvent("Indentified boolean equals operator.");
                        }
                        else
                        {
                            match = true;
                            OutputTokenStream.AddToken(new Token(Token.TokenType.TK_ASSIGN, lineNum, col));
                            if (LexerOutputEvent != null)
                                LexerOutputEvent("Indentified assignment operator.");
                        }
                    }
                    else if (curChar == '<')
                    {
                        match = true;
                        OutputTokenStream.AddToken(new Token(Token.TokenType.TK_BOOL_OP_LESS_THAN, lineNum, col));
                        if (LexerOutputEvent != null)
                            LexerOutputEvent("Indentified boolean less than operator.");
                    }
                    else if (curChar == '>')
                    {
                        match = true;
                        OutputTokenStream.AddToken(new Token(Token.TokenType.TK_BOOL_OP_GREATER_THAN, lineNum, col));
                        if (LexerOutputEvent != null)
                            LexerOutputEvent("Indentified boolean greater than operator.");
                    }
                    else if (curChar == '!')
                    {
                        if ((index + 1) < line.Length && line[index + 1] == '=')
                        {
                            match = true;
                            OutputTokenStream.AddToken(new Token(Token.TokenType.TK_BOOL_OP_NOT_EQUALS, lineNum, col));
                            index++;
                            if (LexerOutputEvent != null)
                                LexerOutputEvent("Indentified bolean not equals operator.");
                        }

                        if (!match)
                        {
                            if (LexerOutputEvent != null)
                                LexerOutputEvent("Warning: Indentified \"!\" symbol with no following \"=\".");
                        }
                    }
                    else if( curChar == ' ')
                    {
                        match = true;
                        OutputTokenStream.AddToken(new Token(Token.TokenType.TK_SPACE, lineNum, col));
                        if (LexerOutputEvent != null)
                            LexerOutputEvent("Indentified space character.");
                    }

                    
                    if (!match && (int)curChar < 32 && (int)curChar > 126 )
                    {
                        match = true;
                        OutputTokenStream.AddToken(new Token(Token.TokenType.TK_INVALID, lineNum, col, curChar.ToString()));
                        if (LexerOutputEvent != null)
                            LexerOutputEvent(String.Format("Unreconized symbol \"unicode:{0}\" on line {1} column {2}", Char.GetNumericValue(curChar).ToString(), lineNum, col));
                    }

                    if (match && eofFound)
                    {
                        if (LexerOutputEvent != null)
                            LexerOutputEvent("Warning: End of file already found. Removing previous EOF.");
                        OutputTokenStream.RemoveToken(eofTokenIndex);
                    }
                }
                
            }

            if( !eofFound )
            {
                if (LexerOutputEvent != null)
                    LexerOutputEvent("No end of file found. Adding EOF token.");
                eofTokenIndex = OutputTokenStream.AddToken(new Token(Token.TokenType.TK_EOF, lineNum, col + 1));
            }
        }
    }
}
