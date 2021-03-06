﻿namespace CompilerInterface
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
            this.textBoxSource = new System.Windows.Forms.TextBox();
            this.labelLoadSource = new System.Windows.Forms.Label();
            this.textBoxSourceFilePath = new System.Windows.Forms.TextBox();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.labelSource = new System.Windows.Forms.Label();
            this.listViewGeneralWarningsAndErrors = new System.Windows.Forms.ListView();
            this.columnHeaderGeneralSystem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeadGeneralType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderGeneralLine = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderGeneralCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderGeneralGrammar = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderGeneralToken = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderGeneralTokenIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderGeneralMsg = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelWarningError = new System.Windows.Forms.Label();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageSource = new System.Windows.Forms.TabPage();
            this.labelGeneralErrorTotal = new System.Windows.Forms.Label();
            this.labelGeneralErrorLabel = new System.Windows.Forms.Label();
            this.labelGeneralWarningTotal = new System.Windows.Forms.Label();
            this.labelGeneralWarningLabel = new System.Windows.Forms.Label();
            this.buttonReset = new System.Windows.Forms.Button();
            this.labelCompilerReturnValue = new System.Windows.Forms.Label();
            this.labelCompilerReturnValueLabel = new System.Windows.Forms.Label();
            this.groupBoxOptions = new System.Windows.Forms.GroupBox();
            this.checkBoxShowMessages = new System.Windows.Forms.CheckBox();
            this.checkBoxShowParseErrorChain = new System.Windows.Forms.CheckBox();
            this.checkBoxOutputOpCodesToFile = new System.Windows.Forms.CheckBox();
            this.groupBoxProcess = new System.Windows.Forms.GroupBox();
            this.checkBoxCodeGenSuccess = new System.Windows.Forms.CheckBox();
            this.checkBoxOptimizationSuccess = new System.Windows.Forms.CheckBox();
            this.checkBoxSyamnticsSuccess = new System.Windows.Forms.CheckBox();
            this.checkBoxParserSuccess = new System.Windows.Forms.CheckBox();
            this.checkBoxLexerSuccess = new System.Windows.Forms.CheckBox();
            this.buttonCompile = new System.Windows.Forms.Button();
            this.labelGeneralMessages = new System.Windows.Forms.Label();
            this.textBoxGeneralMessages = new System.Windows.Forms.TextBox();
            this.tabPageLexer = new System.Windows.Forms.TabPage();
            this.labelLexerErrorTotal = new System.Windows.Forms.Label();
            this.labelLexerErrorLabel = new System.Windows.Forms.Label();
            this.labelLexerWarningsTotal = new System.Windows.Forms.Label();
            this.labelLexerMessages = new System.Windows.Forms.Label();
            this.textBoxLexerMessages = new System.Windows.Forms.TextBox();
            this.labelLexerWarningsLabel = new System.Windows.Forms.Label();
            this.labelLexerWarningErrors = new System.Windows.Forms.Label();
            this.listViewLexerWarningsAndErrors = new System.Windows.Forms.ListView();
            this.columnHeaderLexerType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLexerLine = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLexerColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLexerMessage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelLexerReturnValue = new System.Windows.Forms.Label();
            this.labelLexerReturnValueLabel = new System.Windows.Forms.Label();
            this.labelTokenStreamLabel = new System.Windows.Forms.Label();
            this.listViewTokenList = new System.Windows.Forms.ListView();
            this.columnHeaderToken = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLine = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageParse = new System.Windows.Forms.TabPage();
            this.labelCST = new System.Windows.Forms.Label();
            this.labelParserMessage = new System.Windows.Forms.Label();
            this.labelParserWarningError = new System.Windows.Forms.Label();
            this.listViewParserWarningsAndErrors = new System.Windows.Forms.ListView();
            this.columnHeaderParseType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderParseGrammar = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderParseToken = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderParseTokenIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderParseMessages = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelParserErrorTotal = new System.Windows.Forms.Label();
            this.labelParserErrorLabel = new System.Windows.Forms.Label();
            this.labelParserWarningTotal = new System.Windows.Forms.Label();
            this.textBoxParserMessages = new System.Windows.Forms.TextBox();
            this.labelParserWarningLabel = new System.Windows.Forms.Label();
            this.labelParserReturnValue = new System.Windows.Forms.Label();
            this.labelParserReturnValueLabel = new System.Windows.Forms.Label();
            this.treeViewCST = new System.Windows.Forms.TreeView();
            this.tabPageSymantics = new System.Windows.Forms.TabPage();
            this.labelSymanticAnalyzerWarningsErrors = new System.Windows.Forms.Label();
            this.listViewSymanticAnalyzerWarningsAndErrors = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelSymanticAnalyzerErrorTotal = new System.Windows.Forms.Label();
            this.labelSymanticAnalyzerErrorCountLabel = new System.Windows.Forms.Label();
            this.labelSymanticAnalyzerWarningTotal = new System.Windows.Forms.Label();
            this.labelSymanticAnalyzerWarningCountLabel = new System.Windows.Forms.Label();
            this.labelSymanticAnalyzerReturnValue = new System.Windows.Forms.Label();
            this.labelSyamanticAnalyzerReturnValueLabel = new System.Windows.Forms.Label();
            this.labelAST = new System.Windows.Forms.Label();
            this.labelSymanticAnalyzerMessages = new System.Windows.Forms.Label();
            this.textBoxSymanticAnalyzerMessages = new System.Windows.Forms.TextBox();
            this.treeViewAST = new System.Windows.Forms.TreeView();
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
            this.tabPageOptimization = new System.Windows.Forms.TabPage();
            this.tabPageCodeGeneration = new System.Windows.Forms.TabPage();
            this.tabControlMain.SuspendLayout();
            this.tabPageSource.SuspendLayout();
            this.groupBoxOptions.SuspendLayout();
            this.groupBoxProcess.SuspendLayout();
            this.tabPageLexer.SuspendLayout();
            this.tabPageParse.SuspendLayout();
            this.tabPageSymantics.SuspendLayout();
            this.tabPageSymbolTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxSource
            // 
            this.textBoxSource.Location = new System.Drawing.Point(6, 53);
            this.textBoxSource.Multiline = true;
            this.textBoxSource.Name = "textBoxSource";
            this.textBoxSource.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxSource.Size = new System.Drawing.Size(339, 419);
            this.textBoxSource.TabIndex = 0;
            // 
            // labelLoadSource
            // 
            this.labelLoadSource.AutoSize = true;
            this.labelLoadSource.Location = new System.Drawing.Point(6, 11);
            this.labelLoadSource.Name = "labelLoadSource";
            this.labelLoadSource.Size = new System.Drawing.Size(74, 13);
            this.labelLoadSource.TabIndex = 3;
            this.labelLoadSource.Text = "Load Source :";
            // 
            // textBoxSourceFilePath
            // 
            this.textBoxSourceFilePath.Location = new System.Drawing.Point(86, 8);
            this.textBoxSourceFilePath.Name = "textBoxSourceFilePath";
            this.textBoxSourceFilePath.Size = new System.Drawing.Size(420, 20);
            this.textBoxSourceFilePath.TabIndex = 4;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(599, 6);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 5;
            this.buttonLoad.Text = "L&oad";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(518, 6);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowse.TabIndex = 6;
            this.buttonBrowse.Text = "&Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // labelSource
            // 
            this.labelSource.AutoSize = true;
            this.labelSource.Location = new System.Drawing.Point(6, 37);
            this.labelSource.Name = "labelSource";
            this.labelSource.Size = new System.Drawing.Size(41, 13);
            this.labelSource.TabIndex = 11;
            this.labelSource.Text = "Source";
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
            this.listViewGeneralWarningsAndErrors.Size = new System.Drawing.Size(766, 116);
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
            this.columnHeaderGeneralGrammar.Width = 100;
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
            // labelWarningError
            // 
            this.labelWarningError.AutoSize = true;
            this.labelWarningError.Location = new System.Drawing.Point(3, 483);
            this.labelWarningError.Name = "labelWarningError";
            this.labelWarningError.Size = new System.Drawing.Size(90, 13);
            this.labelWarningError.TabIndex = 15;
            this.labelWarningError.Text = "Warnings / Errors";
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageSource);
            this.tabControlMain.Controls.Add(this.tabPageLexer);
            this.tabControlMain.Controls.Add(this.tabPageParse);
            this.tabControlMain.Controls.Add(this.tabPageSymantics);
            this.tabControlMain.Controls.Add(this.tabPageSymbolTable);
            this.tabControlMain.Controls.Add(this.tabPageOptimization);
            this.tabControlMain.Controls.Add(this.tabPageCodeGeneration);
            this.tabControlMain.Location = new System.Drawing.Point(-1, 11);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(793, 683);
            this.tabControlMain.TabIndex = 16;
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
            this.tabPageSource.Controls.Add(this.labelWarningError);
            this.tabPageSource.Controls.Add(this.labelLoadSource);
            this.tabPageSource.Controls.Add(this.labelGeneralMessages);
            this.tabPageSource.Controls.Add(this.textBoxGeneralMessages);
            this.tabPageSource.Controls.Add(this.listViewGeneralWarningsAndErrors);
            this.tabPageSource.Controls.Add(this.textBoxSourceFilePath);
            this.tabPageSource.Controls.Add(this.labelSource);
            this.tabPageSource.Controls.Add(this.buttonBrowse);
            this.tabPageSource.Controls.Add(this.buttonLoad);
            this.tabPageSource.Location = new System.Drawing.Point(4, 22);
            this.tabPageSource.Name = "tabPageSource";
            this.tabPageSource.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSource.Size = new System.Drawing.Size(785, 657);
            this.tabPageSource.TabIndex = 0;
            this.tabPageSource.Text = "Source";
            this.tabPageSource.UseVisualStyleBackColor = true;
            // 
            // labelGeneralErrorTotal
            // 
            this.labelGeneralErrorTotal.AutoSize = true;
            this.labelGeneralErrorTotal.Location = new System.Drawing.Point(742, 403);
            this.labelGeneralErrorTotal.Name = "labelGeneralErrorTotal";
            this.labelGeneralErrorTotal.Size = new System.Drawing.Size(19, 13);
            this.labelGeneralErrorTotal.TabIndex = 33;
            this.labelGeneralErrorTotal.Text = "00";
            // 
            // labelGeneralErrorLabel
            // 
            this.labelGeneralErrorLabel.AutoSize = true;
            this.labelGeneralErrorLabel.Location = new System.Drawing.Point(694, 403);
            this.labelGeneralErrorLabel.Name = "labelGeneralErrorLabel";
            this.labelGeneralErrorLabel.Size = new System.Drawing.Size(40, 13);
            this.labelGeneralErrorLabel.TabIndex = 32;
            this.labelGeneralErrorLabel.Text = "Errors :";
            // 
            // labelGeneralWarningTotal
            // 
            this.labelGeneralWarningTotal.AutoSize = true;
            this.labelGeneralWarningTotal.Location = new System.Drawing.Point(669, 403);
            this.labelGeneralWarningTotal.Name = "labelGeneralWarningTotal";
            this.labelGeneralWarningTotal.Size = new System.Drawing.Size(19, 13);
            this.labelGeneralWarningTotal.TabIndex = 31;
            this.labelGeneralWarningTotal.Text = "00";
            // 
            // labelGeneralWarningLabel
            // 
            this.labelGeneralWarningLabel.AutoSize = true;
            this.labelGeneralWarningLabel.Location = new System.Drawing.Point(606, 403);
            this.labelGeneralWarningLabel.Name = "labelGeneralWarningLabel";
            this.labelGeneralWarningLabel.Size = new System.Drawing.Size(58, 13);
            this.labelGeneralWarningLabel.TabIndex = 30;
            this.labelGeneralWarningLabel.Text = "Warnings :";
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(616, 628);
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
            this.labelCompilerReturnValue.Location = new System.Drawing.Point(605, 345);
            this.labelCompilerReturnValue.Name = "labelCompilerReturnValue";
            this.labelCompilerReturnValue.Size = new System.Drawing.Size(159, 50);
            this.labelCompilerReturnValue.TabIndex = 28;
            this.labelCompilerReturnValue.Text = "                                                  ";
            // 
            // labelCompilerReturnValueLabel
            // 
            this.labelCompilerReturnValueLabel.AutoSize = true;
            this.labelCompilerReturnValueLabel.Location = new System.Drawing.Point(602, 321);
            this.labelCompilerReturnValueLabel.Name = "labelCompilerReturnValueLabel";
            this.labelCompilerReturnValueLabel.Size = new System.Drawing.Size(118, 13);
            this.labelCompilerReturnValueLabel.TabIndex = 27;
            this.labelCompilerReturnValueLabel.Text = "Compiler Return Value :";
            // 
            // groupBoxOptions
            // 
            this.groupBoxOptions.Controls.Add(this.checkBoxShowMessages);
            this.groupBoxOptions.Controls.Add(this.checkBoxShowParseErrorChain);
            this.groupBoxOptions.Controls.Add(this.checkBoxOutputOpCodesToFile);
            this.groupBoxOptions.Location = new System.Drawing.Point(605, 196);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Size = new System.Drawing.Size(167, 92);
            this.groupBoxOptions.TabIndex = 26;
            this.groupBoxOptions.TabStop = false;
            this.groupBoxOptions.Text = "Options";
            // 
            // checkBoxShowMessages
            // 
            this.checkBoxShowMessages.AutoSize = true;
            this.checkBoxShowMessages.Checked = true;
            this.checkBoxShowMessages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowMessages.Location = new System.Drawing.Point(6, 65);
            this.checkBoxShowMessages.Name = "checkBoxShowMessages";
            this.checkBoxShowMessages.Size = new System.Drawing.Size(104, 17);
            this.checkBoxShowMessages.TabIndex = 27;
            this.checkBoxShowMessages.Text = "Show &Messages";
            this.checkBoxShowMessages.UseVisualStyleBackColor = true;
            this.checkBoxShowMessages.CheckedChanged += new System.EventHandler(this.checkBoxShowMessages_CheckedChanged);
            // 
            // checkBoxShowParseErrorChain
            // 
            this.checkBoxShowParseErrorChain.AutoSize = true;
            this.checkBoxShowParseErrorChain.Location = new System.Drawing.Point(6, 19);
            this.checkBoxShowParseErrorChain.Name = "checkBoxShowParseErrorChain";
            this.checkBoxShowParseErrorChain.Size = new System.Drawing.Size(138, 17);
            this.checkBoxShowParseErrorChain.TabIndex = 26;
            this.checkBoxShowParseErrorChain.Text = "Show &Parse Error Chain";
            this.checkBoxShowParseErrorChain.UseVisualStyleBackColor = true;
            this.checkBoxShowParseErrorChain.CheckedChanged += new System.EventHandler(this.checkBoxShowParseErrorChain_CheckedChanged);
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
            this.groupBoxProcess.Location = new System.Drawing.Point(605, 53);
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
            this.buttonCompile.Location = new System.Drawing.Point(697, 628);
            this.buttonCompile.Name = "buttonCompile";
            this.buttonCompile.Size = new System.Drawing.Size(75, 23);
            this.buttonCompile.TabIndex = 16;
            this.buttonCompile.Text = "&Compile";
            this.buttonCompile.UseVisualStyleBackColor = true;
            this.buttonCompile.Click += new System.EventHandler(this.buttonCompile_Click);
            // 
            // labelGeneralMessages
            // 
            this.labelGeneralMessages.AutoSize = true;
            this.labelGeneralMessages.Location = new System.Drawing.Point(358, 37);
            this.labelGeneralMessages.Name = "labelGeneralMessages";
            this.labelGeneralMessages.Size = new System.Drawing.Size(55, 13);
            this.labelGeneralMessages.TabIndex = 8;
            this.labelGeneralMessages.Text = "Messages";
            // 
            // textBoxGeneralMessages
            // 
            this.textBoxGeneralMessages.Location = new System.Drawing.Point(361, 53);
            this.textBoxGeneralMessages.Multiline = true;
            this.textBoxGeneralMessages.Name = "textBoxGeneralMessages";
            this.textBoxGeneralMessages.ReadOnly = true;
            this.textBoxGeneralMessages.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxGeneralMessages.Size = new System.Drawing.Size(232, 419);
            this.textBoxGeneralMessages.TabIndex = 7;
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
            this.tabPageLexer.Size = new System.Drawing.Size(785, 657);
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
            // tabPageParse
            // 
            this.tabPageParse.Controls.Add(this.labelCST);
            this.tabPageParse.Controls.Add(this.labelParserMessage);
            this.tabPageParse.Controls.Add(this.labelParserWarningError);
            this.tabPageParse.Controls.Add(this.listViewParserWarningsAndErrors);
            this.tabPageParse.Controls.Add(this.labelParserErrorTotal);
            this.tabPageParse.Controls.Add(this.labelParserErrorLabel);
            this.tabPageParse.Controls.Add(this.labelParserWarningTotal);
            this.tabPageParse.Controls.Add(this.textBoxParserMessages);
            this.tabPageParse.Controls.Add(this.labelParserWarningLabel);
            this.tabPageParse.Controls.Add(this.labelParserReturnValue);
            this.tabPageParse.Controls.Add(this.labelParserReturnValueLabel);
            this.tabPageParse.Controls.Add(this.treeViewCST);
            this.tabPageParse.Location = new System.Drawing.Point(4, 22);
            this.tabPageParse.Name = "tabPageParse";
            this.tabPageParse.Size = new System.Drawing.Size(785, 657);
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
            // tabPageSymantics
            // 
            this.tabPageSymantics.Controls.Add(this.labelSymanticAnalyzerWarningsErrors);
            this.tabPageSymantics.Controls.Add(this.listViewSymanticAnalyzerWarningsAndErrors);
            this.tabPageSymantics.Controls.Add(this.labelSymanticAnalyzerErrorTotal);
            this.tabPageSymantics.Controls.Add(this.labelSymanticAnalyzerErrorCountLabel);
            this.tabPageSymantics.Controls.Add(this.labelSymanticAnalyzerWarningTotal);
            this.tabPageSymantics.Controls.Add(this.labelSymanticAnalyzerWarningCountLabel);
            this.tabPageSymantics.Controls.Add(this.labelSymanticAnalyzerReturnValue);
            this.tabPageSymantics.Controls.Add(this.labelSyamanticAnalyzerReturnValueLabel);
            this.tabPageSymantics.Controls.Add(this.labelAST);
            this.tabPageSymantics.Controls.Add(this.labelSymanticAnalyzerMessages);
            this.tabPageSymantics.Controls.Add(this.textBoxSymanticAnalyzerMessages);
            this.tabPageSymantics.Controls.Add(this.treeViewAST);
            this.tabPageSymantics.Location = new System.Drawing.Point(4, 22);
            this.tabPageSymantics.Name = "tabPageSymantics";
            this.tabPageSymantics.Size = new System.Drawing.Size(785, 657);
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
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listViewSymanticAnalyzerWarningsAndErrors.Location = new System.Drawing.Point(9, 538);
            this.listViewSymanticAnalyzerWarningsAndErrors.Name = "listViewSymanticAnalyzerWarningsAndErrors";
            this.listViewSymanticAnalyzerWarningsAndErrors.Size = new System.Drawing.Size(766, 116);
            this.listViewSymanticAnalyzerWarningsAndErrors.TabIndex = 37;
            this.listViewSymanticAnalyzerWarningsAndErrors.UseCompatibleStateImageBehavior = false;
            this.listViewSymanticAnalyzerWarningsAndErrors.View = System.Windows.Forms.View.Details;
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
            this.columnHeader3.Text = "Token";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Token Index";
            this.columnHeader4.Width = 80;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Message";
            this.columnHeader5.Width = 807;
            // 
            // labelSymanticAnalyzerErrorTotal
            // 
            this.labelSymanticAnalyzerErrorTotal.AutoSize = true;
            this.labelSymanticAnalyzerErrorTotal.Location = new System.Drawing.Point(690, 60);
            this.labelSymanticAnalyzerErrorTotal.Name = "labelSymanticAnalyzerErrorTotal";
            this.labelSymanticAnalyzerErrorTotal.Size = new System.Drawing.Size(19, 13);
            this.labelSymanticAnalyzerErrorTotal.TabIndex = 36;
            this.labelSymanticAnalyzerErrorTotal.Text = "00";
            // 
            // labelSymanticAnalyzerErrorCountLabel
            // 
            this.labelSymanticAnalyzerErrorCountLabel.AutoSize = true;
            this.labelSymanticAnalyzerErrorCountLabel.Location = new System.Drawing.Point(644, 60);
            this.labelSymanticAnalyzerErrorCountLabel.Name = "labelSymanticAnalyzerErrorCountLabel";
            this.labelSymanticAnalyzerErrorCountLabel.Size = new System.Drawing.Size(40, 13);
            this.labelSymanticAnalyzerErrorCountLabel.TabIndex = 35;
            this.labelSymanticAnalyzerErrorCountLabel.Text = "Errors :";
            // 
            // labelSymanticAnalyzerWarningTotal
            // 
            this.labelSymanticAnalyzerWarningTotal.AutoSize = true;
            this.labelSymanticAnalyzerWarningTotal.Location = new System.Drawing.Point(619, 60);
            this.labelSymanticAnalyzerWarningTotal.Name = "labelSymanticAnalyzerWarningTotal";
            this.labelSymanticAnalyzerWarningTotal.Size = new System.Drawing.Size(19, 13);
            this.labelSymanticAnalyzerWarningTotal.TabIndex = 34;
            this.labelSymanticAnalyzerWarningTotal.Text = "00";
            // 
            // labelSymanticAnalyzerWarningCountLabel
            // 
            this.labelSymanticAnalyzerWarningCountLabel.AutoSize = true;
            this.labelSymanticAnalyzerWarningCountLabel.Location = new System.Drawing.Point(555, 60);
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
            this.labelSymanticAnalyzerReturnValue.Size = new System.Drawing.Size(180, 15);
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
            this.labelSymanticAnalyzerMessages.Location = new System.Drawing.Point(555, 89);
            this.labelSymanticAnalyzerMessages.Name = "labelSymanticAnalyzerMessages";
            this.labelSymanticAnalyzerMessages.Size = new System.Drawing.Size(55, 13);
            this.labelSymanticAnalyzerMessages.TabIndex = 22;
            this.labelSymanticAnalyzerMessages.Text = "Messages";
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
            // treeViewAST
            // 
            this.treeViewAST.Location = new System.Drawing.Point(9, 36);
            this.treeViewAST.Name = "treeViewAST";
            this.treeViewAST.Size = new System.Drawing.Size(525, 469);
            this.treeViewAST.TabIndex = 0;
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
            this.tabPageSymbolTable.Size = new System.Drawing.Size(785, 657);
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
            // tabPageOptimization
            // 
            this.tabPageOptimization.Location = new System.Drawing.Point(4, 22);
            this.tabPageOptimization.Name = "tabPageOptimization";
            this.tabPageOptimization.Size = new System.Drawing.Size(785, 657);
            this.tabPageOptimization.TabIndex = 4;
            this.tabPageOptimization.Text = "Optimization";
            this.tabPageOptimization.UseVisualStyleBackColor = true;
            // 
            // tabPageCodeGeneration
            // 
            this.tabPageCodeGeneration.Location = new System.Drawing.Point(4, 22);
            this.tabPageCodeGeneration.Name = "tabPageCodeGeneration";
            this.tabPageCodeGeneration.Size = new System.Drawing.Size(785, 657);
            this.tabPageCodeGeneration.TabIndex = 5;
            this.tabPageCodeGeneration.Text = "Code Generation";
            this.tabPageCodeGeneration.UseVisualStyleBackColor = true;
            // 
            // CompilerInterfaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 695);
            this.Controls.Add(this.tabControlMain);
            this.Name = "CompilerInterfaceForm";
            this.Text = "Compiler Interface";
            this.tabControlMain.ResumeLayout(false);
            this.tabPageSource.ResumeLayout(false);
            this.tabPageSource.PerformLayout();
            this.groupBoxOptions.ResumeLayout(false);
            this.groupBoxOptions.PerformLayout();
            this.groupBoxProcess.ResumeLayout(false);
            this.groupBoxProcess.PerformLayout();
            this.tabPageLexer.ResumeLayout(false);
            this.tabPageLexer.PerformLayout();
            this.tabPageParse.ResumeLayout(false);
            this.tabPageParse.PerformLayout();
            this.tabPageSymantics.ResumeLayout(false);
            this.tabPageSymantics.PerformLayout();
            this.tabPageSymbolTable.ResumeLayout(false);
            this.tabPageSymbolTable.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSource;
        private System.Windows.Forms.Label labelLoadSource;
        private System.Windows.Forms.TextBox textBoxSourceFilePath;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Label labelSource;
        private System.Windows.Forms.ListView listViewGeneralWarningsAndErrors;
        private System.Windows.Forms.ColumnHeader columnHeadGeneralType;
        private System.Windows.Forms.ColumnHeader columnHeaderGeneralLine;
        private System.Windows.Forms.ColumnHeader columnHeaderGeneralCol;
        private System.Windows.Forms.ColumnHeader columnHeaderGeneralMsg;
        private System.Windows.Forms.Label labelWarningError;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageSource;
        private System.Windows.Forms.TabPage tabPageLexer;
        private System.Windows.Forms.Label labelGeneralMessages;
        private System.Windows.Forms.TextBox textBoxGeneralMessages;
        private System.Windows.Forms.TabPage tabPageParse;
        private System.Windows.Forms.TabPage tabPageSymantics;
        private System.Windows.Forms.TabPage tabPageOptimization;
        private System.Windows.Forms.TabPage tabPageCodeGeneration;
        private System.Windows.Forms.Button buttonCompile;
        private System.Windows.Forms.GroupBox groupBoxProcess;
        private System.Windows.Forms.CheckBox checkBoxParserSuccess;
        private System.Windows.Forms.CheckBox checkBoxLexerSuccess;
        private System.Windows.Forms.CheckBox checkBoxOutputOpCodesToFile;
        private System.Windows.Forms.CheckBox checkBoxCodeGenSuccess;
        private System.Windows.Forms.CheckBox checkBoxOptimizationSuccess;
        private System.Windows.Forms.CheckBox checkBoxSyamnticsSuccess;
        private System.Windows.Forms.Label labelCompilerReturnValue;
        private System.Windows.Forms.Label labelCompilerReturnValueLabel;
        private System.Windows.Forms.GroupBox groupBoxOptions;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Label labelTokenStreamLabel;
        private System.Windows.Forms.ListView listViewTokenList;
        private System.Windows.Forms.Label labelLexerReturnValue;
        private System.Windows.Forms.Label labelLexerReturnValueLabel;
        private System.Windows.Forms.ColumnHeader columnHeaderToken;
        private System.Windows.Forms.ColumnHeader columnHeaderLine;
        private System.Windows.Forms.ColumnHeader columnHeaderColumn;
        private System.Windows.Forms.ColumnHeader columnHeaderValue;
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
        private System.Windows.Forms.ColumnHeader columnHeaderGeneralSystem;
        private System.Windows.Forms.Label labelParserErrorTotal;
        private System.Windows.Forms.Label labelParserErrorLabel;
        private System.Windows.Forms.Label labelParserWarningTotal;
        private System.Windows.Forms.TextBox textBoxParserMessages;
        private System.Windows.Forms.Label labelParserWarningLabel;
        private System.Windows.Forms.Label labelParserReturnValue;
        private System.Windows.Forms.Label labelParserReturnValueLabel;
        private System.Windows.Forms.TreeView treeViewCST;
        private System.Windows.Forms.Label labelParserWarningError;
        private System.Windows.Forms.ListView listViewParserWarningsAndErrors;
        private System.Windows.Forms.ColumnHeader columnHeaderParseGrammar;
        private System.Windows.Forms.ColumnHeader columnHeaderParseToken;
        private System.Windows.Forms.ColumnHeader columnHeaderParseMessages;
        private System.Windows.Forms.Label labelCST;
        private System.Windows.Forms.Label labelParserMessage;
        private System.Windows.Forms.Label labelGeneralErrorTotal;
        private System.Windows.Forms.Label labelGeneralErrorLabel;
        private System.Windows.Forms.Label labelGeneralWarningTotal;
        private System.Windows.Forms.Label labelGeneralWarningLabel;
        private System.Windows.Forms.ColumnHeader columnHeaderGeneralGrammar;
        private System.Windows.Forms.ColumnHeader columnHeaderGeneralToken;
        private System.Windows.Forms.ColumnHeader columnHeaderGeneralTokenIndex;
        private System.Windows.Forms.ColumnHeader columnHeaderParseTokenIndex;
        private System.Windows.Forms.ColumnHeader columnHeaderParseType;
        private System.Windows.Forms.TabPage tabPageSymbolTable;
        private System.Windows.Forms.TreeView treeViewSymbolTable;
        private System.Windows.Forms.Label labelSymbolTable;
        private System.Windows.Forms.Label labelTotalVarsValue;
        private System.Windows.Forms.Label labelTotalVars;
        private System.Windows.Forms.Label labelBytes;
        private System.Windows.Forms.Label labelMaxMemoryValue;
        private System.Windows.Forms.Label labelMaxMemory;
        private System.Windows.Forms.Label labelTotalBooleanValue;
        private System.Windows.Forms.Label labelTotalBoolean;
        private System.Windows.Forms.Label labelTotalSringsValue;
        private System.Windows.Forms.Label labelTotalStrings;
        private System.Windows.Forms.Label labelTotalIntsValue;
        private System.Windows.Forms.Label labelTotalInts;
        private System.Windows.Forms.CheckBox checkBoxShowParseErrorChain;
        private System.Windows.Forms.CheckBox checkBoxShowMessages;
        private System.Windows.Forms.TreeView treeViewAST;
        private System.Windows.Forms.Label labelSymanticAnalyzerMessages;
        private System.Windows.Forms.TextBox textBoxSymanticAnalyzerMessages;
        private System.Windows.Forms.Label labelSymanticAnalyzerErrorTotal;
        private System.Windows.Forms.Label labelSymanticAnalyzerErrorCountLabel;
        private System.Windows.Forms.Label labelSymanticAnalyzerWarningTotal;
        private System.Windows.Forms.Label labelSymanticAnalyzerWarningCountLabel;
        private System.Windows.Forms.Label labelSymanticAnalyzerReturnValue;
        private System.Windows.Forms.Label labelSyamanticAnalyzerReturnValueLabel;
        private System.Windows.Forms.Label labelAST;
        private System.Windows.Forms.Label labelSymanticAnalyzerWarningsErrors;
        private System.Windows.Forms.ListView listViewSymanticAnalyzerWarningsAndErrors;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}

