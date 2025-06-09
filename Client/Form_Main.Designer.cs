namespace Client
{
	partial class Form_Main
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;        /// <summary>
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
			this.pnlUserInfo = new System.Windows.Forms.Panel();
			this.lblAccountBalance = new System.Windows.Forms.TextBox();
			this.lblServiceCost = new System.Windows.Forms.TextBox();
			this.lblTotalCost = new System.Windows.Forms.TextBox();
			this.lblRemainingTime = new System.Windows.Forms.TextBox();
			this.lblUsedTime = new System.Windows.Forms.TextBox();
			this.lblTotalTime = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.pnlNavigation = new System.Windows.Forms.Panel();
			this.btnUtilities = new System.Windows.Forms.Button();
			this.btnLockComputer = new System.Windows.Forms.Button();
			this.btnFood = new System.Windows.Forms.Button();
			this.btnChangePassword = new System.Windows.Forms.Button();
			this.btnLogout = new System.Windows.Forms.Button();
			this.btnMessage = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pnlUserInfo.SuspendLayout();
			this.pnlNavigation.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlUserInfo
			// 
			this.pnlUserInfo.BackColor = System.Drawing.Color.White;
			this.pnlUserInfo.Controls.Add(this.lblAccountBalance);
			this.pnlUserInfo.Controls.Add(this.lblServiceCost);
			this.pnlUserInfo.Controls.Add(this.lblTotalCost);
			this.pnlUserInfo.Controls.Add(this.lblRemainingTime);
			this.pnlUserInfo.Controls.Add(this.lblUsedTime);
			this.pnlUserInfo.Controls.Add(this.lblTotalTime);
			this.pnlUserInfo.Controls.Add(this.label6);
			this.pnlUserInfo.Controls.Add(this.label5);
			this.pnlUserInfo.Controls.Add(this.label4);
			this.pnlUserInfo.Controls.Add(this.label3);
			this.pnlUserInfo.Controls.Add(this.label2);
			this.pnlUserInfo.Controls.Add(this.label1);
			this.pnlUserInfo.Location = new System.Drawing.Point(22, 24);
			this.pnlUserInfo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.pnlUserInfo.Name = "pnlUserInfo";
			this.pnlUserInfo.Size = new System.Drawing.Size(240, 203);
			this.pnlUserInfo.TabIndex = 0;
			// 
			// lblAccountBalance
			// 
			this.lblAccountBalance.BackColor = System.Drawing.Color.White;
			this.lblAccountBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblAccountBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAccountBalance.Location = new System.Drawing.Point(125, 162);
			this.lblAccountBalance.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.lblAccountBalance.Name = "lblAccountBalance";
			this.lblAccountBalance.ReadOnly = true;
			this.lblAccountBalance.Size = new System.Drawing.Size(104, 21);
			this.lblAccountBalance.TabIndex = 11;
			this.lblAccountBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblServiceCost
			// 
			this.lblServiceCost.BackColor = System.Drawing.Color.White;
			this.lblServiceCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblServiceCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblServiceCost.Location = new System.Drawing.Point(125, 134);
			this.lblServiceCost.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.lblServiceCost.Name = "lblServiceCost";
			this.lblServiceCost.ReadOnly = true;
			this.lblServiceCost.Size = new System.Drawing.Size(104, 21);
			this.lblServiceCost.TabIndex = 10;
			this.lblServiceCost.Text = "00:00";
			this.lblServiceCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblTotalCost
			// 
			this.lblTotalCost.BackColor = System.Drawing.Color.White;
			this.lblTotalCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblTotalCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTotalCost.Location = new System.Drawing.Point(125, 106);
			this.lblTotalCost.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.lblTotalCost.Name = "lblTotalCost";
			this.lblTotalCost.ReadOnly = true;
			this.lblTotalCost.Size = new System.Drawing.Size(104, 21);
			this.lblTotalCost.TabIndex = 9;
			this.lblTotalCost.Text = "00:00";
			this.lblTotalCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblRemainingTime
			// 
			this.lblRemainingTime.BackColor = System.Drawing.Color.White;
			this.lblRemainingTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblRemainingTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblRemainingTime.Location = new System.Drawing.Point(125, 77);
			this.lblRemainingTime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.lblRemainingTime.Name = "lblRemainingTime";
			this.lblRemainingTime.ReadOnly = true;
			this.lblRemainingTime.Size = new System.Drawing.Size(104, 21);
			this.lblRemainingTime.TabIndex = 8;
			this.lblRemainingTime.Text = "176:2";
			this.lblRemainingTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblUsedTime
			// 
			this.lblUsedTime.BackColor = System.Drawing.Color.White;
			this.lblUsedTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblUsedTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblUsedTime.Location = new System.Drawing.Point(125, 49);
			this.lblUsedTime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.lblUsedTime.Name = "lblUsedTime";
			this.lblUsedTime.ReadOnly = true;
			this.lblUsedTime.Size = new System.Drawing.Size(104, 21);
			this.lblUsedTime.TabIndex = 7;
			this.lblUsedTime.Text = "00:01";
			this.lblUsedTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblTotalTime
			// 
			this.lblTotalTime.BackColor = System.Drawing.Color.White;
			this.lblTotalTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblTotalTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTotalTime.Location = new System.Drawing.Point(125, 20);
			this.lblTotalTime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.lblTotalTime.Name = "lblTotalTime";
			this.lblTotalTime.ReadOnly = true;
			this.lblTotalTime.Size = new System.Drawing.Size(104, 21);
			this.lblTotalTime.TabIndex = 6;
			this.lblTotalTime.Text = "176:2";
			this.lblTotalTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(11, 162);
			this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(95, 15);
			this.label6.TabIndex = 5;
			this.label6.Text = "Số dư tài khoản:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(11, 134);
			this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(89, 15);
			this.label5.TabIndex = 4;
			this.label5.Text = "Chi phí dịch vụ:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(11, 106);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(77, 15);
			this.label4.TabIndex = 3;
			this.label4.Text = "Tổng chi phí:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(11, 77);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 15);
			this.label3.TabIndex = 2;
			this.label3.Text = "Thời gian còn lại:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(11, 49);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(108, 15);
			this.label2.TabIndex = 1;
			this.label2.Text = "Thời gian sử dụng:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(11, 20);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "Tổng thời gian:";
			// 
			// pnlNavigation
			// 
			this.pnlNavigation.Controls.Add(this.btnUtilities);
			this.pnlNavigation.Controls.Add(this.btnLockComputer);
			this.pnlNavigation.Controls.Add(this.btnFood);
			this.pnlNavigation.Controls.Add(this.btnChangePassword);
			this.pnlNavigation.Controls.Add(this.btnLogout);
			this.pnlNavigation.Controls.Add(this.btnMessage);
			this.pnlNavigation.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlNavigation.Location = new System.Drawing.Point(0, 376);
			this.pnlNavigation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.pnlNavigation.Name = "pnlNavigation";
			this.pnlNavigation.Size = new System.Drawing.Size(286, 89);
			this.pnlNavigation.TabIndex = 1;
			// 
			// btnUtilities
			// 
			this.btnUtilities.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.btnUtilities.Enabled = false;
			this.btnUtilities.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(154)))), ((int)(((byte)(246)))));
			this.btnUtilities.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnUtilities.ForeColor = System.Drawing.Color.Black;
			this.btnUtilities.Image = global::Client.Properties.Resources.unity;
			this.btnUtilities.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnUtilities.Location = new System.Drawing.Point(230, 5);
			this.btnUtilities.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnUtilities.Name = "btnUtilities";
			this.btnUtilities.Size = new System.Drawing.Size(52, 80);
			this.btnUtilities.TabIndex = 5;
			this.btnUtilities.Text = "Tiện ích";
			this.btnUtilities.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnUtilities.UseVisualStyleBackColor = false;
			this.btnUtilities.Click += new System.EventHandler(this.btnUtilities_Click);
			// 
			// btnLockComputer
			// 
			this.btnLockComputer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.btnLockComputer.Enabled = false;
			this.btnLockComputer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(154)))), ((int)(((byte)(246)))));
			this.btnLockComputer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnLockComputer.ForeColor = System.Drawing.Color.Black;
			this.btnLockComputer.Image = global::Client.Properties.Resources._lock;
			this.btnLockComputer.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnLockComputer.Location = new System.Drawing.Point(172, 5);
			this.btnLockComputer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnLockComputer.Name = "btnLockComputer";
			this.btnLockComputer.Size = new System.Drawing.Size(52, 80);
			this.btnLockComputer.TabIndex = 4;
			this.btnLockComputer.Text = "Khóa máy";
			this.btnLockComputer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnLockComputer.UseVisualStyleBackColor = false;
			this.btnLockComputer.Click += new System.EventHandler(this.btnLockComputer_Click);
			// 
			// btnFood
			// 
			this.btnFood.BackColor = System.Drawing.Color.White;
			this.btnFood.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(154)))), ((int)(((byte)(246)))));
			this.btnFood.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnFood.ForeColor = System.Drawing.Color.Black;
			this.btnFood.Image = global::Client.Properties.Resources.food;
			this.btnFood.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnFood.Location = new System.Drawing.Point(116, 5);
			this.btnFood.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnFood.Name = "btnFood";
			this.btnFood.Size = new System.Drawing.Size(52, 80);
			this.btnFood.TabIndex = 3;
			this.btnFood.Text = "Dịch vụ";
			this.btnFood.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnFood.UseVisualStyleBackColor = false;
			this.btnFood.Click += new System.EventHandler(this.btnFood_Click);
			// 
			// btnChangePassword
			// 
			this.btnChangePassword.BackColor = System.Drawing.Color.White;
			this.btnChangePassword.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(154)))), ((int)(((byte)(246)))));
			this.btnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnChangePassword.ForeColor = System.Drawing.Color.Black;
			this.btnChangePassword.Image = global::Client.Properties.Resources.key;
			this.btnChangePassword.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnChangePassword.Location = new System.Drawing.Point(58, 5);
			this.btnChangePassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnChangePassword.Name = "btnChangePassword";
			this.btnChangePassword.Size = new System.Drawing.Size(52, 80);
			this.btnChangePassword.TabIndex = 2;
			this.btnChangePassword.Text = "Mật khẩu";
			this.btnChangePassword.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnChangePassword.UseVisualStyleBackColor = false;
			this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
			// 
			// btnLogout
			// 
			this.btnLogout.BackColor = System.Drawing.Color.White;
			this.btnLogout.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(154)))), ((int)(((byte)(246)))));
			this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnLogout.ForeColor = System.Drawing.Color.Black;
			this.btnLogout.Image = global::Client.Properties.Resources.logout;
			this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnLogout.Location = new System.Drawing.Point(2, 5);
			this.btnLogout.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnLogout.Name = "btnLogout";
			this.btnLogout.Size = new System.Drawing.Size(52, 80);
			this.btnLogout.TabIndex = 1;
			this.btnLogout.Text = "Đăng xuất";
			this.btnLogout.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnLogout.UseVisualStyleBackColor = false;
			this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
			// 
			// btnMessage
			// 
			this.btnMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(154)))), ((int)(((byte)(246)))));
			this.btnMessage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(154)))), ((int)(((byte)(246)))));
			this.btnMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnMessage.ForeColor = System.Drawing.Color.White;
			this.btnMessage.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnMessage.Location = new System.Drawing.Point(-56, 5);
			this.btnMessage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnMessage.Name = "btnMessage";
			this.btnMessage.Size = new System.Drawing.Size(52, 65);
			this.btnMessage.TabIndex = 0;
			this.btnMessage.Text = "Tin nhắn";
			this.btnMessage.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnMessage.UseVisualStyleBackColor = false;
			this.btnMessage.Click += new System.EventHandler(this.btnMessage_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pictureBox1.Image = global::Client.Properties.Resources.supportbanner;
			this.pictureBox1.Location = new System.Drawing.Point(0, 249);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(286, 127);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			// 
			// Form_Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.ClientSize = new System.Drawing.Size(286, 465);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.pnlNavigation);
			this.Controls.Add(this.pnlUserInfo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.MaximizeBox = false;
			this.Name = "Form_Main";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Cyber Client";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Main_FormClosing);
			this.pnlUserInfo.ResumeLayout(false);
			this.pnlUserInfo.PerformLayout();
			this.pnlNavigation.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlUserInfo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox lblAccountBalance;
		private System.Windows.Forms.TextBox lblServiceCost;
		private System.Windows.Forms.TextBox lblTotalCost;
		private System.Windows.Forms.TextBox lblRemainingTime;
		private System.Windows.Forms.TextBox lblUsedTime;
		private System.Windows.Forms.TextBox lblTotalTime;
		private System.Windows.Forms.Panel pnlNavigation;
		private System.Windows.Forms.Button btnUtilities;
		private System.Windows.Forms.Button btnLockComputer;
		private System.Windows.Forms.Button btnFood;
		private System.Windows.Forms.Button btnChangePassword;
		private System.Windows.Forms.Button btnLogout;
		private System.Windows.Forms.Button btnMessage;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}
