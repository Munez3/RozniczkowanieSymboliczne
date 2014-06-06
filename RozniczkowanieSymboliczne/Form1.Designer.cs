namespace RozniczkowanieSymboliczne
{
    partial class BasicForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Widok = new System.Windows.Forms.ToolStripMenuItem();
            this.podstawowyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programistycznyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plikowyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wyrazenieTB = new System.Windows.Forms.TextBox();
            this.WprowadzWyrazenieLabel = new System.Windows.Forms.Label();
            this.BasicPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.listaIdentowLB = new System.Windows.Forms.ListBox();
            this.porzadkujBtn = new System.Windows.Forms.Button();
            this.liczProsteBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.OutputTB = new System.Windows.Forms.RichTextBox();
            this.FormulaPanel = new System.Windows.Forms.Panel();
            this.liczProgramBtn = new System.Windows.Forms.Button();
            this.WprowadzFormulaLabel = new System.Windows.Forms.Label();
            this.FormulaTB = new System.Windows.Forms.RichTextBox();
            this.FilePanel = new System.Windows.Forms.Panel();
            this.filePathBtn = new System.Windows.Forms.Button();
            this.filePathTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.liczFileBtn = new System.Windows.Forms.Button();
            this.outputPanel = new System.Windows.Forms.Panel();
            this.outputFillPanel = new System.Windows.Forms.Panel();
            this.outputTopPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.trybDebugCB = new System.Windows.Forms.CheckBox();
            this.WriteButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.topPanel = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.BasicPanel.SuspendLayout();
            this.FormulaPanel.SuspendLayout();
            this.FilePanel.SuspendLayout();
            this.outputPanel.SuspendLayout();
            this.outputFillPanel.SuspendLayout();
            this.outputTopPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Widok,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(560, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Widok
            // 
            this.Widok.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.podstawowyToolStripMenuItem,
            this.programistycznyToolStripMenuItem,
            this.plikowyToolStripMenuItem});
            this.Widok.Name = "Widok";
            this.Widok.Size = new System.Drawing.Size(53, 20);
            this.Widok.Text = "Widok";
            // 
            // podstawowyToolStripMenuItem
            // 
            this.podstawowyToolStripMenuItem.Name = "podstawowyToolStripMenuItem";
            this.podstawowyToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.podstawowyToolStripMenuItem.Text = "Podstawowy";
            this.podstawowyToolStripMenuItem.Click += new System.EventHandler(this.podstawowyToolStripMenuItem_Click);
            // 
            // programistycznyToolStripMenuItem
            // 
            this.programistycznyToolStripMenuItem.Name = "programistycznyToolStripMenuItem";
            this.programistycznyToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.programistycznyToolStripMenuItem.Text = "Programistyczny";
            this.programistycznyToolStripMenuItem.Click += new System.EventHandler(this.programistycznyToolStripMenuItem_Click);
            // 
            // plikowyToolStripMenuItem
            // 
            this.plikowyToolStripMenuItem.Name = "plikowyToolStripMenuItem";
            this.plikowyToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.plikowyToolStripMenuItem.Text = "Plikowy";
            this.plikowyToolStripMenuItem.Click += new System.EventHandler(this.plikowyToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // wyrazenieTB
            // 
            this.wyrazenieTB.Location = new System.Drawing.Point(20, 75);
            this.wyrazenieTB.Name = "wyrazenieTB";
            this.wyrazenieTB.Size = new System.Drawing.Size(419, 20);
            this.wyrazenieTB.TabIndex = 1;
            this.wyrazenieTB.TextChanged += new System.EventHandler(this.wyrazenieTB_TextChanged);
            this.wyrazenieTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.wyrazenieTB_KeyDown);
            // 
            // WprowadzWyrazenieLabel
            // 
            this.WprowadzWyrazenieLabel.AutoSize = true;
            this.WprowadzWyrazenieLabel.Location = new System.Drawing.Point(17, 45);
            this.WprowadzWyrazenieLabel.Name = "WprowadzWyrazenieLabel";
            this.WprowadzWyrazenieLabel.Size = new System.Drawing.Size(108, 13);
            this.WprowadzWyrazenieLabel.TabIndex = 2;
            this.WprowadzWyrazenieLabel.Text = "Wprowadź wyrażenie";
            // 
            // BasicPanel
            // 
            this.BasicPanel.Controls.Add(this.label3);
            this.BasicPanel.Controls.Add(this.listaIdentowLB);
            this.BasicPanel.Controls.Add(this.porzadkujBtn);
            this.BasicPanel.Controls.Add(this.liczProsteBtn);
            this.BasicPanel.Controls.Add(this.wyrazenieTB);
            this.BasicPanel.Controls.Add(this.WprowadzWyrazenieLabel);
            this.BasicPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BasicPanel.Location = new System.Drawing.Point(0, 0);
            this.BasicPanel.Name = "BasicPanel";
            this.BasicPanel.Size = new System.Drawing.Size(560, 244);
            this.BasicPanel.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Zmienna po której chcemy pochodniować:";
            // 
            // listaIdentowLB
            // 
            this.listaIdentowLB.FormattingEnabled = true;
            this.listaIdentowLB.Location = new System.Drawing.Point(234, 113);
            this.listaIdentowLB.Name = "listaIdentowLB";
            this.listaIdentowLB.Size = new System.Drawing.Size(205, 121);
            this.listaIdentowLB.TabIndex = 7;
            // 
            // porzadkujBtn
            // 
            this.porzadkujBtn.Location = new System.Drawing.Point(457, 104);
            this.porzadkujBtn.Name = "porzadkujBtn";
            this.porzadkujBtn.Size = new System.Drawing.Size(75, 23);
            this.porzadkujBtn.TabIndex = 6;
            this.porzadkujBtn.Text = "Porządkuj";
            this.porzadkujBtn.UseVisualStyleBackColor = true;
            this.porzadkujBtn.Click += new System.EventHandler(this.porzadkujBtn_Click);
            // 
            // liczProsteBtn
            // 
            this.liczProsteBtn.Location = new System.Drawing.Point(457, 74);
            this.liczProsteBtn.Name = "liczProsteBtn";
            this.liczProsteBtn.Size = new System.Drawing.Size(75, 23);
            this.liczProsteBtn.TabIndex = 5;
            this.liczProsteBtn.Text = "Licz";
            this.liczProsteBtn.UseVisualStyleBackColor = true;
            this.liczProsteBtn.Click += new System.EventHandler(this.liczProsteBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Output:";
            // 
            // OutputTB
            // 
            this.OutputTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutputTB.Location = new System.Drawing.Point(0, 0);
            this.OutputTB.Name = "OutputTB";
            this.OutputTB.ReadOnly = true;
            this.OutputTB.Size = new System.Drawing.Size(560, 268);
            this.OutputTB.TabIndex = 3;
            this.OutputTB.Text = "";
            // 
            // FormulaPanel
            // 
            this.FormulaPanel.Controls.Add(this.liczProgramBtn);
            this.FormulaPanel.Controls.Add(this.WprowadzFormulaLabel);
            this.FormulaPanel.Controls.Add(this.FormulaTB);
            this.FormulaPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormulaPanel.Location = new System.Drawing.Point(0, 0);
            this.FormulaPanel.Name = "FormulaPanel";
            this.FormulaPanel.Size = new System.Drawing.Size(560, 244);
            this.FormulaPanel.TabIndex = 3;
            // 
            // liczProgramBtn
            // 
            this.liczProgramBtn.Location = new System.Drawing.Point(15, 213);
            this.liczProgramBtn.Name = "liczProgramBtn";
            this.liczProgramBtn.Size = new System.Drawing.Size(75, 23);
            this.liczProgramBtn.TabIndex = 2;
            this.liczProgramBtn.Text = "Licz";
            this.liczProgramBtn.UseVisualStyleBackColor = true;
            this.liczProgramBtn.Click += new System.EventHandler(this.liczProgramBtn_Click);
            // 
            // WprowadzFormulaLabel
            // 
            this.WprowadzFormulaLabel.AutoSize = true;
            this.WprowadzFormulaLabel.Location = new System.Drawing.Point(12, 33);
            this.WprowadzFormulaLabel.Name = "WprowadzFormulaLabel";
            this.WprowadzFormulaLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.WprowadzFormulaLabel.Size = new System.Drawing.Size(97, 13);
            this.WprowadzFormulaLabel.TabIndex = 1;
            this.WprowadzFormulaLabel.Text = "Wprowadź formułę";
            // 
            // FormulaTB
            // 
            this.FormulaTB.Location = new System.Drawing.Point(15, 62);
            this.FormulaTB.Name = "FormulaTB";
            this.FormulaTB.Size = new System.Drawing.Size(517, 140);
            this.FormulaTB.TabIndex = 0;
            this.FormulaTB.Text = "for i=0:10 %komentarz\n\tx^3+4*x*i+2+i\n                i*x\n\t2*x^3+2*sin(log(2,50*x)" +
    "+20*x)^3\nendfor\n\n2*x^3+2*sin(log(2,50*x)+20*x)^3\n2*x^3+2*sin(log(2,50*x)+20*x)^4" +
    "\n%drugi komentarz";
            // 
            // FilePanel
            // 
            this.FilePanel.Controls.Add(this.filePathBtn);
            this.FilePanel.Controls.Add(this.filePathTB);
            this.FilePanel.Controls.Add(this.label2);
            this.FilePanel.Controls.Add(this.liczFileBtn);
            this.FilePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilePanel.Location = new System.Drawing.Point(0, 0);
            this.FilePanel.Name = "FilePanel";
            this.FilePanel.Size = new System.Drawing.Size(560, 244);
            this.FilePanel.TabIndex = 2;
            // 
            // filePathBtn
            // 
            this.filePathBtn.Location = new System.Drawing.Point(406, 40);
            this.filePathBtn.Name = "filePathBtn";
            this.filePathBtn.Size = new System.Drawing.Size(33, 21);
            this.filePathBtn.TabIndex = 3;
            this.filePathBtn.Text = "...";
            this.filePathBtn.UseVisualStyleBackColor = true;
            this.filePathBtn.Click += new System.EventHandler(this.filePathBtn_Click);
            // 
            // filePathTB
            // 
            this.filePathTB.Location = new System.Drawing.Point(120, 41);
            this.filePathTB.Name = "filePathTB";
            this.filePathTB.Size = new System.Drawing.Size(280, 20);
            this.filePathTB.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ścieżka do pliku:";
            // 
            // liczFileBtn
            // 
            this.liczFileBtn.Location = new System.Drawing.Point(447, 40);
            this.liczFileBtn.Name = "liczFileBtn";
            this.liczFileBtn.Size = new System.Drawing.Size(72, 21);
            this.liczFileBtn.TabIndex = 0;
            this.liczFileBtn.Text = "Licz";
            this.liczFileBtn.UseVisualStyleBackColor = true;
            this.liczFileBtn.Click += new System.EventHandler(this.liczFileBtn_Click);
            // 
            // outputPanel
            // 
            this.outputPanel.Controls.Add(this.outputFillPanel);
            this.outputPanel.Controls.Add(this.outputTopPanel);
            this.outputPanel.Controls.Add(this.panel1);
            this.outputPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputPanel.Location = new System.Drawing.Point(0, 0);
            this.outputPanel.Name = "outputPanel";
            this.outputPanel.Padding = new System.Windows.Forms.Padding(0, 243, 0, 0);
            this.outputPanel.Size = new System.Drawing.Size(560, 565);
            this.outputPanel.TabIndex = 6;
            // 
            // outputFillPanel
            // 
            this.outputFillPanel.Controls.Add(this.OutputTB);
            this.outputFillPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputFillPanel.Location = new System.Drawing.Point(0, 261);
            this.outputFillPanel.Name = "outputFillPanel";
            this.outputFillPanel.Size = new System.Drawing.Size(560, 268);
            this.outputFillPanel.TabIndex = 6;
            // 
            // outputTopPanel
            // 
            this.outputTopPanel.Controls.Add(this.label1);
            this.outputTopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.outputTopPanel.Location = new System.Drawing.Point(0, 243);
            this.outputTopPanel.Name = "outputTopPanel";
            this.outputTopPanel.Size = new System.Drawing.Size(560, 18);
            this.outputTopPanel.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.trybDebugCB);
            this.panel1.Controls.Add(this.WriteButton);
            this.panel1.Controls.Add(this.ClearButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 529);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(560, 36);
            this.panel1.TabIndex = 7;
            // 
            // trybDebugCB
            // 
            this.trybDebugCB.AutoSize = true;
            this.trybDebugCB.Checked = true;
            this.trybDebugCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.trybDebugCB.Location = new System.Drawing.Point(359, 10);
            this.trybDebugCB.Name = "trybDebugCB";
            this.trybDebugCB.Size = new System.Drawing.Size(80, 17);
            this.trybDebugCB.TabIndex = 2;
            this.trybDebugCB.Text = "Tryb debug";
            this.trybDebugCB.UseVisualStyleBackColor = true;
            this.trybDebugCB.CheckedChanged += new System.EventHandler(this.trybDebugCB_CheckedChanged);
            // 
            // WriteButton
            // 
            this.WriteButton.Location = new System.Drawing.Point(475, 5);
            this.WriteButton.Name = "WriteButton";
            this.WriteButton.Size = new System.Drawing.Size(75, 23);
            this.WriteButton.TabIndex = 1;
            this.WriteButton.Text = "Zapisz";
            this.WriteButton.UseVisualStyleBackColor = true;
            this.WriteButton.Click += new System.EventHandler(this.WriteButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(6, 6);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 23);
            this.ClearButton.TabIndex = 0;
            this.ClearButton.Text = "Wyczyść";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.menuStrip1);
            this.topPanel.Controls.Add(this.BasicPanel);
            this.topPanel.Controls.Add(this.FilePanel);
            this.topPanel.Controls.Add(this.FormulaPanel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(560, 244);
            this.topPanel.TabIndex = 7;
            // 
            // BasicForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 565);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.outputPanel);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "BasicForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Różniczkowanie Symboliczne";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.BasicPanel.ResumeLayout(false);
            this.BasicPanel.PerformLayout();
            this.FormulaPanel.ResumeLayout(false);
            this.FormulaPanel.PerformLayout();
            this.FilePanel.ResumeLayout(false);
            this.FilePanel.PerformLayout();
            this.outputPanel.ResumeLayout(false);
            this.outputFillPanel.ResumeLayout(false);
            this.outputTopPanel.ResumeLayout(false);
            this.outputTopPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Widok;
        private System.Windows.Forms.ToolStripMenuItem podstawowyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem programistycznyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem plikowyToolStripMenuItem;
        private System.Windows.Forms.TextBox wyrazenieTB;
        private System.Windows.Forms.Label WprowadzWyrazenieLabel;
        private System.Windows.Forms.Panel BasicPanel;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Panel FormulaPanel;
        private System.Windows.Forms.Label WprowadzFormulaLabel;
        private System.Windows.Forms.RichTextBox FormulaTB;
        private System.Windows.Forms.Panel FilePanel;
        private System.Windows.Forms.RichTextBox OutputTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button liczProsteBtn;
        private System.Windows.Forms.Panel outputPanel;
        private System.Windows.Forms.Panel outputTopPanel;
        private System.Windows.Forms.Panel outputFillPanel;
        private System.Windows.Forms.Button liczProgramBtn;
        private System.Windows.Forms.Button liczFileBtn;
        private System.Windows.Forms.Button filePathBtn;
        private System.Windows.Forms.TextBox filePathTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button WriteButton;
        private System.Windows.Forms.CheckBox trybDebugCB;
        private System.Windows.Forms.Button porzadkujBtn;
        private System.Windows.Forms.ListBox listaIdentowLB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel topPanel;
    }
}

