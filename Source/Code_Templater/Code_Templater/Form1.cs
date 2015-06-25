using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Code_Templater
{
  public partial class FrmMain : Form
  {
    List<FileListInfo> _FileList = new List<FileListInfo>();
    public FrmMain()
    {
      InitializeComponent();
      try
      {
        RefreshFileList();
        BindCbo();
      }
      catch (Exception ex)
      {
        try
        {
          txtResults.Text = ex.ToString();
          tabControl1.SelectedTab = tabPage3;
        }
        catch (Exception)
        {
        }


      }
    }
    private void RefreshFileList()
    {

      DirectoryInfo TemplatePath = new DirectoryInfo(Path.Combine(Application.StartupPath, "Templates"));
      FileInfo[] textFiles = TemplatePath.GetFiles("*.txt");
      _FileList.Clear();
      foreach (FileInfo curFile in textFiles)
      {
        _FileList.Add(new FileListInfo(curFile.Name, curFile.FullName));
      }
    }
    private void BindCbo()
    {
      cboFiles.DisplayMember = "";
      cboFiles.DataSource = null;
      cboFiles.DataSource = _FileList;
      //cboFiles.ValueMember = "FullPath";
      cboFiles.DisplayMember = "Name";
    }

    private void btnProcess_Click(object sender, EventArgs e)
    {
      txtResults.Text = "";
      string results = processTemplateValues(txtTemplate.Text);
      txtResults.Text = processSubTemplates(results);
      tabControl1.SelectedTab = tabPage3;
      Clipboard.SetText(txtResults.Text);
      System.Media.SystemSounds.Beep.Play();
    }
    private string processSubTemplates(string baseCode)
    {

      foreach (FileListInfo curInfo in _FileList)
      {
        string templateCode = LoadFile(curInfo.FullPath);
        if (baseCode.Contains(curInfo.TemplateReplace))
        {
          string processedData = processTemplateValues(templateCode);
          string temp = baseCode.Replace(curInfo.TemplateReplace, processedData);
          baseCode = temp;
        }
      }
      return baseCode;
    }



    private string processTemplateValues(string template)
    {
      string results = "";
      bool needsprocessing = false;
      foreach (DataGridViewColumn curCol in dgValues.Columns)
      {
        if (template.Contains(curCol.HeaderText))
          needsprocessing = true;

      }
      if (needsprocessing)
      {
        for (int i = 0; i < dgValues.Rows.Count - 1; i++)
        {
          DataGridViewRow curRow = dgValues.Rows[i];
          string baseCode = template;
          foreach (DataGridViewCell curCell in curRow.Cells)
          {

            string ColumnTitle = dgValues.Columns[curCell.ColumnIndex].HeaderText;
            if (curCell.Value != null)
            {
              string temp = baseCode.Replace(ColumnTitle, curCell.Value.ToString());
              baseCode = temp;
            }
          }
          results += baseCode;
        }
      }
      else
      {
        results = template;
      }
      return results;
    }

   

    private void copyInDataToolStripMenuItem_Click(object sender, EventArgs e)
    {
      string ClipData = Clipboard.GetText(TextDataFormat.Text).Replace(Environment.NewLine, "\n");
      string[] Lines = ClipData.Split(new string[] { "\n" }, StringSplitOptions.None);
      foreach (string Line in Lines)
      {
        string[] cols = Line.Split(new string[] { "\t" }, StringSplitOptions.None);
        if (cols.Length > 0)
        {
          if (cols[0].Trim() != "")
          {
            int RowIndex = dgValues.Rows.Add();
            DataGridViewRow curRow = dgValues.Rows[RowIndex];
            for (int i = 0; i < cols.Length && i < dgValues.Columns.Count; i++)
            {

              curRow.Cells[i].Value = cols[i];
            }
          }

        }
      }
    }
    private string LoadFile(string FileName)
    {
      string results;
      TextReader tr = File.OpenText(FileName);
      results = tr.ReadToEnd();
      tr.Close();
      return results;
    }
    private void SaveFile(string FileName)
    {
      TextWriter tw = new StreamWriter(FileName);
      tw.Write(txtTemplate.Text);
      tw.Close();
    }
    private void LoadSelectedFile()
    {
      string fileName = "";
      if (cboFiles.SelectedValue is FileListInfo)
      {
        FileListInfo fileInfo = (FileListInfo)cboFiles.SelectedValue;
        fileName = fileInfo.FullPath;
      }
      if (cboFiles.SelectedValue is string)
      {
        fileName = (string)cboFiles.SelectedValue;
      }
      if (File.Exists(fileName))
        txtTemplate.Text = LoadFile(fileName);
    }
    private void cboFiles_SelectedIndexChanged(object sender, EventArgs e)
    {
      LoadSelectedFile();
    }
    private void SaveSelectedFile()
    {
      string fileName = "";
      if (cboFiles.SelectedValue is FileListInfo)
      {
        FileListInfo fileInfo = (FileListInfo)cboFiles.SelectedValue;
        fileName = fileInfo.FullPath;
      }
      if (cboFiles.SelectedValue is string)
      {
        fileName = (string)cboFiles.SelectedValue;
      }
      if (File.Exists(fileName))
        SaveFile(fileName);
    }
    private void btnSave_Click(object sender, EventArgs e)
    {
      SaveSelectedFile();
    }

    private void btnReload_Click(object sender, EventArgs e)
    {
      LoadSelectedFile();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      string newfile = cboFiles.Text;
      string templatepath = Path.Combine(Application.StartupPath, "Templates");
      if (!newfile.EndsWith(".txt", true, null))
        newfile += ".txt";
      string newfilePath = Path.Combine(templatepath, newfile);
      if (!File.Exists(newfilePath))
      {
        txtTemplate.Text = "";
        SaveFile(newfilePath);
        //RefreshFileList();
        //BindCbo();
        FileListInfo newItem = new FileListInfo(newfile, newfilePath);

        _FileList.Add(newItem);
        BindCbo();
        cboFiles.Refresh();
        cboFiles.SelectedItem = newItem;
      }
    }

    private void txtResults_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.Control && e.KeyCode == Keys.A)
      {
        txtResults.SelectAll();
      }
    }

    private void txtTemplate_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.Modifiers == Keys.Control && e.KeyCode == Keys.D1)
      {
        txtTemplate.SelectedText = "${value1}";
        e.Handled = true;
      }
      if (e.Modifiers == Keys.Control && e.KeyCode == Keys.D2)
      {
        txtTemplate.SelectedText = "${value2}";
        e.Handled = true;
      }
      if (e.Modifiers == Keys.Control && e.KeyCode == Keys.D3)
      {
        txtTemplate.SelectedText = "${value3}";
        e.Handled = true;
      }
      if (e.Modifiers == Keys.Control && e.KeyCode == Keys.D4)
      {
        txtTemplate.SelectedText = "${value4}";
        e.Handled = true;
      }
      if (e.Modifiers == Keys.Control && e.KeyCode == Keys.D5)
      {
        txtTemplate.SelectedText = "${value5}";
        e.Handled = true;
      }
      if (e.Modifiers == Keys.Control && e.KeyCode == Keys.D6)
      {
        txtTemplate.SelectedText = "${value6}";
        e.Handled = true;
      }

      if (e.Modifiers == Keys.Control && e.KeyCode == Keys.D7)
      {
        txtTemplate.SelectedText = "${value7}";
        e.Handled = true;
      }
      if (e.Modifiers == Keys.Control && e.KeyCode == Keys.D8)
      {
        txtTemplate.SelectedText = "${value8}";
        e.Handled = true;
      }
      if (e.Modifiers == Keys.Control && e.KeyCode == Keys.D9)
      {
        txtTemplate.SelectedText = "${value9}";
        e.Handled = true;
      }
      if (e.Modifiers == Keys.Control && e.KeyCode == Keys.D0)
      {
        txtTemplate.SelectedText = "${value10}";
        e.Handled = true;
      }

      if ((e.Modifiers == (Keys.Control | Keys.Shift)) && e.KeyCode == Keys.D1)
      {
        txtTemplate.SelectedText = "${value11}";
        e.Handled = true;
      }
      if ((e.Modifiers == (Keys.Control | Keys.Shift)) && e.KeyCode == Keys.D2)
      {
        txtTemplate.SelectedText = "${value12}";
        e.Handled = true;
      }
      if ((e.Modifiers == (Keys.Control | Keys.Shift)) && e.KeyCode == Keys.D3)
      {
        txtTemplate.SelectedText = "${value13}";
        e.Handled = true;
      }
    }

    public static string UnderScoreCharToUpper(string value, bool upperFirst)
    {
      StringBuilder result = new StringBuilder(value.Length);
      bool upperNext = upperFirst;
      for (int i = 0; i < value.Length; i++)
      {
        string curchar = value.Substring(i, 1);
        if (curchar == "_")
          upperNext = true;
        else
        {

          result.Append((upperNext ? curchar.ToUpper() : curchar));
          upperNext = false;
        }
      }
      return result.ToString();
    }

    private void selectedToLowerToolStripMenuItem_Click(object sender, EventArgs e)
    {
      foreach (DataGridViewCell curcell in dgValues.SelectedCells)
      {
        if (curcell.Value != null)
          curcell.Value = curcell.Value.ToString().ToLower();
      }
    }

    private void selectedToUPPERToolStripMenuItem_Click(object sender, EventArgs e)
    {
      foreach (DataGridViewCell curcell in dgValues.SelectedCells)
      {
        if (curcell.Value != null)
          curcell.Value = curcell.Value.ToString().ToUpper();
      }
    }

    private void selectedUnderScoreFixToolStripMenuItem_Click(object sender, EventArgs e)
    {
      foreach (DataGridViewCell curcell in dgValues.SelectedCells)
      {
        if (curcell.Value != null)
          curcell.Value = UnderScoreCharToUpper(curcell.Value.ToString(), true);
      }
    }

  }
}