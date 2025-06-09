namespace Server
{
  partial class Form_QuanLyNhanVien
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
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.comboPosition = new System.Windows.Forms.ComboBox();
			this.btnAdd = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView
			// 
			this.dataGridView.AllowUserToAddRows = false;
			this.dataGridView.AllowUserToDeleteRows = false;
			this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Location = new System.Drawing.Point(12, 41);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.ReadOnly = true;
			this.dataGridView.RowHeadersVisible = false;
			this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView.Size = new System.Drawing.Size(776, 397);
			this.dataGridView.TabIndex = 0;
			// 
			// txtSearch
			// 
			this.txtSearch.Location = new System.Drawing.Point(82, 12);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(200, 20);
			this.txtSearch.TabIndex = 1;
			// 
			// comboPosition
			// 
			this.comboPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboPosition.FormattingEnabled = true;
			this.comboPosition.Location = new System.Drawing.Point(358, 12);
			this.comboPosition.Name = "comboPosition";
			this.comboPosition.Size = new System.Drawing.Size(121, 21);
			this.comboPosition.TabIndex = 2;
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(713, 10);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(75, 23);
			this.btnAdd.TabIndex = 3;
			this.btnAdd.Text = "Thêm mới";
			this.btnAdd.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(52, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Tìm kiếm:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(288, 15);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Vị trí:";
			// 
			// Form_QuanLyNhanVien
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.comboPosition);
			this.Controls.Add(this.txtSearch);
			this.Controls.Add(this.dataGridView);
			this.Name = "Form_QuanLyNhanVien";
			this.Text = "Quản lý nhân viên";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.DataGridView dataGridView;
    private System.Windows.Forms.TextBox txtSearch;
    private System.Windows.Forms.ComboBox comboPosition;
    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
  }
}
