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
            if (e.Node.Text == "Application")
            {
                webBrowser1.Navigate(new Uri(Application.StartupPath + "\\helpFunction/Index.html"));
            }
            else if (e.Node.Text == "exp")
            {
                webBrowser1.Navigate(new Uri(Application.StartupPath+"\\helpFunction/exp.html"));
            }
            else if (e.Node.Text == "log")
            {
                webBrowser1.Navigate(new Uri(Application.StartupPath + "\\helpFunction/log.html"));
            }
            else if (e.Node.Text == "Trygonometryczne")
            {
                webBrowser1.Navigate(new Uri(Application.StartupPath + "\\helpFunction/tryg.html"));
            }
            else if (e.Node.Text == "Podstawowe działania")
            {
                webBrowser1.Navigate(new Uri(Application.StartupPath + "\\helpFunction/simple.html"));
            }
            else if (e.Node.Text == "sqrt")
            {
                webBrowser1.Navigate(new Uri(Application.StartupPath + "\\helpFunction/sqrt.html"));
            }
            else if (e.Node.Text == "pętla for")
            {
                webBrowser1.Navigate(new Uri(Application.StartupPath + "\\helpFunction/forLoop.html"));
            }
        }
    }
}
