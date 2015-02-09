using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlanLanguageCompiler
{
    public class Token
    {
        public enum TokenType
        {
            TK_ID,
            TK_INT,
            TK_DEC,
            TK_LPAREN,
            TK_RPAREN,
            TK_WARNING,
            TK_INVALID
        }

        public TokenType Type{get;set;}
        public int Line { get; set; }
        public int Column { get; set; }
        public String Value { get; set; }

        public Token() 
            : this(TokenType.TK_WARNING,0,0,"")
        {
        }

        public Token(TokenType Type, int Line, int Column)
            : this(Type, Line, Column, "")
        {
        }

        public Token(TokenType Type, int Line, int Column, String Value )
        {
            this.Type = Type;
            this.Line = Line;
            this.Column = Column;
            this.Value = Value;
        }
    }
}
