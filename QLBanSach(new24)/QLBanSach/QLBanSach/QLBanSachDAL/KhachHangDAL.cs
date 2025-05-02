using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBanSachDTO;


namespace QLBanSachDAL
{
    public class KhachHangDAL
    {
        public static List<KhachHangDTO> LayDSKhachHang()
        {
            List<KhachHangDTO> ds = new List<KhachHangDTO>();
            SqlConnection conn = DataProvider.KetNoi();
            string sql = "SELECT * FROM KhachHang";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ds.Add(new KhachHangDTO
                {
                    MaKH = reader["MaKH"].ToString(),
                    TenKH = reader["TenKH"].ToString(),
                    SDT = reader["SDT"].ToString(),
                    DiaChi = reader["DiaChi"].ToString(),
                    TrangThai = reader["TrangThai"].ToString()
                });
            }
            conn.Close();
            return ds;
        }

        public static bool ThemKhachHang(KhachHangDTO kh)
        {
            SqlConnection conn = DataProvider.KetNoi();
            string sql = "INSERT INTO KhachHang (MaKH, TenKH, SDT, DiaChi, TrangThai) VALUES (@MaKH, @TenKH, @SDT, @DiaChi, @TrangThai)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaKH", kh.MaKH);
            cmd.Parameters.AddWithValue("@TenKH", kh.TenKH);
            cmd.Parameters.AddWithValue("@SDT", kh.SDT);
            cmd.Parameters.AddWithValue("@DiaChi", kh.DiaChi);
            cmd.Parameters.AddWithValue("@TrangThai", kh.TrangThai);
            conn.Open();
            int kq = cmd.ExecuteNonQuery();
            conn.Close();
            return kq > 0;
        }

        public static bool SuaKhachHang(KhachHangDTO kh)
        {
            SqlConnection conn = DataProvider.KetNoi();
            string sql = "UPDATE KhachHang SET TenKH = @TenKH, SDT = @SDT, DiaChi = @DiaChi, TrangThai = @TrangThai WHERE MaKH = @MaKH";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaKH", kh.MaKH);
            cmd.Parameters.AddWithValue("@TenKH", kh.TenKH);
            cmd.Parameters.AddWithValue("@SDT", kh.SDT);
            cmd.Parameters.AddWithValue("@DiaChi", kh.DiaChi);
            cmd.Parameters.AddWithValue("@TrangThai", kh.TrangThai);
            conn.Open();
            int kq = cmd.ExecuteNonQuery();
            conn.Close();
            return kq > 0;
        }

        public static bool XoaKhachHang(string maKH)
        {
            SqlConnection conn = DataProvider.KetNoi();
            string sql = "DELETE FROM KhachHang WHERE MaKH = @MaKH";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaKH", maKH);
            conn.Open();
            int kq = cmd.ExecuteNonQuery();
            conn.Close();
            return kq > 0;
        }

        public static List<KhachHangDTO> TimKiem(string keyword)
        {
            List<KhachHangDTO> ds = new List<KhachHangDTO>();
            SqlConnection conn = DataProvider.KetNoi();
            string sql = "SELECT * FROM KhachHang WHERE MaKH LIKE @kw OR TenKH LIKE @kw";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ds.Add(new KhachHangDTO
                {
                    MaKH = reader["MaKH"].ToString(),
                    TenKH = reader["TenKH"].ToString(),
                    SDT = reader["SDT"].ToString(),
                    DiaChi = reader["DiaChi"].ToString(),
                    TrangThai = reader["TrangThai"].ToString()
                });
            }
            conn.Close();
            return ds;
        }
    }
}
