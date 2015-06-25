namespace Code_Templater
{
    partial class FrmMain
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
          this.btnProcess = new System.Windows.Forms.Button();
          this.tabControl1 = new System.Windows.Forms.TabControl();
          this.tabPage1 = new System.Windows.Forms.TabPage();
          this.button1 = new System.Windows.Forms.Button();
          this.btnReload = new System.Windows.Forms.Button();
          this.btnSave = new System.Windows.Forms.Button();
          this.cboFiles = new System.Windows.Forms.ComboBox();
          this.txtTemplate = new System.Windows.Forms.TextBox();
          this.tabPage2 = new System.Windows.Forms.TabPage();
          this.dgValues = new System.Windows.Forms.DataGridView();
          this.value1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.value2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.value3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.value4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.value5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.value6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.value7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.value8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.value9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.value10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.value11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.value12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.value13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.cntPasteStuff = new System.Windows.Forms.ContextMenuStrip(this.components);
          this.copyInDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.selectedToLowerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.selectedToUPPERToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.tabPage3 = new System.Windows.Forms.TabPage();
          this.txtResults = new System.Windows.Forms.TextBox();
          this.selectedUnderScoreFixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.tabControl1.SuspendLayout();
          this.tabPage1.SuspendLayout();
          this.tabPage2.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.dgValues)).BeginInit();
          this.cntPasteStuff.SuspendLayout();
          this.tabPage3.SuspendLayout();
          this.SuspendLayout();
          // 
          // btnProcess
          // 
          this.btnProcess.Location = new System.Drawing.Point(12, 12);
          this.btnProcess.Name = "btnProcess";
          this.btnProcess.Size = new System.Drawing.Size(75, 23);
          this.btnProcess.TabIndex = 0;
          this.btnProcess.Text = "Process";
          this.btnProcess.UseVisualStyleBackColor = true;
          this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
          // 
          // tabControl1
          // 
          this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                      | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
          this.tabControl1.Location = new System.Drawing.Point(12, 41);
          this.tabControl1.Name = "tabControl1";
          this.tabControl1.SelectedIndex = 1;
          this.tabControl1.Size = new System.Drawing.Size(684, 213);
          this.tabControl1.TabIndex = 1;
          this.tabControl1.TabPages.AddRange(new System.Windows.Forms.TabPage[] {
            this.tabPage1,
            this.tabPage2,
            this.tabPage3});
          // 
          // tabPage1
          // 
          this.tabPage1.Controls.Add(this.button1);
          this.tabPage1.Controls.Add(this.btnReload);
          this.tabPage1.Controls.Add(this.btnSave);
          this.tabPage1.Controls.Add(this.cboFiles);
          this.tabPage1.Controls.Add(this.txtTemplate);
          this.tabPage1.Location = new System.Drawing.Point(1, 1);
          this.tabPage1.Name = "tabPage1";
          this.tabPage1.Size = new System.Drawing.Size(682, 188);
          this.tabPage1.TabIndex = 4;
          // 
          // button1
          // 
          this.button1.Location = new System.Drawing.Point(444, 3);
          this.button1.Name = "button1";
          this.button1.Size = new System.Drawing.Size(75, 23);
          this.button1.TabIndex = 4;
          this.button1.Text = "&New";
          this.button1.UseVisualStyleBackColor = true;
          this.button1.Click += new System.EventHandler(this.button1_Click);
          // 
          // btnReload
          // 
          this.btnReload.Location = new System.Drawing.Point(363, 3);
          this.btnReload.Name = "btnReload";
          this.btnReload.Size = new System.Drawing.Size(75, 23);
          this.btnReload.TabIndex = 3;
          this.btnReload.Text = "&Reload";
          this.btnReload.UseVisualStyleBackColor = true;
          this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
          // 
          // btnSave
          // 
          this.btnSave.Location = new System.Drawing.Point(282, 3);
          this.btnSave.Name = "btnSave";
          this.btnSave.Size = new System.Drawing.Size(75, 23);
          this.btnSave.TabIndex = 2;
          this.btnSave.Text = "&Save";
          this.btnSave.UseVisualStyleBackColor = true;
          this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
          // 
          // cboFiles
          // 
          this.cboFiles.FormattingEnabled = true;
          this.cboFiles.Location = new System.Drawing.Point(3, 3);
          this.cboFiles.Name = "cboFiles";
          this.cboFiles.Size = new System.Drawing.Size(273, 23);
          this.cboFiles.TabIndex = 1;
          this.cboFiles.SelectedIndexChanged += new System.EventHandler(this.cboFiles_SelectedIndexChanged);
          // 
          // txtTemplate
          // 
          this.txtTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                      | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
          this.txtTemplate.Location = new System.Drawing.Point(0, 30);
          this.txtTemplate.Multiline = true;
          this.txtTemplate.Name = "txtTemplate";
          this.txtTemplate.ScrollBars = System.Windows.Forms.ScrollBars.Both;
          this.txtTemplate.Size = new System.Drawing.Size(682, 158);
          this.txtTemplate.TabIndex = 0;
          this.txtTemplate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTemplate_KeyDown);
          // 
          // tabPage2
          // 
          this.tabPage2.Controls.Add(this.dgValues);
          this.tabPage2.Location = new System.Drawing.Point(1, 1);
          this.tabPage2.Name = "tabPage2";
          this.tabPage2.Size = new System.Drawing.Size(682, 188);
          this.tabPage2.TabIndex = 5;
          // 
          // dgValues
          // 
          this.dgValues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
          this.dgValues.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.value1,
            this.value2,
            this.value3,
            this.value4,
            this.value5,
            this.value6,
            this.value7,
            this.value8,
            this.value9,
            this.value10,
            this.value11,
            this.value12,
            this.value13});
          this.dgValues.ContextMenuStrip = this.cntPasteStuff;
          this.dgValues.Dock = System.Windows.Forms.DockStyle.Fill;
          this.dgValues.Location = new System.Drawing.Point(0, 0);
          this.dgValues.Name = "dgValues";
          this.dgValues.Size = new System.Drawing.Size(682, 188);
          this.dgValues.TabIndex = 0;
          // 
          // value1
          // 
          this.value1.HeaderText = "${value1}";
          this.value1.Name = "value1";
          // 
          // value2
          // 
          this.value2.HeaderText = "${value2}";
          this.value2.Name = "value2";
          // 
          // value3
          // 
          this.value3.HeaderText = "${value3}";
          this.value3.Name = "value3";
          // 
          // value4
          // 
          this.value4.HeaderText = "${value4}";
          this.value4.Name = "value4";
          // 
          // value5
          // 
          this.value5.HeaderText = "${value5}";
          this.value5.Name = "value5";
          // 
          // value6
          // 
          this.value6.HeaderText = "${value6}";
          this.value6.Name = "value6";
          // 
          // value7
          // 
          this.value7.HeaderText = "${value7}";
          this.value7.Name = "value7";
          // 
          // value8
          // 
          this.value8.HeaderText = "${value8}";
          this.value8.Name = "value8";
          // 
          // value9
          // 
          this.value9.HeaderText = "${value9}";
          this.value9.Name = "value9";
          // 
          // value10
          // 
          this.value10.HeaderText = "${value10}";
          this.value10.Name = "value10";
          // 
          // value11
          // 
          this.value11.HeaderText = "${value11}";
          this.value11.Name = "value11";
          // 
          // value12
          // 
          this.value12.HeaderText = "${value12}";
          this.value12.Name = "value12";
          // 
          // value13
          // 
          this.value13.HeaderText = "${value13}";
          this.value13.Name = "value13";
          // 
          // cntPasteStuff
          // 
          this.cntPasteStuff.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyInDataToolStripMenuItem,
            this.selectedToLowerToolStripMenuItem,
            this.selectedToUPPERToolStripMenuItem,
            this.selectedUnderScoreFixToolStripMenuItem});
          this.cntPasteStuff.Name = "cntPasteStuff";
          this.cntPasteStuff.Size = new System.Drawing.Size(245, 114);
          // 
          // copyInDataToolStripMenuItem
          // 
          this.copyInDataToolStripMenuItem.Name = "copyInDataToolStripMenuItem";
          this.copyInDataToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                      | System.Windows.Forms.Keys.V)));
          this.copyInDataToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
          this.copyInDataToolStripMenuItem.Text = "CopyInData";
          this.copyInDataToolStripMenuItem.Click += new System.EventHandler(this.copyInDataToolStripMenuItem_Click);
          // 
          // selectedToLowerToolStripMenuItem
          // 
          this.selectedToLowerToolStripMenuItem.Name = "selectedToLowerToolStripMenuItem";
          this.selectedToLowerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                      | System.Windows.Forms.Keys.L)));
          this.selectedToLowerToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
          this.selectedToLowerToolStripMenuItem.Text = "Selected to Lower";
          this.selectedToLowerToolStripMenuItem.Click += new System.EventHandler(this.selectedToLowerToolStripMenuItem_Click);
          // 
          // selectedToUPPERToolStripMenuItem
          // 
          this.selectedToUPPERToolStripMenuItem.Name = "selectedToUPPERToolStripMenuItem";
          this.selectedToUPPERToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                      | System.Windows.Forms.Keys.U)));
          this.selectedToUPPERToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
          this.selectedToUPPERToolStripMenuItem.Text = "Selected to UPPER";
          this.selectedToUPPERToolStripMenuItem.Click += new System.EventHandler(this.selectedToUPPERToolStripMenuItem_Click);
          // 
          // tabPage3
          // 
          this.tabPage3.Controls.Add(this.txtResults);
          this.tabPage3.Location = new System.Drawing.Point(1, 1);
          this.tabPage3.Name = "tabPage3";
          this.tabPage3.Size = new System.Drawing.Size(682, 188);
          this.tabPage3.TabIndex = 6;
          // 
          // txtResults
          // 
          this.txtResults.Dock = System.Windows.Forms.DockStyle.Fill;
          this.txtResults.Location = new System.Drawing.Point(0, 0);
          this.txtResults.Multiline = true;
          this.txtResults.Name = "txtResults";
          this.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
          this.txtResults.Size = new System.Drawing.Size(682, 188);
          this.txtResults.TabIndex = 1;
          this.txtResults.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtResults_KeyDown);
          // 
          // selectedUnderScoreFixToolStripMenuItem
          // 
          this.selectedUnderScoreFixToolStripMenuItem.Name = "selectedUnderScoreFixToolStripMenuItem";
          this.selectedUnderScoreFixToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
          this.selectedUnderScoreFixToolStripMenuItem.Text = "Selected UnderScoreFix";
          this.selectedUnderScoreFixToolStripMenuItem.Click += new System.EventHandler(this.selectedUnderScoreFixToolStripMenuItem_Click);
          // 
          // FrmMain
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(708, 266);
          this.Controls.Add(this.tabControl1);
          this.Controls.Add(this.btnProcess);
          this.Name = "FrmMain";
          this.Text = "Code Templater";
          this.tabControl1.ResumeLayout(false);
          this.tabPage1.ResumeLayout(false);
          this.tabPage1.PerformLayout();
          this.tabPage2.ResumeLayout(false);
          ((System.ComponentModel.ISupportInitialize)(this.dgValues)).EndInit();
          this.cntPasteStuff.ResumeLayout(false);
          this.tabPage3.ResumeLayout(false);
          this.tabPage3.PerformLayout();
          this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtTemplate;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgValues;
        private System.Windows.Forms.TextBox txtResults;
        private System.Windows.Forms.ContextMenuStrip cntPasteStuff;
        private System.Windows.Forms.ToolStripMenuItem copyInDataToolStripMenuItem;
        private System.Windows.Forms.ComboBox cboFiles;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn value1;
        private System.Windows.Forms.DataGridViewTextBoxColumn value2;
        private System.Windows.Forms.DataGridViewTextBoxColumn value3;
        private System.Windows.Forms.DataGridViewTextBoxColumn value4;
        private System.Windows.Forms.DataGridViewTextBoxColumn value5;
        private System.Windows.Forms.DataGridViewTextBoxColumn value6;
        private System.Windows.Forms.DataGridViewTextBoxColumn value7;
        private System.Windows.Forms.DataGridViewTextBoxColumn value8;
        private System.Windows.Forms.DataGridViewTextBoxColumn value9;
        private System.Windows.Forms.DataGridViewTextBoxColumn value10;
        private System.Windows.Forms.DataGridViewTextBoxColumn value11;
        private System.Windows.Forms.DataGridViewTextBoxColumn value12;
        private System.Windows.Forms.DataGridViewTextBoxColumn value13;
        private System.Windows.Forms.ToolStripMenuItem selectedToLowerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectedToUPPERToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectedUnderScoreFixToolStripMenuItem;
    }
}

