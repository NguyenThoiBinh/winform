using QLBanSachDAL;
using QLBanSachDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanSachBLL
{
    public class KhachHangBLL
    {
        public static List<KhachHangDTO> LayDSKhachHang()
        {
            return KhachHangDAL.LayDSKhachHang();
        }
        public static bool ThemKhachHang(KhachHangDTO kh)
        {
            return KhachHangDAL.ThemKhachHang(kh);
        }
        public static bool SuaKhachHang(KhachHangDTO kh)
        {
            return KhachHangDAL.SuaKhachHang(kh);
        }
        public static bool XoaKhachHang(string maKH)
        {
            return KhachHangDAL.XoaKhachHang(maKH);
        }
        public static List<KhachHangDTO> TimKiem(string keyword)
        {
            return KhachHangDAL.TimKiem(keyword);
        }
    }
}
