using QLBanSachDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanSachDAL
{
    public class NhaCungCapDAL
    {
        public static List<NhaCungCapDTO> DS_NCC()
        {
            List<NhaCungCapDTO> list = new List<NhaCungCapDTO>();
            SqlConnection conn = DataProvider.KetNoi();
            conn.Open();
            string Select = @"select * from NhaCungCap";
            SqlCommand cmd = new SqlCommand(Select, conn);
            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                NhaCungCapDTO nhaCungCapDTO = new NhaCungCapDTO();
                nhaCungCapDTO.MaNCC = dataReader["MaNCC"].ToString();
                nhaCungCapDTO.TenNCC = dataReader["TenNCC"].ToString();
                nhaCungCapDTO.DiaChi = dataReader["DiaChi"].ToString();
                nhaCungCapDTO.SDT = dataReader["SDT"].ToString();
                nhaCungCapDTO.TrangThai = dataReader["TrangThai"].ToString();
                list.Add(nhaCungCapDTO);
            }
            conn.Close();
            return list;
        }
    }
}
