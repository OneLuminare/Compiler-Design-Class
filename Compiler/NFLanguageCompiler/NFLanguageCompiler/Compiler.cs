﻿using System;
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
        ST_SYMANTICS,
        ST_OPCODEGEN,
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

    // Describes data type
    public enum DataType
    {
        DT_INT,
        DT_STRING,
        DT_BOOLEAN,
        DT_NONE
    }

    // Describes grammer process
    public enum GrammarProcess
    {
        GP_PROGRAM,
        GP_BLOCK,
        GP_STATEMENT,
        GP_STATEMENTLIST,
        GP_PRINTSTATEMENT,
        GP_ASSIGNMENTSTATEMENT,
        GP_VARDEC,
        GP_WHILESTATEMENT,
        GP_IFSTATEMENT,
        GP_EXPR,
        GP_INTEXPR,
        GP_STRINGEXPR,
        GP_BOOLEANEXPR,
        GP_ID,
        GP_CHARLIST,
        GP_TYPE,
        GP_CHAR,
        GP_SPACE,
        GP_DIGIT,
        GP_BOOLOP,
        GP_INTOP,
        GP_BOOLVAL,
        GP_LAMDA,
        GP_NONE
    }

    //Custome parse exception thrown on error
    public class ParseException : Exception
    {
        //Default constructor
        public ParseException()
        {
        }

        //Constructor calls base
        public ParseException(String msg)
            : base(msg)
        {
        }
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
        public SymanticAnalyzer SymanticAnalyzer;
        public OpCodeGenerator OpCodeGen;
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
        public ProcessReturnValue OpCodeGenerationReturnValue
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
            SymanticAnalyzer = new SymanticAnalyzer();
            OpCodeGen = new OpCodeGenerator();
            WarningList = new ArrayList();
            ErrorList = new ArrayList();

            //Reset run values
            ResetData();
            
            //Register events
            Lexer.LexerWarningEvent += new WarningErrorEventHandler(AddWarning);
            Lexer.LexerErrorEvent += new WarningErrorEventHandler(AddError);
            Parser.ParserWarningEvent += new WarningErrorEventHandler(AddWarning);
            Parser.ParserErrorEvent += new WarningErrorEventHandler(AddError);
            SymanticAnalyzer.SymanticAnalyzerWarningEvent += new WarningErrorEventHandler(AddWarning);
            SymanticAnalyzer.SymanticAnalyzerErrorEvent += new WarningErrorEventHandler(AddError);
            OpCodeGen.OpCodeGenWarningEvent += new WarningErrorEventHandler(AddWarning);
            OpCodeGen.OpCodeGenErrorEvent += new WarningErrorEventHandler(AddError);

        }

        #endregion

        #region Warning and Error Access Methods

        // Add warning to list from lexer
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
            OpCodeGenerationReturnValue = ProcessReturnValue.PRV_NONE;

            //Reset warning and error lists
            WarningList.Clear();
            ErrorList.Clear();
        }

        // Compiler code. Goes through all phases of compilation,
        // records output, return values, warnings, and errors.
        // Takes source file as one string.
        public void Compile(String sourceText)
        {
            // Inits
            bool errors = false;

            //Reset data
            ResetData();

            //Lex
            LexerReturnValue = Lexer.LexFromString(sourceText);
            if (LexerReturnValue == ProcessReturnValue.PRV_ERRORS)
                errors = true;

            //Parse if no errors
            if (!errors)
            {
                ParserReturnValue = Parser.Parse(Lexer.OutputTokenStream);
                if (ParserReturnValue == ProcessReturnValue.PRV_ERRORS)
                    errors = true;
            }

            

           // Analyze Symantics if no errors
            if (!errors)
            {
                SymanticReturnValue = SymanticAnalyzer.AnalyzeSymantics(Parser.CSTRootNode);
                if (SymanticReturnValue == ProcessReturnValue.PRV_ERRORS)
                    errors = true;
            }

            // Generate code if no errors
            
           if (!errors)
               OpCodeGenerationReturnValue = OpCodeGen.GenerateOpCodes(SymanticAnalyzer.RootASTNode
                   , SymanticAnalyzer.RootSymbolTableNode);
             
        }

        #endregion

    }
}
