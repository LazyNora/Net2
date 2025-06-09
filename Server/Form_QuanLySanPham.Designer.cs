namespace Server
{
  partial class Form_QuanLySanPham
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
      this.dataGridView = new System.Windows.Forms.DataGridView();
      this.txtSearch = new System.Windows.Forms.TextBox();
      this.comboCategory = new System.Windows.Forms.ComboBox();
      this.btnAdd = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
      this.SuspendLayout();
      //
      // txtSearch
      //
      this.txtSearch.Location = new System.Drawing.Point(12, 12);
      this.txtSearch.Name = "txtSearch";
      this.txtSearch.Size = new System.Drawing.Size(200, 20);
      this.txtSearch.TabIndex = 0;
      //
      // comboCategory
      //
      this.comboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboCategory.Location = new System.Drawing.Point(218, 12);
      this.comboCategory.Name = "comboCategory";
      this.comboCategory.Size = new System.Drawing.Size(121, 21);
      this.comboCategory.TabIndex = 1;
      //
      // btnAdd
      //
      this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnAdd.Location = new System.Drawing.Point(713, 12);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new System.Drawing.Size(75, 23);
      this.btnAdd.TabIndex = 2;
      this.btnAdd.Text = "➕ Thêm mới";
      this.btnAdd.UseVisualStyleBackColor = true;
      //
      // dataGridView
      //
      this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
      | System.Windows.Forms.AnchorStyles.Left)
      | System.Windows.Forms.AnchorStyles.Right)));
      this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView.Location = new System.Drawing.Point(12, 45);
      this.dataGridView.Name = "dataGridView";
      this.dataGridView.Size = new System.Drawing.Size(776, 393);
      this.dataGridView.TabIndex = 3;
      //
      // Form_QuanLySanPham
      //
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.btnAdd);
      this.Controls.Add(this.comboCategory);
      this.Controls.Add(this.txtSearch);
      this.Controls.Add(this.dataGridView);
      this.Name = "Form_QuanLySanPham";
      this.Text = "Quản lý sản phẩm";
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    #endregion
    private System.Windows.Forms.DataGridView dataGridView;
    private System.Windows.Forms.TextBox txtSearch;
    private System.Windows.Forms.ComboBox comboCategory;
    private System.Windows.Forms.Button btnAdd;
  }
}
