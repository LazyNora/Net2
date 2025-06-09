using Server.Helpers;
using SQl_Database.Services;
using SQL_Database;
using System;
using System.Windows.Forms;

namespace Server
{
	public partial class Form_TopUp : Form
	{
		private readonly int customerId;
		private readonly string customerName;
		private decimal currentBalance = 0;
		private DBConnect db;
		private TopUpService topUpService;

		public Form_TopUp(int customerId, string customerName)
		{
			InitializeComponent();

			this.customerId = customerId; this.customerName = customerName;

			// Initialize database connection and services
			db = new DBConnect("Cyber");
			topUpService = new TopUpService();

			// Set up the form
			this.Text = "Nạp tiền cho khách hàng";
			lblCustomerInfo.Text = $"Khách hàng: {customerName} (ID: {customerId})";

			// Load customer balance
			LoadCustomerBalance();
		}
		private void LoadCustomerBalance()
		{
			try
			{
				// Use the service to get the customer balance
				currentBalance = topUpService.GetCustomerBalance(customerId);
				lblCurrentBalance.Text = $"Số dư hiện tại: {currentBalance:N0} VNĐ";
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Lỗi khi tải thông tin số dư: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnTopUp_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtAmount.Text))
			{
				MessageBox.Show("Vui lòng nhập số tiền cần nạp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (!decimal.TryParse(txtAmount.Text, out decimal amount))
			{
				MessageBox.Show("Số tiền không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (amount <= 0)
			{
				MessageBox.Show("Số tiền nạp phải lớn hơn 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			try
			{
				int employeeId = CurrentUser.CurrentEmployee.MaNhanVien;

				// Use the service to get or create an invoice
				int invoiceId = topUpService.GetOrCreateInvoice(customerId, employeeId);

				if (invoiceId > 0)
				{
					// Use the service to perform the top-up
					if (topUpService.PerformTopUp(customerId, invoiceId, amount))
					{
						MessageBox.Show($"Đã nạp thành công {amount:N0} VNĐ vào tài khoản", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

						// Refresh the balance display
						LoadCustomerBalance();

						// Clear the amount textbox
						txtAmount.Clear();

					}
					else
					{
						MessageBox.Show("Không thể nạp tiền vào tài khoản", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Lỗi khi nạp tiền: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			this.Close();
		}
		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}