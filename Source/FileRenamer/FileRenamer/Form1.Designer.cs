namespace FileRenamer
{
  partial class Form1
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
      this.components = new System.ComponentModel.Container();
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.fldBrowse = new System.Windows.Forms.FolderBrowserDialog();
      this.btnAddDir = new System.Windows.Forms.Button();
      this.txtFind = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.txtReplace = new System.Windows.Forms.TextBox();
      this.btnReplaceAll = new System.Windows.Forms.Button();
      this.button1 = new System.Windows.Forms.Button();
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabFiles = new System.Windows.Forms.TabPage();
      this.tabMessages = new System.Windows.Forms.TabPage();
      this.txtMessages = new System.Windows.Forms.TextBox();
      this.txtDir = new System.Windows.Forms.TextBox();
      this.btnSelectDir = new System.Windows.Forms.Button();
      this.chkIncludeSubDirs = new System.Windows.Forms.CheckBox();
      this.originalFilePathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.newFilePathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.bsFiles = new System.Windows.Forms.BindingSource(this.components);
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      this.tabControl1.SuspendLayout();
      this.tabFiles.SuspendLayout();
      this.tabMessages.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.bsFiles)).BeginInit();
      this.SuspendLayout();
      // 
      // dataGridView1
      // 
      this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.dataGridView1.AutoGenerateColumns = false;
      this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.originalFilePathDataGridViewTextBoxColumn,
            this.newFilePathDataGridViewTextBoxColumn});
      this.dataGridView1.DataSource = this.bsFiles;
      this.dataGridView1.Location = new System.Drawing.Point(6, 6);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.Size = new System.Drawing.Size(389, 240);
      this.dataGridView1.TabIndex = 0;
      // 
      // fldBrowse
      // 
      this.fldBrowse.ShowNewFolderButton = false;
      // 
      // btnAddDir
      // 
      this.btnAddDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnAddDir.Location = new System.Drawing.Point(308, 278);
      this.btnAddDir.Name = "btnAddDir";
      this.btnAddDir.Size = new System.Drawing.Size(75, 23);
      this.btnAddDir.TabIndex = 1;
      this.btnAddDir.Text = "Add Dir...";
      this.btnAddDir.UseVisualStyleBackColor = true;
      this.btnAddDir.Click += new System.EventHandler(this.btnAddDir_Click);
      // 
      // txtFind
      // 
      this.txtFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.txtFind.Location = new System.Drawing.Point(67, 341);
      this.txtFind.Name = "txtFind";
      this.txtFind.Size = new System.Drawing.Size(174, 20);
      this.txtFind.TabIndex = 2;
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(17, 344);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(27, 13);
      this.label1.TabIndex = 3;
      this.label1.Text = "Find";
      // 
      // label2
      // 
      this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(17, 370);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(47, 13);
      this.label2.TabIndex = 5;
      this.label2.Text = "Replace";
      // 
      // txtReplace
      // 
      this.txtReplace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.txtReplace.Location = new System.Drawing.Point(70, 367);
      this.txtReplace.Name = "txtReplace";
      this.txtReplace.Size = new System.Drawing.Size(171, 20);
      this.txtReplace.TabIndex = 4;
      // 
      // btnReplaceAll
      // 
      this.btnReplaceAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnReplaceAll.Location = new System.Drawing.Point(166, 393);
      this.btnReplaceAll.Name = "btnReplaceAll";
      this.btnReplaceAll.Size = new System.Drawing.Size(75, 23);
      this.btnReplaceAll.TabIndex = 6;
      this.btnReplaceAll.Text = "Replace All";
      this.btnReplaceAll.UseVisualStyleBackColor = true;
      this.btnReplaceAll.Click += new System.EventHandler(this.btnReplaceAll_Click);
      // 
      // button1
      // 
      this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.button1.Location = new System.Drawing.Point(258, 393);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(135, 23);
      this.button1.TabIndex = 7;
      this.button1.Text = "Process Files";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // tabControl1
      // 
      this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.tabControl1.Controls.Add(this.tabFiles);
      this.tabControl1.Controls.Add(this.tabMessages);
      this.tabControl1.Location = new System.Drawing.Point(6, 5);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(410, 458);
      this.tabControl1.TabIndex = 8;
      // 
      // tabFiles
      // 
      this.tabFiles.Controls.Add(this.chkIncludeSubDirs);
      this.tabFiles.Controls.Add(this.btnSelectDir);
      this.tabFiles.Controls.Add(this.txtDir);
      this.tabFiles.Controls.Add(this.button1);
      this.tabFiles.Controls.Add(this.dataGridView1);
      this.tabFiles.Controls.Add(this.btnReplaceAll);
      this.tabFiles.Controls.Add(this.btnAddDir);
      this.tabFiles.Controls.Add(this.label2);
      this.tabFiles.Controls.Add(this.txtFind);
      this.tabFiles.Controls.Add(this.txtReplace);
      this.tabFiles.Controls.Add(this.label1);
      this.tabFiles.Location = new System.Drawing.Point(4, 22);
      this.tabFiles.Name = "tabFiles";
      this.tabFiles.Padding = new System.Windows.Forms.Padding(3);
      this.tabFiles.Size = new System.Drawing.Size(402, 432);
      this.tabFiles.TabIndex = 0;
      this.tabFiles.Text = "Files";
      this.tabFiles.UseVisualStyleBackColor = true;
      // 
      // tabMessages
      // 
      this.tabMessages.Controls.Add(this.txtMessages);
      this.tabMessages.Location = new System.Drawing.Point(4, 22);
      this.tabMessages.Name = "tabMessages";
      this.tabMessages.Padding = new System.Windows.Forms.Padding(3);
      this.tabMessages.Size = new System.Drawing.Size(402, 432);
      this.tabMessages.TabIndex = 1;
      this.tabMessages.Text = "Messages";
      this.tabMessages.UseVisualStyleBackColor = true;
      // 
      // txtMessages
      // 
      this.txtMessages.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtMessages.Location = new System.Drawing.Point(3, 3);
      this.txtMessages.Multiline = true;
      this.txtMessages.Name = "txtMessages";
      this.txtMessages.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.txtMessages.Size = new System.Drawing.Size(396, 426);
      this.txtMessages.TabIndex = 0;
      // 
      // txtDir
      // 
      this.txtDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.txtDir.Location = new System.Drawing.Point(6, 252);
      this.txtDir.Name = "txtDir";
      this.txtDir.Size = new System.Drawing.Size(377, 20);
      this.txtDir.TabIndex = 8;
      // 
      // btnSelectDir
      // 
      this.btnSelectDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnSelectDir.Location = new System.Drawing.Point(70, 278);
      this.btnSelectDir.Name = "btnSelectDir";
      this.btnSelectDir.Size = new System.Drawing.Size(75, 23);
      this.btnSelectDir.TabIndex = 9;
      this.btnSelectDir.Text = "Select Dir...";
      this.btnSelectDir.UseVisualStyleBackColor = true;
      this.btnSelectDir.Click += new System.EventHandler(this.btnSelectDir_Click);
      // 
      // chkIncludeSubDirs
      // 
      this.chkIncludeSubDirs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.chkIncludeSubDirs.AutoSize = true;
      this.chkIncludeSubDirs.Checked = true;
      this.chkIncludeSubDirs.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkIncludeSubDirs.Location = new System.Drawing.Point(166, 282);
      this.chkIncludeSubDirs.Name = "chkIncludeSubDirs";
      this.chkIncludeSubDirs.Size = new System.Drawing.Size(134, 17);
      this.chkIncludeSubDirs.TabIndex = 10;
      this.chkIncludeSubDirs.Text = "Include Sub-directories";
      this.chkIncludeSubDirs.UseVisualStyleBackColor = true;
      // 
      // originalFilePathDataGridViewTextBoxColumn
      // 
      this.originalFilePathDataGridViewTextBoxColumn.DataPropertyName = "OriginalFilePath";
      this.originalFilePathDataGridViewTextBoxColumn.HeaderText = "Original File Path";
      this.originalFilePathDataGridViewTextBoxColumn.Name = "originalFilePathDataGridViewTextBoxColumn";
      this.originalFilePathDataGridViewTextBoxColumn.ReadOnly = true;
      this.originalFilePathDataGridViewTextBoxColumn.Width = 82;
      // 
      // newFilePathDataGridViewTextBoxColumn
      // 
      this.newFilePathDataGridViewTextBoxColumn.DataPropertyName = "NewFilePath";
      this.newFilePathDataGridViewTextBoxColumn.HeaderText = "New File Path";
      this.newFilePathDataGridViewTextBoxColumn.Name = "newFilePathDataGridViewTextBoxColumn";
      this.newFilePathDataGridViewTextBoxColumn.Width = 90;
      // 
      // bsFiles
      // 
      this.bsFiles.DataSource = typeof(FileRenamer.DataObjects.RenameList);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(415, 465);
      this.Controls.Add(this.tabControl1);
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      this.tabControl1.ResumeLayout(false);
      this.tabFiles.ResumeLayout(false);
      this.tabFiles.PerformLayout();
      this.tabMessages.ResumeLayout(false);
      this.tabMessages.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.bsFiles)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.DataGridViewTextBoxColumn originalFilePathDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn newFilePathDataGridViewTextBoxColumn;
    private System.Windows.Forms.BindingSource bsFiles;
    private System.Windows.Forms.FolderBrowserDialog fldBrowse;
    private System.Windows.Forms.Button btnAddDir;
    private System.Windows.Forms.TextBox txtFind;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtReplace;
    private System.Windows.Forms.Button btnReplaceAll;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabMessages;
    private System.Windows.Forms.TextBox txtMessages;
    private System.Windows.Forms.TabPage tabFiles;
    private System.Windows.Forms.Button btnSelectDir;
    private System.Windows.Forms.TextBox txtDir;
    private System.Windows.Forms.CheckBox chkIncludeSubDirs;
  }
}

