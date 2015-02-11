using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AlanLanguageCompiler;

namespace CompilerInterface
{
    public partial class CompilerInterfaceForm : Form
    {
        //Inits

        Lexer lexer;

        //Constuctor

        public CompilerInterfaceForm()
        {
            InitializeComponent();
            lexer = new Lexer();
        }

        //Event Handlers

        private void buttonLex_Click(object sender, EventArgs e)
        {
            //Add output event handler to display in text box
           lexer.LexerOutputEvent += new Lexer.LexerEventHandler(outputEventHandler);

            //Clear last output messages
           textBoxMessages.Clear();

            //Lex from source
            lexer.LexFromString(textBoxInput.Text);

            //Output token stream
            listViewTokens.Items.Clear();
            foreach( Token tk in lexer.OutputTokenStream)
            {
                ListViewItem item = new ListViewItem(tk.Type.ToString());
                item.SubItems.Add(tk.Line.ToString());
                item.SubItems.Add(tk.Column.ToString());
                item.SubItems.Add(tk.Value);

                listViewTokens.Items.Add(item);
            }
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {

        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {

        }

        public void outputEventHandler(String msg)
        {
            textBoxMessages.AppendText(msg + '\n');
        }

        
    }
}
