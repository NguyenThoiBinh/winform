using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanSachDAL
{
    
    public  class DataProvider
    {
       static string strKetNoi = "Data Source=WINDOWS-PC;Initial Catalog=QuanLyBanSach;Integrated Security=True;Encrypt=False";
        public static SqlConnection  KetNoi()
        { 
            SqlConnection conn= new SqlConnection(strKetNoi);
            return conn;
        }
        public static SqlDataReader TruyVan(string truyvan, SqlConnection conn) {
            SqlCommand command = new SqlCommand(truyvan, conn);
            return command.ExecuteReader();
        }
    }
    
}
