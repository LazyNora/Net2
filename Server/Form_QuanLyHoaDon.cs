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
      dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

      // Add columns
      dataGridView.Columns.Add("MaHD", "Mã HĐ");
      dataGridView.Columns.Add("NgayLap", "Ngày lập");
      dataGridView.Columns.Add("TenKH", "Khách hàng");
      dataGridView.Columns.Add("TenNV", "Nhân viên");
      dataGridView.Columns.Add("TongTien", "Tổng tiền");
      dataGridView.Columns.Add("TrangThai", "Trạng thái");

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
