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

        #region Overrides

        public override string ToString()
        {
            String s = null;
            if (this.Token != null)
            {
                if( Grammar == GrammarProcess.GP_NONE )
                    s = String.Format("{0}       Value: {1}", this.Token.Type.ToString(),this.Token.Value.ToString());
                else
                    s = String.Format("{0} {1}", Grammar.ToString(),this.Token.Type.ToString());
            }
            else
                s = Grammar.ToString();

            return s;
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
