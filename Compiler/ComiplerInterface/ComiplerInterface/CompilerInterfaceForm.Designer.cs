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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompilerInterfaceForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compileSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showMessagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputOpCodesToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyOpCodesToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grammarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.tabPageCodeGeneration = new System.Windows.Forms.TabPage();
            this.groupBoxDisplay = new System.Windows.Forms.GroupBox();
            this.spinnerDisplayedBytesPerRow = new System.Windows.Forms.NumericUpDown();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.lblBytesPerRow = new System.Windows.Forms.Label();
            this.groupBoxProgramData = new System.Windows.Forms.GroupBox();
            this.lblHeapSizeBytes = new System.Windows.Forms.Label();
            this.lblStackSizeBytes = new System.Windows.Forms.Label();
            this.lblLengthBytes = new System.Windows.Forms.Label();
            this.lblHeapSize = new System.Windows.Forms.Label();
            this.lblStackSize = new System.Windows.Forms.Label();
            this.lblHeapStart = new System.Windows.Forms.Label();
            this.lblStackStart = new System.Windows.Forms.Label();
            this.lblHeapSizeLabel = new System.Windows.Forms.Label();
            this.lblHeapStartLabel = new System.Windows.Forms.Label();
            this.lblStackSizeLabel = new System.Windows.Forms.Label();
            this.lblStackStartLabel = new System.Windows.Forms.Label();
            this.lblLength = new System.Windows.Forms.Label();
            this.lblLengthLabel = new System.Windows.Forms.Label();
            this.textBoxOpCodes = new System.Windows.Forms.TextBox();
            this.textBoxOpCodeGenMessages = new System.Windows.Forms.TextBox();
            this.labelOpCodesLabel = new System.Windows.Forms.Label();
            this.labelOpCodGenMessagesLabel = new System.Windows.Forms.Label();
            this.labelOpCodeGenErrors = new System.Windows.Forms.Label();
            this.labelOpCodeGenErrorsLabel = new System.Windows.Forms.Label();
            this.labelOpCodeGenWarnings = new System.Windows.Forms.Label();
            this.labelOpCodeGenWarningsLabel = new System.Windows.Forms.Label();
            this.labelOpCodeGenProcessReturnValue = new System.Windows.Forms.Label();
            this.labelOpCodeGenProcessReturnValueLabel = new System.Windows.Forms.Label();
            this.labelOpCodeGenWarningsAndErrorsLabel = new System.Windows.Forms.Label();
            this.listViewOpCodeGenWarningsErrors = new System.Windows.Forms.ListView();
            this.columnHeaderOpCodeGenType = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderOpCodeGenMessage = new System.Windows.Forms.ColumnHeader();
            this.tabPageSymbolTable = new System.Windows.Forms.TabPage();
            this.labelBytes = new System.Windows.Forms.Label();
            this.labelMaxMemoryValue = new System.Windows.Forms.Label();
            this.labelMaxMemory = new System.Windows.Forms.Label();
            this.labelTotalBooleanValue = new System.Windows.Forms.Label();
            this.labelTotalBoolean = new System.Windows.Forms.Label();
            this.labelTotalSringsValue = new System.Windows.Forms.Label();
            this.labelTotalStrings = new System.Windows.Forms.Label();
            this.labelTotalIntsValue = new System.Windows.Forms.Label();
            this.labelTotalInts = new System.Windows.Forms.Label();
            this.labelTotalVarsValue = new System.Windows.Forms.Label();
            this.labelTotalVars = new System.Windows.Forms.Label();
            this.treeViewSymbolTable = new System.Windows.Forms.TreeView();
            this.labelSymbolTable = new System.Windows.Forms.Label();
            this.tabPageSymantics = new System.Windows.Forms.TabPage();
            this.labelSymanticAnalyzerWarningsErrors = new System.Windows.Forms.Label();
            this.listViewSymanticAnalyzerWarningsAndErrors = new System.Windows.Forms.ListView();
            this.chSAType = new System.Windows.Forms.ColumnHeader();
            this.chSAGrammar = new System.Windows.Forms.ColumnHeader();
            this.chSALine = new System.Windows.Forms.ColumnHeader();
            this.chSAColumn = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.textBoxSymanticAnalyzerMessages = new System.Windows.Forms.TextBox();
            this.labelSymanticAnalyzerErrorTotal = new System.Windows.Forms.Label();
            this.labelSymanticAnalyzerErrorCountLabel = new System.Windows.Forms.Label();
            this.labelSymanticAnalyzerWarningTotal = new System.Windows.Forms.Label();
            this.labelSymanticAnalyzerWarningCountLabel = new System.Windows.Forms.Label();
            this.labelSymanticAnalyzerReturnValue = new System.Windows.Forms.Label();
            this.labelSyamanticAnalyzerReturnValueLabel = new System.Windows.Forms.Label();
            this.labelAST = new System.Windows.Forms.Label();
            this.labelSymanticAnalyzerMessages = new System.Windows.Forms.Label();
            this.treeViewAST = new System.Windows.Forms.TreeView();
            this.tabPageParse = new System.Windows.Forms.TabPage();
            this.labelCST = new System.Windows.Forms.Label();
            this.labelParserMessage = new System.Windows.Forms.Label();
            this.labelParserWarningError = new System.Windows.Forms.Label();
            this.listViewParserWarningsAndErrors = new System.Windows.Forms.ListView();
            this.columnHeaderParseType = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderParseGrammar = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderParseToken = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderParseTokenIndex = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderParseMessages = new System.Windows.Forms.ColumnHeader();
            this.textBoxParserMessages = new System.Windows.Forms.TextBox();
            this.labelParserErrorTotal = new System.Windows.Forms.Label();
            this.labelParserErrorLabel = new System.Windows.Forms.Label();
            this.labelParserWarningTotal = new System.Windows.Forms.Label();
            this.labelParserWarningLabel = new System.Windows.Forms.Label();
            this.labelParserReturnValue = new System.Windows.Forms.Label();
            this.labelParserReturnValueLabel = new System.Windows.Forms.Label();
            this.treeViewCST = new System.Windows.Forms.TreeView();
            this.tabPageLexer = new System.Windows.Forms.TabPage();
            this.labelLexerErrorTotal = new System.Windows.Forms.Label();
            this.labelLexerErrorLabel = new System.Windows.Forms.Label();
            this.labelLexerWarningsTotal = new System.Windows.Forms.Label();
            this.labelLexerMessages = new System.Windows.Forms.Label();
            this.textBoxLexerMessages = new System.Windows.Forms.TextBox();
            this.labelLexerWarningsLabel = new System.Windows.Forms.Label();
            this.labelLexerWarningErrors = new System.Windows.Forms.Label();
            this.listViewLexerWarningsAndErrors = new System.Windows.Forms.ListView();
            this.columnHeaderLexerType = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderLexerLine = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderLexerColumn = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderLexerMessage = new System.Windows.Forms.ColumnHeader();
            this.labelLexerReturnValue = new System.Windows.Forms.Label();
            this.labelLexerReturnValueLabel = new System.Windows.Forms.Label();
            this.labelTokenStreamLabel = new System.Windows.Forms.Label();
            this.listViewTokenList = new System.Windows.Forms.ListView();
            this.columnHeaderToken = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderLine = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderColumn = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderValue = new System.Windows.Forms.ColumnHeader();
            this.tabPageSource = new System.Windows.Forms.TabPage();
            this.labelGeneralErrorTotal = new System.Windows.Forms.Label();
            this.labelGeneralErrorLabel = new System.Windows.Forms.Label();
            this.labelGeneralWarningTotal = new System.Windows.Forms.Label();
            this.labelGeneralWarningLabel = new System.Windows.Forms.Label();
            this.buttonReset = new System.Windows.Forms.Button();
            this.labelCompilerReturnValue = new System.Windows.Forms.Label();
            this.labelCompilerReturnValueLabel = new System.Windows.Forms.Label();
            this.groupBoxOptions = new System.Windows.Forms.GroupBox();
            this.checkBoxCopyOpCodesToClipboard = new System.Windows.Forms.CheckBox();
            this.checkBoxShowMessages = new System.Windows.Forms.CheckBox();
            this.checkBoxOutputOpCodesToFile = new System.Windows.Forms.CheckBox();
            this.groupBoxProcess = new System.Windows.Forms.GroupBox();
            this.checkBoxCodeGenSuccess = new System.Windows.Forms.CheckBox();
            this.checkBoxOptimizationSuccess = new System.Windows.Forms.CheckBox();
            this.checkBoxSyamnticsSuccess = new System.Windows.Forms.CheckBox();
            this.checkBoxParserSuccess = new System.Windows.Forms.CheckBox();
            this.checkBoxLexerSuccess = new System.Windows.Forms.CheckBox();
            this.buttonCompile = new System.Windows.Forms.Button();
            this.textBoxSource = new System.Windows.Forms.TextBox();
            this.textBoxGeneralMessages = new System.Windows.Forms.TextBox();
            this.labelWarningError = new System.Windows.Forms.Label();
            this.labelGeneralMessages = new System.Windows.Forms.Label();
            this.listViewGeneralWarningsAndErrors = new System.Windows.Forms.ListView();
            this.columnHeaderGeneralSystem = new System.Windows.Forms.ColumnHeader();
            this.columnHeadGeneralType = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderGeneralLine = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderGeneralCol = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderGeneralGrammar = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderGeneralToken = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderGeneralTokenIndex = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderGeneralMsg = new System.Windows.Forms.ColumnHeader();
            this.labelSource = new System.Windows.Forms.Label();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.menuStrip1.SuspendLayout();
            this.tabPageCodeGeneration.SuspendLayout();
            this.groupBoxDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinnerDisplayedBytesPerRow)).BeginInit();
            this.groupBoxProgramData.SuspendLayout();
            this.tabPageSymbolTable.SuspendLayout();
            this.tabPageSymantics.SuspendLayout();
            this.tabPageParse.SuspendLayout();
            this.tabPageLexer.SuspendLayout();
            this.tabPageSource.SuspendLayout();
            this.groupBoxOptions.SuspendLayout();
            this.groupBoxProcess.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.compileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(790, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // compileToolStripMenuItem
            // 
            this.compileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.compileSourceToolStripMenuItem,
            this.resetToolStripMenuItem});
            this.compileToolStripMenuItem.Name = "compileToolStripMenuItem";
            this.compileToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.compileToolStripMenuItem.Text = "Compile";
            // 
            // compileSourceToolStripMenuItem
            // 
            this.compileSourceToolStripMenuItem.Name = "compileSourceToolStripMenuItem";
            this.compileSourceToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.C)));
            this.compileSourceToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.compileSourceToolStripMenuItem.Text = "Compile Source";
            this.compileSourceToolStripMenuItem.Click += new System.EventHandler(this.compileSourceToolStripMenuItem_Click);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showMessagesToolStripMenuItem,
            this.outputOpCodesToFileToolStripMenuItem,
            this.copyOpCodesToClipboardToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // showMessagesToolStripMenuItem
            // 
            this.showMessagesToolStripMenuItem.Name = "showMessagesToolStripMenuItem";
            this.showMessagesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.showMessagesToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.showMessagesToolStripMenuItem.Text = "Show Detailed Messages";
            this.showMessagesToolStripMenuItem.Click += new System.EventHandler(this.showMessagesToolStripMenuItem_Click);
            // 
            // outputOpCodesToFileToolStripMenuItem
            // 
            this.outputOpCodesToFileToolStripMenuItem.Name = "outputOpCodesToFileToolStripMenuItem";
            this.outputOpCodesToFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.outputOpCodesToFileToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.outputOpCodesToFileToolStripMenuItem.Text = "Output Op Codes To File";
            this.outputOpCodesToFileToolStripMenuItem.Click += new System.EventHandler(this.outputOpCodesToFileToolStripMenuItem_Click);
            // 
            // copyOpCodesToClipboardToolStripMenuItem
            // 
            this.copyOpCodesToClipboardToolStripMenuItem.Name = "copyOpCodesToClipboardToolStripMenuItem";
            this.copyOpCodesToClipboardToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.copyOpCodesToClipboardToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.copyOpCodesToClipboardToolStripMenuItem.Text = "Copy Op Codes To Clipboard";
            this.copyOpCodesToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyOpCodesToClipboardToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.grammarToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // grammarToolStripMenuItem
            // 
            this.grammarToolStripMenuItem.Name = "grammarToolStripMenuItem";
            this.grammarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.grammarToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.grammarToolStripMenuItem.Text = "NF Langauge Grammar";
            this.grammarToolStripMenuItem.Click += new System.EventHandler(this.grammarToolStripMenuItem_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Type";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Grammar Process";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Line";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Column";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Message";
            this.columnHeader6.Width = 807;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Type";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Grammar Process";
            this.columnHeader8.Width = 100;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Line";
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Column";
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Message";
            this.columnHeader11.Width = 807;
            // 
            // tabPageCodeGeneration
            // 
            this.tabPageCodeGeneration.Controls.Add(this.groupBoxDisplay);
            this.tabPageCodeGeneration.Controls.Add(this.groupBoxProgramData);
            this.tabPageCodeGeneration.Controls.Add(this.textBoxOpCodes);
            this.tabPageCodeGeneration.Controls.Add(this.textBoxOpCodeGenMessages);
            this.tabPageCodeGeneration.Controls.Add(this.labelOpCodesLabel);
            this.tabPageCodeGeneration.Controls.Add(this.labelOpCodGenMessagesLabel);
            this.tabPageCodeGeneration.Controls.Add(this.labelOpCodeGenErrors);
            this.tabPageCodeGeneration.Controls.Add(this.labelOpCodeGenErrorsLabel);
            this.tabPageCodeGeneration.Controls.Add(this.labelOpCodeGenWarnings);
            this.tabPageCodeGeneration.Controls.Add(this.labelOpCodeGenWarningsLabel);
            this.tabPageCodeGeneration.Controls.Add(this.labelOpCodeGenProcessReturnValue);
            this.tabPageCodeGeneration.Controls.Add(this.labelOpCodeGenProcessReturnValueLabel);
            this.tabPageCodeGeneration.Controls.Add(this.labelOpCodeGenWarningsAndErrorsLabel);
            this.tabPageCodeGeneration.Controls.Add(this.listViewOpCodeGenWarningsErrors);
            this.tabPageCodeGeneration.Location = new System.Drawing.Point(4, 22);
            this.tabPageCodeGeneration.Name = "tabPageCodeGeneration";
            this.tabPageCodeGeneration.Size = new System.Drawing.Size(785, 685);
            this.tabPageCodeGeneration.TabIndex = 5;
            this.tabPageCodeGeneration.Text = "Code Generation";
            this.tabPageCodeGeneration.UseVisualStyleBackColor = true;
            // 
            // groupBoxDisplay
            // 
            this.groupBoxDisplay.Controls.Add(this.spinnerDisplayedBytesPerRow);
            this.groupBoxDisplay.Controls.Add(this.buttonUpdate);
            this.groupBoxDisplay.Controls.Add(this.lblBytesPerRow);
            this.groupBoxDisplay.Location = new System.Drawing.Point(474, 221);
            this.groupBoxDisplay.Name = "groupBoxDisplay";
            this.groupBoxDisplay.Size = new System.Drawing.Size(265, 55);
            this.groupBoxDisplay.TabIndex = 14;
            this.groupBoxDisplay.TabStop = false;
            this.groupBoxDisplay.Text = "Display";
            // 
            // spinnerDisplayedBytesPerRow
            // 
            this.spinnerDisplayedBytesPerRow.Location = new System.Drawing.Point(145, 21);
            this.spinnerDisplayedBytesPerRow.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.spinnerDisplayedBytesPerRow.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinnerDisplayedBytesPerRow.Name = "spinnerDisplayedBytesPerRow";
            this.spinnerDisplayedBytesPerRow.Size = new System.Drawing.Size(44, 20);
            this.spinnerDisplayedBytesPerRow.TabIndex = 3;
            this.spinnerDisplayedBytesPerRow.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(195, 20);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(64, 23);
            this.buttonUpdate.TabIndex = 2;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // lblBytesPerRow
            // 
            this.lblBytesPerRow.AutoSize = true;
            this.lblBytesPerRow.Location = new System.Drawing.Point(6, 25);
            this.lblBytesPerRow.Name = "lblBytesPerRow";
            this.lblBytesPerRow.Size = new System.Drawing.Size(132, 13);
            this.lblBytesPerRow.TabIndex = 1;
            this.lblBytesPerRow.Text = "Displayed Bytes Per Row :";
            // 
            // groupBoxProgramData
            // 
            this.groupBoxProgramData.Controls.Add(this.lblHeapSizeBytes);
            this.groupBoxProgramData.Controls.Add(this.lblStackSizeBytes);
            this.groupBoxProgramData.Controls.Add(this.lblLengthBytes);
            this.groupBoxProgramData.Controls.Add(this.lblHeapSize);
            this.groupBoxProgramData.Controls.Add(this.lblStackSize);
            this.groupBoxProgramData.Controls.Add(this.lblHeapStart);
            this.groupBoxProgramData.Controls.Add(this.lblStackStart);
            this.groupBoxProgramData.Controls.Add(this.lblHeapSizeLabel);
            this.groupBoxProgramData.Controls.Add(this.lblHeapStartLabel);
            this.groupBoxProgramData.Controls.Add(this.lblStackSizeLabel);
            this.groupBoxProgramData.Controls.Add(this.lblStackStartLabel);
            this.groupBoxProgramData.Controls.Add(this.lblLength);
            this.groupBoxProgramData.Controls.Add(this.lblLengthLabel);
            this.groupBoxProgramData.Location = new System.Drawing.Point(474, 107);
            this.groupBoxProgramData.Name = "groupBoxProgramData";
            this.groupBoxProgramData.Size = new System.Drawing.Size(265, 104);
            this.groupBoxProgramData.TabIndex = 13;
            this.groupBoxProgramData.TabStop = false;
            this.groupBoxProgramData.Text = "Program Data";
            // 
            // lblHeapSizeBytes
            // 
            this.lblHeapSizeBytes.AutoSize = true;
            this.lblHeapSizeBytes.Location = new System.Drawing.Point(213, 74);
            this.lblHeapSizeBytes.Name = "lblHeapSizeBytes";
            this.lblHeapSizeBytes.Size = new System.Drawing.Size(32, 13);
            this.lblHeapSizeBytes.TabIndex = 25;
            this.lblHeapSizeBytes.Text = "bytes";
            // 
            // lblStackSizeBytes
            // 
            this.lblStackSizeBytes.AutoSize = true;
            this.lblStackSizeBytes.Location = new System.Drawing.Point(213, 49);
            this.lblStackSizeBytes.Name = "lblStackSizeBytes";
            this.lblStackSizeBytes.Size = new System.Drawing.Size(32, 13);
            this.lblStackSizeBytes.TabIndex = 24;
            this.lblStackSizeBytes.Text = "bytes";
            // 
            // lblLengthBytes
            // 
            this.lblLengthBytes.AutoSize = true;
            this.lblLengthBytes.Location = new System.Drawing.Point(98, 25);
            this.lblLengthBytes.Name = "lblLengthBytes";
            this.lblLengthBytes.Size = new System.Drawing.Size(32, 13);
            this.lblLengthBytes.TabIndex = 23;
            this.lblLengthBytes.Text = "bytes";
            // 
            // lblHeapSize
            // 
            this.lblHeapSize.AutoSize = true;
            this.lblHeapSize.Location = new System.Drawing.Point(188, 74);
            this.lblHeapSize.Name = "lblHeapSize";
            this.lblHeapSize.Size = new System.Drawing.Size(19, 13);
            this.lblHeapSize.TabIndex = 22;
            this.lblHeapSize.Text = "00";
            // 
            // lblStackSize
            // 
            this.lblStackSize.AutoSize = true;
            this.lblStackSize.Location = new System.Drawing.Point(188, 49);
            this.lblStackSize.Name = "lblStackSize";
            this.lblStackSize.Size = new System.Drawing.Size(19, 13);
            this.lblStackSize.TabIndex = 21;
            this.lblStackSize.Text = "00";
            // 
            // lblHeapStart
            // 
            this.lblHeapStart.AutoSize = true;
            this.lblHeapStart.Location = new System.Drawing.Point(74, 74);
            this.lblHeapStart.Name = "lblHeapStart";
            this.lblHeapStart.Size = new System.Drawing.Size(19, 13);
            this.lblHeapStart.TabIndex = 20;
            this.lblHeapStart.Text = "00";
            // 
            // lblStackStart
            // 
            this.lblStackStart.AutoSize = true;
            this.lblStackStart.Location = new System.Drawing.Point(74, 49);
            this.lblStackStart.Name = "lblStackStart";
            this.lblStackStart.Size = new System.Drawing.Size(19, 13);
            this.lblStackStart.TabIndex = 19;
            this.lblStackStart.Text = "00";
            // 
            // lblHeapSizeLabel
            // 
            this.lblHeapSizeLabel.AutoSize = true;
            this.lblHeapSizeLabel.Location = new System.Drawing.Point(120, 74);
            this.lblHeapSizeLabel.Name = "lblHeapSizeLabel";
            this.lblHeapSizeLabel.Size = new System.Drawing.Size(62, 13);
            this.lblHeapSizeLabel.TabIndex = 18;
            this.lblHeapSizeLabel.Text = "Heap Size :";
            // 
            // lblHeapStartLabel
            // 
            this.lblHeapStartLabel.AutoSize = true;
            this.lblHeapStartLabel.Location = new System.Drawing.Point(8, 74);
            this.lblHeapStartLabel.Name = "lblHeapStartLabel";
            this.lblHeapStartLabel.Size = new System.Drawing.Size(64, 13);
            this.lblHeapStartLabel.TabIndex = 17;
            this.lblHeapStartLabel.Text = "Heap Start :";
            // 
            // lblStackSizeLabel
            // 
            this.lblStackSizeLabel.AutoSize = true;
            this.lblStackSizeLabel.Location = new System.Drawing.Point(118, 49);
            this.lblStackSizeLabel.Name = "lblStackSizeLabel";
            this.lblStackSizeLabel.Size = new System.Drawing.Size(64, 13);
            this.lblStackSizeLabel.TabIndex = 16;
            this.lblStackSizeLabel.Text = "Stack Size :";
            // 
            // lblStackStartLabel
            // 
            this.lblStackStartLabel.AutoSize = true;
            this.lblStackStartLabel.Location = new System.Drawing.Point(6, 49);
            this.lblStackStartLabel.Name = "lblStackStartLabel";
            this.lblStackStartLabel.Size = new System.Drawing.Size(66, 13);
            this.lblStackStartLabel.TabIndex = 15;
            this.lblStackStartLabel.Text = "Stack Start :";
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Location = new System.Drawing.Point(74, 25);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(19, 13);
            this.lblLength.TabIndex = 14;
            this.lblLength.Text = "00";
            // 
            // lblLengthLabel
            // 
            this.lblLengthLabel.AutoSize = true;
            this.lblLengthLabel.Location = new System.Drawing.Point(26, 25);
            this.lblLengthLabel.Name = "lblLengthLabel";
            this.lblLengthLabel.Size = new System.Drawing.Size(46, 13);
            this.lblLengthLabel.TabIndex = 12;
            this.lblLengthLabel.Text = "Length :";
            // 
            // textBoxOpCodes
            // 
            this.textBoxOpCodes.Location = new System.Drawing.Point(9, 33);
            this.textBoxOpCodes.Multiline = true;
            this.textBoxOpCodes.Name = "textBoxOpCodes";
            this.textBoxOpCodes.ReadOnly = true;
            this.textBoxOpCodes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxOpCodes.Size = new System.Drawing.Size(446, 478);
            this.textBoxOpCodes.TabIndex = 11;
            // 
            // textBoxOpCodeGenMessages
            // 
            this.textBoxOpCodeGenMessages.Location = new System.Drawing.Point(474, 305);
            this.textBoxOpCodeGenMessages.Multiline = true;
            this.textBoxOpCodeGenMessages.Name = "textBoxOpCodeGenMessages";
            this.textBoxOpCodeGenMessages.ReadOnly = true;
            this.textBoxOpCodeGenMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxOpCodeGenMessages.Size = new System.Drawing.Size(299, 206);
            this.textBoxOpCodeGenMessages.TabIndex = 8;
            // 
            // labelOpCodesLabel
            // 
            this.labelOpCodesLabel.AutoSize = true;
            this.labelOpCodesLabel.Location = new System.Drawing.Point(9, 9);
            this.labelOpCodesLabel.Name = "labelOpCodesLabel";
            this.labelOpCodesLabel.Size = new System.Drawing.Size(54, 13);
            this.labelOpCodesLabel.TabIndex = 10;
            this.labelOpCodesLabel.Text = "Op Codes";
            // 
            // labelOpCodGenMessagesLabel
            // 
            this.labelOpCodGenMessagesLabel.AutoSize = true;
            this.labelOpCodGenMessagesLabel.Location = new System.Drawing.Point(474, 289);
            this.labelOpCodGenMessagesLabel.Name = "labelOpCodGenMessagesLabel";
            this.labelOpCodGenMessagesLabel.Size = new System.Drawing.Size(55, 13);
            this.labelOpCodGenMessagesLabel.TabIndex = 9;
            this.labelOpCodGenMessagesLabel.Text = "Messages";
            // 
            // labelOpCodeGenErrors
            // 
            this.labelOpCodeGenErrors.AutoSize = true;
            this.labelOpCodeGenErrors.Location = new System.Drawing.Point(621, 76);
            this.labelOpCodeGenErrors.Name = "labelOpCodeGenErrors";
            this.labelOpCodeGenErrors.Size = new System.Drawing.Size(19, 13);
            this.labelOpCodeGenErrors.TabIndex = 7;
            this.labelOpCodeGenErrors.Text = "00";
            // 
            // labelOpCodeGenErrorsLabel
            // 
            this.labelOpCodeGenErrorsLabel.AutoSize = true;
            this.labelOpCodeGenErrorsLabel.Location = new System.Drawing.Point(575, 76);
            this.labelOpCodeGenErrorsLabel.Name = "labelOpCodeGenErrorsLabel";
            this.labelOpCodeGenErrorsLabel.Size = new System.Drawing.Size(40, 13);
            this.labelOpCodeGenErrorsLabel.TabIndex = 6;
            this.labelOpCodeGenErrorsLabel.Text = "Errors :";
            // 
            // labelOpCodeGenWarnings
            // 
            this.labelOpCodeGenWarnings.AutoSize = true;
            this.labelOpCodeGenWarnings.Location = new System.Drawing.Point(535, 76);
            this.labelOpCodeGenWarnings.Name = "labelOpCodeGenWarnings";
            this.labelOpCodeGenWarnings.Size = new System.Drawing.Size(19, 13);
            this.labelOpCodeGenWarnings.TabIndex = 5;
            this.labelOpCodeGenWarnings.Text = "00";
            // 
            // labelOpCodeGenWarningsLabel
            // 
            this.labelOpCodeGenWarningsLabel.AutoSize = true;
            this.labelOpCodeGenWarningsLabel.Location = new System.Drawing.Point(471, 76);
            this.labelOpCodeGenWarningsLabel.Name = "labelOpCodeGenWarningsLabel";
            this.labelOpCodeGenWarningsLabel.Size = new System.Drawing.Size(58, 13);
            this.labelOpCodeGenWarningsLabel.TabIndex = 4;
            this.labelOpCodeGenWarningsLabel.Text = "Warnings :";
            // 
            // labelOpCodeGenProcessReturnValue
            // 
            this.labelOpCodeGenProcessReturnValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelOpCodeGenProcessReturnValue.Location = new System.Drawing.Point(474, 33);
            this.labelOpCodeGenProcessReturnValue.Name = "labelOpCodeGenProcessReturnValue";
            this.labelOpCodeGenProcessReturnValue.Size = new System.Drawing.Size(166, 32);
            this.labelOpCodeGenProcessReturnValue.TabIndex = 3;
            // 
            // labelOpCodeGenProcessReturnValueLabel
            // 
            this.labelOpCodeGenProcessReturnValueLabel.AutoSize = true;
            this.labelOpCodeGenProcessReturnValueLabel.Location = new System.Drawing.Point(471, 9);
            this.labelOpCodeGenProcessReturnValueLabel.Name = "labelOpCodeGenProcessReturnValueLabel";
            this.labelOpCodeGenProcessReturnValueLabel.Size = new System.Drawing.Size(169, 13);
            this.labelOpCodeGenProcessReturnValueLabel.TabIndex = 2;
            this.labelOpCodeGenProcessReturnValueLabel.Text = "Op Code Generation Return Value";
            // 
            // labelOpCodeGenWarningsAndErrorsLabel
            // 
            this.labelOpCodeGenWarningsAndErrorsLabel.AutoSize = true;
            this.labelOpCodeGenWarningsAndErrorsLabel.Location = new System.Drawing.Point(9, 524);
            this.labelOpCodeGenWarningsAndErrorsLabel.Name = "labelOpCodeGenWarningsAndErrorsLabel";
            this.labelOpCodeGenWarningsAndErrorsLabel.Size = new System.Drawing.Size(104, 13);
            this.labelOpCodeGenWarningsAndErrorsLabel.TabIndex = 1;
            this.labelOpCodeGenWarningsAndErrorsLabel.Text = "Warnings And Errors";
            // 
            // listViewOpCodeGenWarningsErrors
            // 
            this.listViewOpCodeGenWarningsErrors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderOpCodeGenType,
            this.columnHeaderOpCodeGenMessage});
            this.listViewOpCodeGenWarningsErrors.Location = new System.Drawing.Point(9, 549);
            this.listViewOpCodeGenWarningsErrors.Name = "listViewOpCodeGenWarningsErrors";
            this.listViewOpCodeGenWarningsErrors.Size = new System.Drawing.Size(764, 127);
            this.listViewOpCodeGenWarningsErrors.TabIndex = 0;
            this.listViewOpCodeGenWarningsErrors.UseCompatibleStateImageBehavior = false;
            this.listViewOpCodeGenWarningsErrors.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderOpCodeGenType
            // 
            this.columnHeaderOpCodeGenType.Text = "Type";
            // 
            // columnHeaderOpCodeGenMessage
            // 
            this.columnHeaderOpCodeGenMessage.Text = "Message";
            this.columnHeaderOpCodeGenMessage.Width = 700;
            // 
            // tabPageSymbolTable
            // 
            this.tabPageSymbolTable.Controls.Add(this.labelBytes);
            this.tabPageSymbolTable.Controls.Add(this.labelMaxMemoryValue);
            this.tabPageSymbolTable.Controls.Add(this.labelMaxMemory);
            this.tabPageSymbolTable.Controls.Add(this.labelTotalBooleanValue);
            this.tabPageSymbolTable.Controls.Add(this.labelTotalBoolean);
            this.tabPageSymbolTable.Controls.Add(this.labelTotalSringsValue);
            this.tabPageSymbolTable.Controls.Add(this.labelTotalStrings);
            this.tabPageSymbolTable.Controls.Add(this.labelTotalIntsValue);
            this.tabPageSymbolTable.Controls.Add(this.labelTotalInts);
            this.tabPageSymbolTable.Controls.Add(this.labelTotalVarsValue);
            this.tabPageSymbolTable.Controls.Add(this.labelTotalVars);
            this.tabPageSymbolTable.Controls.Add(this.treeViewSymbolTable);
            this.tabPageSymbolTable.Controls.Add(this.labelSymbolTable);
            this.tabPageSymbolTable.Location = new System.Drawing.Point(4, 22);
            this.tabPageSymbolTable.Name = "tabPageSymbolTable";
            this.tabPageSymbolTable.Size = new System.Drawing.Size(785, 685);
            this.tabPageSymbolTable.TabIndex = 6;
            this.tabPageSymbolTable.Text = "Symbol Table";
            this.tabPageSymbolTable.UseVisualStyleBackColor = true;
            // 
            // labelBytes
            // 
            this.labelBytes.AutoSize = true;
            this.labelBytes.Location = new System.Drawing.Point(739, 629);
            this.labelBytes.Name = "labelBytes";
            this.labelBytes.Size = new System.Drawing.Size(32, 13);
            this.labelBytes.TabIndex = 13;
            this.labelBytes.Text = "bytes";
            // 
            // labelMaxMemoryValue
            // 
            this.labelMaxMemoryValue.AutoSize = true;
            this.labelMaxMemoryValue.Location = new System.Drawing.Point(708, 629);
            this.labelMaxMemoryValue.Name = "labelMaxMemoryValue";
            this.labelMaxMemoryValue.Size = new System.Drawing.Size(25, 13);
            this.labelMaxMemoryValue.TabIndex = 12;
            this.labelMaxMemoryValue.Text = "000";
            // 
            // labelMaxMemory
            // 
            this.labelMaxMemory.AutoSize = true;
            this.labelMaxMemory.Location = new System.Drawing.Point(605, 629);
            this.labelMaxMemory.Name = "labelMaxMemory";
            this.labelMaxMemory.Size = new System.Drawing.Size(97, 13);
            this.labelMaxMemory.TabIndex = 11;
            this.labelMaxMemory.Text = "Maximum Memory :";
            // 
            // labelTotalBooleanValue
            // 
            this.labelTotalBooleanValue.AutoSize = true;
            this.labelTotalBooleanValue.Location = new System.Drawing.Point(531, 629);
            this.labelTotalBooleanValue.Name = "labelTotalBooleanValue";
            this.labelTotalBooleanValue.Size = new System.Drawing.Size(19, 13);
            this.labelTotalBooleanValue.TabIndex = 10;
            this.labelTotalBooleanValue.Text = "00";
            // 
            // labelTotalBoolean
            // 
            this.labelTotalBoolean.AutoSize = true;
            this.labelTotalBoolean.Location = new System.Drawing.Point(441, 629);
            this.labelTotalBoolean.Name = "labelTotalBoolean";
            this.labelTotalBoolean.Size = new System.Drawing.Size(84, 13);
            this.labelTotalBoolean.TabIndex = 9;
            this.labelTotalBoolean.Text = "Total Booleans :";
            // 
            // labelTotalSringsValue
            // 
            this.labelTotalSringsValue.AutoSize = true;
            this.labelTotalSringsValue.Location = new System.Drawing.Point(378, 629);
            this.labelTotalSringsValue.Name = "labelTotalSringsValue";
            this.labelTotalSringsValue.Size = new System.Drawing.Size(19, 13);
            this.labelTotalSringsValue.TabIndex = 8;
            this.labelTotalSringsValue.Text = "00";
            // 
            // labelTotalStrings
            // 
            this.labelTotalStrings.AutoSize = true;
            this.labelTotalStrings.Location = new System.Drawing.Point(300, 629);
            this.labelTotalStrings.Name = "labelTotalStrings";
            this.labelTotalStrings.Size = new System.Drawing.Size(72, 13);
            this.labelTotalStrings.TabIndex = 7;
            this.labelTotalStrings.Text = "Total Strings :";
            // 
            // labelTotalIntsValue
            // 
            this.labelTotalIntsValue.AutoSize = true;
            this.labelTotalIntsValue.Location = new System.Drawing.Point(237, 629);
            this.labelTotalIntsValue.Name = "labelTotalIntsValue";
            this.labelTotalIntsValue.Size = new System.Drawing.Size(19, 13);
            this.labelTotalIntsValue.TabIndex = 6;
            this.labelTotalIntsValue.Text = "00";
            // 
            // labelTotalInts
            // 
            this.labelTotalInts.AutoSize = true;
            this.labelTotalInts.Location = new System.Drawing.Point(174, 629);
            this.labelTotalInts.Name = "labelTotalInts";
            this.labelTotalInts.Size = new System.Drawing.Size(57, 13);
            this.labelTotalInts.TabIndex = 5;
            this.labelTotalInts.Text = "Total Ints :";
            // 
            // labelTotalVarsValue
            // 
            this.labelTotalVarsValue.AutoSize = true;
            this.labelTotalVarsValue.Location = new System.Drawing.Point(76, 629);
            this.labelTotalVarsValue.Name = "labelTotalVarsValue";
            this.labelTotalVarsValue.Size = new System.Drawing.Size(19, 13);
            this.labelTotalVarsValue.TabIndex = 4;
            this.labelTotalVarsValue.Text = "00";
            // 
            // labelTotalVars
            // 
            this.labelTotalVars.AutoSize = true;
            this.labelTotalVars.Location = new System.Drawing.Point(9, 629);
            this.labelTotalVars.Name = "labelTotalVars";
            this.labelTotalVars.Size = new System.Drawing.Size(61, 13);
            this.labelTotalVars.TabIndex = 3;
            this.labelTotalVars.Text = "Total Vars :";
            // 
            // treeViewSymbolTable
            // 
            this.treeViewSymbolTable.Location = new System.Drawing.Point(8, 25);
            this.treeViewSymbolTable.Name = "treeViewSymbolTable";
            this.treeViewSymbolTable.Size = new System.Drawing.Size(766, 580);
            this.treeViewSymbolTable.TabIndex = 2;
            // 
            // labelSymbolTable
            // 
            this.labelSymbolTable.AutoSize = true;
            this.labelSymbolTable.Location = new System.Drawing.Point(9, 9);
            this.labelSymbolTable.Name = "labelSymbolTable";
            this.labelSymbolTable.Size = new System.Drawing.Size(71, 13);
            this.labelSymbolTable.TabIndex = 1;
            this.labelSymbolTable.Text = "Symbol Table";
            // 
            // tabPageSymantics
            // 
            this.tabPageSymantics.Controls.Add(this.labelSymanticAnalyzerWarningsErrors);
            this.tabPageSymantics.Controls.Add(this.listViewSymanticAnalyzerWarningsAndErrors);
            this.tabPageSymantics.Controls.Add(this.textBoxSymanticAnalyzerMessages);
            this.tabPageSymantics.Controls.Add(this.labelSymanticAnalyzerErrorTotal);
            this.tabPageSymantics.Controls.Add(this.labelSymanticAnalyzerErrorCountLabel);
            this.tabPageSymantics.Controls.Add(this.labelSymanticAnalyzerWarningTotal);
            this.tabPageSymantics.Controls.Add(this.labelSymanticAnalyzerWarningCountLabel);
            this.tabPageSymantics.Controls.Add(this.labelSymanticAnalyzerReturnValue);
            this.tabPageSymantics.Controls.Add(this.labelSyamanticAnalyzerReturnValueLabel);
            this.tabPageSymantics.Controls.Add(this.labelAST);
            this.tabPageSymantics.Controls.Add(this.labelSymanticAnalyzerMessages);
            this.tabPageSymantics.Controls.Add(this.treeViewAST);
            this.tabPageSymantics.Location = new System.Drawing.Point(4, 22);
            this.tabPageSymantics.Name = "tabPageSymantics";
            this.tabPageSymantics.Size = new System.Drawing.Size(785, 685);
            this.tabPageSymantics.TabIndex = 3;
            this.tabPageSymantics.Text = "Symantics";
            this.tabPageSymantics.UseVisualStyleBackColor = true;
            // 
            // labelSymanticAnalyzerWarningsErrors
            // 
            this.labelSymanticAnalyzerWarningsErrors.AutoSize = true;
            this.labelSymanticAnalyzerWarningsErrors.Location = new System.Drawing.Point(6, 522);
            this.labelSymanticAnalyzerWarningsErrors.Name = "labelSymanticAnalyzerWarningsErrors";
            this.labelSymanticAnalyzerWarningsErrors.Size = new System.Drawing.Size(90, 13);
            this.labelSymanticAnalyzerWarningsErrors.TabIndex = 38;
            this.labelSymanticAnalyzerWarningsErrors.Text = "Warnings / Errors";
            // 
            // listViewSymanticAnalyzerWarningsAndErrors
            // 
            this.listViewSymanticAnalyzerWarningsAndErrors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chSAType,
            this.chSAGrammar,
            this.chSALine,
            this.chSAColumn,
            this.columnHeader5});
            this.listViewSymanticAnalyzerWarningsAndErrors.Location = new System.Drawing.Point(9, 538);
            this.listViewSymanticAnalyzerWarningsAndErrors.Name = "listViewSymanticAnalyzerWarningsAndErrors";
            this.listViewSymanticAnalyzerWarningsAndErrors.Size = new System.Drawing.Size(766, 116);
            this.listViewSymanticAnalyzerWarningsAndErrors.TabIndex = 37;
            this.listViewSymanticAnalyzerWarningsAndErrors.UseCompatibleStateImageBehavior = false;
            this.listViewSymanticAnalyzerWarningsAndErrors.View = System.Windows.Forms.View.Details;
            // 
            // chSAType
            // 
            this.chSAType.Text = "Type";
            // 
            // chSAGrammar
            // 
            this.chSAGrammar.Text = "Grammar Process";
            this.chSAGrammar.Width = 100;
            // 
            // chSALine
            // 
            this.chSALine.Text = "Line";
            // 
            // chSAColumn
            // 
            this.chSAColumn.Text = "Column";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Message";
            this.columnHeader5.Width = 807;
            // 
            // textBoxSymanticAnalyzerMessages
            // 
            this.textBoxSymanticAnalyzerMessages.Location = new System.Drawing.Point(558, 116);
            this.textBoxSymanticAnalyzerMessages.Multiline = true;
            this.textBoxSymanticAnalyzerMessages.Name = "textBoxSymanticAnalyzerMessages";
            this.textBoxSymanticAnalyzerMessages.ReadOnly = true;
            this.textBoxSymanticAnalyzerMessages.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxSymanticAnalyzerMessages.Size = new System.Drawing.Size(217, 389);
            this.textBoxSymanticAnalyzerMessages.TabIndex = 21;
            // 
            // labelSymanticAnalyzerErrorTotal
            // 
            this.labelSymanticAnalyzerErrorTotal.AutoSize = true;
            this.labelSymanticAnalyzerErrorTotal.Location = new System.Drawing.Point(694, 76);
            this.labelSymanticAnalyzerErrorTotal.Name = "labelSymanticAnalyzerErrorTotal";
            this.labelSymanticAnalyzerErrorTotal.Size = new System.Drawing.Size(19, 13);
            this.labelSymanticAnalyzerErrorTotal.TabIndex = 36;
            this.labelSymanticAnalyzerErrorTotal.Text = "00";
            // 
            // labelSymanticAnalyzerErrorCountLabel
            // 
            this.labelSymanticAnalyzerErrorCountLabel.AutoSize = true;
            this.labelSymanticAnalyzerErrorCountLabel.Location = new System.Drawing.Point(648, 76);
            this.labelSymanticAnalyzerErrorCountLabel.Name = "labelSymanticAnalyzerErrorCountLabel";
            this.labelSymanticAnalyzerErrorCountLabel.Size = new System.Drawing.Size(40, 13);
            this.labelSymanticAnalyzerErrorCountLabel.TabIndex = 35;
            this.labelSymanticAnalyzerErrorCountLabel.Text = "Errors :";
            // 
            // labelSymanticAnalyzerWarningTotal
            // 
            this.labelSymanticAnalyzerWarningTotal.AutoSize = true;
            this.labelSymanticAnalyzerWarningTotal.Location = new System.Drawing.Point(623, 76);
            this.labelSymanticAnalyzerWarningTotal.Name = "labelSymanticAnalyzerWarningTotal";
            this.labelSymanticAnalyzerWarningTotal.Size = new System.Drawing.Size(19, 13);
            this.labelSymanticAnalyzerWarningTotal.TabIndex = 34;
            this.labelSymanticAnalyzerWarningTotal.Text = "00";
            // 
            // labelSymanticAnalyzerWarningCountLabel
            // 
            this.labelSymanticAnalyzerWarningCountLabel.AutoSize = true;
            this.labelSymanticAnalyzerWarningCountLabel.Location = new System.Drawing.Point(559, 76);
            this.labelSymanticAnalyzerWarningCountLabel.Name = "labelSymanticAnalyzerWarningCountLabel";
            this.labelSymanticAnalyzerWarningCountLabel.Size = new System.Drawing.Size(58, 13);
            this.labelSymanticAnalyzerWarningCountLabel.TabIndex = 33;
            this.labelSymanticAnalyzerWarningCountLabel.Text = "Warnings :";
            // 
            // labelSymanticAnalyzerReturnValue
            // 
            this.labelSymanticAnalyzerReturnValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelSymanticAnalyzerReturnValue.Location = new System.Drawing.Point(558, 36);
            this.labelSymanticAnalyzerReturnValue.Name = "labelSymanticAnalyzerReturnValue";
            this.labelSymanticAnalyzerReturnValue.Size = new System.Drawing.Size(180, 31);
            this.labelSymanticAnalyzerReturnValue.TabIndex = 32;
            this.labelSymanticAnalyzerReturnValue.Text = "                                                         ";
            // 
            // labelSyamanticAnalyzerReturnValueLabel
            // 
            this.labelSyamanticAnalyzerReturnValueLabel.AutoSize = true;
            this.labelSyamanticAnalyzerReturnValueLabel.Location = new System.Drawing.Point(555, 13);
            this.labelSyamanticAnalyzerReturnValueLabel.Name = "labelSyamanticAnalyzerReturnValueLabel";
            this.labelSyamanticAnalyzerReturnValueLabel.Size = new System.Drawing.Size(158, 13);
            this.labelSyamanticAnalyzerReturnValueLabel.TabIndex = 31;
            this.labelSyamanticAnalyzerReturnValueLabel.Text = "Symantic Analyzer Return Value";
            // 
            // labelAST
            // 
            this.labelAST.AutoSize = true;
            this.labelAST.Location = new System.Drawing.Point(6, 13);
            this.labelAST.Name = "labelAST";
            this.labelAST.Size = new System.Drawing.Size(28, 13);
            this.labelAST.TabIndex = 23;
            this.labelAST.Text = "AST";
            // 
            // labelSymanticAnalyzerMessages
            // 
            this.labelSymanticAnalyzerMessages.AutoSize = true;
            this.labelSymanticAnalyzerMessages.Location = new System.Drawing.Point(559, 98);
            this.labelSymanticAnalyzerMessages.Name = "labelSymanticAnalyzerMessages";
            this.labelSymanticAnalyzerMessages.Size = new System.Drawing.Size(55, 13);
            this.labelSymanticAnalyzerMessages.TabIndex = 22;
            this.labelSymanticAnalyzerMessages.Text = "Messages";
            // 
            // treeViewAST
            // 
            this.treeViewAST.Location = new System.Drawing.Point(9, 36);
            this.treeViewAST.Name = "treeViewAST";
            this.treeViewAST.Size = new System.Drawing.Size(525, 469);
            this.treeViewAST.TabIndex = 0;
            // 
            // tabPageParse
            // 
            this.tabPageParse.Controls.Add(this.labelCST);
            this.tabPageParse.Controls.Add(this.labelParserMessage);
            this.tabPageParse.Controls.Add(this.labelParserWarningError);
            this.tabPageParse.Controls.Add(this.listViewParserWarningsAndErrors);
            this.tabPageParse.Controls.Add(this.textBoxParserMessages);
            this.tabPageParse.Controls.Add(this.labelParserErrorTotal);
            this.tabPageParse.Controls.Add(this.labelParserErrorLabel);
            this.tabPageParse.Controls.Add(this.labelParserWarningTotal);
            this.tabPageParse.Controls.Add(this.labelParserWarningLabel);
            this.tabPageParse.Controls.Add(this.labelParserReturnValue);
            this.tabPageParse.Controls.Add(this.labelParserReturnValueLabel);
            this.tabPageParse.Controls.Add(this.treeViewCST);
            this.tabPageParse.Location = new System.Drawing.Point(4, 22);
            this.tabPageParse.Name = "tabPageParse";
            this.tabPageParse.Size = new System.Drawing.Size(785, 685);
            this.tabPageParse.TabIndex = 2;
            this.tabPageParse.Text = "Parser";
            this.tabPageParse.UseVisualStyleBackColor = true;
            // 
            // labelCST
            // 
            this.labelCST.AutoSize = true;
            this.labelCST.Location = new System.Drawing.Point(9, 14);
            this.labelCST.Name = "labelCST";
            this.labelCST.Size = new System.Drawing.Size(28, 13);
            this.labelCST.TabIndex = 34;
            this.labelCST.Text = "CST";
            // 
            // labelParserMessage
            // 
            this.labelParserMessage.AutoSize = true;
            this.labelParserMessage.Location = new System.Drawing.Point(489, 84);
            this.labelParserMessage.Name = "labelParserMessage";
            this.labelParserMessage.Size = new System.Drawing.Size(55, 13);
            this.labelParserMessage.TabIndex = 33;
            this.labelParserMessage.Text = "Messages";
            // 
            // labelParserWarningError
            // 
            this.labelParserWarningError.AutoSize = true;
            this.labelParserWarningError.Location = new System.Drawing.Point(6, 518);
            this.labelParserWarningError.Name = "labelParserWarningError";
            this.labelParserWarningError.Size = new System.Drawing.Size(90, 13);
            this.labelParserWarningError.TabIndex = 32;
            this.labelParserWarningError.Text = "Warnings / Errors";
            // 
            // listViewParserWarningsAndErrors
            // 
            this.listViewParserWarningsAndErrors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderParseType,
            this.columnHeaderParseGrammar,
            this.columnHeaderParseToken,
            this.columnHeaderParseTokenIndex,
            this.columnHeaderParseMessages});
            this.listViewParserWarningsAndErrors.Location = new System.Drawing.Point(9, 534);
            this.listViewParserWarningsAndErrors.Name = "listViewParserWarningsAndErrors";
            this.listViewParserWarningsAndErrors.Size = new System.Drawing.Size(766, 116);
            this.listViewParserWarningsAndErrors.TabIndex = 31;
            this.listViewParserWarningsAndErrors.UseCompatibleStateImageBehavior = false;
            this.listViewParserWarningsAndErrors.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderParseType
            // 
            this.columnHeaderParseType.Text = "Type";
            // 
            // columnHeaderParseGrammar
            // 
            this.columnHeaderParseGrammar.Text = "Grammar Process";
            this.columnHeaderParseGrammar.Width = 100;
            // 
            // columnHeaderParseToken
            // 
            this.columnHeaderParseToken.Text = "Token";
            this.columnHeaderParseToken.Width = 80;
            // 
            // columnHeaderParseTokenIndex
            // 
            this.columnHeaderParseTokenIndex.Text = "Token Index";
            this.columnHeaderParseTokenIndex.Width = 80;
            // 
            // columnHeaderParseMessages
            // 
            this.columnHeaderParseMessages.Text = "Message";
            this.columnHeaderParseMessages.Width = 807;
            // 
            // textBoxParserMessages
            // 
            this.textBoxParserMessages.Location = new System.Drawing.Point(492, 100);
            this.textBoxParserMessages.Multiline = true;
            this.textBoxParserMessages.Name = "textBoxParserMessages";
            this.textBoxParserMessages.ReadOnly = true;
            this.textBoxParserMessages.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxParserMessages.Size = new System.Drawing.Size(283, 405);
            this.textBoxParserMessages.TabIndex = 27;
            // 
            // labelParserErrorTotal
            // 
            this.labelParserErrorTotal.AutoSize = true;
            this.labelParserErrorTotal.Location = new System.Drawing.Point(624, 61);
            this.labelParserErrorTotal.Name = "labelParserErrorTotal";
            this.labelParserErrorTotal.Size = new System.Drawing.Size(19, 13);
            this.labelParserErrorTotal.TabIndex = 30;
            this.labelParserErrorTotal.Text = "00";
            // 
            // labelParserErrorLabel
            // 
            this.labelParserErrorLabel.AutoSize = true;
            this.labelParserErrorLabel.Location = new System.Drawing.Point(578, 61);
            this.labelParserErrorLabel.Name = "labelParserErrorLabel";
            this.labelParserErrorLabel.Size = new System.Drawing.Size(40, 13);
            this.labelParserErrorLabel.TabIndex = 29;
            this.labelParserErrorLabel.Text = "Errors :";
            // 
            // labelParserWarningTotal
            // 
            this.labelParserWarningTotal.AutoSize = true;
            this.labelParserWarningTotal.Location = new System.Drawing.Point(553, 61);
            this.labelParserWarningTotal.Name = "labelParserWarningTotal";
            this.labelParserWarningTotal.Size = new System.Drawing.Size(19, 13);
            this.labelParserWarningTotal.TabIndex = 28;
            this.labelParserWarningTotal.Text = "00";
            // 
            // labelParserWarningLabel
            // 
            this.labelParserWarningLabel.AutoSize = true;
            this.labelParserWarningLabel.Location = new System.Drawing.Point(489, 61);
            this.labelParserWarningLabel.Name = "labelParserWarningLabel";
            this.labelParserWarningLabel.Size = new System.Drawing.Size(58, 13);
            this.labelParserWarningLabel.TabIndex = 26;
            this.labelParserWarningLabel.Text = "Warnings :";
            // 
            // labelParserReturnValue
            // 
            this.labelParserReturnValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelParserReturnValue.Location = new System.Drawing.Point(492, 37);
            this.labelParserReturnValue.Name = "labelParserReturnValue";
            this.labelParserReturnValue.Size = new System.Drawing.Size(180, 15);
            this.labelParserReturnValue.TabIndex = 25;
            this.labelParserReturnValue.Text = "                                                         ";
            // 
            // labelParserReturnValueLabel
            // 
            this.labelParserReturnValueLabel.AutoSize = true;
            this.labelParserReturnValueLabel.Location = new System.Drawing.Point(489, 14);
            this.labelParserReturnValueLabel.Name = "labelParserReturnValueLabel";
            this.labelParserReturnValueLabel.Size = new System.Drawing.Size(102, 13);
            this.labelParserReturnValueLabel.TabIndex = 24;
            this.labelParserReturnValueLabel.Text = "Parser Return Value";
            // 
            // treeViewCST
            // 
            this.treeViewCST.Location = new System.Drawing.Point(9, 37);
            this.treeViewCST.Name = "treeViewCST";
            this.treeViewCST.Size = new System.Drawing.Size(459, 468);
            this.treeViewCST.TabIndex = 0;
            // 
            // tabPageLexer
            // 
            this.tabPageLexer.Controls.Add(this.labelLexerErrorTotal);
            this.tabPageLexer.Controls.Add(this.labelLexerErrorLabel);
            this.tabPageLexer.Controls.Add(this.labelLexerWarningsTotal);
            this.tabPageLexer.Controls.Add(this.labelLexerMessages);
            this.tabPageLexer.Controls.Add(this.textBoxLexerMessages);
            this.tabPageLexer.Controls.Add(this.labelLexerWarningsLabel);
            this.tabPageLexer.Controls.Add(this.labelLexerWarningErrors);
            this.tabPageLexer.Controls.Add(this.listViewLexerWarningsAndErrors);
            this.tabPageLexer.Controls.Add(this.labelLexerReturnValue);
            this.tabPageLexer.Controls.Add(this.labelLexerReturnValueLabel);
            this.tabPageLexer.Controls.Add(this.labelTokenStreamLabel);
            this.tabPageLexer.Controls.Add(this.listViewTokenList);
            this.tabPageLexer.Location = new System.Drawing.Point(4, 22);
            this.tabPageLexer.Name = "tabPageLexer";
            this.tabPageLexer.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLexer.Size = new System.Drawing.Size(785, 685);
            this.tabPageLexer.TabIndex = 1;
            this.tabPageLexer.Text = "Lexer";
            this.tabPageLexer.UseVisualStyleBackColor = true;
            // 
            // labelLexerErrorTotal
            // 
            this.labelLexerErrorTotal.AutoSize = true;
            this.labelLexerErrorTotal.Location = new System.Drawing.Point(742, 36);
            this.labelLexerErrorTotal.Name = "labelLexerErrorTotal";
            this.labelLexerErrorTotal.Size = new System.Drawing.Size(19, 13);
            this.labelLexerErrorTotal.TabIndex = 23;
            this.labelLexerErrorTotal.Text = "00";
            // 
            // labelLexerErrorLabel
            // 
            this.labelLexerErrorLabel.AutoSize = true;
            this.labelLexerErrorLabel.Location = new System.Drawing.Point(696, 36);
            this.labelLexerErrorLabel.Name = "labelLexerErrorLabel";
            this.labelLexerErrorLabel.Size = new System.Drawing.Size(40, 13);
            this.labelLexerErrorLabel.TabIndex = 22;
            this.labelLexerErrorLabel.Text = "Errors :";
            // 
            // labelLexerWarningsTotal
            // 
            this.labelLexerWarningsTotal.AutoSize = true;
            this.labelLexerWarningsTotal.Location = new System.Drawing.Point(660, 36);
            this.labelLexerWarningsTotal.Name = "labelLexerWarningsTotal";
            this.labelLexerWarningsTotal.Size = new System.Drawing.Size(19, 13);
            this.labelLexerWarningsTotal.TabIndex = 21;
            this.labelLexerWarningsTotal.Text = "00";
            // 
            // labelLexerMessages
            // 
            this.labelLexerMessages.AutoSize = true;
            this.labelLexerMessages.Location = new System.Drawing.Point(379, 66);
            this.labelLexerMessages.Name = "labelLexerMessages";
            this.labelLexerMessages.Size = new System.Drawing.Size(55, 13);
            this.labelLexerMessages.TabIndex = 20;
            this.labelLexerMessages.Text = "Messages";
            // 
            // textBoxLexerMessages
            // 
            this.textBoxLexerMessages.Location = new System.Drawing.Point(382, 82);
            this.textBoxLexerMessages.Multiline = true;
            this.textBoxLexerMessages.Name = "textBoxLexerMessages";
            this.textBoxLexerMessages.ReadOnly = true;
            this.textBoxLexerMessages.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxLexerMessages.Size = new System.Drawing.Size(393, 419);
            this.textBoxLexerMessages.TabIndex = 19;
            // 
            // labelLexerWarningsLabel
            // 
            this.labelLexerWarningsLabel.AutoSize = true;
            this.labelLexerWarningsLabel.Location = new System.Drawing.Point(596, 36);
            this.labelLexerWarningsLabel.Name = "labelLexerWarningsLabel";
            this.labelLexerWarningsLabel.Size = new System.Drawing.Size(58, 13);
            this.labelLexerWarningsLabel.TabIndex = 18;
            this.labelLexerWarningsLabel.Text = "Warnings :";
            // 
            // labelLexerWarningErrors
            // 
            this.labelLexerWarningErrors.AutoSize = true;
            this.labelLexerWarningErrors.Location = new System.Drawing.Point(6, 519);
            this.labelLexerWarningErrors.Name = "labelLexerWarningErrors";
            this.labelLexerWarningErrors.Size = new System.Drawing.Size(90, 13);
            this.labelLexerWarningErrors.TabIndex = 17;
            this.labelLexerWarningErrors.Text = "Warnings / Errors";
            // 
            // listViewLexerWarningsAndErrors
            // 
            this.listViewLexerWarningsAndErrors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderLexerType,
            this.columnHeaderLexerLine,
            this.columnHeaderLexerColumn,
            this.columnHeaderLexerMessage});
            this.listViewLexerWarningsAndErrors.Location = new System.Drawing.Point(9, 535);
            this.listViewLexerWarningsAndErrors.Name = "listViewLexerWarningsAndErrors";
            this.listViewLexerWarningsAndErrors.Size = new System.Drawing.Size(766, 116);
            this.listViewLexerWarningsAndErrors.TabIndex = 16;
            this.listViewLexerWarningsAndErrors.UseCompatibleStateImageBehavior = false;
            this.listViewLexerWarningsAndErrors.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderLexerType
            // 
            this.columnHeaderLexerType.Text = "Type";
            // 
            // columnHeaderLexerLine
            // 
            this.columnHeaderLexerLine.Text = "Line";
            // 
            // columnHeaderLexerColumn
            // 
            this.columnHeaderLexerColumn.Text = "Column";
            // 
            // columnHeaderLexerMessage
            // 
            this.columnHeaderLexerMessage.Text = "Message";
            this.columnHeaderLexerMessage.Width = 807;
            // 
            // labelLexerReturnValue
            // 
            this.labelLexerReturnValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelLexerReturnValue.Location = new System.Drawing.Point(382, 35);
            this.labelLexerReturnValue.Name = "labelLexerReturnValue";
            this.labelLexerReturnValue.Size = new System.Drawing.Size(180, 15);
            this.labelLexerReturnValue.TabIndex = 3;
            this.labelLexerReturnValue.Text = "                                                         ";
            // 
            // labelLexerReturnValueLabel
            // 
            this.labelLexerReturnValueLabel.AutoSize = true;
            this.labelLexerReturnValueLabel.Location = new System.Drawing.Point(379, 19);
            this.labelLexerReturnValueLabel.Name = "labelLexerReturnValueLabel";
            this.labelLexerReturnValueLabel.Size = new System.Drawing.Size(98, 13);
            this.labelLexerReturnValueLabel.TabIndex = 2;
            this.labelLexerReturnValueLabel.Text = "Lexer Return Value";
            // 
            // labelTokenStreamLabel
            // 
            this.labelTokenStreamLabel.AutoSize = true;
            this.labelTokenStreamLabel.Location = new System.Drawing.Point(13, 19);
            this.labelTokenStreamLabel.Name = "labelTokenStreamLabel";
            this.labelTokenStreamLabel.Size = new System.Drawing.Size(74, 13);
            this.labelTokenStreamLabel.TabIndex = 1;
            this.labelTokenStreamLabel.Text = "Token Stream";
            // 
            // listViewTokenList
            // 
            this.listViewTokenList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderToken,
            this.columnHeaderLine,
            this.columnHeaderColumn,
            this.columnHeaderValue});
            this.listViewTokenList.Location = new System.Drawing.Point(9, 35);
            this.listViewTokenList.Name = "listViewTokenList";
            this.listViewTokenList.Size = new System.Drawing.Size(356, 466);
            this.listViewTokenList.TabIndex = 0;
            this.listViewTokenList.UseCompatibleStateImageBehavior = false;
            this.listViewTokenList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderToken
            // 
            this.columnHeaderToken.Text = "Token";
            this.columnHeaderToken.Width = 165;
            // 
            // columnHeaderLine
            // 
            this.columnHeaderLine.Text = "Line";
            // 
            // columnHeaderColumn
            // 
            this.columnHeaderColumn.Text = "Column";
            // 
            // columnHeaderValue
            // 
            this.columnHeaderValue.Text = "Value";
            // 
            // tabPageSource
            // 
            this.tabPageSource.Controls.Add(this.labelGeneralErrorTotal);
            this.tabPageSource.Controls.Add(this.labelGeneralErrorLabel);
            this.tabPageSource.Controls.Add(this.labelGeneralWarningTotal);
            this.tabPageSource.Controls.Add(this.labelGeneralWarningLabel);
            this.tabPageSource.Controls.Add(this.buttonReset);
            this.tabPageSource.Controls.Add(this.labelCompilerReturnValue);
            this.tabPageSource.Controls.Add(this.labelCompilerReturnValueLabel);
            this.tabPageSource.Controls.Add(this.groupBoxOptions);
            this.tabPageSource.Controls.Add(this.groupBoxProcess);
            this.tabPageSource.Controls.Add(this.buttonCompile);
            this.tabPageSource.Controls.Add(this.textBoxSource);
            this.tabPageSource.Controls.Add(this.textBoxGeneralMessages);
            this.tabPageSource.Controls.Add(this.labelWarningError);
            this.tabPageSource.Controls.Add(this.labelGeneralMessages);
            this.tabPageSource.Controls.Add(this.listViewGeneralWarningsAndErrors);
            this.tabPageSource.Controls.Add(this.labelSource);
            this.tabPageSource.Location = new System.Drawing.Point(4, 22);
            this.tabPageSource.Name = "tabPageSource";
            this.tabPageSource.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSource.Size = new System.Drawing.Size(785, 685);
            this.tabPageSource.TabIndex = 0;
            this.tabPageSource.Text = "Source";
            this.tabPageSource.UseVisualStyleBackColor = true;
            // 
            // labelGeneralErrorTotal
            // 
            this.labelGeneralErrorTotal.AutoSize = true;
            this.labelGeneralErrorTotal.Location = new System.Drawing.Point(744, 350);
            this.labelGeneralErrorTotal.Name = "labelGeneralErrorTotal";
            this.labelGeneralErrorTotal.Size = new System.Drawing.Size(19, 13);
            this.labelGeneralErrorTotal.TabIndex = 33;
            this.labelGeneralErrorTotal.Text = "00";
            // 
            // labelGeneralErrorLabel
            // 
            this.labelGeneralErrorLabel.AutoSize = true;
            this.labelGeneralErrorLabel.Location = new System.Drawing.Point(696, 350);
            this.labelGeneralErrorLabel.Name = "labelGeneralErrorLabel";
            this.labelGeneralErrorLabel.Size = new System.Drawing.Size(40, 13);
            this.labelGeneralErrorLabel.TabIndex = 32;
            this.labelGeneralErrorLabel.Text = "Errors :";
            // 
            // labelGeneralWarningTotal
            // 
            this.labelGeneralWarningTotal.AutoSize = true;
            this.labelGeneralWarningTotal.Location = new System.Drawing.Point(671, 350);
            this.labelGeneralWarningTotal.Name = "labelGeneralWarningTotal";
            this.labelGeneralWarningTotal.Size = new System.Drawing.Size(19, 13);
            this.labelGeneralWarningTotal.TabIndex = 31;
            this.labelGeneralWarningTotal.Text = "00";
            // 
            // labelGeneralWarningLabel
            // 
            this.labelGeneralWarningLabel.AutoSize = true;
            this.labelGeneralWarningLabel.Location = new System.Drawing.Point(608, 350);
            this.labelGeneralWarningLabel.Name = "labelGeneralWarningLabel";
            this.labelGeneralWarningLabel.Size = new System.Drawing.Size(58, 13);
            this.labelGeneralWarningLabel.TabIndex = 30;
            this.labelGeneralWarningLabel.Text = "Warnings :";
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(616, 653);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 29;
            this.buttonReset.Text = "&Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // labelCompilerReturnValue
            // 
            this.labelCompilerReturnValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelCompilerReturnValue.Location = new System.Drawing.Point(607, 292);
            this.labelCompilerReturnValue.Name = "labelCompilerReturnValue";
            this.labelCompilerReturnValue.Size = new System.Drawing.Size(159, 50);
            this.labelCompilerReturnValue.TabIndex = 28;
            this.labelCompilerReturnValue.Text = "                                                  ";
            // 
            // labelCompilerReturnValueLabel
            // 
            this.labelCompilerReturnValueLabel.AutoSize = true;
            this.labelCompilerReturnValueLabel.Location = new System.Drawing.Point(604, 268);
            this.labelCompilerReturnValueLabel.Name = "labelCompilerReturnValueLabel";
            this.labelCompilerReturnValueLabel.Size = new System.Drawing.Size(118, 13);
            this.labelCompilerReturnValueLabel.TabIndex = 27;
            this.labelCompilerReturnValueLabel.Text = "Compiler Return Value :";
            // 
            // groupBoxOptions
            // 
            this.groupBoxOptions.Controls.Add(this.checkBoxCopyOpCodesToClipboard);
            this.groupBoxOptions.Controls.Add(this.checkBoxShowMessages);
            this.groupBoxOptions.Controls.Add(this.checkBoxOutputOpCodesToFile);
            this.groupBoxOptions.Location = new System.Drawing.Point(605, 162);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Size = new System.Drawing.Size(167, 92);
            this.groupBoxOptions.TabIndex = 26;
            this.groupBoxOptions.TabStop = false;
            this.groupBoxOptions.Text = "Options";
            // 
            // checkBoxCopyOpCodesToClipboard
            // 
            this.checkBoxCopyOpCodesToClipboard.AutoSize = true;
            this.checkBoxCopyOpCodesToClipboard.Location = new System.Drawing.Point(6, 19);
            this.checkBoxCopyOpCodesToClipboard.Name = "checkBoxCopyOpCodesToClipboard";
            this.checkBoxCopyOpCodesToClipboard.Size = new System.Drawing.Size(163, 17);
            this.checkBoxCopyOpCodesToClipboard.TabIndex = 28;
            this.checkBoxCopyOpCodesToClipboard.Text = "&Copy Op Codes To Clipboard";
            this.checkBoxCopyOpCodesToClipboard.UseVisualStyleBackColor = true;
            this.checkBoxCopyOpCodesToClipboard.CheckedChanged += new System.EventHandler(this.checkBoxCopyOpCodesToClipboard_CheckedChanged);
            // 
            // checkBoxShowMessages
            // 
            this.checkBoxShowMessages.AutoSize = true;
            this.checkBoxShowMessages.Location = new System.Drawing.Point(6, 65);
            this.checkBoxShowMessages.Name = "checkBoxShowMessages";
            this.checkBoxShowMessages.Size = new System.Drawing.Size(146, 17);
            this.checkBoxShowMessages.TabIndex = 27;
            this.checkBoxShowMessages.Text = "Show Detailed &Messages";
            this.checkBoxShowMessages.UseVisualStyleBackColor = true;
            this.checkBoxShowMessages.CheckedChanged += new System.EventHandler(this.checkBoxShowMessages_CheckedChanged);
            // 
            // checkBoxOutputOpCodesToFile
            // 
            this.checkBoxOutputOpCodesToFile.AutoSize = true;
            this.checkBoxOutputOpCodesToFile.Location = new System.Drawing.Point(6, 42);
            this.checkBoxOutputOpCodesToFile.Name = "checkBoxOutputOpCodesToFile";
            this.checkBoxOutputOpCodesToFile.Size = new System.Drawing.Size(143, 17);
            this.checkBoxOutputOpCodesToFile.TabIndex = 25;
            this.checkBoxOutputOpCodesToFile.Text = "Output &Op Codes To File";
            this.checkBoxOutputOpCodesToFile.UseVisualStyleBackColor = true;
            this.checkBoxOutputOpCodesToFile.CheckedChanged += new System.EventHandler(this.checkBoxOutputOpCodesToFile_CheckedChanged);
            // 
            // groupBoxProcess
            // 
            this.groupBoxProcess.Controls.Add(this.checkBoxCodeGenSuccess);
            this.groupBoxProcess.Controls.Add(this.checkBoxOptimizationSuccess);
            this.groupBoxProcess.Controls.Add(this.checkBoxSyamnticsSuccess);
            this.groupBoxProcess.Controls.Add(this.checkBoxParserSuccess);
            this.groupBoxProcess.Controls.Add(this.checkBoxLexerSuccess);
            this.groupBoxProcess.Location = new System.Drawing.Point(605, 19);
            this.groupBoxProcess.Name = "groupBoxProcess";
            this.groupBoxProcess.Size = new System.Drawing.Size(167, 137);
            this.groupBoxProcess.TabIndex = 21;
            this.groupBoxProcess.TabStop = false;
            this.groupBoxProcess.Text = "Process";
            // 
            // checkBoxCodeGenSuccess
            // 
            this.checkBoxCodeGenSuccess.AutoSize = true;
            this.checkBoxCodeGenSuccess.Enabled = false;
            this.checkBoxCodeGenSuccess.Location = new System.Drawing.Point(6, 111);
            this.checkBoxCodeGenSuccess.Name = "checkBoxCodeGenSuccess";
            this.checkBoxCodeGenSuccess.Size = new System.Drawing.Size(161, 17);
            this.checkBoxCodeGenSuccess.TabIndex = 24;
            this.checkBoxCodeGenSuccess.Text = "Code Generation Successful";
            this.checkBoxCodeGenSuccess.UseVisualStyleBackColor = true;
            // 
            // checkBoxOptimizationSuccess
            // 
            this.checkBoxOptimizationSuccess.AutoSize = true;
            this.checkBoxOptimizationSuccess.Enabled = false;
            this.checkBoxOptimizationSuccess.Location = new System.Drawing.Point(6, 88);
            this.checkBoxOptimizationSuccess.Name = "checkBoxOptimizationSuccess";
            this.checkBoxOptimizationSuccess.Size = new System.Drawing.Size(138, 17);
            this.checkBoxOptimizationSuccess.TabIndex = 23;
            this.checkBoxOptimizationSuccess.Text = "Optimization Successful";
            this.checkBoxOptimizationSuccess.UseVisualStyleBackColor = true;
            // 
            // checkBoxSyamnticsSuccess
            // 
            this.checkBoxSyamnticsSuccess.AutoSize = true;
            this.checkBoxSyamnticsSuccess.Enabled = false;
            this.checkBoxSyamnticsSuccess.Location = new System.Drawing.Point(6, 65);
            this.checkBoxSyamnticsSuccess.Name = "checkBoxSyamnticsSuccess";
            this.checkBoxSyamnticsSuccess.Size = new System.Drawing.Size(129, 17);
            this.checkBoxSyamnticsSuccess.TabIndex = 22;
            this.checkBoxSyamnticsSuccess.Text = "Symantics Successful";
            this.checkBoxSyamnticsSuccess.UseVisualStyleBackColor = true;
            // 
            // checkBoxParserSuccess
            // 
            this.checkBoxParserSuccess.AutoSize = true;
            this.checkBoxParserSuccess.Enabled = false;
            this.checkBoxParserSuccess.Location = new System.Drawing.Point(6, 42);
            this.checkBoxParserSuccess.Name = "checkBoxParserSuccess";
            this.checkBoxParserSuccess.Size = new System.Drawing.Size(111, 17);
            this.checkBoxParserSuccess.TabIndex = 21;
            this.checkBoxParserSuccess.Text = "Parser Successful";
            this.checkBoxParserSuccess.UseVisualStyleBackColor = true;
            // 
            // checkBoxLexerSuccess
            // 
            this.checkBoxLexerSuccess.AutoSize = true;
            this.checkBoxLexerSuccess.Enabled = false;
            this.checkBoxLexerSuccess.Location = new System.Drawing.Point(6, 19);
            this.checkBoxLexerSuccess.Name = "checkBoxLexerSuccess";
            this.checkBoxLexerSuccess.Size = new System.Drawing.Size(107, 17);
            this.checkBoxLexerSuccess.TabIndex = 20;
            this.checkBoxLexerSuccess.Text = "Lexer Successful";
            this.checkBoxLexerSuccess.UseVisualStyleBackColor = true;
            // 
            // buttonCompile
            // 
            this.buttonCompile.Location = new System.Drawing.Point(697, 653);
            this.buttonCompile.Name = "buttonCompile";
            this.buttonCompile.Size = new System.Drawing.Size(75, 23);
            this.buttonCompile.TabIndex = 16;
            this.buttonCompile.Text = "&Compile";
            this.buttonCompile.UseVisualStyleBackColor = true;
            this.buttonCompile.Click += new System.EventHandler(this.buttonCompile_Click);
            // 
            // textBoxSource
            // 
            this.textBoxSource.Location = new System.Drawing.Point(6, 19);
            this.textBoxSource.Multiline = true;
            this.textBoxSource.Name = "textBoxSource";
            this.textBoxSource.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxSource.Size = new System.Drawing.Size(339, 453);
            this.textBoxSource.TabIndex = 0;
            // 
            // textBoxGeneralMessages
            // 
            this.textBoxGeneralMessages.Location = new System.Drawing.Point(361, 19);
            this.textBoxGeneralMessages.Multiline = true;
            this.textBoxGeneralMessages.Name = "textBoxGeneralMessages";
            this.textBoxGeneralMessages.ReadOnly = true;
            this.textBoxGeneralMessages.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxGeneralMessages.Size = new System.Drawing.Size(232, 453);
            this.textBoxGeneralMessages.TabIndex = 7;
            // 
            // labelWarningError
            // 
            this.labelWarningError.AutoSize = true;
            this.labelWarningError.Location = new System.Drawing.Point(3, 483);
            this.labelWarningError.Name = "labelWarningError";
            this.labelWarningError.Size = new System.Drawing.Size(90, 13);
            this.labelWarningError.TabIndex = 15;
            this.labelWarningError.Text = "Warnings / Errors";
            // 
            // labelGeneralMessages
            // 
            this.labelGeneralMessages.AutoSize = true;
            this.labelGeneralMessages.Location = new System.Drawing.Point(358, 3);
            this.labelGeneralMessages.Name = "labelGeneralMessages";
            this.labelGeneralMessages.Size = new System.Drawing.Size(55, 13);
            this.labelGeneralMessages.TabIndex = 8;
            this.labelGeneralMessages.Text = "Messages";
            // 
            // listViewGeneralWarningsAndErrors
            // 
            this.listViewGeneralWarningsAndErrors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderGeneralSystem,
            this.columnHeadGeneralType,
            this.columnHeaderGeneralLine,
            this.columnHeaderGeneralCol,
            this.columnHeaderGeneralGrammar,
            this.columnHeaderGeneralToken,
            this.columnHeaderGeneralTokenIndex,
            this.columnHeaderGeneralMsg});
            this.listViewGeneralWarningsAndErrors.Location = new System.Drawing.Point(6, 499);
            this.listViewGeneralWarningsAndErrors.Name = "listViewGeneralWarningsAndErrors";
            this.listViewGeneralWarningsAndErrors.Size = new System.Drawing.Size(766, 139);
            this.listViewGeneralWarningsAndErrors.TabIndex = 14;
            this.listViewGeneralWarningsAndErrors.UseCompatibleStateImageBehavior = false;
            this.listViewGeneralWarningsAndErrors.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderGeneralSystem
            // 
            this.columnHeaderGeneralSystem.Text = "System";
            this.columnHeaderGeneralSystem.Width = 90;
            // 
            // columnHeadGeneralType
            // 
            this.columnHeadGeneralType.Text = "Type";
            // 
            // columnHeaderGeneralLine
            // 
            this.columnHeaderGeneralLine.Text = "Line";
            // 
            // columnHeaderGeneralCol
            // 
            this.columnHeaderGeneralCol.Text = "Column";
            // 
            // columnHeaderGeneralGrammar
            // 
            this.columnHeaderGeneralGrammar.Text = "Grammar Process";
            this.columnHeaderGeneralGrammar.Width = 150;
            // 
            // columnHeaderGeneralToken
            // 
            this.columnHeaderGeneralToken.Text = "Token";
            this.columnHeaderGeneralToken.Width = 90;
            // 
            // columnHeaderGeneralTokenIndex
            // 
            this.columnHeaderGeneralTokenIndex.Text = "Token Index";
            this.columnHeaderGeneralTokenIndex.Width = 75;
            // 
            // columnHeaderGeneralMsg
            // 
            this.columnHeaderGeneralMsg.Text = "Message";
            this.columnHeaderGeneralMsg.Width = 807;
            // 
            // labelSource
            // 
            this.labelSource.AutoSize = true;
            this.labelSource.Location = new System.Drawing.Point(3, 3);
            this.labelSource.Name = "labelSource";
            this.labelSource.Size = new System.Drawing.Size(41, 13);
            this.labelSource.TabIndex = 11;
            this.labelSource.Text = "Source";
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageSource);
            this.tabControlMain.Controls.Add(this.tabPageLexer);
            this.tabControlMain.Controls.Add(this.tabPageParse);
            this.tabControlMain.Controls.Add(this.tabPageSymantics);
            this.tabControlMain.Controls.Add(this.tabPageSymbolTable);
            this.tabControlMain.Controls.Add(this.tabPageCodeGeneration);
            this.tabControlMain.Location = new System.Drawing.Point(-1, 27);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(793, 711);
            this.tabControlMain.TabIndex = 16;
            // 
            // CompilerInterfaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 737);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "CompilerInterfaceForm";
            this.Text = "Compiler Interface";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabPageCodeGeneration.ResumeLayout(false);
            this.tabPageCodeGeneration.PerformLayout();
            this.groupBoxDisplay.ResumeLayout(false);
            this.groupBoxDisplay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinnerDisplayedBytesPerRow)).EndInit();
            this.groupBoxProgramData.ResumeLayout(false);
            this.groupBoxProgramData.PerformLayout();
            this.tabPageSymbolTable.ResumeLayout(false);
            this.tabPageSymbolTable.PerformLayout();
            this.tabPageSymantics.ResumeLayout(false);
            this.tabPageSymantics.PerformLayout();
            this.tabPageParse.ResumeLayout(false);
            this.tabPageParse.PerformLayout();
            this.tabPageLexer.ResumeLayout(false);
            this.tabPageLexer.PerformLayout();
            this.tabPageSource.ResumeLayout(false);
            this.tabPageSource.PerformLayout();
            this.groupBoxOptions.ResumeLayout(false);
            this.groupBoxOptions.PerformLayout();
            this.groupBoxProcess.ResumeLayout(false);
            this.groupBoxProcess.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compileSourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outputOpCodesToFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showMessagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem grammarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.TabPage tabPageCodeGeneration;
        private System.Windows.Forms.GroupBox groupBoxDisplay;
        private System.Windows.Forms.NumericUpDown spinnerDisplayedBytesPerRow;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Label lblBytesPerRow;
        private System.Windows.Forms.GroupBox groupBoxProgramData;
        private System.Windows.Forms.Label lblHeapSizeBytes;
        private System.Windows.Forms.Label lblStackSizeBytes;
        private System.Windows.Forms.Label lblLengthBytes;
        private System.Windows.Forms.Label lblHeapSize;
        private System.Windows.Forms.Label lblStackSize;
        private System.Windows.Forms.Label lblHeapStart;
        private System.Windows.Forms.Label lblStackStart;
        private System.Windows.Forms.Label lblHeapSizeLabel;
        private System.Windows.Forms.Label lblHeapStartLabel;
        private System.Windows.Forms.Label lblStackSizeLabel;
        private System.Windows.Forms.Label lblStackStartLabel;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.Label lblLengthLabel;
        private System.Windows.Forms.TextBox textBoxOpCodes;
        private System.Windows.Forms.TextBox textBoxOpCodeGenMessages;
        private System.Windows.Forms.Label labelOpCodesLabel;
        private System.Windows.Forms.Label labelOpCodGenMessagesLabel;
        private System.Windows.Forms.Label labelOpCodeGenErrors;
        private System.Windows.Forms.Label labelOpCodeGenErrorsLabel;
        private System.Windows.Forms.Label labelOpCodeGenWarnings;
        private System.Windows.Forms.Label labelOpCodeGenWarningsLabel;
        private System.Windows.Forms.Label labelOpCodeGenProcessReturnValue;
        private System.Windows.Forms.Label labelOpCodeGenProcessReturnValueLabel;
        private System.Windows.Forms.Label labelOpCodeGenWarningsAndErrorsLabel;
        private System.Windows.Forms.ListView listViewOpCodeGenWarningsErrors;
        private System.Windows.Forms.ColumnHeader columnHeaderOpCodeGenType;
        private System.Windows.Forms.ColumnHeader columnHeaderOpCodeGenMessage;
        private System.Windows.Forms.TabPage tabPageSymbolTable;
        private System.Windows.Forms.Label labelBytes;
        private System.Windows.Forms.Label labelMaxMemoryValue;
        private System.Windows.Forms.Label labelMaxMemory;
        private System.Windows.Forms.Label labelTotalBooleanValue;
        private System.Windows.Forms.Label labelTotalBoolean;
        private System.Windows.Forms.Label labelTotalSringsValue;
        private System.Windows.Forms.Label labelTotalStrings;
        private System.Windows.Forms.Label labelTotalIntsValue;
        private System.Windows.Forms.Label labelTotalInts;
        private System.Windows.Forms.Label labelTotalVarsValue;
        private System.Windows.Forms.Label labelTotalVars;
        private System.Windows.Forms.TreeView treeViewSymbolTable;
        private System.Windows.Forms.Label labelSymbolTable;
        private System.Windows.Forms.TabPage tabPageSymantics;
        private System.Windows.Forms.Label labelSymanticAnalyzerWarningsErrors;
        private System.Windows.Forms.ListView listViewSymanticAnalyzerWarningsAndErrors;
        private System.Windows.Forms.ColumnHeader chSAType;
        private System.Windows.Forms.ColumnHeader chSAGrammar;
        private System.Windows.Forms.ColumnHeader chSALine;
        private System.Windows.Forms.ColumnHeader chSAColumn;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.TextBox textBoxSymanticAnalyzerMessages;
        private System.Windows.Forms.Label labelSymanticAnalyzerErrorTotal;
        private System.Windows.Forms.Label labelSymanticAnalyzerErrorCountLabel;
        private System.Windows.Forms.Label labelSymanticAnalyzerWarningTotal;
        private System.Windows.Forms.Label labelSymanticAnalyzerWarningCountLabel;
        private System.Windows.Forms.Label labelSymanticAnalyzerReturnValue;
        private System.Windows.Forms.Label labelSyamanticAnalyzerReturnValueLabel;
        private System.Windows.Forms.Label labelAST;
        private System.Windows.Forms.Label labelSymanticAnalyzerMessages;
        private System.Windows.Forms.TreeView treeViewAST;
        private System.Windows.Forms.TabPage tabPageParse;
        private System.Windows.Forms.Label labelCST;
        private System.Windows.Forms.Label labelParserMessage;
        private System.Windows.Forms.Label labelParserWarningError;
        private System.Windows.Forms.ListView listViewParserWarningsAndErrors;
        private System.Windows.Forms.ColumnHeader columnHeaderParseType;
        private System.Windows.Forms.ColumnHeader columnHeaderParseGrammar;
        private System.Windows.Forms.ColumnHeader columnHeaderParseToken;
        private System.Windows.Forms.ColumnHeader columnHeaderParseTokenIndex;
        private System.Windows.Forms.ColumnHeader columnHeaderParseMessages;
        private System.Windows.Forms.TextBox textBoxParserMessages;
        private System.Windows.Forms.Label labelParserErrorTotal;
        private System.Windows.Forms.Label labelParserErrorLabel;
        private System.Windows.Forms.Label labelParserWarningTotal;
        private System.Windows.Forms.Label labelParserWarningLabel;
        private System.Windows.Forms.Label labelParserReturnValue;
        private System.Windows.Forms.Label labelParserReturnValueLabel;
        private System.Windows.Forms.TreeView treeViewCST;
        private System.Windows.Forms.TabPage tabPageLexer;
        private System.Windows.Forms.Label labelLexerErrorTotal;
        private System.Windows.Forms.Label labelLexerErrorLabel;
        private System.Windows.Forms.Label labelLexerWarningsTotal;
        private System.Windows.Forms.Label labelLexerMessages;
        private System.Windows.Forms.TextBox textBoxLexerMessages;
        private System.Windows.Forms.Label labelLexerWarningsLabel;
        private System.Windows.Forms.Label labelLexerWarningErrors;
        private System.Windows.Forms.ListView listViewLexerWarningsAndErrors;
        private System.Windows.Forms.ColumnHeader columnHeaderLexerType;
        private System.Windows.Forms.ColumnHeader columnHeaderLexerLine;
        private System.Windows.Forms.ColumnHeader columnHeaderLexerColumn;
        private System.Windows.Forms.ColumnHeader columnHeaderLexerMessage;
        private System.Windows.Forms.Label labelLexerReturnValue;
        private System.Windows.Forms.Label labelLexerReturnValueLabel;
        private System.Windows.Forms.Label labelTokenStreamLabel;
        private System.Windows.Forms.ListView listViewTokenList;
        private System.Windows.Forms.ColumnHeader columnHeaderToken;
        private System.Windows.Forms.ColumnHeader columnHeaderLine;
        private System.Windows.Forms.ColumnHeader columnHeaderColumn;
        private System.Windows.Forms.ColumnHeader columnHeaderValue;
        private System.Windows.Forms.TabPage tabPageSource;
        private System.Windows.Forms.Label labelGeneralErrorTotal;
        private System.Windows.Forms.Label labelGeneralErrorLabel;
        private System.Windows.Forms.Label labelGeneralWarningTotal;
        private System.Windows.Forms.Label labelGeneralWarningLabel;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Label labelCompilerReturnValue;
        private System.Windows.Forms.Label labelCompilerReturnValueLabel;
        private System.Windows.Forms.GroupBox groupBoxOptions;
        private System.Windows.Forms.CheckBox checkBoxShowMessages;
        private System.Windows.Forms.CheckBox checkBoxOutputOpCodesToFile;
        private System.Windows.Forms.GroupBox groupBoxProcess;
        private System.Windows.Forms.CheckBox checkBoxCodeGenSuccess;
        private System.Windows.Forms.CheckBox checkBoxOptimizationSuccess;
        private System.Windows.Forms.CheckBox checkBoxSyamnticsSuccess;
        private System.Windows.Forms.CheckBox checkBoxParserSuccess;
        private System.Windows.Forms.CheckBox checkBoxLexerSuccess;
        private System.Windows.Forms.Button buttonCompile;
        private System.Windows.Forms.TextBox textBoxSource;
        private System.Windows.Forms.TextBox textBoxGeneralMessages;
        private System.Windows.Forms.Label labelWarningError;
        private System.Windows.Forms.Label labelGeneralMessages;
        private System.Windows.Forms.ListView listViewGeneralWarningsAndErrors;
        private System.Windows.Forms.ColumnHeader columnHeaderGeneralSystem;
        private System.Windows.Forms.ColumnHeader columnHeadGeneralType;
        private System.Windows.Forms.ColumnHeader columnHeaderGeneralLine;
        private System.Windows.Forms.ColumnHeader columnHeaderGeneralCol;
        private System.Windows.Forms.ColumnHeader columnHeaderGeneralGrammar;
        private System.Windows.Forms.ColumnHeader columnHeaderGeneralToken;
        private System.Windows.Forms.ColumnHeader columnHeaderGeneralTokenIndex;
        private System.Windows.Forms.ColumnHeader columnHeaderGeneralMsg;
        private System.Windows.Forms.Label labelSource;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.ToolStripMenuItem copyOpCodesToClipboardToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBoxCopyOpCodesToClipboard;
    }
}

