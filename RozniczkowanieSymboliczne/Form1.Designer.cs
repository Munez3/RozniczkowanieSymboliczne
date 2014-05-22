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
            this.menuStrip1.SuspendLayout();
            this.BasicPanel.SuspendLayout();
            this.FormulaPanel.SuspendLayout();
            this.FilePanel.SuspendLayout();
            this.outputPanel.SuspendLayout();
            this.outputFillPanel.SuspendLayout();
            this.outputTopPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Widok,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(562, 24);
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
            this.wyrazenieTB.Location = new System.Drawing.Point(98, 95);
            this.wyrazenieTB.Name = "wyrazenieTB";
            this.wyrazenieTB.Size = new System.Drawing.Size(341, 20);
            this.wyrazenieTB.TabIndex = 1;
            // 
            // WprowadzWyrazenieLabel
            // 
            this.WprowadzWyrazenieLabel.AutoSize = true;
            this.WprowadzWyrazenieLabel.Location = new System.Drawing.Point(95, 65);
            this.WprowadzWyrazenieLabel.Name = "WprowadzWyrazenieLabel";
            this.WprowadzWyrazenieLabel.Size = new System.Drawing.Size(108, 13);
            this.WprowadzWyrazenieLabel.TabIndex = 2;
            this.WprowadzWyrazenieLabel.Text = "Wprowadź wyrażenie";
            // 
            // BasicPanel
            // 
            this.BasicPanel.Controls.Add(this.liczProsteBtn);
            this.BasicPanel.Controls.Add(this.wyrazenieTB);
            this.BasicPanel.Controls.Add(this.WprowadzWyrazenieLabel);
            this.BasicPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BasicPanel.Location = new System.Drawing.Point(0, 0);
            this.BasicPanel.Name = "BasicPanel";
            this.BasicPanel.Size = new System.Drawing.Size(562, 544);
            this.BasicPanel.TabIndex = 3;
            // 
            // liczProsteBtn
            // 
            this.liczProsteBtn.Location = new System.Drawing.Point(457, 92);
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
            this.OutputTB.Size = new System.Drawing.Size(562, 248);
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
            this.FormulaPanel.Size = new System.Drawing.Size(562, 544);
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
                "+20*x)^3\nend\n\n2*x^3+2*sin(log(2,50*x)+20*x)^3\n2*x^3+2*sin(log(2,50*x)+20*x)^4\n%d" +
                "rugi komentarz";
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
            this.FilePanel.Size = new System.Drawing.Size(562, 544);
            this.FilePanel.TabIndex = 2;
            // 
            // filePathBtn
            // 
            this.filePathBtn.Location = new System.Drawing.Point(406, 57);
            this.filePathBtn.Name = "filePathBtn";
            this.filePathBtn.Size = new System.Drawing.Size(33, 21);
            this.filePathBtn.TabIndex = 3;
            this.filePathBtn.Text = "...";
            this.filePathBtn.UseVisualStyleBackColor = true;
            this.filePathBtn.Click += new System.EventHandler(this.filePathBtn_Click);
            // 
            // filePathTB
            // 
            this.filePathTB.Location = new System.Drawing.Point(120, 57);
            this.filePathTB.Name = "filePathTB";
            this.filePathTB.Size = new System.Drawing.Size(280, 20);
            this.filePathTB.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ścieżka do pliku:";
            // 
            // liczFileBtn
            // 
            this.liczFileBtn.Location = new System.Drawing.Point(447, 57);
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
            this.outputPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.outputPanel.Location = new System.Drawing.Point(0, 242);
            this.outputPanel.Name = "outputPanel";
            this.outputPanel.Size = new System.Drawing.Size(562, 302);
            this.outputPanel.TabIndex = 6;
            // 
            // outputFillPanel
            // 
            this.outputFillPanel.Controls.Add(this.OutputTB);
            this.outputFillPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputFillPanel.Location = new System.Drawing.Point(0, 18);
            this.outputFillPanel.Name = "outputFillPanel";
            this.outputFillPanel.Size = new System.Drawing.Size(562, 248);
            this.outputFillPanel.TabIndex = 6;
            // 
            // outputTopPanel
            // 
            this.outputTopPanel.Controls.Add(this.label1);
            this.outputTopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.outputTopPanel.Location = new System.Drawing.Point(0, 0);
            this.outputTopPanel.Name = "outputTopPanel";
            this.outputTopPanel.Size = new System.Drawing.Size(562, 18);
            this.outputTopPanel.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 266);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(562, 36);
            this.panel1.TabIndex = 7;
            // 
            // BasicForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 544);
            this.Controls.Add(this.outputPanel);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.FormulaPanel);
            this.Controls.Add(this.FilePanel);
            this.Controls.Add(this.BasicPanel);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "BasicForm";
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
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}

