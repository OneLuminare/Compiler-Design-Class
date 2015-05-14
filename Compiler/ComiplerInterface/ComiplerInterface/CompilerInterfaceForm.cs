using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using NFLanguageCompiler;
using DynamicBranchTree;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace CompilerInterface
{

    public partial class CompilerInterfaceForm : Form
    {

        #region Data Members

        Compiler compiler;
        private int symtblVars;
        private int symtblInts;
        private int symtblStrings;
        private int symtblBools;
        private int symtblMemory;
        private int block = 0;

        #endregion

        #region Constructors

        //Default constructor. Initialzes componets, compiler, and register events
        public CompilerInterfaceForm()
        {
            //Init controls
            InitializeComponent();

            //checkBoxShowMessages.Checked = false;

            //Init comipiler
            compiler = new Compiler();
            symtblVars = 0;
            symtblInts = 0;
            symtblStrings = 0;
            symtblBools = 0;
            symtblMemory = 0;

            //Register events
            /*
            compiler.Lexer.LexerMessageEvent += new MessageEventHandler(OutputGeneralMessages);
            compiler.Lexer.LexerMessageEvent += new MessageEventHandler(OutputLexerMessages);
            compiler.Parser.ParserMessageEvent += new MessageEventHandler(OutputGeneralMessages);
            compiler.Parser.ParserMessageEvent += new MessageEventHandler(OutputParserMessages);
            compiler.SymanticAnalyzer.SymanticAnalyzerMessageEvent += new MessageEventHandler(OutputGeneralMessages);
            compiler.SymanticAnalyzer.SymanticAnalyzerMessageEvent += new MessageEventHandler(OutputSymanticAnalyzerMessages);
             */
        }

        #endregion

        #region Compiler Event Handlers

        //Outputs all messages based on MessageEventHandler events
        private void OutputGeneralMessages(String msg)
        {
            textBoxGeneralMessages.AppendText(msg + '\n');
        }

        //Outputs lexer messages based on MessageEventHandler events
        private void OutputLexerMessages(String msg)
        {
            textBoxLexerMessages.AppendText(msg + '\n');
        }

        //Outputs parser messages based on MessageEventHandler events
        private void OutputParserMessages(String msg)
        {
            textBoxParserMessages.AppendText(msg + '\n');
        }

        // Outputs symantic messages base on MessageEventHandler events
        private void OutputSymanticAnalyzerMessages(String msg)
        {
            textBoxSymanticAnalyzerMessages.AppendText(msg + '\n');
        }

        // Ouputs op code gen messages
        private void OutputOpCodeGeneratorMessages(String msg)
        {
            textBoxOpCodeGenMessages.AppendText(msg + '\n');
        }

        #endregion

        #region General Methods

        //Output all warnings and errors to general list view control
        private void OutputGeneralWarningsAndErrors()
        {
            //Inits
            NFLanguageCompiler.Message msg = null;
            ListViewItem item = null;
            SystemType proc = SystemType.ST_NONE;
            
            //Clear warnings and errors
            listViewGeneralWarningsAndErrors.Items.Clear();

            //Output all warnings
            for (int i = 0; i < compiler.WarningCount; i++)
            {
                //Get Message object
                msg = compiler.GetWarning(i);

                //Get system type
                proc = msg.System;

                //Output lexer warnings 
                if (proc == SystemType.ST_LEXER)
                {
                    //Create listview item
                    item = new ListViewItem(proc.ToString());
                    item.SubItems.Add("Warning");
                    item.SubItems.Add(msg.Line.ToString());
                    item.SubItems.Add(msg.Column.ToString());
                    item.SubItems.Add("");
                    item.SubItems.Add("");
                    item.SubItems.Add("");
                    item.SubItems.Add(msg.Text);
                }
                else if( proc == SystemType.ST_PARSER )
                {

                    //Create listview item
                    item = new ListViewItem(proc.ToString());
                    item.SubItems.Add("Warning");
                    item.SubItems.Add(msg.Line.ToString());
                    item.SubItems.Add(msg.Column.ToString());
                    item.SubItems.Add(msg.Grammar.ToString());
                    if (msg.Token != null)
                        item.SubItems.Add(msg.Token.Type.ToString());
                    else
                        item.SubItems.Add("");
      
                    item.SubItems.Add(msg.TokenIndex.ToString());
                    item.SubItems.Add(msg.Text);
                }
                else if (proc == SystemType.ST_SYMANTICS)
                {
                    //Create listview item
                    item = new ListViewItem(proc.ToString());
                    item.SubItems.Add("Warning");
                    item.SubItems.Add(msg.Line.ToString());
                    item.SubItems.Add(msg.Column.ToString());
                    item.SubItems.Add(msg.Grammar.ToString());
                    item.SubItems.Add("");
                    item.SubItems.Add("");
                    item.SubItems.Add(msg.Text);
                }

                //Add item to list
                listViewGeneralWarningsAndErrors.Items.Add(item);
            }

            //Output all errors
            for (int i = 0; i < compiler.ErrorCount; i++)
            {
                //Get Message object
                msg = compiler.GetError(i);

                //Get system type
                proc = msg.System;

                //Output lexer warnings 
                if (proc == SystemType.ST_LEXER)
                {
                    //Create listview item
                    item = new ListViewItem(proc.ToString());
                    item.SubItems.Add("Error");
                    item.SubItems.Add(msg.Line.ToString());
                    item.SubItems.Add(msg.Column.ToString());
                    item.SubItems.Add("");
                    item.SubItems.Add("");
                    item.SubItems.Add("");
                    item.SubItems.Add(msg.Text);
                }
                else if (proc == SystemType.ST_PARSER)
                {
                    //Create listview item
                    item = new ListViewItem(proc.ToString());
                    item.SubItems.Add("Error");
                    item.SubItems.Add(msg.Line.ToString());
                    item.SubItems.Add(msg.Column.ToString());
                    item.SubItems.Add(msg.Grammar.ToString());
                    if (msg.Token != null)
                        item.SubItems.Add(msg.Token.Type.ToString());
                    else
                        item.SubItems.Add("");
                    item.SubItems.Add(msg.TokenIndex.ToString());
                    item.SubItems.Add(msg.Text);
                }
                else if (proc == SystemType.ST_SYMANTICS)
                {
                    //Create listview item
                    item = new ListViewItem(proc.ToString());
                    item.SubItems.Add("Error");
                    item.SubItems.Add(msg.Line.ToString());
                    item.SubItems.Add(msg.Column.ToString());
                    item.SubItems.Add(msg.Grammar.ToString());
                    item.SubItems.Add("");
                    item.SubItems.Add("");
                    item.SubItems.Add(msg.Text);
                }

                //Add to list
                listViewGeneralWarningsAndErrors.Items.Add(item);
            }
        }

        //Output all Lexer warning and errors to list view control
        private void OutputLexerWarningsAndErrors()
        {
            //Inits
            NFLanguageCompiler.Message msg = null;
            ListViewItem item = null;

            //Clear warnings and errors
            listViewLexerWarningsAndErrors.Items.Clear();

            //Output lexer warnings
            for (int i = 0; i < compiler.WarningCount; i++)
            {
                //Get Message object
                msg = compiler.GetWarning(i);

                //Verify lexer warning
                if (msg.System == SystemType.ST_LEXER)
                {
                    //Create list view item
                    item = new ListViewItem("Warning");
                    item.SubItems.Add(msg.Line.ToString());
                    item.SubItems.Add(msg.Column.ToString());
                    item.SubItems.Add(msg.Text);

                    //Add item
                    listViewLexerWarningsAndErrors.Items.Add(item);
                }
            }

            //Output all errors
            for (int i = 0; i < compiler.ErrorCount; i++)
            {
                //Get Message object
                msg = compiler.GetError(i);

                //Verify lexer warning
                if (msg.System == SystemType.ST_LEXER)
                {
                    //Createl list view item
                    item = new ListViewItem("Error");
                    item.SubItems.Add(msg.Line.ToString());
                    item.SubItems.Add(msg.Column.ToString());
                    item.SubItems.Add(msg.Text);

                    //Add item to list
                    listViewLexerWarningsAndErrors.Items.Add(item);
                }
            }
        }

        //Output all Parser warning and errors to list view control
        private void OutputParserWarningsAndErrors()
        {
            //Inits
            NFLanguageCompiler.Message msg = null;
            ListViewItem item = null;

            //Clear warnings and errors
            listViewParserWarningsAndErrors.Items.Clear();

            //Output parser warnings
            for (int i = 0; i < compiler.WarningCount; i++)
            {
                //Get Message object
                msg = compiler.GetWarning(i);

                //Verify parser warning
                if (msg.System == SystemType.ST_PARSER)
                {
                    //Create list view item
                    item = new ListViewItem("Warning");
                    item.SubItems.Add(msg.Grammar.ToString());
                    if (msg.Token != null)
                        item.SubItems.Add(msg.Token.Type.ToString());
                    else
                        item.SubItems.Add("");
                    item.SubItems.Add(msg.TokenIndex.ToString());
                    item.SubItems.Add(msg.Text);

                    //Add item
                    listViewParserWarningsAndErrors.Items.Add(item);
                }
            }

            //Output all errors
            for (int i = 0; i < compiler.ErrorCount; i++)
            {
                //Get Message object
                msg = compiler.GetError(i);

                //Verify parser warning
                if (msg.System == SystemType.ST_PARSER)
                {
                    //Createl list view item
                    item = new ListViewItem("Error");
                    item.SubItems.Add(msg.Grammar.ToString());
                    if (msg.Token != null)
                        item.SubItems.Add(msg.Token.Type.ToString());
                    else
                        item.SubItems.Add("");
                    item.SubItems.Add(msg.TokenIndex.ToString());
                    item.SubItems.Add(msg.Text);

                    //Add item to list
                    listViewParserWarningsAndErrors.Items.Add(item);
                }
            }
        }

        // Output all Symantic Analysis warnings and errors to list view control
        private void OutputSymanticAnalyzerWarningsAndErrors()
        {
            //Inits
            NFLanguageCompiler.Message msg = null;
            ListViewItem item = null;

            //Clear warnings and errors
            listViewParserWarningsAndErrors.Items.Clear();

            //Output parser warnings
            for (int i = 0; i < compiler.WarningCount; i++)
            {
                //Get Message object
                msg = compiler.GetWarning(i);

                //Verify parser warning
                if (msg.System == SystemType.ST_SYMANTICS)
                {
                    //Create list view item
                    item = new ListViewItem("Warning");
                    item.SubItems.Add(msg.Grammar.ToString());
                    item.SubItems.Add(msg.Line.ToString());
                    item.SubItems.Add(msg.Column.ToString());
                    item.SubItems.Add(msg.Text);

                    //Add item
                    listViewSymanticAnalyzerWarningsAndErrors.Items.Add(item);
                }
            }

            //Output all errors
            for (int i = 0; i < compiler.ErrorCount; i++)
            {
                //Get Message object
                msg = compiler.GetError(i);

                //Verify parser warning
                if (msg.System == SystemType.ST_SYMANTICS)
                {
                    //Createl list view item
                    item = new ListViewItem("Error");
                    item.SubItems.Add(msg.Grammar.ToString());
                    item.SubItems.Add(msg.Line.ToString());
                    item.SubItems.Add(msg.Column.ToString());
                    item.SubItems.Add(msg.Text);

                    //Add item to list

                    listViewSymanticAnalyzerWarningsAndErrors.Items.Add(item);
                }
            }
        }

        // Output all Symantic Analysis warnings and errors to list view control
        private void OutputOpCodeGenWarningsAndErrors()
        {
            //Inits
            NFLanguageCompiler.Message msg = null;
            ListViewItem item = null;

            //Clear warnings and errors
            listViewOpCodeGenWarningsErrors.Items.Clear();

            //Output parser warnings
            for (int i = 0; i < compiler.WarningCount; i++)
            {
                //Get Message object
                msg = compiler.GetWarning(i);

                //Verify parser warning
                if (msg.System == SystemType.ST_OPCODEGEN)
                {
                    //Create list view item
                    item = new ListViewItem("Warning");
                    item.SubItems.Add(msg.Text);

                    //Add item
                    listViewOpCodeGenWarningsErrors.Items.Add(item);
                }
            }

            //Output all errors
            for (int i = 0; i < compiler.ErrorCount; i++)
            {
                //Get Message object
                msg = compiler.GetError(i);

                //Verify parser warning
                if (msg.System == SystemType.ST_OPCODEGEN)
                {
                    //Createl list view item
                    item = new ListViewItem("Error");
                    item.SubItems.Add(msg.Text);

                    //Add item to list

                    listViewOpCodeGenWarningsErrors.Items.Add(item);
                }
            }
        }

        // Output all opcode gen warnings and errors
        //Resets all forms for new compilation
        private void ResetAllTabs(bool includeSource)
        {
            //If includeSource, remove those too
            if (includeSource)
                ResetSourceTab();
            //Else just remove output
            else
                ResetGeneralOutput();

            //Reset other systme output
            ResetLexOutput();
            ResetParseOutput();
            ResetSymanticOutput();
            ResetSymbolTableOutput();
        }

        //Resets source tab
        private void ResetSourceTab()
        {
            //Clear source box
            textBoxSource.Clear();

            //Clear output messages
            ResetGeneralOutput();
        }

        //Clear general output messages
        private void ResetGeneralOutput()
        {
            //Clear message boxes
            listViewGeneralWarningsAndErrors.Items.Clear();
            textBoxGeneralMessages.Clear();

            //Clear output messages
            labelGeneralWarningTotal.Text = "00";
            labelGeneralErrorTotal.Text = "00";
            labelCompilerReturnValue.Text = "";
            checkBoxLexerSuccess.Checked = false;
            checkBoxParserSuccess.Checked = false;
            checkBoxSyamnticsSuccess.Checked = false;
            checkBoxOptimizationSuccess.Checked = false;
            checkBoxCodeGenSuccess.Checked = false;
        }

        //Reset all lex tab controls
        private void ResetLexOutput()
        {
            //Reset controls
            listViewTokenList.Items.Clear();
            textBoxLexerMessages.Clear();
            listViewLexerWarningsAndErrors.Items.Clear();

            //Clear output messages
            labelLexerReturnValue.Text = "";
            labelLexerErrorTotal.Text = "00";
            labelLexerWarningsTotal.Text = "00";
        }

        //Reset all parse tab controls
        private void ResetParseOutput()
        {
            //Reset controls
            treeViewCST.Nodes.Clear();
            textBoxParserMessages.Clear();
            listViewParserWarningsAndErrors.Items.Clear();

            //Clear output messages
            labelParserReturnValue.Text = "";
            labelParserErrorTotal.Text = "00";
            labelParserWarningTotal.Text = "00";
        }

        //Resets symbol table output
        private void ResetSymbolTableOutput()
        {
            //Reset tree control
            treeViewSymbolTable.Nodes.Clear();

            //Reset internal counters for stats
            symtblVars = 0;
            symtblInts = 0;
            symtblStrings = 0;
            symtblBools = 0;
            symtblMemory = 0;
        }

        // Resets symantic tab output
        private void ResetSymanticOutput()
        {
            treeViewAST.Nodes.Clear();
            textBoxSymanticAnalyzerMessages.Clear();
            listViewSymanticAnalyzerWarningsAndErrors.Items.Clear();

            labelSymanticAnalyzerReturnValue.Text = "";
            labelSymanticAnalyzerErrorTotal.Text = "00";
            labelSymanticAnalyzerWarningTotal.Text = "00";
        }

        //Outputs token stream to listviewtokens
        private void OutputTokenSteam()
        {
            //Data Members
            ListViewItem  item = null;

            //Clear previous list
            listViewTokenList.Items.Clear();

            //Cycle through tokens
            foreach (Token tk in compiler.Lexer.OutputTokenStream)
            {
                //Create list view item
                item = new ListViewItem(tk.Type.ToString());
                item.SubItems.Add(tk.Line.ToString());
                item.SubItems.Add(tk.Column.ToString());
                item.SubItems.Add(tk.Value.ToString());

                //Add list item to list
                listViewTokenList.Items.Add(item);
            }
        }

        //Output CST to treeViewCST
        private void OutputCST()
        {
            //Inits
            DynamicBranchTreeNode<CSTValue> curNode = null;

            //Get root node
            curNode = compiler.Parser.CSTRootNode;

            //Begin tree view update
            treeViewCST.BeginUpdate();

            //Reset tree control
            treeViewCST.Nodes.Clear();

            //Start recursive output cst node
            treeViewCST.Nodes.Add(curNode.Data.ToString());
            OutputCSTNode(curNode, treeViewCST.Nodes[0]);

            //Expand all
            treeViewCST.ExpandAll();

            //End update(suppress paint)
            treeViewCST.EndUpdate();
        }

        //Recursive output tree view child nodes
        private void OutputCSTNode(DynamicBranchTreeNode<CSTValue> CSTNode,TreeNode treeNode)
        {
            //Inits
            int children = 0;
            DynamicBranchTreeNode<CSTValue> childNode = null;
            TreeNode parentTreeNode = null;

            //Get number of children
            
            children = CSTNode.NodeCount;

            

            //Cycle through children and add nodes
            for(int i = 0; i < children; i++)
            {
                //Get child node
                childNode = CSTNode.GetChild(i);

                //Add node
                parentTreeNode = treeNode.Nodes.Add(childNode.Data.ToString());

                //Add nodes children
                OutputCSTNode(childNode, parentTreeNode);
            }
        }

        //Output symbol table
        private void OutputSymbolTable()
        {
            //Inits
            DynamicBranchTreeNode<SymbolHashTable> curNode = compiler.SymanticAnalyzer.RootSymbolTableNode;

            

            //Begin tree control update
            treeViewSymbolTable.BeginUpdate();

            //Clear items
            treeViewSymbolTable.Nodes.Clear();

            // Check if root symbol table is not null
            if (curNode != null)
            {

                //Reset counters
                ResetSymbolTableCounters();

                //Output symbol table to tree controll
                treeViewSymbolTable.Nodes.Add(String.Format("Block {0}", block));
                OutputSymbolTableEntry(curNode, treeViewSymbolTable.Nodes[0]);

            }

            // Expand tree view 
            treeViewSymbolTable.ExpandAll();

            //End tree control update
            treeViewSymbolTable.EndUpdate();
            
            //Update stats (counted in recursive function to save a pass through nodes )
            labelTotalVarsValue.Text = symtblVars.ToString();
            labelTotalIntsValue.Text = symtblInts.ToString();
            labelTotalSringsValue.Text = symtblStrings.ToString();
            labelTotalBooleanValue.Text = symtblBools.ToString();
            labelMaxMemoryValue.Text = symtblMemory.ToString();
        }

        // Outputs AST tree nodes
        private void OutputAST()
        {
            // Inits
            ASTNode curNode = compiler.SymanticAnalyzer.RootASTNode;

            // Begin update
            treeViewAST.BeginUpdate();

            // Clear tree
            treeViewAST.Nodes.Clear();

            // Output base block node
            treeViewAST.Nodes.Add(curNode.ToString());
            OutputASTNode(curNode, treeViewAST.Nodes[0]);

            // Expand AST view
            treeViewAST.ExpandAll();

            // End update
            treeViewAST.EndUpdate();
        }

        // Recursive output ast tree nodes
        private void OutputASTNode(ASTNode node, TreeNode treeNode)
        {
            TreeNode childNode = null;
            ASTNode curNode = node.LeftMostChild;

            while(curNode != null)
            {
                childNode = treeNode.Nodes.Add(curNode.ToString());
                OutputASTNode(curNode, childNode);

                curNode = curNode.RightSibling;
            }
            /*
            // Switch AST Node type
            switch (node.NodeType)
            {
                // Case block
                case ASTNodeType.ASTTYPE_BLOCK:
                    break;
            }
             */
        }

        // Resets symbol table stat counters
        private void ResetSymbolTableCounters()
        {
            block = 0;
            symtblVars = 0;
            symtblInts = 0;
            symtblStrings = 0;
            symtblBools = 0;
            symtblMemory = 0;
        }

        // Recursive output symbol table entry function
        private void OutputSymbolTableEntry(DynamicBranchTreeNode<SymbolHashTable> entry, TreeNode treeNode)
        {
           
            //Inits
            SymbolHashTable hashSet = entry.Data;
            SymbolTableEntry[] entries = hashSet.GetAllItems();
            TreeNode newNode = null;

            //Output hash set
            foreach (SymbolTableEntry symEntry in entries)
            {
                //Add each entry to node
                treeNode.Nodes.Add( symEntry.ToString() );

                //Collect data

                //Inc var count
                symtblVars++;

                //Check for int type
                if( symEntry.DataType == DataType.DT_INT )
                {
                    //Inc int type count
                    symtblInts++;

                    //Inc memory 1 byte
                    symtblMemory++;
                }
                //Check for string type
                else if( symEntry.DataType == DataType.DT_STRING )
                {
                    //Inc total strings type counter
                    symtblStrings++;

                    //Incrmeent memory 1 byte for each char
                    symtblMemory += (symEntry.StringValue.Length);
                }
                //Check for boolean type
                else if( symEntry.DataType == DataType.DT_BOOLEAN )
                {
                    //Inc bool type counter
                    symtblBools++;

                    //Increment max memory 1 byte
                    symtblMemory++;
                }
            }

            //Cycle through children nodes, and call recursive function
            for( int i = 0; i < entry.NodeCount; i++ )
            {
                //Increment block
                block++;

                //Create a new block node title
                newNode = treeNode.Nodes.Add(String.Format("Block {0}", block));

                //Call recursive function on child
                OutputSymbolTableEntry(entry.GetChild(i), newNode);
            }
        }

        // Toggle output op codes to file
        private void ToggleOutputOPCodesToFile(bool show)
        {
            outputOpCodesToFileToolStripMenuItem.Checked = show;
            compiler.OpCodeGen.OutputOpCodesToFile = show;
        }

        // Toggles show parse error change option
        private void ToggleShowParseErrorChain(bool show)
        {
            showParseErrorChainToolStripMenuItem.Checked = show;
            compiler.Parser.ShowErrorChain = show;
        }

        // Toggles show messages option.
        private void ToggleShowMessages(bool show)
        {
            // Toggle menu check
            showMessagesToolStripMenuItem.Checked = show;

            if (show)
            {
                //Register events
                compiler.Lexer.LexerGeneralMessageEvent -= OutputGeneralMessages;
                compiler.Lexer.LexerGeneralMessageEvent -= OutputLexerMessages;
                compiler.Lexer.LexerMessageEvent += new MessageEventHandler(OutputGeneralMessages);
                compiler.Lexer.LexerMessageEvent += new MessageEventHandler(OutputLexerMessages);
                compiler.Parser.ParserGeneralMessageEvent -= OutputGeneralMessages;
                compiler.Parser.ParserGeneralMessageEvent -= OutputParserMessages;
                compiler.Parser.ParserMessageEvent += new MessageEventHandler(OutputGeneralMessages);
                compiler.Parser.ParserMessageEvent += new MessageEventHandler(OutputParserMessages);
                compiler.SymanticAnalyzer.SymanticAnalyzerGeneralMessageEvent -= OutputGeneralMessages;
                compiler.SymanticAnalyzer.SymanticAnalyzerGeneralMessageEvent -= OutputSymanticAnalyzerMessages;
                compiler.SymanticAnalyzer.SymanticAnalyzerMessageEvent += new MessageEventHandler(OutputGeneralMessages);
                compiler.SymanticAnalyzer.SymanticAnalyzerMessageEvent += new MessageEventHandler(OutputSymanticAnalyzerMessages);
            }
            else
            {
                //Unregister events
                compiler.Lexer.LexerGeneralMessageEvent += new MessageEventHandler(OutputGeneralMessages);
                compiler.Lexer.LexerGeneralMessageEvent += new MessageEventHandler(OutputLexerMessages);
                compiler.Lexer.LexerMessageEvent -= OutputGeneralMessages;
                compiler.Lexer.LexerMessageEvent -= OutputLexerMessages;
                compiler.Parser.ParserGeneralMessageEvent += new MessageEventHandler(OutputGeneralMessages);
                compiler.Parser.ParserGeneralMessageEvent += new MessageEventHandler(OutputParserMessages);
                compiler.Parser.ParserMessageEvent -= OutputGeneralMessages;
                compiler.Parser.ParserMessageEvent -= OutputParserMessages;
                compiler.SymanticAnalyzer.SymanticAnalyzerGeneralMessageEvent += new MessageEventHandler(OutputGeneralMessages);
                compiler.SymanticAnalyzer.SymanticAnalyzerGeneralMessageEvent += new MessageEventHandler(OutputSymanticAnalyzerMessages);
                compiler.SymanticAnalyzer.SymanticAnalyzerMessageEvent -= OutputGeneralMessages;
                compiler.SymanticAnalyzer.SymanticAnalyzerMessageEvent -= OutputSymanticAnalyzerMessages;
            }
        }

        // Compile source code. Calls all comipler processes, outputs deliverables,
        // and shows waning/error messages.
        private void Compile()
        {
            //Inits
            bool error = false;
            bool noComplete = false;
            int phase = 0;

            //Clear last output messages
            ResetAllTabs(false);

            //Compile from source
            compiler.Compile(textBoxSource.Text);

            //Check if lex returned errors
            if (compiler.LexerReturnValue == ProcessReturnValue.PRV_ERRORS)
            {
                //Set error flag to true
                error = true;
            }
            //Check if no lex due to empty source file
            else if (compiler.LexerReturnValue == ProcessReturnValue.PRV_NONE)
            {
                //Set no complete flag to true
                noComplete = true;
            }

            //If complete, output token stream and errors
            if (!noComplete)
            {
                //Output token stream
                OutputTokenSteam();

                //Ouput general warnings and errors
                OutputGeneralWarningsAndErrors();

                //Output lex warning and errors
                OutputLexerWarningsAndErrors();

                //Set lex complete
                checkBoxLexerSuccess.Checked = true;

                //Increment phase
                phase = 1;
            }
            //If not complete empty source, message user
            else
            {
                //Message user
                MessageBox.Show("Empty source, only token is EOF. No program can be created.", "Lex Error");
            }

            //Check if no errors or nocomplete to parse
            if (!error && !noComplete)
            {
                //Check if parser returned errors
                if (compiler.ParserReturnValue == ProcessReturnValue.PRV_ERRORS)
                {
                    //Set error flag to true
                    error = true;
                }
                //Check if no parse due to empty token stream
                else if (compiler.ParserReturnValue == ProcessReturnValue.PRV_NONE)
                {
                    //Set no complete flag to true
                    noComplete = true;
                }

                //If complete, output token stream and errors
                if (!noComplete)
                {

                    //Output CST
                    OutputCST();

                    //Ouput general warnings and errors
                    OutputParserWarningsAndErrors();

                    //Set lex complete
                    checkBoxParserSuccess.Checked = true;

                    //Increment phase
                    phase = 2;
                }
                //If not complete empty source, message user
                else
                {
                    //Message user
                    MessageBox.Show("Empty token stream. No program can be created.", "Parse Error");
                }
            }

            // Perform Symantic Analyzis if no errors
            if (!error && !noComplete)
            {
                // Set error flag on error
                if (compiler.SymanticReturnValue == ProcessReturnValue.PRV_ERRORS)
                {
                    error = true;
                }
                else if (compiler.SymanticReturnValue == ProcessReturnValue.PRV_NONE)
                {
                    noComplete = true;
                }


                // Output warnigns and errors
                OutputSymanticAnalyzerWarningsAndErrors();

                // Output AST
                OutputAST();

                // Output updated symbol table
                OutputSymbolTable();

                // Set check flag on process
                if (!error)
                    checkBoxSyamnticsSuccess.Checked = true;

                // Set phase 
                phase = 3;
            }

            // Check if no Symantic Analysis errors 
            if (!error && !noComplete)
            {
                // Set error flag on error
                if (compiler.OptimizationReturnValue == ProcessReturnValue.PRV_ERRORS)
                    error = true;
                else if (compiler.OptimizationReturnValue == ProcessReturnValue.PRV_NONE)
                    noComplete = true;

                // Output op codes
                OutputOpCodes();

                // Output errors and warnings
                OutputOpCodeGenerationWarningsErrors();

                // Check if no error
                if (!error)
                {
                    // Check process complete flag 
                    checkBoxOptimizationSuccess.Checked = true;
                    checkBoxCodeGenSuccess.Checked = true;

                    // Check if ooutput op code to file option is set
                    if (compiler.OpCodeGen.OutputOpCodesToFile)
                        OutputOpCodesToFile();
                }

                // Set phase indiator
                phase = 4;
            }

            //Check if at least lex passed
            if (phase >= 1)
            {
                //Output lex warnings and error count
                labelLexerWarningsTotal.Text = String.Format("{0,2}", compiler.Lexer.WarningCount);
                labelLexerErrorTotal.Text = String.Format("{0,2}", compiler.Lexer.ErrorCount);


                //Ouput lex return value with errors
                if (compiler.LexerReturnValue == ProcessReturnValue.PRV_ERRORS)
                {
                    labelLexerReturnValue.Text = "Lexer returned with errors.";
                    labelCompilerReturnValue.Text = "Lexer returned with errors.\n Cannot Parse.";
                }
                //Else if warnings output lex return value with warnings
                else if (compiler.LexerReturnValue == ProcessReturnValue.PRV_WARNINGS)
                {
                    labelLexerReturnValue.Text = "Lexer returned successfully, but with warnings.";
                    labelCompilerReturnValue.Text = "Lexer returned successfully, but with warnings.";
                }
                //Else if warnings output lex return value with warnings
                else if (compiler.LexerReturnValue == ProcessReturnValue.PRV_OK)
                {
                    labelLexerReturnValue.Text = "Lexer completed successfully.";
                    labelCompilerReturnValue.Text = "Lexer completed successfully.";
                }
            }

            //Check if parse and lex passed
            if (phase >= 2)
            {
                //Output lex warnings and error count
                labelParserWarningTotal.Text = String.Format("{0,2}", compiler.Parser.WarningCount);
                labelParserErrorTotal.Text = String.Format("{0,2}", compiler.Parser.ErrorCount);

                //Ouput lex return value with errors
                if (compiler.ParserReturnValue == ProcessReturnValue.PRV_ERRORS)
                {
                    labelParserReturnValue.Text = "Parse returned with errors.";
                    labelCompilerReturnValue.Text = "Parse returned with errors. \nCan not perform Symantic Analysis.";
                }
                //Else if warnings output lex return value with warnings
                else if (compiler.ParserReturnValue == ProcessReturnValue.PRV_WARNINGS)
                {
                    labelParserReturnValue.Text = "Parse returned successfully, but with warnings.";
                    labelCompilerReturnValue.Text = "Parse returned successfully, but with warnings.";
                }
                //Else if warnings output lex return value with warnings
                else if (compiler.ParserReturnValue == ProcessReturnValue.PRV_OK)
                {
                    labelParserReturnValue.Text = "Parse completed successfully.";
                    labelCompilerReturnValue.Text = "Parse completed successfully.";
                }
            }

            // Check if parse, lex, and symantics passed
            if (phase >= 3)
            {
                //Output warnings and error count for symantics
                labelSymanticAnalyzerWarningTotal.Text = String.Format("{0,2}", compiler.SymanticAnalyzer.WarningCount);
                labelSymanticAnalyzerErrorTotal.Text = String.Format("{0,2}", compiler.SymanticAnalyzer.ErrorCount);

                //Output return values for symantics and compiler
                if (compiler.SymanticReturnValue == ProcessReturnValue.PRV_ERRORS)
                {
                    labelSymanticAnalyzerReturnValue.Text = "Symantic Analysis returned with errors.";
                    labelCompilerReturnValue.Text = "Symantic Analyzer returned with errors. \nCan not perform Code Generation.";
                }
                //Output return values for symantics and compiler
                else if (compiler.SymanticReturnValue == ProcessReturnValue.PRV_WARNINGS)
                {
                    labelSymanticAnalyzerReturnValue.Text = "Symantic Analysis returned successfully, but with warnings.";
                    labelCompilerReturnValue.Text = "Symantic Analyzer returned successfully, but with warnings.";
                }
                //Output return values for symantics and compiler
                else if (compiler.SymanticReturnValue == ProcessReturnValue.PRV_OK)
                {
                    labelSymanticAnalyzerReturnValue.Text = "Symantic Analysis returned successfully.";
                    labelCompilerReturnValue.Text = "Symantic Analyzer returned successfully.";
                }
            }

            // Check if parse, lex, and symantics passed
            if (phase >= 4)
            {
                //Output warnings and error count for symantics
                labelOpCodeGenWarnings.Text = String.Format("{0,2}", compiler.OpCodeGen.WarningCount);
                labelOpCodeGenErrors.Text = String.Format("{0,2}", compiler.OpCodeGen.ErrorCount);

                //Output return values for symantics and compiler
                if (compiler.OpCodeGenerationReturnValue == ProcessReturnValue.PRV_ERRORS)
                {
                    labelOpCodeGenProcessReturnValue.Text = "Code Generation returned with errors.";
                    labelCompilerReturnValue.Text = "Code Generation returned with errors.";
                }
                //Output return values for symantics and compiler
                else if (compiler.OpCodeGenerationReturnValue == ProcessReturnValue.PRV_WARNINGS)
                {
                    labelOpCodeGenProcessReturnValue.Text = "Code Generation returned successfully, but with warnings.";
                    labelCompilerReturnValue.Text = "Code Generation returned successfully, but with warnings.";
                }
                //Output return values for symantics and compiler
                else if (compiler.OpCodeGenerationReturnValue == ProcessReturnValue.PRV_OK)
                {
                    labelOpCodeGenProcessReturnValue.Text = "Code Generation returned successfully.";
                    labelCompilerReturnValue.Text = "Code Generation returned successfully.";
                }
            }



            //TODO ERROR WARNING RETURN VALUES

            // Output total errors and warnings
            labelGeneralErrorTotal.Text = String.Format("{0,2}", compiler.ErrorCount);
            labelGeneralWarningTotal.Text = String.Format("{0,2}", compiler.WarningCount);

            //Check if invalid source
            if (phase == 10)
            {
                labelCompilerReturnValue.Text = "Empty source file. Could not continue.";
                labelLexerReturnValue.Text = "Lexer returned with errors.";
            }
        }

        // Outputs op codes to text area
        private void OutputOpCodes()
        {
            /* DEBUGGING CODE 
            BlockSizeTableEntry entry = null;
            textBoxOpCodes.Text = "";
            for (int i = 0; i < compiler.OpCodeGen.blockSizeTable.Count; i++)
            {
                entry = (BlockSizeTableEntry)compiler.OpCodeGen.blockSizeTable[i];
                textBoxOpCodes.Text += String.Format("Block ID: {0} Start Byte: {1} End Byte: {2}", entry.BlockID, entry.StartByte, entry.EndByte);
            }
             * */

            /*
            textBoxOpCodes.Text = "";

            int n = 0;
            while (n < compiler.OpCodeGen.OpCodeData.Length)
            {
                if ((n + 16) < compiler.OpCodeGen.OpCodeData.Length)
                {
                    textBoxOpCodes.Text += compiler.OpCodeGen.OpCodeData.Substring(n, 16);
                    n = n + 16;
                }
                else
                {
                    textBoxOpCodes.Text += compiler.OpCodeGen.OpCodeData.Substring(n, (compiler.OpCodeGen.OpCodeData.Length - n));
                    n = compiler.OpCodeGen.OpCodeData.Length;
                }

                textBoxOpCodes.Text += '\n';
            }
             * */

            textBoxOpCodes.Text = "";

            int nBytesPerLine = 5;
            StringBuilder sb = new StringBuilder(256);
            for (int i = 0; i < compiler.OpCodeGen.ProgramData.totalBytes; i++)
            {
                sb.AppendFormat("{0} ", compiler.OpCodeGen.OpCodeDataBytes[i].ToString("X2"));

                if ( ((i + 1) % nBytesPerLine) == 0)
                    sb.Append("\r\n");
            }

            textBoxOpCodes.Text = sb.ToString();

        }

        // Outputs op code gen warings and errors
        public void OutputOpCodeGenerationWarningsErrors()
        {
        }

        // Outputs generated op codes to file
        public void OutputOpCodesToFile()
        {
        }

        #endregion

        #region Control Event Handlers

        //Reset all output and source box
        private void buttonReset_Click(object sender, EventArgs e)
        {
            ResetAllTabs(true);
        }

        // Compiles source
        private void buttonCompile_Click(object sender, EventArgs e)
        {
            Compile();
        }

        //Toggle token stream to file option on clicked
        private void checkBoxOutputOpCodesToFile_CheckedChanged(object sender, EventArgs e)
        {
            ToggleOutputOPCodesToFile(checkBoxOutputOpCodesToFile.Checked);
        }

        //Toggles show all parse error chain or just first error
        private void checkBoxShowParseErrorChain_CheckedChanged(object sender, EventArgs e)
        {
            ToggleShowParseErrorChain(checkBoxShowParseErrorChain.Checked);
        }

        //Toggles enabling message events to speed up compilation
        private void checkBoxShowMessages_CheckedChanged(object sender, EventArgs e)
        {
            ToggleShowMessages(checkBoxShowMessages.Checked);
        }

        // Saves source file
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Inits
            String filePath = null;
            StreamWriter sw = null;
            FileStream file = null;

            // Create save dialog, starting in MyDocuuments
            SaveFileDialog dlgSave = new SaveFileDialog();
            dlgSave.Title = "Save Source File";
            dlgSave.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
            dlgSave.Filter = "Text Files(*.txt) |*.txt";

            //Open save dialog and check for ok
            if (dlgSave.ShowDialog() == DialogResult.OK)
            {
                // Get save location
                filePath = dlgSave.FileName;

                try
                {
                    // Create file and open stream writer
                    file = new FileStream(filePath, FileMode.CreateNew);
                    sw = new StreamWriter(file);

                    sw.Write(textBoxSource.Text);
                }

                catch (IOException ex)
                {
                    //Show MessageBox describing error
                    MessageBox.Show(String.Format("Error \"{0}\" occurred saving file '{1}'", ex.Message, filePath)
                        , "File Error");
                }

                finally
                {
                    if (sw != null)
                        sw.Close();
                    file.Close();
                }
            }

            dlgSave.Dispose();
        }

        // Opens source file
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Inits
            String filePath = null;

            //Create file dialog, starting in MyDocuments
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Title = "Open Source File";
            dlgOpen.Filter = "Text Files(*.txt)|*.txt|All Files(*,*)|*.*";
            dlgOpen.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();

            //Open dialog and check for OK
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                //Get file path
                filePath = dlgOpen.FileName;

                //Data members
                StreamReader sr = null;
                FileStream file = null;

                //Try open file
                try
                {
                    //Create file stream and open
                    file = new FileStream(filePath, FileMode.Open);

                    //Create stream reader
                    sr = new StreamReader(file);

                    //Read entire file into string
                    String line = sr.ReadToEnd();

                    //Put text into input box
                    textBoxSource.Text = line;
                }

                //Catch IOException, and message user
                catch (IOException ex)
                {
                    //Show MessageBox describing error
                    MessageBox.Show(String.Format("Error \"{0}\" occurred opening file '{1}'", ex.Message, filePath)
                        , "File Error");
                }

                //Make sure file is closed
                finally
                {
                    //If stream reader is not null, close stream reader and stream
                    if (sr != null)
                        sr.Close();

                    file.Close();
                }
            }

            //Dispose of OpenFileDialog
            dlgOpen.Dispose();

        }


        // Exits app
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Compiles source
        private void compileSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Compile();
        }

        // Toggles show messages compiler option
        private void showMessagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleShowMessages(showMessagesToolStripMenuItem.Checked);
        }

        // Toggles show parse error chain compiler option
        private void showParseErrorChainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleShowParseErrorChain(showParseErrorChainToolStripMenuItem.Checked);
        }

        // Toggles output op codes to file compiler option
        private void outputOpCodesToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleOutputOPCodesToFile(outputOpCodesToFileToolStripMenuItem.Checked);
        }

        // Shows general help
        private void generalHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        // Shows grammar 
        private void grammarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        // Resets all compiler tabs
        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetAllTabs(true);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {

        }

        #endregion

      



    }
}
