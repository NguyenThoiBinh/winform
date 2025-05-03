using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
<<<<<<< HEAD
=======
using System.Net;
>>>>>>> cuong/master
using System.Text;
using System.Threading.Tasks;

namespace QLBanSachDAL
{
    
    public  class DataProvider
    {
<<<<<<< HEAD
       static string strKetNoi = "Data Source=WINDOWS-PC;Initial Catalog=QuanLyBanSach;Integrated Security=True;Encrypt=False";
=======
       static string strKetNoi = "Data Source=.;Initial Catalog=QuanLyBanSach;Integrated Security=True;Encrypt=False";
>>>>>>> cuong/master
        public static SqlConnection  KetNoi()
        { 
            SqlConnection conn= new SqlConnection(strKetNoi);
            return conn;
        }
<<<<<<< HEAD
        public static SqlDataReader TruyVan(string truyvan, SqlConnection conn) {
            SqlCommand command = new SqlCommand(truyvan, conn);
            return command.ExecuteReader();
        }
=======
        public static SqlDataReader TruyVan(string truyvan, SqlConnection conn ) {
            
            SqlCommand command = new SqlCommand(truyvan, conn);
            
            return command.ExecuteReader();
        }
        public static int ThucThi(string thucthi, SqlConnection conn, SqlParameter[] parameters)
        {
            using (SqlCommand cmd = new SqlCommand(thucthi, conn))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                return cmd.ExecuteNonQuery();
            }
        }

>>>>>>> cuong/master
    }
    
}
