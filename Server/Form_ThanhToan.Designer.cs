namespace Server
{
    partial class Form_ThanhToan
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
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtTongTien = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.dgv_Sotiennap = new System.Windows.Forms.DataGridView();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.dgv_Dichvu = new System.Windows.Forms.DataGridView();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.txtTienDu = new System.Windows.Forms.TextBox();
			this.txtTienKhachDua = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txt1 = new System.Windows.Forms.Label();
			this.btnHienQR = new System.Windows.Forms.Button();
			this.rdb_TienMat = new System.Windows.Forms.RadioButton();
			this.rdb_NganHang = new System.Windows.Forms.RadioButton();
			this.btn_Submit = new System.Windows.Forms.Button();
			this.btn_Back = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv_Sotiennap)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv_Dichvu)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 22);
			this.label1.TabIndex = 0;
			this.label1.Text = "Mã hóa đơn :";
			// 
			// textBox1
			// 
			this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox1.Location = new System.Drawing.Point(122, 18);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(174, 26);
			this.textBox1.TabIndex = 1;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtTongTien);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.dgv_Sotiennap);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.dgv_Dichvu);
			this.groupBox1.Font = new System.Drawing.Font("Nunito", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(12, 77);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(554, 536);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Cho tiết hóa đơn";
			// 
			// txtTongTien
			// 
			this.txtTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTongTien.Location = new System.Drawing.Point(195, 475);
			this.txtTongTien.Name = "txtTongTien";
			this.txtTongTien.ReadOnly = true;
			this.txtTongTien.Size = new System.Drawing.Size(305, 26);
			this.txtTongTien.TabIndex = 5;
			this.txtTongTien.TabStop = false;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Nunito", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(75, 479);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(79, 22);
			this.label4.TabIndex = 4;
			this.label4.Text = "Tổng tiền";
			// 
			// dgv_Sotiennap
			// 
			this.dgv_Sotiennap.AllowUserToAddRows = false;
			this.dgv_Sotiennap.AllowUserToDeleteRows = false;
			this.dgv_Sotiennap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_Sotiennap.Location = new System.Drawing.Point(16, 315);
			this.dgv_Sotiennap.MultiSelect = false;
			this.dgv_Sotiennap.Name = "dgv_Sotiennap";
			this.dgv_Sotiennap.ReadOnly = true;
			this.dgv_Sotiennap.RowHeadersVisible = false;
			this.dgv_Sotiennap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgv_Sotiennap.Size = new System.Drawing.Size(315, 109);
			this.dgv_Sotiennap.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 283);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(85, 20);
			this.label3.TabIndex = 2;
			this.label3.Text = "Số tiền nạp";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 42);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(106, 20);
			this.label2.TabIndex = 1;
			this.label2.Text = "Dịch vụ đã đặt";
			// 
			// dgv_Dichvu
			// 
			this.dgv_Dichvu.AllowUserToAddRows = false;
			this.dgv_Dichvu.AllowUserToDeleteRows = false;
			this.dgv_Dichvu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_Dichvu.Location = new System.Drawing.Point(16, 71);
			this.dgv_Dichvu.MultiSelect = false;
			this.dgv_Dichvu.Name = "dgv_Dichvu";
			this.dgv_Dichvu.ReadOnly = true;
			this.dgv_Dichvu.RowHeadersVisible = false;
			this.dgv_Dichvu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgv_Dichvu.Size = new System.Drawing.Size(517, 182);
			this.dgv_Dichvu.TabIndex = 0;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.txtTienDu);
			this.groupBox2.Controls.Add(this.txtTienKhachDua);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.txt1);
			this.groupBox2.Controls.Add(this.btnHienQR);
			this.groupBox2.Controls.Add(this.rdb_TienMat);
			this.groupBox2.Controls.Add(this.rdb_NganHang);
			this.groupBox2.Font = new System.Drawing.Font("Nunito", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox2.Location = new System.Drawing.Point(584, 77);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(374, 292);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Phương thức thanh toán";
			// 
			// txtTienDu
			// 
			this.txtTienDu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTienDu.Location = new System.Drawing.Point(181, 230);
			this.txtTienDu.Name = "txtTienDu";
			this.txtTienDu.ReadOnly = true;
			this.txtTienDu.Size = new System.Drawing.Size(175, 26);
			this.txtTienDu.TabIndex = 7;
			// 
			// txtTienKhachDua
			// 
			this.txtTienKhachDua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTienKhachDua.Location = new System.Drawing.Point(181, 188);
			this.txtTienKhachDua.Name = "txtTienKhachDua";
			this.txtTienKhachDua.Size = new System.Drawing.Size(175, 26);
			this.txtTienKhachDua.TabIndex = 6;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(57, 233);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(66, 20);
			this.label6.TabIndex = 4;
			this.label6.Text = "Tiền dư :";
			// 
			// txt1
			// 
			this.txt1.AutoSize = true;
			this.txt1.Location = new System.Drawing.Point(57, 188);
			this.txt1.Name = "txt1";
			this.txt1.Size = new System.Drawing.Size(118, 20);
			this.txt1.TabIndex = 3;
			this.txt1.Text = "Tiền khách đưa :";
			// 
			// btnHienQR
			// 
			this.btnHienQR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.btnHienQR.Location = new System.Drawing.Point(61, 84);
			this.btnHienQR.Name = "btnHienQR";
			this.btnHienQR.Size = new System.Drawing.Size(131, 46);
			this.btnHienQR.TabIndex = 2;
			this.btnHienQR.Text = "Hiện mã QR";
			this.btnHienQR.UseVisualStyleBackColor = false;
			this.btnHienQR.Click += new System.EventHandler(this.btnHienQR_Click);
			// 
			// rdb_TienMat
			// 
			this.rdb_TienMat.AutoSize = true;
			this.rdb_TienMat.Location = new System.Drawing.Point(33, 145);
			this.rdb_TienMat.Name = "rdb_TienMat";
			this.rdb_TienMat.Size = new System.Drawing.Size(86, 24);
			this.rdb_TienMat.TabIndex = 1;
			this.rdb_TienMat.TabStop = true;
			this.rdb_TienMat.Text = "Tiền mặt";
			this.rdb_TienMat.UseVisualStyleBackColor = true;
			// 
			// rdb_NganHang
			// 
			this.rdb_NganHang.AutoSize = true;
			this.rdb_NganHang.Location = new System.Drawing.Point(33, 38);
			this.rdb_NganHang.Name = "rdb_NganHang";
			this.rdb_NganHang.Size = new System.Drawing.Size(103, 24);
			this.rdb_NganHang.TabIndex = 0;
			this.rdb_NganHang.TabStop = true;
			this.rdb_NganHang.Text = "Ngân hàng";
			this.rdb_NganHang.UseVisualStyleBackColor = true;
			// 
			// btn_Submit
			// 
			this.btn_Submit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.btn_Submit.Font = new System.Drawing.Font("Nunito", 9.749998F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_Submit.Location = new System.Drawing.Point(783, 474);
			this.btn_Submit.Name = "btn_Submit";
			this.btn_Submit.Size = new System.Drawing.Size(175, 61);
			this.btn_Submit.TabIndex = 5;
			this.btn_Submit.Text = "THANH TOÁN THÀNH CÔNG";
			this.btn_Submit.UseVisualStyleBackColor = false;
			this.btn_Submit.Click += new System.EventHandler(this.btn_Submit_Click);
			// 
			// btn_Back
			// 
			this.btn_Back.BackColor = System.Drawing.Color.RosyBrown;
			this.btn_Back.Font = new System.Drawing.Font("Nunito", 9.749998F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_Back.Location = new System.Drawing.Point(584, 474);
			this.btn_Back.Name = "btn_Back";
			this.btn_Back.Size = new System.Drawing.Size(175, 61);
			this.btn_Back.TabIndex = 4;
			this.btn_Back.Text = "QUAY LẠI ĐƠN HÀNG";
			this.btn_Back.UseVisualStyleBackColor = false;
			this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
			// 
			// Form_ThanhToan
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(970, 651);
			this.Controls.Add(this.btn_Back);
			this.Controls.Add(this.btn_Submit);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.Name = "Form_ThanhToan";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Thanh toán";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv_Sotiennap)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv_Dichvu)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_Dichvu;
        private System.Windows.Forms.DataGridView dgv_Sotiennap;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnHienQR;
        private System.Windows.Forms.RadioButton rdb_TienMat;
        private System.Windows.Forms.RadioButton rdb_NganHang;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.TextBox txtTienDu;
        private System.Windows.Forms.TextBox txtTienKhachDua;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label txt1;
        private System.Windows.Forms.Button btn_Submit;
        private System.Windows.Forms.Button btn_Back;
    }
}