namespace Client
{
    partial class Form_ChangePassword
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
			this.lblTitle = new System.Windows.Forms.Label();
			this.lblCurrentPassword = new System.Windows.Forms.Label();
			this.lblNewPassword = new System.Windows.Forms.Label();
			this.lblConfirmPassword = new System.Windows.Forms.Label();
			this.txtCurrentPassword = new System.Windows.Forms.TextBox();
			this.txtNewPassword = new System.Windows.Forms.TextBox();
			this.txtConfirmPassword = new System.Windows.Forms.TextBox();
			this.btnChangePassword = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitle.Location = new System.Drawing.Point(73, 16);
			this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(157, 24);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = "ĐỔI MẬT KHẨU";
			// 
			// lblCurrentPassword
			// 
			this.lblCurrentPassword.AutoSize = true;
			this.lblCurrentPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCurrentPassword.Location = new System.Drawing.Point(26, 65);
			this.lblCurrentPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblCurrentPassword.Name = "lblCurrentPassword";
			this.lblCurrentPassword.Size = new System.Drawing.Size(104, 15);
			this.lblCurrentPassword.TabIndex = 1;
			this.lblCurrentPassword.Text = "Mật khẩu hiện tại:";
			// 
			// lblNewPassword
			// 
			this.lblNewPassword.AutoSize = true;
			this.lblNewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblNewPassword.Location = new System.Drawing.Point(26, 98);
			this.lblNewPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblNewPassword.Name = "lblNewPassword";
			this.lblNewPassword.Size = new System.Drawing.Size(85, 15);
			this.lblNewPassword.TabIndex = 2;
			this.lblNewPassword.Text = "Mật khẩu mới:";
			// 
			// lblConfirmPassword
			// 
			this.lblConfirmPassword.AutoSize = true;
			this.lblConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblConfirmPassword.Location = new System.Drawing.Point(26, 130);
			this.lblConfirmPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblConfirmPassword.Name = "lblConfirmPassword";
			this.lblConfirmPassword.Size = new System.Drawing.Size(116, 15);
			this.lblConfirmPassword.TabIndex = 3;
			this.lblConfirmPassword.Text = "Xác nhận mật khẩu:";
			// 
			// txtCurrentPassword
			// 
			this.txtCurrentPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtCurrentPassword.Location = new System.Drawing.Point(141, 65);
			this.txtCurrentPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.txtCurrentPassword.Name = "txtCurrentPassword";
			this.txtCurrentPassword.PasswordChar = '*';
			this.txtCurrentPassword.Size = new System.Drawing.Size(136, 21);
			this.txtCurrentPassword.TabIndex = 4;
			// 
			// txtNewPassword
			// 
			this.txtNewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtNewPassword.Location = new System.Drawing.Point(141, 98);
			this.txtNewPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.txtNewPassword.Name = "txtNewPassword";
			this.txtNewPassword.PasswordChar = '*';
			this.txtNewPassword.Size = new System.Drawing.Size(136, 21);
			this.txtNewPassword.TabIndex = 5;
			// 
			// txtConfirmPassword
			// 
			this.txtConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtConfirmPassword.Location = new System.Drawing.Point(141, 130);
			this.txtConfirmPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.txtConfirmPassword.Name = "txtConfirmPassword";
			this.txtConfirmPassword.PasswordChar = '*';
			this.txtConfirmPassword.Size = new System.Drawing.Size(136, 21);
			this.txtConfirmPassword.TabIndex = 6;
			// 
			// btnChangePassword
			// 
			this.btnChangePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnChangePassword.Location = new System.Drawing.Point(69, 171);
			this.btnChangePassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnChangePassword.Name = "btnChangePassword";
			this.btnChangePassword.Size = new System.Drawing.Size(75, 28);
			this.btnChangePassword.TabIndex = 7;
			this.btnChangePassword.Text = "Đổi";
			this.btnChangePassword.UseVisualStyleBackColor = true;
			this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCancel.Location = new System.Drawing.Point(159, 171);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 28);
			this.btnCancel.TabIndex = 8;
			this.btnCancel.Text = "Hủy";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// Form_ChangePassword
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(302, 222);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnChangePassword);
			this.Controls.Add(this.txtConfirmPassword);
			this.Controls.Add(this.txtNewPassword);
			this.Controls.Add(this.txtCurrentPassword);
			this.Controls.Add(this.lblConfirmPassword);
			this.Controls.Add(this.lblNewPassword);
			this.Controls.Add(this.lblCurrentPassword);
			this.Controls.Add(this.lblTitle);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form_ChangePassword";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Đổi mật khẩu";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCurrentPassword;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox txtCurrentPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Button btnCancel;
    }
}
