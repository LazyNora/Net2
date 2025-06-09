using System;
using System.Data;
using System.Windows.Forms;
using SQl_Database.Services;

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
      dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

      // Add columns
      dataGridView.Columns.Add("MaNV", "Mã NV");
      dataGridView.Columns.Add("TenNV", "Tên nhân viên");
      dataGridView.Columns.Add("TenViTri", "Vị trí");
      dataGridView.Columns.Add("SDT", "Số điện thoại");
      dataGridView.Columns.Add("Email", "Email");
      dataGridView.Columns.Add("DiaChi", "Địa chỉ");

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
