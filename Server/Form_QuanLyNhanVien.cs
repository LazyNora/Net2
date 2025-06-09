using SQl_Database.Services;
using System.Windows.Forms;

namespace Server
{
	public partial class Form_QuanLyNhanVien : Form
	{
		private readonly UserService _userService;

		public Form_QuanLyNhanVien()
		{
			InitializeComponent();
			_userService = new UserService();

			// Set up DataGridView
			SetupDataGridView();

			// Set up search controls
			SetupSearchControls();

			// Load initial data
			LoadData();
		}

		private void SetupDataGridView()
		{
			dataGridView.AutoGenerateColumns = false;
			dataGridView.AllowUserToAddRows = false;
			dataGridView.ReadOnly = true;
			dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;      // Add columns
			dataGridView.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = "MaNV",
				HeaderText = "Mã NV",
				DataPropertyName = "MaNhanVien"
			});
			dataGridView.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = "TenTK",
				HeaderText = "Tên nhân viên",
				DataPropertyName = "HoTen"
			});
			dataGridView.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = "TenNV",
				HeaderText = "Tên nhân viên",
				DataPropertyName = "TenTK"
			});
			dataGridView.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = "Email",
				HeaderText = "Email",
				DataPropertyName = "Email"
			});
			dataGridView.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = "NgayVaoLam",
				HeaderText = "Ngày vào làm",
				DataPropertyName = "NgayVaoLam"
			});
			dataGridView.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = "TenViTri",
				HeaderText = "Vị trí",
				DataPropertyName = "TenViTri"
			});
			dataGridView.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = "TrangThaiNV",
				HeaderText = "Trạng thái",
				DataPropertyName = "TrangThaiNV"
			});


			// Setup context menu
			var contextMenu = new ContextMenuStrip();
			contextMenu.Items.Add("Thêm mới", null, (s, e) => MessageBox.Show("Chức năng đang phát triển"));
			contextMenu.Items.Add("Sửa", null, (s, e) => MessageBox.Show("Chức năng đang phát triển"));
			contextMenu.Items.Add("Xóa", null, (s, e) => MessageBox.Show("Chức năng đang phát triển"));

			dataGridView.ContextMenuStrip = contextMenu;
		}

		private void SetupSearchControls()
		{
			// Setup search textbox
			txtSearch.TextChanged += (s, e) => ApplyFilter(txtSearch.Text);

			// Setup position filter
			comboPosition.Items.AddRange(new[] { "Tất cả", "Quản lý", "Nhân viên" });
			comboPosition.SelectedIndex = 0;
			comboPosition.SelectedIndexChanged += (s, e) => ApplyFilter(txtSearch.Text);

			// Setup add button
			btnAdd.Click += (s, e) => MessageBox.Show("Chức năng đang phát triển");
		}

		private void LoadData()
		{
			var dt = _userService.GetAllEmployees();
			dataGridView.DataSource = dt;
		}

		private void ApplyFilter(string searchText)
		{
			// Filter logic will be implemented here
			MessageBox.Show("Chức năng lọc đang phát triển");
		}
	}
}
