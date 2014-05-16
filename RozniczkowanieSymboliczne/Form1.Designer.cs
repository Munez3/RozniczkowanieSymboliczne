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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.WprowadzWyrazenieLabel = new System.Windows.Forms.Label();
            this.BasicPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.OutputTB = new System.Windows.Forms.RichTextBox();
            this.FormulaPanel = new System.Windows.Forms.Panel();
            this.WprowadzFormulaLabel = new System.Windows.Forms.Label();
            this.FormulaTextBox = new System.Windows.Forms.RichTextBox();
            this.FilePanel = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.BasicPanel.SuspendLayout();
            this.FormulaPanel.SuspendLayout();
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
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(98, 95);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(341, 20);
            this.textBox1.TabIndex = 1;
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
            this.BasicPanel.Controls.Add(this.label1);
            this.BasicPanel.Controls.Add(this.OutputTB);
            this.BasicPanel.Controls.Add(this.textBox1);
            this.BasicPanel.Controls.Add(this.WprowadzWyrazenieLabel);
            this.BasicPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BasicPanel.Location = new System.Drawing.Point(0, 0);
            this.BasicPanel.Name = "BasicPanel";
            this.BasicPanel.Size = new System.Drawing.Size(562, 544);
            this.BasicPanel.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Output:";
            // 
            // OutputTB
            // 
            this.OutputTB.Location = new System.Drawing.Point(98, 182);
            this.OutputTB.Name = "OutputTB";
            this.OutputTB.Size = new System.Drawing.Size(341, 177);
            this.OutputTB.TabIndex = 3;
            this.OutputTB.Text = "";
            // 
            // FormulaPanel
            // 
            this.FormulaPanel.Controls.Add(this.WprowadzFormulaLabel);
            this.FormulaPanel.Controls.Add(this.FormulaTextBox);
            this.FormulaPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormulaPanel.Location = new System.Drawing.Point(0, 0);
            this.FormulaPanel.Name = "FormulaPanel";
            this.FormulaPanel.Size = new System.Drawing.Size(562, 544);
            this.FormulaPanel.TabIndex = 3;
            // 
            // WprowadzFormulaLabel
            // 
            this.WprowadzFormulaLabel.AutoSize = true;
            this.WprowadzFormulaLabel.Location = new System.Drawing.Point(115, 149);
            this.WprowadzFormulaLabel.Name = "WprowadzFormulaLabel";
            this.WprowadzFormulaLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.WprowadzFormulaLabel.Size = new System.Drawing.Size(97, 13);
            this.WprowadzFormulaLabel.TabIndex = 1;
            this.WprowadzFormulaLabel.Text = "Wprowadź formułę";
            // 
            // FormulaTextBox
            // 
            this.FormulaTextBox.Location = new System.Drawing.Point(81, 182);
            this.FormulaTextBox.Name = "FormulaTextBox";
            this.FormulaTextBox.Size = new System.Drawing.Size(335, 201);
            this.FormulaTextBox.TabIndex = 0;
            this.FormulaTextBox.Text = "";
            // 
            // FilePanel
            // 
            this.FilePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilePanel.Location = new System.Drawing.Point(0, 0);
            this.FilePanel.Name = "FilePanel";
            this.FilePanel.Size = new System.Drawing.Size(562, 544);
            this.FilePanel.TabIndex = 2;
            // 
            // BasicForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 544);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.BasicPanel);
            this.Controls.Add(this.FormulaPanel);
            this.Controls.Add(this.FilePanel);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "BasicForm";
            this.Text = "Różniczkowanie Symboliczne";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.BasicPanel.ResumeLayout(false);
            this.BasicPanel.PerformLayout();
            this.FormulaPanel.ResumeLayout(false);
            this.FormulaPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Widok;
        private System.Windows.Forms.ToolStripMenuItem podstawowyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem programistycznyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem plikowyToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label WprowadzWyrazenieLabel;
        private System.Windows.Forms.Panel BasicPanel;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Panel FormulaPanel;
        private System.Windows.Forms.Label WprowadzFormulaLabel;
        private System.Windows.Forms.RichTextBox FormulaTextBox;
        private System.Windows.Forms.Panel FilePanel;
        private System.Windows.Forms.RichTextBox OutputTB;
        private System.Windows.Forms.Label label1;
    }
}

