using Microsoft.SqlServer.Server;
using QLBanSachDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace QLBanSachDAL
{
    public class SachDAL
    {
        public List<SachDTO> Load_DS_Sach()
        {
            List<SachDTO> ds_sach = new List<SachDTO>();
            SqlConnection conn = DataProvider.KetNoi();
            conn.Open();
            
            string select_DS = "select * from Sach";
            SqlDataReader dr = DataProvider.TruyVan(select_DS, conn);

            while (dr.Read())
            {
                SachDTO sach = new SachDTO();
                sach.MaSach = dr["MaSach"].ToString();
                sach.TenSach = dr["TenSach"].ToString();
                sach.TacGia = dr["TacGia"].ToString();
                sach.TheLoai = dr["TheLoai"].ToString();
                sach.NhaXuatBan = dr["NhaXuatBan"].ToString();
                sach.GiaNhap = decimal.Parse(dr["GiaNhap"].ToString());
                sach.GiaBan = decimal.Parse(dr["GiaBan"].ToString());
                sach.SoLuong = int.Parse(dr["SoLuong"].ToString());
                sach.DonViTinh = dr["DonViTinh"].ToString();
                sach.MaNhaCungCap = dr["MaNhaCungCap"].ToString();
                sach.HinhAnh = dr["HinhAnh"].ToString();
                sach.KhuyenMai = float.Parse(dr["KhuyenMai"].ToString());
                sach.TrangThaiBan = dr["TrangThaiBan"].ToString();
                ds_sach.Add(sach);

            }
            dr.Close();
            conn.Close();
            return ds_sach;

        }
        public  List<SachDTO> Load_DS_Sach(string a)
        {
            List<SachDTO> ds_sach = new List<SachDTO>();
            SqlConnection conn = DataProvider.KetNoi();
            conn.Open();

            string select_DS = "select * from Sach where MaSach like @a or" +
                " TenSach like @a or" +
                " TacGia like @a or" +
                " TheLoai like @a or" +
                " NhaXuatban like @a or" +
                " GiaNhap like @a or" +
                " GiaBan like @a or" +
                " SoLuong like @a or" +
                " DonViTinh like @a or" +
                " MaNhaCungCap like @a or" +
                " HinhAnh like @a or" +
                " KhuyenMai like @a or" +
                " TrangThaiBan like @a";
            SqlCommand cmd = new SqlCommand(select_DS, conn);
            cmd.Parameters.AddWithValue("@a", "%" + a + "%");


            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                SachDTO sach = new SachDTO();
                sach.MaSach = dr["MaSach"].ToString();
                sach.TenSach = dr["TenSach"].ToString();
                sach.TacGia = dr["TacGia"].ToString();
                sach.TheLoai = dr["TheLoai"].ToString();
                sach.NhaXuatBan = dr["NhaXuatBan"].ToString();
                sach.GiaNhap = decimal.Parse(dr["GiaNhap"].ToString());
                sach.GiaBan = decimal.Parse(dr["GiaBan"].ToString());
                sach.SoLuong = int.Parse(dr["SoLuong"].ToString());
                sach.DonViTinh = dr["DonViTinh"].ToString();
                sach.MaNhaCungCap = dr["MaNhaCungCap"].ToString();
                sach.HinhAnh = dr["HinhAnh"].ToString();
                sach.KhuyenMai = float.Parse(dr["KhuyenMai"].ToString());
                sach.TrangThaiBan = dr["TrangThaiBan"].ToString();
                ds_sach.Add(sach);

            }
            dr.Close();
            conn.Close();
            return ds_sach;

        }
         public static int ThemSach(SachDTO sach)
    {
        using (SqlConnection conn = DataProvider.KetNoi())
        {
            string sql = @"INSERT INTO Sach 
                (MaSach, TenSach, TacGia, TheLoai, NhaXuatBan, GiaNhap, GiaBan, SoLuong, DonViTinh, MaNhaCungCap, HinhAnh, KhuyenMai, TrangThaiBan)
                VALUES 
                (@MaSach, @TenSach, @TacGia, @TheLoai, @NhaXuatBan, @GiaNhap, @GiaBan, @SoLuong, @DonViTinh, @MaNhaCungCap, @HinhAnh, @KhuyenMai, @TrangThaiBan)";
            
            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@MaSach", sach.MaSach);
            cmd.Parameters.AddWithValue("@TenSach", sach.TenSach);
            cmd.Parameters.AddWithValue("@TacGia", sach.TacGia);
            cmd.Parameters.AddWithValue("@TheLoai", sach.TheLoai);
            cmd.Parameters.AddWithValue("@NhaXuatBan", sach.NhaXuatBan);
            cmd.Parameters.AddWithValue("@GiaNhap", sach.GiaNhap);
            cmd.Parameters.AddWithValue("@GiaBan", sach.GiaBan);
            cmd.Parameters.AddWithValue("@SoLuong", sach.SoLuong);
            cmd.Parameters.AddWithValue("@DonViTinh", sach.DonViTinh);
            cmd.Parameters.AddWithValue("@MaNhaCungCap", sach.MaNhaCungCap);
            cmd.Parameters.AddWithValue("@HinhAnh", sach.HinhAnh);
            cmd.Parameters.AddWithValue("@KhuyenMai", sach.KhuyenMai);
            cmd.Parameters.AddWithValue("@TrangThaiBan", sach.TrangThaiBan);

            conn.Open();
            return cmd.ExecuteNonQuery(); 
        }
        
    }
        public static int XoaSach(SachDTO sach)
        {
            string delete = @"DELETE FROM Sach WHERE MaSach = @MaSach";
            SqlConnection conn = DataProvider.KetNoi();
            conn.Open();

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaSach", sach.MaSach)
            };

            int dong = DataProvider.ThucThi(delete, conn, parameters);

            conn.Close();
            return dong;


        }
        public static int SuaSach(SachDTO sach) {
            string update = @"update Sach set TenSach=@TenSach,
TacGia=@TacGia,TheLoai=@TheLoai,NhaXuatBan=@NhaXuatBan,GiaNhap=@GiaNhap,GiaBan=@GiaBan,
SoLuong=@SoLuong,DonViTinh=@DonViTinh,MaNhaCungCap=@MaNhaCungCap,HinhAnh=@HinhAnh,KhuyenMai=@KhuyenMai,
TrangThaiBan=@TrangThaiBan where MaSach=@MaSach" ;
            SqlConnection conn = DataProvider.KetNoi();
            conn.Open();
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@MaSach",sach.MaSach),
                new SqlParameter ("@TenSach",sach.TenSach),
                new SqlParameter ("@TacGia",sach.TacGia),
                new SqlParameter ("@TheLoai",sach.TheLoai),
                new SqlParameter ("@NhaXuatBan",sach.NhaXuatBan),
                new SqlParameter ("@GiaNhap",sach.GiaNhap),
                new SqlParameter ("@GiaBan",sach.GiaBan),
                new SqlParameter ("@SoLuong",sach.SoLuong),
                new SqlParameter ("@DonViTinh",sach.DonViTinh),
                new SqlParameter ("@MaNhaCungCap",sach.MaNhaCungCap),
                new SqlParameter ("@HinhAnh",sach.HinhAnh),
                new SqlParameter ("@KhuyenMai",sach.KhuyenMai),
                new SqlParameter ("@TrangThaiBan",sach.TrangThaiBan)

            };
            int dong   =DataProvider.ThucThi(update, conn,sqlParameters);
            conn.Close();
            return dong;

        }
    }
}
