using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace NFLanguageCompiler
{
    #region Types

    // Describes system type for use in warning and error messages.
    public enum SystemType 
    {
        ST_LEXER,
        ST_PARSER,
        ST_NONE
    };

    // Describes process return values
    public enum ProcessReturnValue
    {
        PRV_OK,
        PRV_WARNINGS,
        PRV_ERRORS,
        PRV_NONE
    }

    #endregion

    #region Delegates

    // Describes methods that handle message events
    public delegate void MessageEventHandler(String message);

    // Describes methods that handle warnings and errors
    public delegate void WarningErrorEventHandler(Message msg);

    #endregion

    // Compiler object contains all systems of the compilation process.
    // Controlls the entires process, records warnings/errors, and handles
    // data logging. Ultimate output is machine code.
    public class Compiler
    {
        #region Data Members

        public Lexer Lexer;
        public Parser Parser;
        private ArrayList WarningList;
        private ArrayList ErrorList;

        #endregion

        #region Properties

        //Current run lexer return value
        public ProcessReturnValue LexerReturnValue
        {
            get; set;
        }

        //Current run parser return value
        public ProcessReturnValue ParserReturnValue
        {
            get;
            set;
        }

        //Current run symantics return value
        public ProcessReturnValue SymanticReturnValue
        {
            get;
            set;
        }

        //Current run optimization return value
        public ProcessReturnValue OptimizationReturnValue
        {
            get;
            set;
        }

        //Current run code generation return value
        public ProcessReturnValue CodeGenerationReturnValue
        {
            get;
            set;
        }

        // Returns error list coun. Read only.
        public int ErrorCount
        {
            get
            {
                return ErrorList.Count;
            }
        }

        // Returns warning list count. Read only.
        public int WarningCount
        {
            get
            {
                return WarningList.Count;
            }
        }

        #endregion

        #region Constructor

        // Default constructor. Initiazlies data members, and register events.
        public Compiler()
        {
            //Init objects
            Lexer = new Lexer();
            Parser = new Parser();
            WarningList = new ArrayList();
            ErrorList = new ArrayList();

            //Reset run values
            ResetData();
            
            //Register events
            Lexer.LexerWarningEvent += new WarningErrorEventHandler(AddWarning);
            Lexer.LexerErrorEvent += new WarningErrorEventHandler(AddError);
            Parser.ParserWarningEvent += new WarningErrorEventHandler(AddWarning);
            Parser.ParserErrorEvent += new WarningErrorEventHandler(AddError);
        }

        #endregion

        #region Warning and Error Access Methods

        // Add warning to list
        public void AddWarning(Message message)
        {
            WarningList.Add(message);
        }

        // Get warning from list by index.
        // Throws: IndexOutOfRangeException
        public Message GetWarning(int index)
        {
            if (index >= WarningList.Count)
                throw new IndexOutOfRangeException("Warning list index out of bounds.");
            else
                return (Message)WarningList[index];
        }
        
        // Clear warning list
        public void ClearWarnings()
        {
            WarningList.Clear();
        }

        // Add error to list
        public void AddError(Message message)
        {
            ErrorList.Add(message);
        }

        // Get error by index. 
        // Throws: IndexOutOfRangeException
        public Message GetError(int index)
        {
            if (index >= ErrorList.Count)
                throw new IndexOutOfRangeException("Error list index out of bounds.");
            else
                return (Message)ErrorList[index];
        }
        
        // Clear error list
        public void ClearErrors()
        {
            ErrorList.Clear();
        }

        #endregion

        #region Methods

        //Resets system return values and warning/error lists
        private void ResetData()
        {
            //Reset return values
            LexerReturnValue = ProcessReturnValue.PRV_NONE;
            ParserReturnValue = ProcessReturnValue.PRV_NONE;
            SymanticReturnValue = ProcessReturnValue.PRV_NONE;
            OptimizationReturnValue = ProcessReturnValue.PRV_NONE;
            CodeGenerationReturnValue = ProcessReturnValue.PRV_NONE;

            //Reset warning and error lists
            WarningList.Clear();
            ErrorList.Clear();
        }

        // Compiler code. Goes through all phases of compilation,
        // records output, return values, warnings, and errors.
        // Takes source file as one string.
        public void Compile(String sourceText)
        {
            //Reset data
            ResetData();

            //Lex
            LexerReturnValue = Lexer.LexFromString(sourceText);

            //Parse if no errors
            if (LexerReturnValue != ProcessReturnValue.PRV_ERRORS)
                ParserReturnValue = Parser.Parse(Lexer.OutputTokenStream);
        }

        #endregion

    }
}
