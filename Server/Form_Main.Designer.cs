namespace Server
{
  partial class Form_Main
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
			this.panelSidebar = new System.Windows.Forms.Panel();
			this.btnLogout = new System.Windows.Forms.Button();
			this.btnProfile = new System.Windows.Forms.Button();
			this.btnStatistics = new System.Windows.Forms.Button();
			this.panelManagementSubmenu = new System.Windows.Forms.Panel();
			this.btnComputerManagement = new System.Windows.Forms.Button();
			this.btnOrderManagement = new System.Windows.Forms.Button();
			this.btnEmployeeManagement = new System.Windows.Forms.Button();
			this.btnProductManagement = new System.Windows.Forms.Button();
			this.btnAccountManagement = new System.Windows.Forms.Button();
			this.btnManagement = new System.Windows.Forms.Button();
			this.btnHome = new System.Windows.Forms.Button();
			this.panelUserInfo = new System.Windows.Forms.Panel();
			this.lblRole = new System.Windows.Forms.Label();
			this.lblUsername = new System.Windows.Forms.Label();
			this.pictureBoxAvatar = new System.Windows.Forms.PictureBox();
			this.panelHeader = new System.Windows.Forms.Panel();
			this.lblTitle = new System.Windows.Forms.Label();
			this.panelTime = new System.Windows.Forms.Panel();
			this.lblDate = new System.Windows.Forms.Label();
			this.lblTime = new System.Windows.Forms.Label();
			this.panelContent = new System.Windows.Forms.Panel();
			this.panelSidebar.SuspendLayout();
			this.panelManagementSubmenu.SuspendLayout();
			this.panelUserInfo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).BeginInit();
			this.panelHeader.SuspendLayout();
			this.panelTime.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelSidebar
			// 
			this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(151)))), ((int)(((byte)(253)))));
			this.panelSidebar.Controls.Add(this.btnLogout);
			this.panelSidebar.Controls.Add(this.btnProfile);
			this.panelSidebar.Controls.Add(this.btnStatistics);
			this.panelSidebar.Controls.Add(this.panelManagementSubmenu);
			this.panelSidebar.Controls.Add(this.btnManagement);
			this.panelSidebar.Controls.Add(this.btnHome);
			this.panelSidebar.Controls.Add(this.panelUserInfo);
			this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
			this.panelSidebar.Location = new System.Drawing.Point(0, 0);
			this.panelSidebar.Name = "panelSidebar";
			this.panelSidebar.Size = new System.Drawing.Size(250, 761);
			this.panelSidebar.TabIndex = 0;
			// 
			// btnLogout
			// 
			this.btnLogout.BackColor = System.Drawing.Color.White;
			this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.btnLogout.FlatAppearance.BorderSize = 0;
			this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnLogout.ForeColor = System.Drawing.Color.Red;
			this.btnLogout.Location = new System.Drawing.Point(0, 711);
			this.btnLogout.Name = "btnLogout";
			this.btnLogout.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.btnLogout.Size = new System.Drawing.Size(250, 50);
			this.btnLogout.TabIndex = 6;
			this.btnLogout.Text = "Đăng xuất";
			this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnLogout.UseVisualStyleBackColor = false;
			this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
			// 
			// btnProfile
			// 
			this.btnProfile.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnProfile.FlatAppearance.BorderSize = 0;
			this.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnProfile.ForeColor = System.Drawing.Color.White;
			this.btnProfile.Location = new System.Drawing.Point(0, 390);
			this.btnProfile.Name = "btnProfile";
			this.btnProfile.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.btnProfile.Size = new System.Drawing.Size(250, 50);
			this.btnProfile.TabIndex = 5;
			this.btnProfile.Text = "Cá nhân";
			this.btnProfile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnProfile.UseVisualStyleBackColor = true;
			this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
			// 
			// btnStatistics
			// 
			this.btnStatistics.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnStatistics.FlatAppearance.BorderSize = 0;
			this.btnStatistics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnStatistics.ForeColor = System.Drawing.Color.White;
			this.btnStatistics.Location = new System.Drawing.Point(0, 340);
			this.btnStatistics.Name = "btnStatistics";
			this.btnStatistics.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.btnStatistics.Size = new System.Drawing.Size(250, 50);
			this.btnStatistics.TabIndex = 4;
			this.btnStatistics.Text = "Thống kê";
			this.btnStatistics.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnStatistics.UseVisualStyleBackColor = true;
			this.btnStatistics.Click += new System.EventHandler(this.btnStatistics_Click);
			// 
			// panelManagementSubmenu
			// 
			this.panelManagementSubmenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(166)))), ((int)(((byte)(253)))));
			this.panelManagementSubmenu.Controls.Add(this.btnComputerManagement);
			this.panelManagementSubmenu.Controls.Add(this.btnOrderManagement);
			this.panelManagementSubmenu.Controls.Add(this.btnEmployeeManagement);
			this.panelManagementSubmenu.Controls.Add(this.btnProductManagement);
			this.panelManagementSubmenu.Controls.Add(this.btnAccountManagement);
			this.panelManagementSubmenu.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelManagementSubmenu.Location = new System.Drawing.Point(0, 190);
			this.panelManagementSubmenu.Name = "panelManagementSubmenu";
			this.panelManagementSubmenu.Size = new System.Drawing.Size(250, 150);
			this.panelManagementSubmenu.TabIndex = 3;
			// 
			// btnComputerManagement
			// 
			this.btnComputerManagement.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnComputerManagement.FlatAppearance.BorderSize = 0;
			this.btnComputerManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnComputerManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnComputerManagement.ForeColor = System.Drawing.Color.White;
			this.btnComputerManagement.Location = new System.Drawing.Point(0, 120);
			this.btnComputerManagement.Name = "btnComputerManagement";
			this.btnComputerManagement.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
			this.btnComputerManagement.Size = new System.Drawing.Size(250, 30);
			this.btnComputerManagement.TabIndex = 4;
			this.btnComputerManagement.Text = "Quản lý máy";
			this.btnComputerManagement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnComputerManagement.UseVisualStyleBackColor = true;
			this.btnComputerManagement.Click += new System.EventHandler(this.btnComputerManagement_Click);
			// 
			// btnOrderManagement
			// 
			this.btnOrderManagement.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnOrderManagement.FlatAppearance.BorderSize = 0;
			this.btnOrderManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnOrderManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnOrderManagement.ForeColor = System.Drawing.Color.White;
			this.btnOrderManagement.Location = new System.Drawing.Point(0, 90);
			this.btnOrderManagement.Name = "btnOrderManagement";
			this.btnOrderManagement.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
			this.btnOrderManagement.Size = new System.Drawing.Size(250, 30);
			this.btnOrderManagement.TabIndex = 3;
			this.btnOrderManagement.Text = "Quản lý hóa đơn";
			this.btnOrderManagement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnOrderManagement.UseVisualStyleBackColor = true;
			this.btnOrderManagement.Click += new System.EventHandler(this.btnOrderManagement_Click);
			// 
			// btnEmployeeManagement
			// 
			this.btnEmployeeManagement.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnEmployeeManagement.FlatAppearance.BorderSize = 0;
			this.btnEmployeeManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnEmployeeManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnEmployeeManagement.ForeColor = System.Drawing.Color.White;
			this.btnEmployeeManagement.Location = new System.Drawing.Point(0, 60);
			this.btnEmployeeManagement.Name = "btnEmployeeManagement";
			this.btnEmployeeManagement.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
			this.btnEmployeeManagement.Size = new System.Drawing.Size(250, 30);
			this.btnEmployeeManagement.TabIndex = 2;
			this.btnEmployeeManagement.Text = "Quản lý nhân viên";
			this.btnEmployeeManagement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnEmployeeManagement.UseVisualStyleBackColor = true;
			this.btnEmployeeManagement.Click += new System.EventHandler(this.btnEmployeeManagement_Click);
			// 
			// btnProductManagement
			// 
			this.btnProductManagement.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnProductManagement.FlatAppearance.BorderSize = 0;
			this.btnProductManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnProductManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnProductManagement.ForeColor = System.Drawing.Color.White;
			this.btnProductManagement.Location = new System.Drawing.Point(0, 30);
			this.btnProductManagement.Name = "btnProductManagement";
			this.btnProductManagement.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
			this.btnProductManagement.Size = new System.Drawing.Size(250, 30);
			this.btnProductManagement.TabIndex = 1;
			this.btnProductManagement.Text = "Quản lý sản phẩm";
			this.btnProductManagement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnProductManagement.UseVisualStyleBackColor = true;
			this.btnProductManagement.Click += new System.EventHandler(this.btnProductManagement_Click);
			// 
			// btnAccountManagement
			// 
			this.btnAccountManagement.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnAccountManagement.FlatAppearance.BorderSize = 0;
			this.btnAccountManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAccountManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAccountManagement.ForeColor = System.Drawing.Color.White;
			this.btnAccountManagement.Location = new System.Drawing.Point(0, 0);
			this.btnAccountManagement.Name = "btnAccountManagement";
			this.btnAccountManagement.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
			this.btnAccountManagement.Size = new System.Drawing.Size(250, 30);
			this.btnAccountManagement.TabIndex = 0;
			this.btnAccountManagement.Text = "Quản lý tài khoản";
			this.btnAccountManagement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnAccountManagement.UseVisualStyleBackColor = true;
			this.btnAccountManagement.Click += new System.EventHandler(this.btnAccountManagement_Click);
			// 
			// btnManagement
			// 
			this.btnManagement.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnManagement.FlatAppearance.BorderSize = 0;
			this.btnManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnManagement.ForeColor = System.Drawing.Color.White;
			this.btnManagement.Location = new System.Drawing.Point(0, 140);
			this.btnManagement.Name = "btnManagement";
			this.btnManagement.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.btnManagement.Size = new System.Drawing.Size(250, 50);
			this.btnManagement.TabIndex = 2;
			this.btnManagement.Text = "Quản lý";
			this.btnManagement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnManagement.UseVisualStyleBackColor = true;
			this.btnManagement.Click += new System.EventHandler(this.btnManagement_Click);
			// 
			// btnHome
			// 
			this.btnHome.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnHome.FlatAppearance.BorderSize = 0;
			this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnHome.ForeColor = System.Drawing.Color.White;
			this.btnHome.Location = new System.Drawing.Point(0, 90);
			this.btnHome.Name = "btnHome";
			this.btnHome.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.btnHome.Size = new System.Drawing.Size(250, 50);
			this.btnHome.TabIndex = 1;
			this.btnHome.Text = "Trang chủ";
			this.btnHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnHome.UseVisualStyleBackColor = true;
			this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
			// 
			// panelUserInfo
			// 
			this.panelUserInfo.Controls.Add(this.lblRole);
			this.panelUserInfo.Controls.Add(this.lblUsername);
			this.panelUserInfo.Controls.Add(this.pictureBoxAvatar);
			this.panelUserInfo.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelUserInfo.Location = new System.Drawing.Point(0, 0);
			this.panelUserInfo.Name = "panelUserInfo";
			this.panelUserInfo.Size = new System.Drawing.Size(250, 90);
			this.panelUserInfo.TabIndex = 0;
			// 
			// lblRole
			// 
			this.lblRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblRole.ForeColor = System.Drawing.Color.White;
			this.lblRole.Location = new System.Drawing.Point(86, 49);
			this.lblRole.Name = "lblRole";
			this.lblRole.Size = new System.Drawing.Size(149, 15);
			this.lblRole.TabIndex = 2;
			this.lblRole.Text = "Quản lý";
			// 
			// lblUsername
			// 
			this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblUsername.ForeColor = System.Drawing.Color.White;
			this.lblUsername.Location = new System.Drawing.Point(86, 27);
			this.lblUsername.Name = "lblUsername";
			this.lblUsername.Size = new System.Drawing.Size(149, 16);
			this.lblUsername.TabIndex = 1;
			this.lblUsername.Text = "Nguyễn Văn A";
			// 
			// pictureBoxAvatar
			// 
			this.pictureBoxAvatar.BackColor = System.Drawing.Color.White;
			this.pictureBoxAvatar.Location = new System.Drawing.Point(12, 15);
			this.pictureBoxAvatar.Name = "pictureBoxAvatar";
			this.pictureBoxAvatar.Size = new System.Drawing.Size(60, 60);
			this.pictureBoxAvatar.TabIndex = 0;
			this.pictureBoxAvatar.TabStop = false;
			// 
			// panelHeader
			// 
			this.panelHeader.BackColor = System.Drawing.Color.White;
			this.panelHeader.Controls.Add(this.lblTitle);
			this.panelHeader.Controls.Add(this.panelTime);
			this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelHeader.Location = new System.Drawing.Point(250, 0);
			this.panelHeader.Name = "panelHeader";
			this.panelHeader.Size = new System.Drawing.Size(934, 60);
			this.panelHeader.TabIndex = 1;
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(151)))), ((int)(((byte)(253)))));
			this.lblTitle.Location = new System.Drawing.Point(19, 17);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(278, 25);
			this.lblTitle.TabIndex = 1;
			this.lblTitle.Text = "Hệ Thống Quản Lý Cyber";
			// 
			// panelTime
			// 
			this.panelTime.Controls.Add(this.lblDate);
			this.panelTime.Controls.Add(this.lblTime);
			this.panelTime.Dock = System.Windows.Forms.DockStyle.Right;
			this.panelTime.Location = new System.Drawing.Point(734, 0);
			this.panelTime.Name = "panelTime";
			this.panelTime.Size = new System.Drawing.Size(200, 60);
			this.panelTime.TabIndex = 0;
			// 
			// lblDate
			// 
			this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDate.Location = new System.Drawing.Point(36, 31);
			this.lblDate.Name = "lblDate";
			this.lblDate.Size = new System.Drawing.Size(148, 16);
			this.lblDate.TabIndex = 1;
			this.lblDate.Text = "09/06/2025";
			this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblTime
			// 
			this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTime.Location = new System.Drawing.Point(36, 10);
			this.lblTime.Name = "lblTime";
			this.lblTime.Size = new System.Drawing.Size(148, 20);
			this.lblTime.TabIndex = 0;
			this.lblTime.Text = "10:30:00";
			this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panelContent
			// 
			this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelContent.Location = new System.Drawing.Point(250, 60);
			this.panelContent.Name = "panelContent";
			this.panelContent.Size = new System.Drawing.Size(934, 701);
			this.panelContent.TabIndex = 2;
			// 
			// Form_Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1184, 761);
			this.Controls.Add(this.panelContent);
			this.Controls.Add(this.panelHeader);
			this.Controls.Add(this.panelSidebar);
			this.MinimumSize = new System.Drawing.Size(1000, 700);
			this.Name = "Form_Main";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Cyber Management System";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Main_FormClosing);
			this.panelSidebar.ResumeLayout(false);
			this.panelManagementSubmenu.ResumeLayout(false);
			this.panelUserInfo.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).EndInit();
			this.panelHeader.ResumeLayout(false);
			this.panelHeader.PerformLayout();
			this.panelTime.ResumeLayout(false);
			this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panelSidebar;
    private System.Windows.Forms.Panel panelUserInfo;
    private System.Windows.Forms.PictureBox pictureBoxAvatar;
    private System.Windows.Forms.Label lblUsername;
    private System.Windows.Forms.Label lblRole;
    private System.Windows.Forms.Button btnHome;
    private System.Windows.Forms.Button btnManagement;
    private System.Windows.Forms.Panel panelManagementSubmenu;
    private System.Windows.Forms.Button btnAccountManagement;
    private System.Windows.Forms.Button btnProductManagement;
    private System.Windows.Forms.Button btnEmployeeManagement;
    private System.Windows.Forms.Button btnOrderManagement;
    private System.Windows.Forms.Button btnComputerManagement;
    private System.Windows.Forms.Button btnStatistics;
    private System.Windows.Forms.Button btnProfile;
    private System.Windows.Forms.Button btnLogout;
    private System.Windows.Forms.Panel panelHeader;
    private System.Windows.Forms.Panel panelTime;
    private System.Windows.Forms.Label lblTime;
    private System.Windows.Forms.Label lblDate;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.Panel panelContent;
  }
}
