using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace NFLanguageCompiler 
{
    // Describes warning and error information. 
    // Includes a message, line number, column, and system type.
    // Added grammer, token, and token index for parrser;
    [Serializable]
    public class Message : ISerializable
    {
        #region Properties

        public String Text { get; set; }
        public int Line { get; set; }
        public int Column { get; set; }
        public SystemType System { get; set; }
        //Add during Parse development
        public GrammarProcess Grammar { get; set; }
        public Token Token { get; set; }
        public int TokenIndex { get; set; }

        #endregion

        #region Constructors

        // Default constructor
        public Message()
            : this("", 0, 0, SystemType.ST_NONE, GrammarProcess.GP_NONE, null, -1)
        {
        }

        // Input constructor for lexer
        public Message(String message, int line, int column, SystemType system)
            : this(message,line,column,system,GrammarProcess.GP_NONE,null,-1)
        {
        }

        // Input constructor for parser
        public Message(String message, SystemType system,GrammarProcess grammar,Token token, int tokenIndex)
            : this(message, -1,-1, system, GrammarProcess.GP_NONE, null, -1)
        {
        }

        //Base input constructor, has all values
        public Message(String message, int line, int column, SystemType system, GrammarProcess grammar,Token token, int tokenIndex)
        {
            Text = message;
            Line = line;
            Column = column;
            System = system;
            Grammar = grammar;
            Token = token;
            TokenIndex = tokenIndex;
        }

        // Deserialization constructor
        public Message(SerializationInfo info, StreamingContext sc)
        {
            Text = (String)info.GetValue("Text", typeof(String));
            Line = (int)info.GetValue("Line", typeof(int));
            Column = (int)info.GetValue("Column", typeof(int));
            System = (SystemType)info.GetValue("System", typeof(SystemType));
            Grammar = (GrammarProcess)info.GetValue("Grammar", typeof(GrammarProcess));
            Token = (Token)info.GetValue("Token", typeof(Token));
            TokenIndex = (int)info.GetValue("TokenIndex", typeof(int));

        }

        #endregion
        
        #region ISerializable Members

        // Serialization interface method. Describes how data is serialized.
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Text", Text, typeof(String));
            info.AddValue("Line", Line, typeof(int));
            info.AddValue("Column", Column, typeof(int));
            info.AddValue("System", System, typeof(SystemType));
            info.AddValue("Grammar", Grammar, typeof(GrammarProcess));
            info.AddValue("Token", Token, typeof(Token));
            info.AddValue("TokenIndex", TokenIndex, typeof(int));
        }

        #endregion
    }
}
