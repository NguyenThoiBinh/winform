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
            return info;
        }

    }
}
