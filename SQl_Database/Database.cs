using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SQl_Database
{
	public class Database
	{
		private string connectionString = "Data Source=localhost;Initial Catalog=Cyber;Integrated Security=True";

		// Hàm mở kết nối
		public SqlConnection GetConnection()
		{
			return new SqlConnection(connectionString);
		}

		// SELECT: Trả về DataTable
		public DataTable GetData(string query)
		{
			using (SqlConnection conn = GetConnection())
			{
				try
				{
					conn.Open();
					SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
					DataTable dt = new DataTable();
					adapter.Fill(dt);
					return dt;
				}
				catch (Exception ex)
				{
					MessageBox.Show("Lỗi truy vấn: " + ex.Message);
					return null;
				}
			}
		}


		// Có tham số: Trả về DataTable
		public DataTable GetData(string query, SqlParameter[] parameters)
		{
			using (SqlConnection conn = GetConnection())
			{
				try
				{
					conn.Open();
					SqlCommand cmd = new SqlCommand(query, conn);
					if (parameters != null)
					{
						cmd.Parameters.AddRange(parameters);
					}
					SqlDataAdapter adapter = new SqlDataAdapter(cmd);
					DataTable dt = new DataTable();
					adapter.Fill(dt);
					return dt;
				}
				catch (Exception ex)
				{
					MessageBox.Show("Lỗi truy vấn: " + ex.Message);
					return null;
				}
			}
		}

		// INSERT, UPDATE, DELETE: Trả về số dòng bị ảnh hưởng
		public int Execute(string query, SqlParameter[] parameters = null)
		{
			using (SqlConnection conn = GetConnection())
			{
				try
				{
					conn.Open();
					SqlCommand cmd = new SqlCommand(query, conn);
					if (parameters != null)
					{
						cmd.Parameters.AddRange(parameters);
					}
					return cmd.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					MessageBox.Show("Lỗi thực thi: " + ex.Message);
					return -1;
				}
			}
		}
	}
}

