using QLBanSachDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QLBanSachDAL
{
    public class SqlConnectionData
    {
        //Tạo chuỗi kết nối CSDL
        public static SqlConnection Connect()
        {
<<<<<<< HEAD
            string Strconn = @"Data Source=WINDOWS-PC;Initial Catalog=QuanLyBanSach;Integrated Security=True;Encrypt=False";
=======
            string Strconn = @"Data Source=.;Initial Catalog=QuanLyBanSach;Integrated Security=True;Encrypt=False";
>>>>>>> cuong/master
            SqlConnection conn = new SqlConnection(Strconn);//Khởi tạo Connect
            return conn;
        }
    }
    
    public class DataBase
    {
        public static string CheckLogicDTO(TK taikhoan)
        {
            string result = "fail";
            SqlConnection conn = SqlConnectionData.Connect();
            conn.Open();
            SqlCommand command = new SqlCommand("proc_logic", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@UserName", taikhoan.UserName.Trim());
            command.Parameters.AddWithValue("@PassWord", taikhoan.PassWord.Trim());

            object value = command.ExecuteScalar();
            if (value != null)
                result = value.ToString();

            conn.Close();
            return result;
        }
    }
}
