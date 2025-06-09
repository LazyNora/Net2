using SQl_Database.Models;
using SQl_Database.Services;
using SQL_Database;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Server
{
	public partial class Form_Home : Form
	{
		// Theme colors
		private readonly Color themeBlue = ColorTranslator.FromHtml("#3297fd");
		private readonly Color themeWhite = Color.White;
		private readonly Color themeLight = Color.FromArgb(240, 240, 240);

		// Status colors
		private static readonly Dictionary<string, Color> StatusColors = new Dictionary<string, Color>
		{
			{ "Sẵn sàng", Color.LightGreen },
			{ "Đang sử dụng", Color.LightBlue },
			{ "Không hoạt động", Color.LightPink }
		};

		// Store computer panels for easy access
		private Dictionary<string, ComputerPanel> computerPanels = new Dictionary<string, ComputerPanel>();

		// Panel to hold the grid of computers
		private FlowLayoutPanel computerGridPanel;    // Database connection
		private DBConnect db;
		// Service classes
		private ComputerService computerService;
		private TopUpService topUpService;

		public Form_Home()
		{
			InitializeComponent();

			// Initialize database connection and services
			db = new DBConnect("Cyber");
			computerService = new ComputerService();
			topUpService = new TopUpService();

			SetupUI();
			LoadComputers();
		}

		private void SetupUI()
		{
			// Set up the computer grid panel
			computerGridPanel = new FlowLayoutPanel
			{
				Dock = DockStyle.Fill,
				AutoScroll = true,
				BackColor = themeLight,
				Padding = new Padding(20),
			};

			Controls.Add(computerGridPanel);

			// Add refresh button at the top
			Button refreshButton = new Button
			{
				Text = "Làm mới",
				BackColor = themeBlue,
				ForeColor = Color.White,
				Dock = DockStyle.Top,
				Height = 40,
				FlatStyle = FlatStyle.Flat,
			};
			refreshButton.FlatAppearance.BorderSize = 0;
			refreshButton.Click += (s, e) => LoadComputers();

			Controls.Add(refreshButton);
			//refreshButton.BringToFront();
		}
		private void LoadComputers()
		{
			// Clear existing panels
			computerGridPanel.Controls.Clear();
			computerPanels.Clear();

			try
			{
				// Get computers from the service
				List<Computer> computers = computerService.GetAllComputers();

				foreach (Computer computer in computers)
				{
					string computerId = computer.MaMay.ToString();
					string status = computer.TrangThaiMay;
					string room = computer.TenPhong;
					int customerId = computer.MaKH ?? -1;
					string customerName = computer.TenKH;

					// Create a panel for each computer
					ComputerPanel panel = new ComputerPanel(computerId, status, room, customerId, customerName);

					// Add context menu
					panel.AddContextMenu(CreateComputerContextMenu(computerId, status, customerId, customerName));

					// Add to the flow layout panel
					computerGridPanel.Controls.Add(panel);

					// Store for easy access
					computerPanels[computerId] = panel;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi khi tải danh sách máy: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private ContextMenuStrip CreateComputerContextMenu(string computerId, string status, int customerId, string customerName)
		{
			ContextMenuStrip menu = new ContextMenuStrip();

			// Add "Xem chi tiết" option
			ToolStripMenuItem detailItem = new ToolStripMenuItem("Xem chi tiết");
			detailItem.Click += (s, e) => ShowComputerDetail(computerId);
			menu.Items.Add(detailItem);

			// Add "Tắt máy" option if computer is in use
			if (status == "Đang sử dụng")
			{
				ToolStripMenuItem shutdownItem = new ToolStripMenuItem("Tắt máy");
				shutdownItem.Click += (s, e) => ShutdownComputer(computerId);
				menu.Items.Add(shutdownItem);

				// Add "Nạp tiền" option
				ToolStripMenuItem topUpItem = new ToolStripMenuItem("Nạp tiền");
				topUpItem.Click += (s, e) => TopUpAccount(customerId, customerName);
				menu.Items.Add(topUpItem);

				// Add "Thanh toán" option if computer is in use
				Computer computer = computerService.GetComputerById(int.Parse(computerId));
				if (computer != null && computer.MaHD.HasValue && !computer.DaThanhToan)
				{
					ToolStripMenuItem paymentItem = new ToolStripMenuItem("Thanh toán");
					paymentItem.Click += (s, e) => PayForComputer(computerId);
					menu.Items.Add(paymentItem);
				}
			}

			// Add "Đặt hàng" option if computer is in use
			if (status == "Đang sử dụng" && customerId != -1)
			{
				ToolStripMenuItem orderItem = new ToolStripMenuItem("Đặt hàng");
				orderItem.Click += (s, e) => PlaceOrder(customerId);
				menu.Items.Add(orderItem);
			}

			return menu;
		}

		#region Context Menu Actions
		private void ShowComputerDetail(string computerId)
		{
			try
			{
				int computerIdInt = int.Parse(computerId);
				Form_ComputerDetail detailForm = new Form_ComputerDetail(computerIdInt);
				detailForm.ShowDialog();

				// Refresh the computers list after closing the detail form
				LoadComputers();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Lỗi khi hiển thị chi tiết máy: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private void ShutdownComputer(string computerId)
		{
			DialogResult result = MessageBox.Show($"Bạn có chắc muốn tắt máy {computerId}?",
				"Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				try
				{
					if (computerService.ShutdownComputer(int.Parse(computerId)))
					{
						MessageBox.Show($"Đã tắt máy {computerId} thành công",
							"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
						MessageBox.Show($"Không thể tắt máy {computerId}",
							"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}

					// Refresh the view
					LoadComputers();
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Lỗi khi tắt máy: {ex.Message}",
						"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void TopUpAccount(int customerId, string customerName)
		{
			if (customerId == -1)
			{
				MessageBox.Show("Không có khách hàng đang sử dụng máy này", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Open top-up form
			Form_TopUp topUpForm = new Form_TopUp(customerId, customerName);
			topUpForm.ShowDialog();

			// Refresh computers after top-up to reflect changes
			LoadComputers();
		}

		private void PlaceOrder(int customerId)
		{
			if (customerId == -1)
			{
				MessageBox.Show("Không có khách hàng đang sử dụng máy này", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// TODO: Open order form
			MessageBox.Show($"Đặt hàng cho khách hàng ID: {customerId}", "Chức năng đang phát triển", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void PayForComputer(string computerId)
		{
			try
			{
				Computer computer = computerService.GetComputerById(int.Parse(computerId));

				if (computer != null && computer.MaHD.HasValue && !computer.DaThanhToan)
				{
					// Get invoice information
					Invoice invoice = computerService.GetInvoiceForComputer(int.Parse(computerId));

					if (invoice != null)
					{
						Form_ThanhToan paymentForm = new Form_ThanhToan(invoice.MaHD, invoice.TongTien);
						paymentForm.ShowDialog();

						// Refresh the computers list after payment
						LoadComputers();
					}
					else
					{
						MessageBox.Show("Không tìm thấy hóa đơn cho máy này", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				else
				{
					MessageBox.Show("Máy này không có hóa đơn cần thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Lỗi khi thanh toán: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		#endregion
	}

	// Custom Panel for displaying computer information
	public class ComputerPanel : Panel
	{
		// Theme colors
		private readonly Color themeBlue = ColorTranslator.FromHtml("#3297fd");
		private readonly Color themeWhite = Color.White;
		private readonly Color themeLight = Color.FromArgb(240, 240, 240);

		// Status colors
		private static readonly Dictionary<string, Color> StatusColors = new Dictionary<string, Color>
		{
			{ "Sẵn sàng", Color.LightGreen },
			{ "Đang sử dụng", Color.LightBlue },
			{ "Không hoạt động", Color.LightPink }
		};

		// Labels
		private Label lblComputerId;
		private Label lblStatus;
		private Label lblRoom;
		private Label lblCustomer;

		// Properties
		public string ComputerId { get; private set; }
		public string Status { get; private set; }
		public string Room { get; private set; }
		public int CustomerId { get; private set; }
		public string CustomerName { get; private set; }

		public ComputerPanel(string computerId, string status, string room, int customerId, string customerName)
		{
			ComputerId = computerId;
			Status = status;
			Room = room;
			CustomerId = customerId;
			CustomerName = customerName;

			// Set up panel properties
			Size = new Size(150, 150);
			Margin = new Padding(10);
			BackColor = StatusColors.ContainsKey(status) ? StatusColors[status] : Color.Gray;
			BorderStyle = BorderStyle.FixedSingle;

			// Create and add labels
			lblComputerId = new Label
			{
				Text = $"Máy {computerId}",
				Dock = DockStyle.Bottom,
				Height = 30,
				TextAlign = ContentAlignment.MiddleCenter,
				Font = new Font("Arial", 10, FontStyle.Bold),
				BackColor = themeBlue,
				ForeColor = themeWhite
			};

			lblStatus = new Label
			{
				Text = $"Trạng thái: {status}",
				Dock = DockStyle.Top,
				Height = 25,
				TextAlign = ContentAlignment.MiddleLeft,
				Padding = new Padding(5, 0, 0, 0)
			};

			lblRoom = new Label
			{
				Text = $"Phòng: {room}",
				Dock = DockStyle.Top,
				Height = 25,
				TextAlign = ContentAlignment.MiddleLeft,
				Padding = new Padding(5, 0, 0, 0)
			};

			lblCustomer = new Label
			{
				Text = string.IsNullOrEmpty(customerName) ? "Không có người dùng" : $"Người dùng: {customerName}",
				Dock = DockStyle.Top,
				Height = 40,
				TextAlign = ContentAlignment.MiddleLeft,
				Padding = new Padding(5, 0, 0, 0),
				AutoEllipsis = true
			};

			// Add controls to panel
			Controls.Add(lblCustomer);
			Controls.Add(lblRoom);
			Controls.Add(lblStatus);
			Controls.Add(lblComputerId);

			// Bring the ID label to the front
			lblComputerId.BringToFront();
		}

		public void AddContextMenu(ContextMenuStrip menu)
		{
			this.ContextMenuStrip = menu;
		}
	}
}
