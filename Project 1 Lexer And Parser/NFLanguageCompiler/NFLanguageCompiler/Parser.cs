using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public Parser()
        {
        }

        #endregion

        #region Parsing Methods

        public ProcessReturnValue Parse(TokenStream tokenStream)
        {
            return ProcessReturnValue.PRV_NONE;
        }

        #endregion
    }
}
