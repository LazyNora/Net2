using SQl_Database;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace Server
{
	partial class Form_ThanhToan : Form
	{
		private int maHoaDon;
		private decimal tongTien;
		Database db = new Database();
		private Form qrForm; // Form to display QR code

		public Form_ThanhToan(int maHD, decimal tongTien)
		{
			InitializeComponent();
			maHoaDon = maHD;
			this.tongTien = tongTien;

			textBox1.Text = maHoaDon.ToString();
			textBox1.ReadOnly = true;
			btnHienQR.Enabled = false;
			txtTienKhachDua.Enabled = false;
			txtTienDu.Enabled = false;
			txtTongTien.Text = tongTien.ToString("N0");


			LoadDichVuSuDung(maHD);
			LoadSoTienNap(maHD);
			FormatGridView();


			rdb_NganHang.CheckedChanged += rdb_NganHang_CheckedChanged;
			rdb_TienMat.CheckedChanged += rdb_TienMat_CheckedChanged;
			txtTienKhachDua.TextChanged += txtTienKhachDua_TextChanged;

		}


		// Load Chi tiết Dịch vụ sử dụng
		private void LoadDichVuSuDung(int maHD)
		{
			string query = @"
							SELECT
								dv.TenDichVu,
								ctdv.SoLuong,
								ctdv.DonGia,
								ctdv.ThanhTien
							FROM ChiTietDichVu ctdv
							INNER JOIN DichVu dv ON ctdv.MaDichVu = dv.MaDichVu
							WHERE ctdv.MaHD = @MaHD";

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@MaHD", maHD)
			};

			DataTable dt = db.GetData(query, parameters);
			if (dt != null)
				dgv_Dichvu.DataSource = dt;
		}


		// Load Số tiền nạp
		private void LoadSoTienNap(int maHD)
		{
			string query = @"
							SELECT
								SoTienNap
							FROM ChiTietNap
							WHERE MaHD = @MaHD";

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@MaHD", maHD)
			};

			DataTable dt = db.GetData(query, parameters);

			if (dt != null)
			{
				// Thêm cột STT thủ công
				DataTable dtWithSTT = new DataTable();
				dtWithSTT.Columns.Add("STT", typeof(int));
				dtWithSTT.Columns.Add("SoTienNap", typeof(decimal));

				int stt = 1;
				foreach (DataRow row in dt.Rows)
				{
					dtWithSTT.Rows.Add(stt++, row["SoTienNap"]);
				}

				dgv_Sotiennap.DataSource = dtWithSTT;
			}
		}


		//Format
		private void FormatGridView()
		{
			// Dich vụ sử dụng

			dgv_Dichvu.Columns["TenDichVu"].HeaderText = "Tên dịch vụ";
			dgv_Dichvu.Columns["SoLuong"].HeaderText = "Số lượng";
			dgv_Dichvu.Columns["DonGia"].HeaderText = "Đơn giá";
			dgv_Dichvu.Columns["ThanhTien"].HeaderText = "Thành tiền";

			dgv_Dichvu.Columns["TenDichVu"].Width = 150;
			dgv_Dichvu.Columns["SoLuong"].Width = 100;
			dgv_Dichvu.Columns["DonGia"].Width = 100;
			dgv_Dichvu.Columns["ThanhTien"].Width = 120;

			dgv_Dichvu.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dgv_Dichvu.Columns["DonGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgv_Dichvu.Columns["ThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

			dgv_Dichvu.Columns["DonGia"].DefaultCellStyle.Format = "N0";
			dgv_Dichvu.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";

			dgv_Dichvu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


			// Số tiền nạp
			dgv_Sotiennap.Columns["STT"].HeaderText = "Số lần nạp";
			dgv_Sotiennap.Columns["SoTienNap"].HeaderText = "Số tiền nạp";

			dgv_Sotiennap.Columns["STT"].Width = 120;
			dgv_Sotiennap.Columns["SoTienNap"].Width = 150;

			dgv_Sotiennap.Columns["STT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dgv_Sotiennap.Columns["SoTienNap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

			dgv_Sotiennap.Columns["SoTienNap"].DefaultCellStyle.Format = "N0";
			dgv_Sotiennap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
		}

		private void rdb_NganHang_CheckedChanged(object sender, EventArgs e)
		{
			if (rdb_NganHang.Checked)
			{
				btnHienQR.Enabled = true;

				// Vô hiệu hóa nhập tiền mặt
				txtTienKhachDua.Enabled = false;
				txtTienKhachDua.Clear();
				txtTienKhachDua.Clear();
			}
		}

		private void rdb_TienMat_CheckedChanged(object sender, EventArgs e)
		{
			if (rdb_TienMat.Checked)
			{
				btnHienQR.Enabled = false;

				// Cho nhập tiền khách đưa
				txtTienKhachDua.Enabled = true;
				txtTienKhachDua.Focus();
			}
		}

		private void txtTienKhachDua_TextChanged(object sender, EventArgs e)
		{
			if (decimal.TryParse(txtTienKhachDua.Text, out decimal tienKhachDua))
			{
				if (tienKhachDua >= tongTien)
				{
					decimal tienDu = tienKhachDua - tongTien;
					txtTienDu.Text = tienDu.ToString("N0");
				}
				else
				{
					txtTienDu.Text = "Thiếu tiền!";
				}
			}
			else
			{
				txtTienDu.Text = "";
			}
		}

		private void btn_Back_Click(object sender, EventArgs e)
		{
			this.Close();
		}


		private void btn_Submit_Click(object sender, EventArgs e)
		{
			try
			{
				string phuongThuc = "";

				if (rdb_NganHang.Checked)
				{
					phuongThuc = "Ngân hàng";
				}
				else if (rdb_TienMat.Checked)
				{
					phuongThuc = "Tiền mặt";

					// Kiểm tra đầu vào
					if (string.IsNullOrWhiteSpace(txtTienKhachDua.Text))
					{
						MessageBox.Show("Vui lòng nhập số tiền khách đưa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}

					if (!decimal.TryParse(txtTienKhachDua.Text.Trim(), out decimal tienKhachDua))
					{
						MessageBox.Show("Số tiền khách đưa không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}

					if (tienKhachDua < tongTien)
					{
						MessageBox.Show("Số tiền khách đưa không đủ để thanh toán!", "Thiếu tiền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}

					// Gán tiền dư
					decimal tienDu = tienKhachDua - tongTien;
					txtTienDu.Text = tienDu.ToString("N2");
				}
				else
				{
					MessageBox.Show("Vui lòng chọn phương thức thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				// Câu lệnh SQL để thêm dữ liệu vào bảng ThanhToan
				string query = "INSERT INTO ThanhToan (SoTienTT, PhuongThucTT, MaHD) VALUES (@SoTienTT, @PhuongThucTT, @MaHD)";
				SqlParameter[] parameters = new SqlParameter[]
				{
					new SqlParameter("@SoTienTT", tongTien),
					new SqlParameter("@PhuongThucTT", phuongThuc),
					new SqlParameter("@MaHD", maHoaDon)
				};

				int result = db.Execute(query, parameters);
				if (result > 0)
				{
					MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					this.Close();    // đóng form Thanh toán
				}
				else
				{
					MessageBox.Show("Thanh toán thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi xử lý thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnHienQR_Click(object sender, EventArgs e)
		{
			try
			{
				// Create URL for QR code with the current amount
				string url = $"https://api.vietqr.io/image/970436-113366668888-g3eAwfv.jpg?accountName=ABC ABC&amount={tongTien}";

				// Download the image
				using (WebClient client = new WebClient())
				{
					byte[] imageData = client.DownloadData(url);
					using (var ms = new System.IO.MemoryStream(imageData))
					{
						Image qrImage = Image.FromStream(ms);

						// Create a new form to display the QR code
						if (qrForm != null && !qrForm.IsDisposed)
						{
							qrForm.Close();
						}

						qrForm = new Form
						{
							Text = "Quét mã QR để thanh toán",
							Size = new Size(400, 450),
							FormBorderStyle = FormBorderStyle.FixedDialog,
							MaximizeBox = false,
							MinimizeBox = false,
							StartPosition = FormStartPosition.CenterParent
						};

						PictureBox pictureBox = new PictureBox
						{
							Image = qrImage,
							SizeMode = PictureBoxSizeMode.Zoom,
							Dock = DockStyle.Fill
						};

						qrForm.Controls.Add(pictureBox);
						qrForm.ShowDialog(this);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Không thể tải mã QR. Lỗi: " + ex.Message, "Lỗi",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			base.OnFormClosing(e);
			if (qrForm != null && !qrForm.IsDisposed)
			{
				qrForm.Close();
			}
		}
	}
}
