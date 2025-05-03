using QLBanSachDAL;
using QLBanSachDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanSachBLL
{
    public class SachBLL
    {
        public List<SachDTO> DS_Sach() { 
        
            SachDAL sachDAL = new SachDAL();

            return sachDAL.Load_DS_Sach();
            
        }

    }
}
