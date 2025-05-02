using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBanSachDTO;

namespace QLBanSachDAL
{
    public class NhanVienDAL
    {
        public static List<NhanVienDTO> LayDSNhanVien()
        {
            List<NhanVienDTO> ds = new List<NhanVienDTO>();
            SqlConnection conn = DataProvider.KetNoi();
            string sql = "SELECT * FROM NhanVien";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ds.Add(new NhanVienDTO
                {
                    MaNV = reader["MaNV"].ToString(),
                    TenNV = reader["TenNV"].ToString(),
                    GioiTinh = reader["GioiTinh"].ToString(),
                    SDT = reader["SDT"].ToString(),
                    Luong = Convert.ToDecimal(reader["Luong"]),
                    UserName = reader["UserName"].ToString(),
                    Password = reader["Password"].ToString(),
                    TrangThai = reader["TrangThai"].ToString(),
                    NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                    DiaChi = reader["DiaChi"].ToString()
                });
            }
            conn.Close();
            return ds;
        }

        public static bool ThemNhanVien(NhanVienDTO nv)
        {
            SqlConnection conn = DataProvider.KetNoi();
            string sql = @"INSERT INTO NhanVien 
                           (MaNV, TenNV, GioiTinh, SDT, Luong, UserName, Password, TrangThai, NgaySinh, DiaChi)
                           VALUES (@MaNV, @TenNV, @GioiTinh, @SDT, @Luong, @UserName, @Password, @TrangThai, @NgaySinh, @DiaChi)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaNV", nv.MaNV);
            cmd.Parameters.AddWithValue("@TenNV", nv.TenNV);
            cmd.Parameters.AddWithValue("@GioiTinh", nv.GioiTinh);
            cmd.Parameters.AddWithValue("@SDT", nv.SDT);
            cmd.Parameters.AddWithValue("@Luong", nv.Luong);
            cmd.Parameters.AddWithValue("@UserName", nv.UserName);
            cmd.Parameters.AddWithValue("@Password", nv.Password);
            cmd.Parameters.AddWithValue("@TrangThai", nv.TrangThai);
            cmd.Parameters.AddWithValue("@NgaySinh", nv.NgaySinh);
            cmd.Parameters.AddWithValue("@DiaChi", nv.DiaChi);
            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            conn.Close();
            return rows > 0;
        }

        public static bool SuaNhanVien(NhanVienDTO nv)
        {
            SqlConnection conn = DataProvider.KetNoi();
            string sql = @"UPDATE NhanVien SET 
                           TenNV=@TenNV, GioiTinh=@GioiTinh, SDT=@SDT, Luong=@Luong,
                           UserName=@UserName, Password=@Password, TrangThai=@TrangThai,
                           NgaySinh=@NgaySinh, DiaChi=@DiaChi 
                           WHERE MaNV=@MaNV";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaNV", nv.MaNV);
            cmd.Parameters.AddWithValue("@TenNV", nv.TenNV);
            cmd.Parameters.AddWithValue("@GioiTinh", nv.GioiTinh);
            cmd.Parameters.AddWithValue("@SDT", nv.SDT);
            cmd.Parameters.AddWithValue("@Luong", nv.Luong);
            cmd.Parameters.AddWithValue("@UserName", nv.UserName);
            cmd.Parameters.AddWithValue("@Password", nv.Password);
            cmd.Parameters.AddWithValue("@TrangThai", nv.TrangThai);
            cmd.Parameters.AddWithValue("@NgaySinh", nv.NgaySinh);
            cmd.Parameters.AddWithValue("@DiaChi", nv.DiaChi);
            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            conn.Close();
            return rows > 0;
        }

        public static bool XoaNhanVien(string maNV)
        {
            SqlConnection conn = DataProvider.KetNoi();
            string sql = "DELETE FROM NhanVien WHERE MaNV=@MaNV";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaNV", maNV);
            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            conn.Close();
            return rows > 0;
        }

        public static List<NhanVienDTO> TimKiem(string keyword)
        {
            List<NhanVienDTO> ds = new List<NhanVienDTO>();
            SqlConnection conn = DataProvider.KetNoi();
            string sql = "SELECT * FROM NhanVien WHERE MaNV LIKE @kw OR TenNV LIKE @kw";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ds.Add(new NhanVienDTO
                {
                    MaNV = reader["MaNV"].ToString(),
                    TenNV = reader["TenNV"].ToString(),
                    GioiTinh = reader["GioiTinh"].ToString(),
                    SDT = reader["SDT"].ToString(),
                    Luong = Convert.ToDecimal(reader["Luong"]),
                    UserName = reader["UserName"].ToString(),
                    Password = reader["Password"].ToString(),
                    TrangThai = reader["TrangThai"].ToString(),
                    NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                    DiaChi = reader["DiaChi"].ToString()
                });
            }
            conn.Close();
            return ds;
        }
    }
}
