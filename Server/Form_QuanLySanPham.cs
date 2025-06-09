using System;
using System.Data;
using System.Windows.Forms;
using SQl_Database.Services;

namespace Server
{
  public partial class Form_QuanLySanPham : Form
  {
    private readonly ServiceOrderService _serviceService;

    public Form_QuanLySanPham()
    {
      InitializeComponent();
      _serviceService = new ServiceOrderService();

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
      dataGridView.Columns.Add("MaDV", "Mã dịch vụ");
      dataGridView.Columns.Add("TenDV", "Tên dịch vụ");
      dataGridView.Columns.Add("MoTa", "Mô tả");
      dataGridView.Columns.Add("Gia", "Giá");
      dataGridView.Columns.Add("LoaiDV", "Loại dịch vụ");

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

      // Setup category filter
      comboCategory.Items.AddRange(new[] { "Tất cả", "Đồ ăn", "Đồ uống", "Dịch vụ khác" });
      comboCategory.SelectedIndex = 0;
      comboCategory.SelectedIndexChanged += (s, e) => ApplyFilter(txtSearch.Text);

      // Setup add button
      btnAdd.Click += (s, e) => MessageBox.Show("Chức năng đang phát triển");
    }

    private void LoadData()
    {
      var services = _serviceService.GetAllServices();
      dataGridView.DataSource = services;
    }

    private void ApplyFilter(string searchText)
    {
      // Filter logic will be implemented here
      MessageBox.Show("Chức năng lọc đang phát triển");
    }
  }
}
