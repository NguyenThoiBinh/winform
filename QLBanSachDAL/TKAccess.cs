using System;
using System.Collections.Generic;
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
    }
}
