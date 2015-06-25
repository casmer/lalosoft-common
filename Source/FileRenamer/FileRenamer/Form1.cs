using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FileRenamer.DataObjects;
using System.IO;

namespace FileRenamer
{
  public partial class Form1 : Form
  {

    RenameList _items = new RenameList();
    public Form1()
    {
      InitializeComponent();
    }

    private void btnAddDir_Click(object sender, EventArgs e)
    {
      if ((!string.IsNullOrWhiteSpace(txtDir.Text)) && Directory.Exists(txtDir.Text))
        AddFilesToList(txtDir.Text, chkIncludeSubDirs.Checked);
      else
        MessageBox.Show(this, "Directory does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      
    }


    private void AddFilesToList(string dirPath,bool includeSubDirs)
    {
 	    DirectoryInfo dir = new DirectoryInfo(dirPath);
      if (dir.Exists)
      {
        FileInfo[] files = dir.GetFiles();
        foreach (FileInfo curFile in files)
        {
          RenameInfo newItem = new RenameInfo(curFile.FullName);
          if (!_items.Contains(newItem))
            _items.Add(newItem);
        }
        if (includeSubDirs)
        {
          DirectoryInfo[] dirs = dir.GetDirectories();
          foreach (DirectoryInfo curDir in dirs)
            AddFilesToList(curDir.FullName, includeSubDirs);
        }
      }
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      bsFiles.DataSource = _items;
       bsFiles.ResetBindings(false);

    }

    private void btnReplaceAll_Click(object sender, EventArgs e)
    {
      foreach (RenameInfo curInfo in _items)
      {
        curInfo.NewFilePath = curInfo.NewFilePath.Replace(txtFind.Text, txtReplace.Text);
      }
      dataGridView1.Refresh();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      RenameList toRemove = new RenameList();
      bsFiles.EndEdit();
      foreach (RenameInfo curInfo in _items)
      {
        if (RenameItem(curInfo))
          toRemove.Add(curInfo);
        
      }

      foreach (RenameInfo curInfo in toRemove)
      {
        _items.Remove(curInfo);
      }
      MessageBox.Show(this, "Done!", "done");
    }

    private bool RenameItem(RenameInfo curInfo)
    {
      bool res = false;
      try
      {
        FileInfo Finfo = new FileInfo(curInfo.OriginalFilePath);
        if (Finfo.Exists)
        {
          FileInfo newFile = new FileInfo(curInfo.NewFilePath);
          if (newFile.Exists)
            AddMessage(string.Format("Could not Move {0} to {1}, {1} already exists", curInfo.OriginalFilePath, curInfo.NewFilePath));
          else
          {
            if (!newFile.Directory.Exists)
              newFile.Directory.Create();
            File.Move(Finfo.FullName, newFile.FullName);
          }

        }
      }
      catch (Exception ex)
      {
        AddMessage(string.Format("Could not Move {0} to {1}, {2} already exists", curInfo.OriginalFilePath, curInfo.NewFilePath, ex.Message));
      }
      return res;

    }

    private void AddMessage(string message)
    {
 	    txtMessages.Text += message + Environment.NewLine;
    }

    private void btnSelectDir_Click(object sender, EventArgs e)
    {
      if (fldBrowse.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
      {
        
        txtDir.Text = fldBrowse.SelectedPath;
      }
    }
  }
}
