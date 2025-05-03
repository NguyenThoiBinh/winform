using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBanSachDTO;
using QLBanSachDAL;
namespace QLBanSachBLL
{
    public class TaiKhoanBLL
    {
        TKAccess tkAccess = new TKAccess();
        public string CheckLogic(TK taikhoan)
        {
            if (string.IsNullOrWhiteSpace(taikhoan.UserName))
                return "required_taikhoan";
            if (string.IsNullOrWhiteSpace(taikhoan.PassWord))
                return "required_password";

            string info = tkAccess.CheckLogic(taikhoan);
<<<<<<< HEAD
            if (info == "fail")
                return "Tài khoản hoặc mật khẩu không chính xác!";
            return info;


        }
        public string LayMaNV(string username)
        {
            return TKAccess.LayMaNV(username);   // ✅ đúng
        }

        public string LayTenNV(string username)
        {
            return TKAccess.LayTenNV(username);  // ✅ đúng
        }
        public string LayRole(string username)
        {
            return TKAccess.LayRole(username);
        }
=======
            return info;
        }

>>>>>>> cuong/master
    }
}
