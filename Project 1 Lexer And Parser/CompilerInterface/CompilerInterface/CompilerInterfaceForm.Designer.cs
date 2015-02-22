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
            this.textBoxSource = new System.Windows.Forms.TextBox();
            this.labelLoadSource = new System.Windows.Forms.Label();
            this.textBoxSourceFilePath = new System.Windows.Forms.TextBox();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.labelSource = new System.Windows.Forms.Label();
            this.listViewGeneralWarningsAndErrors = new System.Windows.Forms.ListView();
            this.columnHeaderGeneralSystem = new System.Windows.Forms.ColumnHeader();
            this.columnHeadGeneralType = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderGeneralLine = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderGeneralCol = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderGeneralMsg = new System.Windows.Forms.ColumnHeader();
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
            this.checkBoxOutputOpCodesToFile = new System.Windows.Forms.CheckBox();
            this.checkBoxOutputErrorsToFile = new System.Windows.Forms.CheckBox();
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
            this.tabPageParse = new System.Windows.Forms.TabPage();
            this.labelCST = new System.Windows.Forms.Label();
            this.labelParserMessage = new System.Windows.Forms.Label();
            this.labelParserWarningError = new System.Windows.Forms.Label();
            this.listViewParserWarningsAndErrors = new System.Windows.Forms.ListView();
            this.columnHeaderParseType = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderParseLine = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderParseColumn = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderParseMessages = new System.Windows.Forms.ColumnHeader();
            this.labelParserErrorTotal = new System.Windows.Forms.Label();
            this.labelParserErrorLabel = new System.Windows.Forms.Label();
            this.labelParserWarningTotal = new System.Windows.Forms.Label();
            this.textBoxParserMessages = new System.Windows.Forms.TextBox();
            this.labelParserWarningLabel = new System.Windows.Forms.Label();
            this.labelParserReturnValue = new System.Windows.Forms.Label();
            this.labelParserReturnValueLabel = new System.Windows.Forms.Label();
            this.treeViewCST = new System.Windows.Forms.TreeView();
            this.tabPageSymantics = new System.Windows.Forms.TabPage();
            this.tabPageOptimization = new System.Windows.Forms.TabPage();
            this.tabPageCodeGeneration = new System.Windows.Forms.TabPage();
            this.tabControlMain.SuspendLayout();
            this.tabPageSource.SuspendLayout();
            this.groupBoxOptions.SuspendLayout();
            this.groupBoxProcess.SuspendLayout();
            this.tabPageLexer.SuspendLayout();
            this.tabPageParse.SuspendLayout();
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
            this.labelGeneralErrorTotal.Location = new System.Drawing.Point(744, 347);
            this.labelGeneralErrorTotal.Name = "labelGeneralErrorTotal";
            this.labelGeneralErrorTotal.Size = new System.Drawing.Size(19, 13);
            this.labelGeneralErrorTotal.TabIndex = 33;
            this.labelGeneralErrorTotal.Text = "00";
            // 
            // labelGeneralErrorLabel
            // 
            this.labelGeneralErrorLabel.AutoSize = true;
            this.labelGeneralErrorLabel.Location = new System.Drawing.Point(696, 347);
            this.labelGeneralErrorLabel.Name = "labelGeneralErrorLabel";
            this.labelGeneralErrorLabel.Size = new System.Drawing.Size(40, 13);
            this.labelGeneralErrorLabel.TabIndex = 32;
            this.labelGeneralErrorLabel.Text = "Errors :";
            // 
            // labelGeneralWarningTotal
            // 
            this.labelGeneralWarningTotal.AutoSize = true;
            this.labelGeneralWarningTotal.Location = new System.Drawing.Point(671, 347);
            this.labelGeneralWarningTotal.Name = "labelGeneralWarningTotal";
            this.labelGeneralWarningTotal.Size = new System.Drawing.Size(19, 13);
            this.labelGeneralWarningTotal.TabIndex = 31;
            this.labelGeneralWarningTotal.Text = "00";
            // 
            // labelGeneralWarningLabel
            // 
            this.labelGeneralWarningLabel.AutoSize = true;
            this.labelGeneralWarningLabel.Location = new System.Drawing.Point(608, 347);
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
            this.labelCompilerReturnValue.Location = new System.Drawing.Point(605, 300);
            this.labelCompilerReturnValue.Name = "labelCompilerReturnValue";
            this.labelCompilerReturnValue.Size = new System.Drawing.Size(159, 35);
            this.labelCompilerReturnValue.TabIndex = 28;
            this.labelCompilerReturnValue.Text = "                                                  ";
            // 
            // labelCompilerReturnValueLabel
            // 
            this.labelCompilerReturnValueLabel.AutoSize = true;
            this.labelCompilerReturnValueLabel.Location = new System.Drawing.Point(602, 276);
            this.labelCompilerReturnValueLabel.Name = "labelCompilerReturnValueLabel";
            this.labelCompilerReturnValueLabel.Size = new System.Drawing.Size(118, 13);
            this.labelCompilerReturnValueLabel.TabIndex = 27;
            this.labelCompilerReturnValueLabel.Text = "Compiler Return Value :";
            // 
            // groupBoxOptions
            // 
            this.groupBoxOptions.Controls.Add(this.checkBoxOutputOpCodesToFile);
            this.groupBoxOptions.Controls.Add(this.checkBoxOutputErrorsToFile);
            this.groupBoxOptions.Location = new System.Drawing.Point(605, 196);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Size = new System.Drawing.Size(167, 68);
            this.groupBoxOptions.TabIndex = 26;
            this.groupBoxOptions.TabStop = false;
            this.groupBoxOptions.Text = "Options";
            // 
            // checkBoxOutputOpCodesToFile
            // 
            this.checkBoxOutputOpCodesToFile.AutoSize = true;
            this.checkBoxOutputOpCodesToFile.Location = new System.Drawing.Point(6, 42);
            this.checkBoxOutputOpCodesToFile.Name = "checkBoxOutputOpCodesToFile";
            this.checkBoxOutputOpCodesToFile.Size = new System.Drawing.Size(143, 17);
            this.checkBoxOutputOpCodesToFile.TabIndex = 25;
            this.checkBoxOutputOpCodesToFile.Text = "Output Op Codes To File";
            this.checkBoxOutputOpCodesToFile.UseVisualStyleBackColor = true;
            this.checkBoxOutputOpCodesToFile.CheckedChanged += new System.EventHandler(this.checkBoxOutputOpCodesToFile_CheckedChanged);
            // 
            // checkBoxOutputErrorsToFile
            // 
            this.checkBoxOutputErrorsToFile.AutoSize = true;
            this.checkBoxOutputErrorsToFile.Location = new System.Drawing.Point(6, 19);
            this.checkBoxOutputErrorsToFile.Name = "checkBoxOutputErrorsToFile";
            this.checkBoxOutputErrorsToFile.Size = new System.Drawing.Size(123, 17);
            this.checkBoxOutputErrorsToFile.TabIndex = 17;
            this.checkBoxOutputErrorsToFile.Text = "Output Errors To File";
            this.checkBoxOutputErrorsToFile.UseVisualStyleBackColor = true;
            this.checkBoxOutputErrorsToFile.CheckedChanged += new System.EventHandler(this.checkBoxOutputErrorsToFile_CheckedChanged);
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
            this.columnHeaderParseLine,
            this.columnHeaderParseColumn,
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
            this.columnHeaderParseType.Width = 80;
            // 
            // columnHeaderParseLine
            // 
            this.columnHeaderParseLine.Text = "Line";
            // 
            // columnHeaderParseColumn
            // 
            this.columnHeaderParseColumn.Text = "Column";
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
            this.tabPageSymantics.Location = new System.Drawing.Point(4, 22);
            this.tabPageSymantics.Name = "tabPageSymantics";
            this.tabPageSymantics.Size = new System.Drawing.Size(785, 657);
            this.tabPageSymantics.TabIndex = 3;
            this.tabPageSymantics.Text = "Symantics";
            this.tabPageSymantics.UseVisualStyleBackColor = true;
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
        private System.Windows.Forms.CheckBox checkBoxOutputErrorsToFile;
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
        private System.Windows.Forms.ColumnHeader columnHeaderParseType;
        private System.Windows.Forms.ColumnHeader columnHeaderParseLine;
        private System.Windows.Forms.ColumnHeader columnHeaderParseColumn;
        private System.Windows.Forms.ColumnHeader columnHeaderParseMessages;
        private System.Windows.Forms.Label labelCST;
        private System.Windows.Forms.Label labelParserMessage;
        private System.Windows.Forms.Label labelGeneralErrorTotal;
        private System.Windows.Forms.Label labelGeneralErrorLabel;
        private System.Windows.Forms.Label labelGeneralWarningTotal;
        private System.Windows.Forms.Label labelGeneralWarningLabel;
    }
}

