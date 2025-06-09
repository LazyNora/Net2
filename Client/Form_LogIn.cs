using Client.Helpers;
using SQl_Database.Models;
using SQl_Database.Services;
using System;
using System.Windows.Forms;

namespace Client
{
	public partial class Form_LogIn : Form
	{
		private readonly UserService _userService;
		private Form_Main currentMainForm;

		public Form_LogIn()
		{
			InitializeComponent();
			_userService = new UserService();
		}

		private void btnLogin_Click(object sender, EventArgs e)
		{
			string username = txtUsername.Text.Trim();
			string password = txtPassword.Text.Trim();

			if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
			{
				MessageBox.Show("Vui lòng nhập đầy đủ thông tin đăng nhập!", "Thông báo",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			Customer customer = _userService.CustomerLogin(username, password);

			if (customer != null)
			{       // Lưu thông tin khách hàng đăng nhập
				CurrentUser.CurrentCustomer = customer;

				// Chuyển đến form chính của ứng dụng khách hàng
				currentMainForm = new Form_Main();
				currentMainForm.FormClosed += (s, args) =>
				{
					this.Show();
					txtPassword.Clear();
				};
				currentMainForm.Show();
				this.Hide();
			}
			else
			{
				MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng hoặc tài khoản đã bị khóa!",
					"Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void Form_LogIn_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
			{
				DialogResult result = MessageBox.Show("Bạn có muốn thoát ứng dụng không?", "Xác nhận",
					MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result == DialogResult.No)
				{
					e.Cancel = true;
				}
			}
		}
	}
}
