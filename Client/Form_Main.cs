using Client.Helpers;
using SQl_Database.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client
{
	public partial class Form_Main : Form
	{
		// Services
		private readonly SessionService _sessionService;
		private readonly ServiceOrderService _serviceOrderService;

		// Timer for updating the session info
		private Timer sessionTimer;
		private DateTime sessionStartTime;
		private double totalMinutes = 0; // Total minutes granted (could come from the package purchased)
		private double usedMinutes = 0;  // Used minutes in current session

		// Session and computer information
		private const int COMPUTER_ID = 1;  // Hardcoded computer ID
		private int sessionId = -1;
		private int roomId = 0;
		private decimal pricePerHour = 0;

		public Form_Main()
		{
			InitializeComponent();

			// Initialize services
			_sessionService = new SessionService();
			_serviceOrderService = new ServiceOrderService();

			// Position form in top right corner of screen
			Rectangle workingArea = Screen.GetWorkingArea(this);
			this.Location = new Point(workingArea.Right - this.Width, workingArea.Top);

			// Disable unimplemented functionality buttons
			btnMessage.Enabled = false;
			btnLockComputer.Enabled = false;
			btnUtilities.Enabled = false;

			// Initialize session
			InitializeSession();
		}

		private void InitializeSession()
		{
			// Create a session for the customer
			roomId = _sessionService.GetRoomIdForComputer(COMPUTER_ID);
			pricePerHour = _sessionService.GetRoomHourlyPrice(roomId);

			sessionId = _sessionService.CreateSession(CurrentUser.CurrentCustomer.MaKH, COMPUTER_ID);
			if (sessionId == -1)
			{
				MessageBox.Show("Không thể tạo phiên sử dụng máy. Vui lòng thử lại sau!", "Lỗi",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.Close();
				return;
			}

			// Update computer status
			_sessionService.UpdateComputerStatus(COMPUTER_ID, "Đang sử dụng");

			// Set customer info
			lblAccountBalance.Text = CurrentUser.CurrentCustomer.SoDu.ToString("N0");

			// Calculate how many minutes the customer can use based on their balance
			decimal balanceInMinutes = (CurrentUser.CurrentCustomer.SoDu / pricePerHour) * 60;
			totalMinutes = (double)balanceInMinutes;
			usedMinutes = 0;

			// Update UI
			UpdateSessionInfo();

			// Start the timer for session tracking
			sessionStartTime = DateTime.Now;
			sessionTimer = new Timer();
			sessionTimer.Interval = 1000; // 1 second
			sessionTimer.Tick += SessionTimer_Tick;
			sessionTimer.Start();
		}

		private void SessionTimer_Tick(object sender, EventArgs e)
		{
			// Calculate elapsed time
			TimeSpan elapsedTime = DateTime.Now - sessionStartTime;
			usedMinutes = elapsedTime.TotalMinutes;

			// Update session info on UI
			UpdateSessionInfo();

			// Check if session time is up
			if (usedMinutes >= totalMinutes)
			{
				sessionTimer.Stop();
				MessageBox.Show("Thời gian sử dụng đã hết. Vui lòng nạp thêm tiền để tiếp tục.",
						"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

				// End the session
				if (sessionId > 0)
				{
					_sessionService.EndSession(sessionId);
					_sessionService.UpdateComputerStatus(COMPUTER_ID, "Sẵn sàng");

					// Update customer balance
					decimal costPerMinute = pricePerHour / 60;
					decimal totalCost = (decimal)usedMinutes * costPerMinute;
					_sessionService.UpdateCustomerBalance(CurrentUser.CurrentCustomer.MaKH, totalCost);
				}

				// Auto logout
				LogoutUser();
			}
		}

		private void UpdateSessionInfo()
		{
			// Update time information
			lblTotalTime.Text = $"{Math.Floor(totalMinutes / 60):00}:{totalMinutes % 60:00}:00";

			// Format time as HH:mm:ss
			TimeSpan usedTime = TimeSpan.FromMinutes(usedMinutes);
			lblUsedTime.Text = $"{usedTime.Hours:00}:{usedTime.Minutes:00}:{usedTime.Seconds:00}";

			double remainingMinutes = Math.Max(0, totalMinutes - usedMinutes);
			TimeSpan remainingTime = TimeSpan.FromMinutes(remainingMinutes);
			lblRemainingTime.Text = $"{remainingTime.Hours:00}:{remainingTime.Minutes:00}:{remainingTime.Seconds:00}";

			// Calculate computer usage costs
			decimal costPerMinute = pricePerHour / 60; // Convert hourly price to per-minute
			decimal computerCost = (decimal)usedMinutes * costPerMinute;

			// Get service costs (food, drinks, etc.)
			decimal serviceCost = _serviceOrderService.GetCustomerServiceCost(CurrentUser.CurrentCustomer.MaKH);

			// Update costs on UI with currency format
			lblTotalCost.Text = $"{(computerCost + serviceCost):N0}đ";
			lblServiceCost.Text = $"{serviceCost:N0}đ";

			// Update account balance - subtract both computer and service costs
			decimal totalCost = computerCost + serviceCost;
			decimal currentBalance = CurrentUser.CurrentCustomer.SoDu - computerCost;
			lblAccountBalance.Text = $"{currentBalance:N0}đ";
		}

		private void btnLogout_Click(object sender, EventArgs e)
		{
			LogoutUser();
		}

		private void LogoutUser()
		{
			this.Close();
		}

		private void btnMessage_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Tính năng tin nhắn chưa được triển khai.", "Thông báo",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnChangePassword_Click(object sender, EventArgs e)
		{
			Form_ChangePassword changePasswordForm = new Form_ChangePassword();
			changePasswordForm.ShowDialog();
		}
		private void btnFood_Click(object sender, EventArgs e)
		{
			// Open food/drink order form
			Form_YeuCauDichVu serviceForm = new Form_YeuCauDichVu();
			serviceForm.ShowDialog();

			// After the form is closed, refresh all service costs
			UpdateSessionInfo();
		}

		private void btnLockComputer_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Tính năng khóa máy chưa được triển khai.", "Thông báo",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnUtilities_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Tính năng tiện ích chưa được triển khai.", "Thông báo",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
			{
				if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận",
						MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				{
					e.Cancel = true;
					return;
				}

				// Stop the session timer
				if (sessionTimer != null && sessionTimer.Enabled)
				{
					sessionTimer.Stop();
				}

				// End the session and update costs in database
				if (sessionId > 0)
				{
					// End the current session
					_sessionService.EndSession(sessionId);

					// Update computer status back to available
					_sessionService.UpdateComputerStatus(COMPUTER_ID, "Sẵn sàng");

					// Calculate and deduct the final costs
					decimal costPerMinute = pricePerHour / 60;
					decimal totalCost = (decimal)usedMinutes * costPerMinute;
					_sessionService.UpdateCustomerBalance(CurrentUser.CurrentCustomer.MaKH, totalCost);
				}

				// Log out user
				CurrentUser.Logout();
			}
		}

		protected override void OnActivated(EventArgs e)
		{
			base.OnActivated(e);
			// Refresh the service costs when the form is activated
			UpdateSessionInfo();
		}
	}
}
