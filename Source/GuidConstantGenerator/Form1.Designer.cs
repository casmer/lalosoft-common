namespace GuidConstantGenerator
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
      this.guidConstantListBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.guidValueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.constantDefDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.guidConstantListBindingSource)).BeginInit();
      this.SuspendLayout();
      // 
      // dataGridView1
      // 
      this.dataGridView1.AutoGenerateColumns = false;
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.guidValueDataGridViewTextBoxColumn,
            this.constantDefDataGridViewTextBoxColumn});
      this.dataGridView1.DataSource = this.guidConstantListBindingSource;
      this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dataGridView1.Location = new System.Drawing.Point(0, 0);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.Size = new System.Drawing.Size(896, 329);
      this.dataGridView1.TabIndex = 0;
      // 
      // guidConstantListBindingSource
      // 
      this.guidConstantListBindingSource.DataSource = typeof(GuidConstantGenerator.GuidConstantList);
      // 
      // nameDataGridViewTextBoxColumn
      // 
      this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
      this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
      this.nameDataGridViewTextBoxColumn.MinimumWidth = 150;
      this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
      this.nameDataGridViewTextBoxColumn.Width = 150;
      // 
      // guidValueDataGridViewTextBoxColumn
      // 
      this.guidValueDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.guidValueDataGridViewTextBoxColumn.DataPropertyName = "GuidValue";
      this.guidValueDataGridViewTextBoxColumn.HeaderText = "GuidValue";
      this.guidValueDataGridViewTextBoxColumn.MinimumWidth = 100;
      this.guidValueDataGridViewTextBoxColumn.Name = "guidValueDataGridViewTextBoxColumn";
      // 
      // constantDefDataGridViewTextBoxColumn
      // 
      this.constantDefDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.constantDefDataGridViewTextBoxColumn.DataPropertyName = "ConstantDef";
      this.constantDefDataGridViewTextBoxColumn.HeaderText = "ConstantDef";
      this.constantDefDataGridViewTextBoxColumn.MinimumWidth = 200;
      this.constantDefDataGridViewTextBoxColumn.Name = "constantDefDataGridViewTextBoxColumn";
      this.constantDefDataGridViewTextBoxColumn.ReadOnly = true;
      this.constantDefDataGridViewTextBoxColumn.Width = 200;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(896, 329);
      this.Controls.Add(this.dataGridView1);
      this.Name = "Form1";
      this.Text = "Guid Constant Generator";
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.guidConstantListBindingSource)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn guidValueDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn constantDefDataGridViewTextBoxColumn;
    private System.Windows.Forms.BindingSource guidConstantListBindingSource;
  }
}

