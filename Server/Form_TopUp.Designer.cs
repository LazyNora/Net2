namespace Server
{
	partial class Form_TopUp
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

		private void InitializeComponent()
		{
			this.lblCustomerInfo = new System.Windows.Forms.Label();
			this.lblCurrentBalance = new System.Windows.Forms.Label();
			this.lblAmount = new System.Windows.Forms.Label();
			this.txtAmount = new System.Windows.Forms.TextBox();
			this.btnTopUp = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			//
			// lblCustomerInfo
			//
			this.lblCustomerInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCustomerInfo.Location = new System.Drawing.Point(12, 20);
			this.lblCustomerInfo.Name = "lblCustomerInfo";
			this.lblCustomerInfo.Size = new System.Drawing.Size(360, 23);
			this.lblCustomerInfo.TabIndex = 0;
			this.lblCustomerInfo.Text = "Khách hàng: [Tên khách hàng] (ID: [Mã KH])";
			//
			// lblCurrentBalance
			//
			this.lblCurrentBalance.Location = new System.Drawing.Point(12, 55);
			this.lblCurrentBalance.Name = "lblCurrentBalance";
			this.lblCurrentBalance.Size = new System.Drawing.Size(360, 23);
			this.lblCurrentBalance.TabIndex = 1;
			this.lblCurrentBalance.Text = "Số dư hiện tại: 0 VNĐ";
			//
			// lblAmount
			//
			this.lblAmount.AutoSize = true;
			this.lblAmount.Location = new System.Drawing.Point(12, 100);
			this.lblAmount.Name = "lblAmount";
			this.lblAmount.Size = new System.Drawing.Size(76, 13);
			this.lblAmount.TabIndex = 2;
			this.lblAmount.Text = "Số tiền nạp:";
			//
			// txtAmount
			//
			this.txtAmount.Location = new System.Drawing.Point(94, 97);
			this.txtAmount.Name = "txtAmount";
			this.txtAmount.Size = new System.Drawing.Size(278, 20);
			this.txtAmount.TabIndex = 3;
			//
			// btnTopUp
			//
			this.btnTopUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(151)))), ((int)(((byte)(253)))));
			this.btnTopUp.FlatAppearance.BorderSize = 0;
			this.btnTopUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnTopUp.ForeColor = System.Drawing.Color.White;
			this.btnTopUp.Location = new System.Drawing.Point(94, 140);
			this.btnTopUp.Name = "btnTopUp";
			this.btnTopUp.Size = new System.Drawing.Size(120, 35);
			this.btnTopUp.TabIndex = 4;
			this.btnTopUp.Text = "Nạp tiền";
			this.btnTopUp.UseVisualStyleBackColor = false;
			this.btnTopUp.Click += new System.EventHandler(this.btnTopUp_Click);
			//
			// btnCancel
			//
			this.btnCancel.BackColor = System.Drawing.Color.Silver;
			this.btnCancel.FlatAppearance.BorderSize = 0;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCancel.ForeColor = System.Drawing.Color.White;
			this.btnCancel.Location = new System.Drawing.Point(252, 140);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(120, 35);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Hủy";
			this.btnCancel.UseVisualStyleBackColor = false;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			//
			// Form_TopUp
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(384, 196);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnTopUp);
			this.Controls.Add(this.txtAmount);
			this.Controls.Add(this.lblAmount);
			this.Controls.Add(this.lblCurrentBalance);
			this.Controls.Add(this.lblCustomerInfo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form_TopUp";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Nạp tiền cho khách hàng";
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		private System.Windows.Forms.Label lblCustomerInfo;
		private System.Windows.Forms.Label lblCurrentBalance;
		private System.Windows.Forms.Label lblAmount;
		private System.Windows.Forms.TextBox txtAmount;
		private System.Windows.Forms.Button btnTopUp;
		private System.Windows.Forms.Button btnCancel;
	}
}
