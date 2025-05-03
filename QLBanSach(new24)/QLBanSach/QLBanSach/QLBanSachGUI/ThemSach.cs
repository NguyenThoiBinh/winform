using QLBanSachBLL;
using QLBanSachDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBanSachGUI
{
    public partial class frmThemSach : Form
    {
        public frmThemSach()
        {
            InitializeComponent();
        }



        private void frmThemSach_Load(object sender, EventArgs e)
        {
            cbDonViTinh.DataSource = SachBLL.DS_DonViTinh();
            
            cbKM.DataSource = SachBLL.DS_KhuyenMai();
            
            cbTheLoai.DataSource = SachBLL.DS_TheLoai();
            
            cbNCC.DataSource = SachBLL.DS_NCC();
            cbNCC.DisplayMember = "TenNCC";
            cbNCC.ValueMember = "MaNCC";
            
            cbTacGia.DataSource =SachBLL.DS_TacGia();
            
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            
            SachBLL sachBLL = new SachBLL();
            List<SachDTO> list = new List<SachDTO>();
            int s = sachBLL.DS_Sach().Count()+20;
            

            SachDTO sach = new SachDTO()
            {
                MaSach = ("S"+s),
                TenSach = txtTenSach.Text,
                TacGia = cbTacGia.SelectedValue.ToString(),
                TheLoai = cbTheLoai.SelectedValue.ToString(),
                NhaXuatBan = txtNXB.Text,
                GiaNhap = decimal.Parse(txtGiaNhap.Text),
                GiaBan = decimal.Parse(txtGiaBan.Text),
                SoLuong = (int)nupSoLuong.Value,
                DonViTinh = cbDonViTinh.SelectedValue.ToString(),
                MaNhaCungCap = cbNCC.SelectedValue.ToString(),
                HinhAnh = txtHinhAnh.Text,
                KhuyenMai = float.Parse(cbKM.SelectedValue.ToString()),
                TrangThaiBan = "Còn Bán"
            };

            bool themThanhCong = SachBLL.ThemSach(sach);

            if (themThanhCong) { 
                MessageBox.Show("Thêm sách thành công!");
                this.Close();
                   

                
            }
                
            else
                MessageBox.Show("Thêm sách thất bại!");
        }
    }
}
