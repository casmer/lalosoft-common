using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Windows.Forms;

namespace CamelCaser
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      StringBuilder res = new StringBuilder();
      string[] lines = textBox1.Text.Split(new string[] {Environment.NewLine}, StringSplitOptions.None);
      
      foreach (string line in lines)
      {
        bool nextIsUpper = true;
        for (int i=0; i<line.Length; i++)
        {
          string s = line.Substring(i, 1);
          if (s == "_")
            nextIsUpper = true;
          else
          {
            if (nextIsUpper)
              res.Append(s.ToUpper());
            else
            {
              if (keepUppers.Checked)
                res.Append(s);
              else
              res.Append(s.ToLower());
            }
            nextIsUpper = false;
          }
        }
        res.Append(Environment.NewLine);

      }
      textBox1.Text = res.ToString();
    }

    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
      
    }

    private void textBox1_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.Control && e.KeyCode == Keys.A)
      {
        textBox1.SelectAll();
      }
    }
  }
}
