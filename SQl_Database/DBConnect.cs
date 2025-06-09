using System;
using System.Data;
using System.Data.SqlClient;
namespace SQL_Database
{
	public class DBConnect
	{
		private SqlConnection _conn;
		private string _strConnect, _strServerName, _strDBName, _strUserID, _strPassword;
		private DataSet _dset;

		public DataSet Dset
		{
			get { return _dset; }
			set { _dset = value; }
		}
		public SqlConnection conn
		{
			get { return _conn; }
			set { _conn = value; }
		}
		public string strConnect
		{
			get { return _strConnect; }
			set { _strConnect = value; }
		}
		public string strServerName
		{
			get { return _strServerName; }
			set { _strServerName = value; }
		}
		public string strDBName
		{
			get { return _strDBName; }
			set { _strDBName = value; }
		}
		public string strUserID
		{
			get { return _strUserID; }
			set { _strUserID = value; }
		}
		public string strPassword
		{
			get { return _strPassword; }
			set { _strPassword = value; }
		}
		public DBConnect(string strDBName)
		{
			strServerName = "localhost";
			this.strDBName = strDBName;
			//Dùng với quyền của của Windows
			strConnect = @"Data Source=" + strServerName + ";Initial Catalog=" + strDBName +
			";Integrated Security=true";
			//Dùng với quyền của SQL Server
			//strUserID = "";
			//strPassword = "";
			//strConnect = @"Data Source=" + strServerName + ";Initial Catalog=" + strDBName + ";User ID=" + strUserID + ";Password=" + strPassword;
			conn = new SqlConnection(strConnect); //Khởi tạo đối tượng kết nối đến CSDL
			Dset = new DataSet(strConnect);
		}
		public DBConnect(string pServerName, string pDBName)
		{ //Dùng với quyền của của Windows
			strConnect = @"Data Source=" + pServerName + ";Initial Catalog=" + pDBName +
		";Integrated Security=true";
			conn = new SqlConnection(strConnect); //Khởi tạo đối tượng kết nối đến CSDL
			Dset = new DataSet(strConnect);
		}
		public DBConnect(string pServerName, string pDBName, string pUserID, string pPassword)
		{ //Dùng với quyền của SQL Server
			strServerName = pServerName;
			strDBName = pDBName;
			strUserID = pUserID;
			strPassword = pPassword;
			strConnect = @"Data Source=" + strServerName + ";Initial Catalog=" + strDBName +
			";User ID=" + strUserID + ";Password=" + strPassword;
			conn = new SqlConnection(strConnect); //Khởi tạo đối tượng kết nối đến CSDL
			Dset = new DataSet(strConnect);
		}
		public void openConnect()
		{ //Mở kết nối
			if (conn.State == ConnectionState.Closed)
				conn.Open();
		}
		public void closeConnect()
		{ //Đóng kết nối
			if (conn.State == ConnectionState.Open)
				conn.Close();
		}
		public void disposeConnect()
		{ //Hủy đối tượng kết nối
			if (conn.State == ConnectionState.Open)
				conn.Close();
			conn.Dispose(); //Giải phóng vùng nhớ đã cấp phát cho conn
		}
		public void updateToDataBase(string strSQL)
		{ //Cho phép cập nhật CSDL với các thao tác gồm: Thêm, Xóa, Sửa
			openConnect(); //Mở kết nối
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = conn;
			cmd.CommandText = strSQL; //Câu truy vấn đưa vào
			cmd.ExecuteNonQuery(); //Thực thi
			closeConnect(); //Đóng kết nối
		}
		public int getCount(string strSQL)
		{
			openConnect(); //Mở kết nối
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = conn;
			cmd.CommandText = strSQL; //Câu truy vấn đưa vào
			int count = (int)cmd.ExecuteScalar(); //Thực thi
			closeConnect(); //Đóng kết nối
			return count;
		}
		public int getInt(string strSQL)
		{
			openConnect(); //Mở kết nối
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = conn;
			cmd.CommandText = strSQL; //Câu truy vấn đưa vào
			int count = (int)cmd.ExecuteScalar(); //Thực thi
			closeConnect(); //Đóng kết nối
			return count;
		}
		public decimal getDecimal(string strSQL)
		{
			openConnect(); //Mở kết nối
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = conn;
			cmd.CommandText = strSQL; //Câu truy vấn đưa vào
			decimal count = (decimal)cmd.ExecuteScalar(); //Thực thi
			closeConnect(); //Đóng kết nối
			return count;
		}
		public string getString(string strSQL)
		{
			openConnect(); //Mở kết nối
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = conn;
			cmd.CommandText = strSQL; //Câu truy vấn đưa vào
			object result = cmd.ExecuteScalar(); // Thực thi
			closeConnect(); // Đóng kết nối

			if (result == DBNull.Value)
			{
				return null; // Trả về null nếu kết quả là DBNull
			}
			else
			{
				return (string)result; // Trả về kết quả nếu không phải là DBNull
			}
		}
		public bool checkExist(string strSQL)
		{
			return getCount(strSQL) > 0 ? true : false;
		}

		public SqlDataAdapter getDataAdapter(string strSQL, string tableName)
		{
			openConnect();
			SqlDataAdapter ada = new SqlDataAdapter(strSQL, conn);
			ada.Fill(Dset, tableName);
			closeConnect();
			return ada;
		}
		public DataTable getDataTable(string strSQL, string tableName)
		{
			openConnect();
			SqlDataAdapter ada = new SqlDataAdapter(strSQL, conn);
			ada.Fill(Dset, tableName);
			closeConnect();
			return Dset.Tables[tableName];
		}
		public DataTable getDataTable(string strSQL, string tableName, params string[] keyName)
		{
			openConnect();
			SqlDataAdapter ada = new SqlDataAdapter(strSQL, conn);
			ada.Fill(Dset, tableName);
			int n = keyName.Length;
			// Tao khoa chinh 
			DataColumn[] primaryKey = new DataColumn[n];
			for (int i = 0; i < n; i++)
			{
				primaryKey[i] = Dset.Tables[tableName].Columns[keyName[i]];
			}
			Dset.Tables[tableName].PrimaryKey = primaryKey;
			closeConnect();
			return Dset.Tables[tableName];
		}
		public decimal GetTotalAmount()
		{
			decimal totalAmount = 0;
			string query = "SELECT SUM(dongia * soluong) AS tongtien FROM CHITIETPHIEUNHAP";

			openConnect();
			SqlCommand command = new SqlCommand(query, conn);
			totalAmount = (decimal)command.ExecuteScalar();
			closeConnect(); // Ensure the connection is closed

			return totalAmount;
		}
	}
}
