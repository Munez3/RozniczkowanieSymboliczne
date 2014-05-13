using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RozniczkowanieSymboliczne
{
    public partial class BasicForm : Form
    {
        public BasicForm()
        {
            InitializeComponent();
        }

        private void WprowadzFormulaLabel_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void BasicPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormulaPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void podstawowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasicPanel.Visible=true;
            FilePanel.Visible = false;
            FormulaPanel.Visible = false;
        }

        private void programistycznyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasicPanel.Visible = false;
            FilePanel.Visible = false;
            FormulaPanel.Visible = true;
        }

        private void plikowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasicPanel.Visible = false;
            FilePanel.Visible = true;
            FormulaPanel.Visible = false;
        }
    }
}
