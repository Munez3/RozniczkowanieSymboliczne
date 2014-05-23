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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "exp")
            {
                //MessageBox.Show("luuul");
                webBrowser1.Navigate(new Uri(Application.StartupPath+"\\helpFunction/exp.html"));
            }
        }
    }
}
