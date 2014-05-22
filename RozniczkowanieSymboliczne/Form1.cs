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
            HelpForm.Visible = false;
        }

        private Form2 HelpForm = new Form2();

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

        private void liczProgramBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Skaner skaner = new Skaner(FormulaTB.Text, Mode.Programmer);
                List<Token> tokeny = skaner.GetAllTokens();
                OutputTB.Text = "";
                //foreach (var token in tokeny)
                //{
                //    OutputTB.Text += token.Nazwa + " - " + token.Wartosc + '\n';
                //}
                Parser parser = new Parser(tokeny);
                if (parser.Parse())
                {
                    GeneratorKodu generatorKodu = new GeneratorKodu(tokeny);
                    OutputTB.Text = generatorKodu.WyswietlWyniki();
                }
            }
            catch (Exception ex) { OutputTB.Text = ex.Message+"\n"+OutputTB.Text; }
        }

        private void liczProsteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Skaner skaner = new Skaner(wyrazenieTB.Text, Mode.Line);
                List<Token> tokeny = skaner.GetAllTokens();
                OutputTB.Text = "";
                foreach (var token in tokeny)
                {
                    OutputTB.Text += token.Nazwa + " - " + token.Wartosc + '\n';
                }
                //TODO
            }
            catch (Exception ex) { OutputTB.Text = ex.Message; }
        }

        private void liczFileBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Skaner skaner = new Skaner(filePathTB.Text, Mode.File);
                List<Token> tokeny = skaner.GetAllTokens();
                OutputTB.Text = "";
                foreach (var token in tokeny)
                {
                    OutputTB.Text += token.Nazwa + " - " + token.Wartosc + '\n';
                }
                //TODO
            }
            catch (Exception ex) { OutputTB.Text = ex.Message; }
        }

        private void filePathBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK) filePathTB.Text = file.FileName;
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpForm.Visible = true;
            helpToolStripMenuItem.Enabled = false;
            if (HelpForm.IsDisposed==false) helpToolStripMenuItem.Enabled = true; 
        }

    }
}
