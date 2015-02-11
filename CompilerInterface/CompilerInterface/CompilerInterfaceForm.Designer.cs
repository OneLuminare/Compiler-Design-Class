namespace CompilerInterface
{
    partial class CompilerInterfaceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.buttonLex = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSource = new System.Windows.Forms.TextBox();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.textBoxMessages = new System.Windows.Forms.TextBox();
            this.labelMessages = new System.Windows.Forms.Label();
            this.listViewTokens = new System.Windows.Forms.ListView();
            this.columnHeaderToken = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderLine = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderColumn = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderValue = new System.Windows.Forms.ColumnHeader();
            this.labelTokens = new System.Windows.Forms.Label();
            this.Source = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxInput
            // 
            this.textBoxInput.Location = new System.Drawing.Point(12, 71);
            this.textBoxInput.Multiline = true;
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxInput.Size = new System.Drawing.Size(316, 419);
            this.textBoxInput.TabIndex = 0;
            // 
            // buttonLex
            // 
            this.buttonLex.Location = new System.Drawing.Point(601, 654);
            this.buttonLex.Name = "buttonLex";
            this.buttonLex.Size = new System.Drawing.Size(75, 23);
            this.buttonLex.TabIndex = 2;
            this.buttonLex.Text = "Lex";
            this.buttonLex.UseVisualStyleBackColor = true;
            this.buttonLex.Click += new System.EventHandler(this.buttonLex_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Load Source :";
            // 
            // textBoxSource
            // 
            this.textBoxSource.Location = new System.Drawing.Point(92, 26);
            this.textBoxSource.Name = "textBoxSource";
            this.textBoxSource.Size = new System.Drawing.Size(420, 20);
            this.textBoxSource.TabIndex = 4;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(599, 24);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 5;
            this.buttonLoad.Text = "L&oad";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(518, 24);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowse.TabIndex = 6;
            this.buttonBrowse.Text = "&Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // textBoxMessages
            // 
            this.textBoxMessages.Location = new System.Drawing.Point(12, 519);
            this.textBoxMessages.Multiline = true;
            this.textBoxMessages.Name = "textBoxMessages";
            this.textBoxMessages.ReadOnly = true;
            this.textBoxMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxMessages.Size = new System.Drawing.Size(658, 129);
            this.textBoxMessages.TabIndex = 7;
            // 
            // labelMessages
            // 
            this.labelMessages.AutoSize = true;
            this.labelMessages.Location = new System.Drawing.Point(12, 503);
            this.labelMessages.Name = "labelMessages";
            this.labelMessages.Size = new System.Drawing.Size(55, 13);
            this.labelMessages.TabIndex = 8;
            this.labelMessages.Text = "Messages";
            // 
            // listViewTokens
            // 
            this.listViewTokens.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderToken,
            this.columnHeaderLine,
            this.columnHeaderColumn,
            this.columnHeaderValue});
            this.listViewTokens.Location = new System.Drawing.Point(348, 71);
            this.listViewTokens.Name = "listViewTokens";
            this.listViewTokens.Size = new System.Drawing.Size(326, 419);
            this.listViewTokens.TabIndex = 9;
            this.listViewTokens.UseCompatibleStateImageBehavior = false;
            this.listViewTokens.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderToken
            // 
            this.columnHeaderToken.Text = "Token";
            this.columnHeaderToken.Width = 180;
            // 
            // columnHeaderLine
            // 
            this.columnHeaderLine.Text = "Line";
            this.columnHeaderLine.Width = 40;
            // 
            // columnHeaderColumn
            // 
            this.columnHeaderColumn.Text = "Col";
            this.columnHeaderColumn.Width = 40;
            // 
            // columnHeaderValue
            // 
            this.columnHeaderValue.Text = "Value";
            this.columnHeaderValue.Width = 200;
            // 
            // labelTokens
            // 
            this.labelTokens.AutoSize = true;
            this.labelTokens.Location = new System.Drawing.Point(345, 55);
            this.labelTokens.Name = "labelTokens";
            this.labelTokens.Size = new System.Drawing.Size(74, 13);
            this.labelTokens.TabIndex = 10;
            this.labelTokens.Text = "Token Stream";
            // 
            // Source
            // 
            this.Source.AutoSize = true;
            this.Source.Location = new System.Drawing.Point(12, 55);
            this.Source.Name = "Source";
            this.Source.Size = new System.Drawing.Size(41, 13);
            this.Source.TabIndex = 11;
            this.Source.Text = "Source";
            // 
            // CompilerInterfaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 689);
            this.Controls.Add(this.Source);
            this.Controls.Add(this.labelTokens);
            this.Controls.Add(this.listViewTokens);
            this.Controls.Add(this.labelMessages);
            this.Controls.Add(this.textBoxMessages);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.textBoxSource);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonLex);
            this.Controls.Add(this.textBoxInput);
            this.Name = "CompilerInterfaceForm";
            this.Text = "Compiler Interface";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Button buttonLex;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSource;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.TextBox textBoxMessages;
        private System.Windows.Forms.Label labelMessages;
        private System.Windows.Forms.ListView listViewTokens;
        private System.Windows.Forms.ColumnHeader columnHeaderToken;
        private System.Windows.Forms.ColumnHeader columnHeaderLine;
        private System.Windows.Forms.ColumnHeader columnHeaderColumn;
        private System.Windows.Forms.ColumnHeader columnHeaderValue;
        private System.Windows.Forms.Label labelTokens;
        private System.Windows.Forms.Label Source;
    }
}

