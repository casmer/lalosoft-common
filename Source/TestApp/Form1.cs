﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace TestApp
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      try
      {
        Match res = Regex.Match(txtInput.Text, txtExpression.Text);
        txtResult.Text = res.Value;
      }
      catch (Exception ex)
      {
        txtResult.Text = ex.ToString();
      }
    }
  }
}
