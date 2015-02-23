using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace NFLanguageCompiler
{
    //Stores value for CST tree. Simply a grammar process id and token if needed.
    //
    //Interfaces: ISerializeable
    [Serializable]
    public class CSTValue : ISerializable
    {
        #region Properties

        //Stores grammar process id
        public GrammarProcess Grammar
        {
            get;
            set;
        }

        //Optionall stores token
        public Token Token
        {
            get;
            set;
        }

        #endregion

        #region Constructor

        //Default constructor, inits values
        public CSTValue()
            :this(GrammarProcess.GP_NONE,null)
        {
        }

        //Input constructor
        public CSTValue(GrammarProcess grammar)
            : this(grammar,null)
        {
        }

        //Master input construtor
        public CSTValue(GrammarProcess grammar, Token token)
        {
            Grammar = grammar;
            Token = token;
        }

        //Deserialization construcotr. 
        public CSTValue(SerializationInfo info, StreamingContext context)
        {
            Grammar = (GrammarProcess)info.GetValue("Grammar", typeof(GrammarProcess));
            Token = (Token)info.GetValue("Token", typeof(Token));
        }

        #endregion

        #region Methods

        //Resets values
        public void Clear()
        {
            Grammar = GrammarProcess.GP_NONE;
            Token = null;
        }

        #endregion

        #region ISerializable Members

        //Describes object for serialization. ISerializeable member.
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Grammar", Grammar, typeof(GrammarProcess));
            info.AddValue("Token", Token, typeof(Token));
        }

        #endregion
    }
}
