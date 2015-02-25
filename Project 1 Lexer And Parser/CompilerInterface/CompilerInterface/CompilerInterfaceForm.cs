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
        bool optionSaveErrorsToFile;
        bool optionSaveTokenStreamToFile;

        #endregion

        #region Constructors

        //Default constructor. Initialzes componets, compiler, and register events
        public CompilerInterfaceForm()
        {
            //Init controls
            InitializeComponent();

            //Init comipiler
            compiler = new Compiler();
            optionSaveErrorsToFile = false;
            optionSaveTokenStreamToFile = false;

            //Register events
            compiler.Lexer.LexerMessageEvent += new MessageEventHandler(OutputGeneralMessages);
            compiler.Lexer.LexerMessageEvent += new MessageEventHandler(OutputLexerMessages);
            compiler.Parser.ParserMessageEvent += new MessageEventHandler(OutputGeneralMessages);
            compiler.Parser.ParserMessageEvent += new MessageEventHandler(OutputParserMessages);
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
                    item.SubItems.Add("");
                    item.SubItems.Add("");
                    item.SubItems.Add(msg.Grammar.ToString());
                    if (msg.Token != null)
                        item.SubItems.Add(msg.Token.Type.ToString());
                    else
                        item.SubItems.Add("");
      
                    item.SubItems.Add(msg.TokenIndex.ToString());
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
                    item.SubItems.Add("");
                    item.SubItems.Add("");
                    item.SubItems.Add(msg.Grammar.ToString());
                    if (msg.Token != null)
                        item.SubItems.Add(msg.Token.Type.ToString());
                    else
                        item.SubItems.Add("");
                    item.SubItems.Add(msg.TokenIndex.ToString());
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

        #endregion

        #region Control Event Handlers

        //Locates file, and place location in source text box.
        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            //Create file dialog, starting in MyDocuments
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Title = "Open Source File";
            dlgOpen.Filter = "Text Files(*.txt)|*.txt|All Files(*,*)|*.*";
            dlgOpen.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();

            //Open dialog and check for OK
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                //Put file location in source box
                textBoxSourceFilePath.Text = dlgOpen.FileName;
            }

            //Dispose of OpenFileDialog
            dlgOpen.Dispose();
        }

        // Load file location in source text box.
        //
        // Throws: IOException
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            // Check if trimmed location is not empty
            if (textBoxSourceFilePath.Text.Trim() != String.Empty)
            {
                //Data members
                StreamReader sr = null;

                //Try open file
                try
                {
                    //Create file stream and open
                    FileStream file = new FileStream(textBoxSourceFilePath.Text, FileMode.Open);

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
                    MessageBox.Show(String.Format("Error \"{0}\" occurred opening file '{1}'",ex.Message,textBoxSourceFilePath.Text)
                        ,"File Error");
                }

                //Make sure file is closed
                finally
                {
                    //If stream reader is not null, close stream reader and stream
                    if( sr != null )
                        sr.Close();
                }
            }
        }

        //Reset all output and source box
        private void buttonReset_Click(object sender, EventArgs e)
        {
            ResetAllTabs(true);
        }

        private void buttonCompile_Click(object sender, EventArgs e)
        {
            //Inits
            bool error = false;
            bool noComplete = false;
            int phase = 10;

            //Clear last output messages
            ResetAllTabs(false);

            //Compile from source
            compiler.Compile(textBoxSource.Text);

            //Check if lex returned errors
            if (compiler.LexerReturnValue == ProcessReturnValue.PRV_ERRORS )
            {
                //Set error flag to true
                error = true;
            }
            //Check if no lex due to empty source file
            else if(compiler.LexerReturnValue == ProcessReturnValue.PRV_NONE )
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
            
            //Check if at least lex passed
            if (phase < 2)
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
                    labelLexerReturnValue.Text = "Lexer returned with warnings.";
                    labelCompilerReturnValue.Text = "Lexer returned with warnings.";
                }
                //Else if warnings output lex return value with warnings
                else if (compiler.LexerReturnValue == ProcessReturnValue.PRV_OK)
                {
                    labelLexerReturnValue.Text = "Lexer completed successfully.";
                    labelCompilerReturnValue.Text = "Lexer completed successfully.";
                }
            }

            //Check if parse and lex passed
            if (phase < 3)
            {
                //Output lex warnings and error count
                labelParserWarningTotal.Text = String.Format("{0,2}", compiler.Parser.WarningCount);
                labelParserErrorTotal.Text = String.Format("{0,2}", compiler.Parser.ErrorCount);

                //Ouput lex return value with errors
                if (compiler.ParserReturnValue == ProcessReturnValue.PRV_ERRORS)
                {
                    labelParserReturnValue.Text = "Parse returned with errors.";
                    labelCompilerReturnValue.Text = "Parse returned with errors.";
                }
                //Else if warnings output lex return value with warnings
                else if (compiler.ParserReturnValue == ProcessReturnValue.PRV_WARNINGS)
                {
                    labelParserReturnValue.Text = "Parse returned with warnings.";
                    labelCompilerReturnValue.Text = "Parse returned with warnings.";
                }
                //Else if warnings output lex return value with warnings
                else if (compiler.ParserReturnValue == ProcessReturnValue.PRV_OK)
                {
                    labelParserReturnValue.Text = "Parse completed successfully.";
                    labelCompilerReturnValue.Text = "Parse completed successfully.";
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
 
        //Toggle error to file option on clicked
        private void checkBoxOutputErrorsToFile_CheckedChanged(object sender, EventArgs e)
        {
            optionSaveErrorsToFile = !optionSaveErrorsToFile;
        }

        //Toggle token stream to file option on clicked
        private void checkBoxOutputOpCodesToFile_CheckedChanged(object sender, EventArgs e)
        {
            optionSaveTokenStreamToFile = !optionSaveTokenStreamToFile;
        }

        #endregion

        #region Old Code

        /*
        private void button1_Click(object sender, EventArgs e)
        {
            string s = "C:\\Test\\Test.tst";
            FileStream sf = new FileStream(s,FileMode.Create);
            IFormatter f = new BinaryFormatter();

            f.Serialize(sf, compiler.lexer.OutputTokenStream);
            sf.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = "C:\\Test\\Test.tst";
            FileStream sf = new FileStream(s, FileMode.Open);
            IFormatter f = new BinaryFormatter();

            compiler.lexer.OutputTokenStream = (TokenStream)f.Deserialize(sf);

            //Output token stream
            listViewTokens.Items.Clear();
            foreach (Token tk in compiler.lexer.OutputTokenStream)
            {
                ListViewItem item = new ListViewItem(tk.Type.ToString());
                item.SubItems.Add(tk.Line.ToString());
                item.SubItems.Add(tk.Column.ToString());
                item.SubItems.Add(tk.Value.ToString());

                listViewTokens.Items.Add(item);
            }
            sf.Close();
        }

        */
        #endregion
        
    }
}
