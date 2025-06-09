using System;
using System.Data;
using System.Windows.Forms;
using SQl_Database.Services;

namespace Server
{
  public partial class Form_QuanLyTaiKhoan : Form
  {
    private readonly UserService _userService;

    public Form_QuanLyTaiKhoan()
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
      dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

      // Add columns
      dataGridView.Columns.Add("MaKH", "Mã KH");
      dataGridView.Columns.Add("TenKH", "Tên khách hàng");
      dataGridView.Columns.Add("TenTK", "Tên tài khoản");
      dataGridView.Columns.Add("Email", "Email");
      dataGridView.Columns.Add("TrangThaiKH", "Trạng thái");
      dataGridView.Columns.Add("SoDu", "Số dư");

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

      // Setup status filter
      comboStatus.Items.AddRange(new[] { "Tất cả", "Hoạt động", "Đã khóa" });
      comboStatus.SelectedIndex = 0;
      comboStatus.SelectedIndexChanged += (s, e) => ApplyFilter(txtSearch.Text);

      // Setup add button
      btnAdd.Click += (s, e) => MessageBox.Show("Chức năng đang phát triển");
    }

    private void LoadData()
    {
      var dt = _userService.GetAllCustomers();
      dataGridView.DataSource = dt;
    }

    private void ApplyFilter(string searchText)
    {
      // Filter logic will be implemented here
      MessageBox.Show("Chức năng lọc đang phát triển");
    }
  }
}
