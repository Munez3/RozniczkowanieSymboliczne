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
        private GeneratorKodu generatorKodu;
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
            topPanel.Bounds = new Rectangle(0, 0, topPanel.Width, 244);
            outputPanel.Padding = new Padding(0,243,0,0);
        }

        private void programistycznyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasicPanel.Visible = false;
            FilePanel.Visible = false;
            FormulaPanel.Visible = true;
            topPanel.Bounds = new Rectangle(0, 0, topPanel.Width, 244);
            outputPanel.Padding = new Padding(0, 243, 0, 0);
        }

        private void plikowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasicPanel.Visible = false;
            FilePanel.Visible = true;
            FormulaPanel.Visible = false;
            topPanel.Bounds = new Rectangle(0,0,topPanel.Width,81);
            outputPanel.Padding = new Padding(0, 80, 0, 0);
        }

        private void liczProgramBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Skaner skaner = new Skaner(FormulaTB.Text, Mode.Programmer);
                List<Token> tokeny = skaner.GetAllTokens();
                OutputTB.Text = "";

                Parser parser = new Parser(tokeny);
                if (parser.Parse())
                {
                    generatorKodu = new GeneratorKodu(tokeny);
                    OutputTB.Text = ((!trybDebugCB.Checked) ? generatorKodu.WyswietlWyniki(GeneratorMode.Normal) : generatorKodu.WyswietlWyniki(GeneratorMode.Debug));
                }
            }
            catch (Exception ex) { OutputTB.Text = ex.Message + "\n" + OutputTB.Text; }
        }

        private void liczProsteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Skaner skaner;
                if(listaIdentowLB.SelectedIndex == -1) skaner = new Skaner(wyrazenieTB.Text, Mode.Line);
                else skaner = new Skaner("#"+listaIdentowLB.SelectedItem+" "+wyrazenieTB.Text, Mode.Line);
                List<Token> tokeny = skaner.GetAllTokens();
                OutputTB.Text = "";

                Parser parser = new Parser(tokeny);
                if (parser.Parse())
                {
                    generatorKodu = new GeneratorKodu(tokeny);
                    OutputTB.Text = ((!trybDebugCB.Checked)?generatorKodu.WyswietlWyniki(GeneratorMode.Normal):generatorKodu.WyswietlWyniki(GeneratorMode.Debug));
                }
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

                Parser parser = new Parser(tokeny);
                if (parser.Parse())
                {
                    generatorKodu = new GeneratorKodu(tokeny);
                    OutputTB.Text = ((!trybDebugCB.Checked) ? generatorKodu.WyswietlWyniki(GeneratorMode.Normal) : generatorKodu.WyswietlWyniki(GeneratorMode.Debug));
                }
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
            HelpForm.treeView1.SelectedNode = HelpForm.treeView1.Nodes[0];
            HelpForm.Visible = true;
            helpToolStripMenuItem.Enabled = false;
            if (HelpForm.IsDisposed==false) helpToolStripMenuItem.Enabled = true; 
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            OutputTB.Clear();
        }

        private void WriteButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sFile = new SaveFileDialog();
            sFile.Filter = "Normal Text File (*.txt)|*.txt";
            sFile.Title = "Save result";
            if (sFile.ShowDialog() == DialogResult.OK)
            {
                if (sFile.FileName != "")
                {
                    System.IO.File.WriteAllLines(sFile.FileName, OutputTB.Lines);
                }
            }
        }

        private void wyrazenieTB_KeyDown(Object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                liczProsteBtn_Click(sender, (EventArgs)e);
            }
                
        }

        private void trybDebugCB_CheckedChanged(object sender, EventArgs e)
        {
            if(generatorKodu != null)
                OutputTB.Text = ((!trybDebugCB.Checked) ? generatorKodu.WyswietlWyniki(GeneratorMode.Normal) : generatorKodu.WyswietlWyniki(GeneratorMode.Debug));
        }

        private void porzadkujBtn_Click(object sender, EventArgs e)
        {
            Skaner skaner = new Skaner(wyrazenieTB.Text, Mode.Line);
            Parser parser = new Parser(skaner.GetAllTokens());
            parser.Parse();

            OutputTB.Text = Cleaner.PorzadkujWyrazenie(wyrazenieTB.Text);
        }

        private void wyrazenieTB_TextChanged(object sender, EventArgs e)
        {
            listaIdentowLB.Items.Clear();
            string wyrazenie = wyrazenieTB.Text;
            int i = 0;
            while (i < wyrazenie.Length && Char.IsWhiteSpace(wyrazenie[i])) i++;
            if (i != wyrazenie.Length && wyrazenie[i] == '#' && listaIdentowLB.Enabled) listaIdentowLB.Enabled = false;
            else if (i != wyrazenie.Length && wyrazenie[i] != '#' && !listaIdentowLB.Enabled) listaIdentowLB.Enabled = true;

            try
            {
                Skaner skaner = new Skaner(wyrazenie, Mode.Line);
                foreach (var token in skaner.GetAllTokens())
                {
                    if (token.Nazwa == TokenName.ident && !listaIdentowLB.Items.Contains(token.Wartosc)) listaIdentowLB.Items.Add(token.Wartosc);
                }
            }
            catch (Exception ex)
            {
                listaIdentowLB.Items.Clear();
            }
        }

    }
}
