using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBanSachDAL;
using QLBanSachDTO;

namespace QLBanSachBLL
{
    public class NhanVienBLL
    {
        public static List<NhanVienDTO> LayDSNhanVien()
        {
            return NhanVienDAL.LayDSNhanVien();
        }

        public static bool ThemNhanVien(NhanVienDTO nv)
        {
            return NhanVienDAL.ThemNhanVien(nv);
        }

        public static bool SuaNhanVien(NhanVienDTO nv)
        {
            return NhanVienDAL.SuaNhanVien(nv);
        }

        public static bool XoaNhanVien(string maNV)
        {
            return NhanVienDAL.XoaNhanVien(maNV);
        }


        public static List<NhanVienDTO> TimKiem(string keyword)
        {
            return NhanVienDAL.TimKiem(keyword);
        }
    }
}
