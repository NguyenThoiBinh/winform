using QLBanSachDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanSachDAL
{
    public class SachDAL
    {
       public  List<SachDTO> Load_DS_Sach() {
            List<SachDTO> ds_sach = new List<SachDTO>();
            SqlConnection conn = DataProvider.KetNoi();
            conn.Open();
            
            string select_DS = "select * from Sach";
            SqlDataReader dr = DataProvider.TruyVan(select_DS, conn);
            
            while (dr.Read()) {
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
                sach.KhuyenMai = float.Parse( dr["KhuyenMai"].ToString());
                sach.TrangThaiBan = dr["TrangThaiBan"].ToString() ;
                ds_sach.Add(sach);

            }
            dr.Close();
            conn.Close();
            return ds_sach;

        }
    }
}
