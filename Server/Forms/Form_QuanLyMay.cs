using System;
using System.Data;
using System.Windows.Forms;
using SQl_Database.Services;

namespace Server
{
  public partial class Form_QuanLyMay : Form
  {
    private readonly ComputerService _computerService;

    public Form_QuanLyMay()
    {
      InitializeComponent();
      _computerService = new ComputerService();

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
          Name = "MaMay",
          HeaderText = "Mã máy",
          DataPropertyName = "MaMay"
      });
      dataGridView.Columns.Add(new DataGridViewTextBoxColumn
      {
          Name = "TenMay",
          HeaderText = "Tên máy",
          DataPropertyName = "TenMay"
      });
      dataGridView.Columns.Add(new DataGridViewTextBoxColumn
      {
          Name = "MoTa",
          HeaderText = "Mô tả",
          DataPropertyName = "MoTa"
      });
      dataGridView.Columns.Add(new DataGridViewTextBoxColumn
      {
          Name = "TrangThai",
          HeaderText = "Trạng thái",
          DataPropertyName = "TrangThai"
      });
      dataGridView.Columns.Add(new DataGridViewTextBoxColumn
      {
          Name = "GiaTien",
          HeaderText = "Giá tiền/giờ",
          DataPropertyName = "GiaTien"
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

      // Setup status filter
      comboStatus.Items.AddRange(new[] { "Tất cả", "Đang sử dụng", "Trống", "Bảo trì" });
      comboStatus.SelectedIndex = 0;
      comboStatus.SelectedIndexChanged += (s, e) => ApplyFilter(txtSearch.Text);

      // Setup add button
      btnAdd.Click += (s, e) => MessageBox.Show("Chức năng đang phát triển");
    }

    private void LoadData()
    {
      var computers = _computerService.GetAllComputers();
      dataGridView.DataSource = computers;
    }

    private void ApplyFilter(string searchText)
    {
      // Filter logic will be implemented here
      MessageBox.Show("Chức năng lọc đang phát triển");
    }
  }
}
