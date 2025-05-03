using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Data.SqlClient;
=======
>>>>>>> cuong/master
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBanSachDTO;

namespace QLBanSachDAL
{
    public class TKAccess :DataBase
    {
        public string CheckLogic(TK taikhoan)
        {
            string info = CheckLogicDTO(taikhoan);
            return info;
        }
<<<<<<< HEAD
        public static string LayMaNV(string username)
        {
            string maNV = null;
            using (SqlConnection conn = DataProvider.KetNoi())
            {
                string sql = "SELECT MaNV FROM NhanVien WHERE UserName = @username";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@username", username);
                conn.Open();
                var result = cmd.ExecuteScalar();
                if (result != null)
                    maNV = result.ToString();
            }
            return maNV;
        }

        public static string LayTenNV(string username)
        {
            string tenNV = null;
            using (SqlConnection conn = DataProvider.KetNoi())
            {
                string sql = "SELECT TenNV FROM NhanVien WHERE UserName = @username";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@username", username);
                conn.Open();
                var result = cmd.ExecuteScalar();
                if (result != null)
                    tenNV = result.ToString();
            }
            return tenNV;
        }
        public static string LayRole(string username)
        {
            string role = "";
            SqlConnection conn = DataProvider.KetNoi();
            string sql = "SELECT Role FROM NhanVien WHERE UserName = @username";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@username", username);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                role = reader["Role"].ToString();
            }
            conn.Close();
            return role;
        }

=======
>>>>>>> cuong/master
    }
}
