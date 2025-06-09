using System;
using System.Data;
using System.Windows.Forms;
using SQl_Database.Services;

namespace Server
{
  public partial class Form_QuanLyHoaDon : Form
  {
    public Form_QuanLyHoaDon()
    {
      InitializeComponent();

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
        Name = "MaHD",
        HeaderText = "Mã HĐ",
        DataPropertyName = "MaHD"
      });
      dataGridView.Columns.Add(new DataGridViewTextBoxColumn
      {
        Name = "NgayLap",
        HeaderText = "Ngày lập",
        DataPropertyName = "NgayLap"
      });
      dataGridView.Columns.Add(new DataGridViewTextBoxColumn
      {
        Name = "TenKH",
        HeaderText = "Khách hàng",
        DataPropertyName = "TenKH"
      });
      dataGridView.Columns.Add(new DataGridViewTextBoxColumn
      {
        Name = "TenNV",
        HeaderText = "Nhân viên",
        DataPropertyName = "TenNV"
      });
      dataGridView.Columns.Add(new DataGridViewTextBoxColumn
      {
        Name = "TongTien",
        HeaderText = "Tổng tiền",
        DataPropertyName = "TongTien"
      });
      dataGridView.Columns.Add(new DataGridViewTextBoxColumn
      {
        Name = "TrangThai",
        HeaderText = "Trạng thái",
        DataPropertyName = "TrangThai"
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

      // Setup date filter
      dtpFrom.ValueChanged += (s, e) => ApplyFilter(txtSearch.Text);
      dtpTo.ValueChanged += (s, e) => ApplyFilter(txtSearch.Text);

      // Setup status filter
      comboStatus.Items.AddRange(new[] { "Tất cả", "Chưa thanh toán", "Đã thanh toán" });
      comboStatus.SelectedIndex = 0;
      comboStatus.SelectedIndexChanged += (s, e) => ApplyFilter(txtSearch.Text);

      // Setup add button
      btnAdd.Click += (s, e) => MessageBox.Show("Chức năng đang phát triển");
    }

    private void LoadData()
    {
      // TODO: Add service call to load HoaDon data
      dataGridView.DataSource = null;
    }

    private void ApplyFilter(string searchText)
    {
      // Filter logic will be implemented here
      MessageBox.Show("Chức năng lọc đang phát triển");
    }
  }
}
