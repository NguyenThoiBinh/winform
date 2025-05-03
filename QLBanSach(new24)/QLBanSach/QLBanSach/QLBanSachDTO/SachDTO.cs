using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanSachDTO
{
    public class SachDTO
    {
        public string MaSach { get; set; }
        public string TenSach { get; set; }
        public string TacGia { get; set; }
        public string TheLoai { get; set; }
        public string NhaXuatBan { get; set; }
        public decimal GiaNhap { get; set; }
        public decimal GiaBan { get; set; }
        public int SoLuong { get; set; }
        public string DonViTinh { get; set; }
        public string MaNhaCungCap { get; set; }
        public string HinhAnh { get; set; }
        public float KhuyenMai { get; set; }
        public string TrangThaiBan { get; set; }
    }
}
