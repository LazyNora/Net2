namespace Server
{
  partial class Form_QuanLyHoaDon
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
      this.comboStatus = new System.Windows.Forms.ComboBox();
      this.btnAdd = new System.Windows.Forms.Button();
      this.dtpFrom = new System.Windows.Forms.DateTimePicker();
      this.dtpTo = new System.Windows.Forms.DateTimePicker();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();

      ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
      this.SuspendLayout();
      //
      // dataGridView
      //
      this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
      this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView.Location = new System.Drawing.Point(12, 41);
      this.dataGridView.Name = "dataGridView";
      this.dataGridView.Size = new System.Drawing.Size(776, 397);
      this.dataGridView.TabIndex = 0;
      //
      // txtSearch
      //
      this.txtSearch.Location = new System.Drawing.Point(82, 12);
      this.txtSearch.Name = "txtSearch";
      this.txtSearch.Size = new System.Drawing.Size(150, 20);
      this.txtSearch.TabIndex = 1;
      //
      // comboStatus
      //
      this.comboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboStatus.FormattingEnabled = true;
      this.comboStatus.Location = new System.Drawing.Point(580, 12);
      this.comboStatus.Name = "comboStatus";
      this.comboStatus.Size = new System.Drawing.Size(121, 21);
      this.comboStatus.TabIndex = 2;
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
      // dtpFrom
      //
      this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.dtpFrom.Location = new System.Drawing.Point(282, 12);
      this.dtpFrom.Name = "dtpFrom";
      this.dtpFrom.Size = new System.Drawing.Size(100, 20);
      this.dtpFrom.TabIndex = 4;
      //
      // dtpTo
      //
      this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.dtpTo.Location = new System.Drawing.Point(422, 12);
      this.dtpTo.Name = "dtpTo";
      this.dtpTo.Size = new System.Drawing.Size(100, 20);
      this.dtpTo.TabIndex = 5;
      //
      // label1
      //
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 15);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(64, 13);
      this.label1.TabIndex = 6;
      this.label1.Text = "Tìm kiếm:";
      //
      // label2
      //
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(238, 15);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(38, 13);
      this.label2.TabIndex = 7;
      this.label2.Text = "Từ:";
      //
      // label3
      //
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(388, 15);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(30, 13);
      this.label3.TabIndex = 8;
      this.label3.Text = "Đến:";
      //
      // label4
      //
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(528, 15);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(46, 13);
      this.label4.TabIndex = 9;
      this.label4.Text = "Trạng thái:";
      //
      // Form_QuanLyHoaDon
      //
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.dtpTo);
      this.Controls.Add(this.dtpFrom);
      this.Controls.Add(this.btnAdd);
      this.Controls.Add(this.comboStatus);
      this.Controls.Add(this.txtSearch);
      this.Controls.Add(this.dataGridView);
      this.Name = "Form_QuanLyHoaDon";
      this.Text = "Quản lý hóa đơn";
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    #endregion

    private System.Windows.Forms.DataGridView dataGridView;
    private System.Windows.Forms.TextBox txtSearch;
    private System.Windows.Forms.ComboBox comboStatus;
    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.DateTimePicker dtpFrom;
    private System.Windows.Forms.DateTimePicker dtpTo;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
  }
}
