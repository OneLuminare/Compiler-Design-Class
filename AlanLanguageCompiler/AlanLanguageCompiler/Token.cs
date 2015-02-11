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
            TK_PRINT,
            TK_WHILE,
            TK_IF,
            TK_STRING,
            TK_BOOLEAN,
            TK_BOOL_TRUE,
            TK_BOOL_FALSE,
            TK_INT_LITERAL,
            TK_STRING_LITERAL,
            TK_SPACE,
            //TK_DECIMAL_LITERAL,
            //TK_DECIMAL,
            TK_LPARAM,
            TK_RPARAM,
            TK_LBRACE,
            TK_RBRACE,
            TK_ASSIGN,
            TK_BOOL_OP_EQUALS,
            TK_BOOL_OP_NOT_EQUALS,
            TK_BOOL_OP_LESS_THAN,
            TK_BOOL_OP_GREATER_THAN,
            TK_EOF,
            TK_INVALID
        }

        public TokenType Type{get;set;}
        public int Line { get; set; }
        public int Column { get; set; }
        public String Value { get; set; }

        public Token() 
            : this(TokenType.TK_INVALID,0,0,"")
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
