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

        protected void Lex(String sourceFilePath)
        {
        }

        protected void LexFromString(String source)
        {
            int lineNum = 0;
            int index = 0;
            int headIndex = 0;
            int col = 0;
            bool match = false;
            Char curChar;

            String[] lines = source.Split('\n');
            OutputTokenStream.ClearTokens();

            foreach (String line in lines)
            {
                lineNum++;
                match = false;

                curChar = line[index];

                if (Char.IsLetter(curChar))
                {
                    if (curChar == 'n' || curChar == 'N')
                    {
                        if( line.Length - index >= 3 && line.Substring(index,3).ToUpper() == "NULL" )
                        {
                            match = true;
                            OutputTokenStream.AddToken(new Token(Token.TokenType.TK_ID, lineNum, col, curChar.ToString()));
                            index += 3;
                        }
                    }
                    else if (curChar == 'i' || curChar == 'I')
                    {
                        
                    }
                    
                    if(!match)
                    {
                        match = true;
                        OutputTokenStream.AddToken(new Token(Token.TokenType.TK_ID, lineNum, col, curChar.ToString()));
                        index++;
                    }
                }
                else if (Char.IsDigit(curChar))
                {
                }
                else if (curChar == '"')
                {
                }
                else if (curChar == '{')
                {
                }
                else if (curChar == '}')
                {
                }
                else if (curChar == '$')
                {
                }
                else if (curChar == '.')
                {
                }
                else if (curChar == '=')
                {
                }
                else if (curChar == '|')
                {
                }
                else if (curChar == '<')
                {
                }
                else if (curChar == '>')
                {
                }
                else if (curChar == '!')
                {
                }

                if (!match)
                {
                    OutputTokenStream.AddToken(new Token(Token.TokenType.TK_INVALID, lineNum, col, curChar.ToString()));
                    index++;
                }
            }
        }
    }
}
