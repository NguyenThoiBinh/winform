using QLBanSachDAL;
using QLBanSachDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanSachBLL
{
    public class SachBLL
    {
        public  List<SachDTO> DS_Sach() { 
        
            SachDAL sachDAL = new SachDAL();

            return sachDAL.Load_DS_Sach();
            
        }
       
        public static List<string> DS_TacGia()
        {
                SachDAL sachDAL = new SachDAL();
                List<string> ds_tacGia = new List<string>();
            ds_tacGia.Add("----");
            foreach (SachDTO sach in sachDAL.Load_DS_Sach())
                    if (!ds_tacGia.Contains(sach.TacGia))
                        ds_tacGia.Add(sach.TacGia);
            
                return ds_tacGia;

        }
        public static List<string> DS_TheLoai()
        {
            SachDAL sachDAL = new SachDAL();
            List<string> ds_TheLoai = new List<string>();
            ds_TheLoai.Add("----");
            foreach (SachDTO sach in sachDAL.Load_DS_Sach())
                if (!ds_TheLoai.Contains(sach.TheLoai))
                    ds_TheLoai.Add(sach.TheLoai);
            
            return ds_TheLoai;

        }
        public static List<string> DS_KhuyenMai()
        {
            SachDAL sachDAL = new SachDAL();
            List<string> ds_KhuyenMai = new List<string>();
            ds_KhuyenMai.Add("----");
            foreach (SachDTO sach in sachDAL.Load_DS_Sach())
                if (!ds_KhuyenMai.Contains(sach.KhuyenMai.ToString()))
                    ds_KhuyenMai.Add(sach.KhuyenMai.ToString());
            
            return ds_KhuyenMai;

        }
        public static List<string> DS_DonViTinh()
        {
            SachDAL sachDAL = new SachDAL();
            
            List<string> ds_DonViTinh = new List<string>();
            ds_DonViTinh.Add("----");
            foreach (SachDTO sach in sachDAL.Load_DS_Sach())
                if (!ds_DonViTinh.Contains(sach.DonViTinh))
                    ds_DonViTinh.Add(sach.DonViTinh);
           
            return ds_DonViTinh;

        }
        public static List<string> DS_MaNCC()
        {
            SachDAL sachDAL = new SachDAL();

            List<string> ds_MaNCC = new List<string>();
            ds_MaNCC.Add("----");
            foreach (SachDTO sach in sachDAL.Load_DS_Sach())
                if (!ds_MaNCC.Contains(sach.MaNhaCungCap))
                    ds_MaNCC.Add(sach.MaNhaCungCap);

            return ds_MaNCC;

        }
        public static List<string> DS_TrangThai()
        {
            SachDAL sachDAL = new SachDAL();
            
            List<string> ds_TrangThai = new List<string>();
            ds_TrangThai.Add("----");
            foreach (SachDTO sach in sachDAL.Load_DS_Sach())
                if (!ds_TrangThai.Contains(sach.TrangThaiBan))
                    ds_TrangThai.Add(sach.TrangThaiBan);
            
            return ds_TrangThai;

        }
        public static List<SachDTO> Tim_DS_sach(string a)
        {
            SachDAL sachDAL=new SachDAL();  
            return sachDAL.Load_DS_Sach(a);
        }
        public static List<NhaCungCapDTO> DS_NCC()
        {
            return NhaCungCapDAL.DS_NCC();
        }
        
       public static bool ThemSach(SachDTO sach)
       {
                int result = SachDAL.ThemSach(sach);
                return result > 0;
       }
        public static bool XoaSach(SachDTO sach)
        {
            int result =SachDAL.XoaSach(sach);
            return result > 0;
        }
        public static bool SuaSach(SachDTO sach)
        {
            int result = SachDAL.SuaSach(sach);
            return result > 0;
        }


    }
}
