using Client.Helpers;
using SQL_Database;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Client
{
	public partial class Form_YeuCauDichVu : Form
	{
		DBConnect db = new DBConnect("Cyber");

		public Form_YeuCauDichVu()
		{
			InitializeComponent();
			getDataServices();

		}
		public void getDataServices()
		{
			string sql = "SELECT MaDichVu, TenDichVu, Gia, Anh, TonKho, MaLoai FROM DichVu";

			// Lấy dữ liệu vào DataTable
			DataTable dt = db.getDataTable(sql, "DichVu");

			// Duyệt qua các dòng dữ liệu
			foreach (DataRow row in dt.Rows)
			{
				string maDichVu = row["MaDichVu"].ToString();
				string tenDichVu = row["TenDichVu"].ToString();
				decimal gia = Convert.ToDecimal(row["Gia"]);
				string anh = row["Anh"].ToString();
				int tonKho = Convert.ToInt32(row["TonKho"]);
				string maLoai = row["MaLoai"].ToString();

				AddProduct(maDichVu, tenDichVu, gia, anh);

			}
		}

		private void AddProduct(string maDichVu, string name, decimal price, string imageFileName)
		{
			var productCard = new Panel { Width = 160, Height = 250, Margin = new Padding(10), BorderStyle = BorderStyle.FixedSingle };

			var image = new PictureBox
			{
				Width = 160,
				Height = 100,
				BackColor = Color.LightGray,
				SizeMode = PictureBoxSizeMode.StretchImage,
				Top = 5,
				Left = 5
			};

			string imagePath = Application.StartupPath + imageFileName.Replace("/", "\\");

			// If not found, try the original path
			if (!File.Exists(imagePath))
			{
				imagePath = @"E:\TranCongManh\TH PTTKHT\project\Cyber\Cyber" + imageFileName;
			}

			try
			{
				if (File.Exists(imagePath))
				{
					// Sử dụng Image thay vì BackgroundImage
					image.Image = Image.FromFile(imagePath);
				}
				else
				{
					// Use a placeholder instead of showing error message
					image.BackColor = Color.FromArgb(224, 224, 224); // Light gray
				}
			}
			catch (Exception)
			{
				// Use a placeholder instead of showing error message
				image.BackColor = Color.FromArgb(224, 224, 224); // Light gray
			}

			var madichvu = new Label
			{
				Text = maDichVu,
				AutoSize = false,
				Width = 150,
				Height = 30,
				TextAlign = ContentAlignment.MiddleCenter,
				Visible = false // Ẩn label mã dịch vụ
			};

			var lblName = new Label
			{
				Text = name,
				AutoSize = false,
				Width = 150,
				Height = 30,
				TextAlign = ContentAlignment.MiddleCenter
			};

			var lblPrice = new Label
			{
				Text = price.ToString("N0") + "đ",
				AutoSize = false,
				Width = 150,
				Height = 30,
				TextAlign = ContentAlignment.MiddleCenter
			};

			var numQuantity = new NumericUpDown
			{
				Width = 50,
				Minimum = 0,
				Maximum = 100,
				TextAlign = HorizontalAlignment.Center,
			};

			var controls = new TableLayoutPanel
			{
				Width = 150,
				Height = 120,
				RowCount = 4,
				ColumnCount = 1,
				Top = image.Bottom + 5,
				Left = 5
			};
			controls.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
			controls.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
			controls.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
			controls.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
			controls.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));

			productCard.Controls.Add(image);
			productCard.Controls.Add(madichvu);
			controls.Controls.Add(lblName, 0, 0);
			controls.Controls.Add(lblPrice, 0, 1);
			controls.Controls.Add(numQuantity, 0, 2);

			productCard.Controls.Add(controls);

			image.Location = new Point(5, 5);
			controls.Location = new Point(5, image.Bottom + 5);

			flowLayoutPanel.Controls.Add(productCard);
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			foreach (Control productCard in flowLayoutPanel.Controls)
			{
				foreach (Control child in productCard.Controls)
				{
					// Tìm TableLayoutPanel chứa các control con
					if (child is TableLayoutPanel controls)
					{
						foreach (Control c in controls.Controls)
						{
							if (c is NumericUpDown num && num.Value > 0)
							{
								num.Value = 0;
							}
						}
					}
				}
			}
		}

		private void btn_CallServices_Click(object sender, EventArgs e)
		{
			int customerId = CurrentUser.CurrentCustomer.MaKH;

			string sql = $"INSERT INTO HoaDon (NgayLap, MaKH, MaNhanVien) VALUES (GETDATE(), {customerId}, NULL); SELECT SCOPE_IDENTITY()";
			int mahd = (int)db.getDecimal(sql); // Fix: getDecimal returns decimal, cast to int
			sql = "INSERT INTO ChiTietDichVu (MaHD, MaDichVu, SoLuong, DonGia, ThanhTien) VALUES";

			foreach (Control productCard in flowLayoutPanel.Controls)
			{
				// Lấy mã dịch vụ từ label ẩn
				Label lblMaDichVu = productCard.Controls
					.OfType<Label>()
					.FirstOrDefault(l => l.Visible == false);

				if (lblMaDichVu == null) continue;

				foreach (Control child in productCard.Controls)
				{
					// Tìm TableLayoutPanel chứa các control con
					if (child is TableLayoutPanel controls)
					{
						foreach (Control c in controls.Controls)
						{
							if (c is NumericUpDown num && num.Value > 0)
							{
								string maDichVu = ((Label)controls.Controls[0]).Text; // Lấy mã dịch vụ từ label
								decimal gia = Convert.ToDecimal(((Label)controls.Controls[1]).Text.Replace("đ", "").Replace(",", ""));
								sql += $"({mahd},{lblMaDichVu.Text}, {num.Value}, {gia},{num.Value * gia}),";
							}
						}
					}
				}
			}
			if (sql.EndsWith(","))
			{
				sql = sql.TrimEnd(',') + ";"; // Loại bỏ dấu phẩy cuối cùng và thêm dấu chấm phẩy
				db.updateToDataBase(sql);
				MessageBox.Show("Đã gọi dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show("Không có dịch vụ nào được chọn để gọi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
	}
}
