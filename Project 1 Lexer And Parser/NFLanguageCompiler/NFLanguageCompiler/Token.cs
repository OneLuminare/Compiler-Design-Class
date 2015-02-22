using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace NFLanguageCompiler
{
    // Token class represents all aspects of a token, including its type, line number, 
    // and column number. 
    [Serializable]
    public class Token : ISerializable
    {
        #region Type Definition 

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
            TK_QUOTE,
            TK_CHAR_LITERAL,
            TK_LPARAM,
            TK_RPARAM,
            TK_LBRACE,
            TK_RBRACE,
            TK_ASSIGN,
            TK_OP_ADD,
            TK_BOOL_OP_EQUALS,
            TK_BOOL_OP_NOT_EQUALS,
            TK_BOOL_OP_LESS_THAN,
            TK_BOOL_OP_GREATER_THAN,
            TK_EOF,
            TK_INVALID
        }

        #endregion

        #region Properties
        
        public TokenType Type{get;set;}
        public int Line { get; set; }
        public int Column { get; set; }
        public char Value { get; set; }
        //Value was String when I accepted integers of any length
        //and String Literals as one token
        //public String Value { get; set; }

        #endregion

        #region Constructors

        //Default constructor
        public Token() 
            : this(TokenType.TK_INVALID,0,0,' ')
        {
        }

        //Input constructor
        public Token(TokenType Type, int Line, int Column)
            : this(Type, Line, Column, ' ')
        {
        }

        //Input constructor
        public Token(TokenType Type, int Line, int Column, char Value )
        {
            this.Type = Type;
            this.Line = Line;
            this.Column = Column;
            this.Value = Value;
        }

        //Deserialization constructor
        public Token(SerializationInfo info, StreamingContext sc)
        {
            Type = (TokenType)info.GetValue("TokenType",  typeof(TokenType));
            Line = (int)info.GetValue("Line",  typeof(int));
            Column = (int)info.GetValue("Column",  typeof(int));
            Value = (char)info.GetValue("Value",  typeof(char));
        }

        #endregion
        
        #region ISerializable Members

        //Serialization interface method. Declares which data members are to be serialized.
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("TokenType", Type, typeof(TokenType));
            info.AddValue("Line", Line, typeof(int));
            info.AddValue("Column", Column, typeof(int));
            info.AddValue("Value", Value, typeof(char));
        }

        #endregion
    }
}
