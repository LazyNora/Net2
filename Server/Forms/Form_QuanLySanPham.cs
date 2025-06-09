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
      dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;      // Add columns
      dataGridView.Columns.Add(new DataGridViewTextBoxColumn
      {
          Name = "MaDV",
          HeaderText = "Mã dịch vụ",
          DataPropertyName = "MaDV"
      });
      dataGridView.Columns.Add(new DataGridViewTextBoxColumn
      {
          Name = "TenDV",
          HeaderText = "Tên dịch vụ",
          DataPropertyName = "TenDV"
      });
      dataGridView.Columns.Add(new DataGridViewTextBoxColumn
      {
          Name = "MoTa",
          HeaderText = "Mô tả",
          DataPropertyName = "MoTa"
      });
      dataGridView.Columns.Add(new DataGridViewTextBoxColumn
      {
          Name = "Gia",
          HeaderText = "Giá",
          DataPropertyName = "Gia"
      });
      dataGridView.Columns.Add(new DataGridViewTextBoxColumn
      {
          Name = "LoaiDV",
          HeaderText = "Loại dịch vụ",
          DataPropertyName = "LoaiDV"
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
