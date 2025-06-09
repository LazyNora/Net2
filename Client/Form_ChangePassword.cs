using System;
using System.Windows.Forms;
using Client.Helpers;
using SQl_Database.Services;

namespace Client
{
    public partial class Form_ChangePassword : Form
    {
        private readonly SessionService _sessionService;

        public Form_ChangePassword()
        {
            InitializeComponent();
            _sessionService = new SessionService();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            string currentPassword = txtCurrentPassword.Text.Trim();
            string newPassword = txtNewPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

            // Validate inputs
            if (string.IsNullOrEmpty(currentPassword) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if new password matches confirm password
            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không khớp!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate current password
            if (!_sessionService.ValidateCustomerPassword(CurrentUser.CurrentCustomer.MaKH, currentPassword))
            {
                MessageBox.Show("Mật khẩu hiện tại không đúng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Change password
            if (_sessionService.ChangeCustomerPassword(CurrentUser.CurrentCustomer.MaKH, newPassword))
            {
                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Đổi mật khẩu thất bại. Vui lòng thử lại sau!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
