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
    public partial class ucSach : UserControl
    {
        public ucSach()
        {
            InitializeComponent();
        }
        List<SachDTO> list=new List<SachDTO>();
        
        List<string> listTG = new List<string>();
        private void ucSach_Load(object sender, EventArgs e)
        {
            LayDS_Sach();
            
            cbTacGia.DataSource = SachBLL.DS_TacGia();
            cbTheLoai.DataSource=SachBLL.DS_TheLoai();
            cbKM.DataSource = SachBLL.DS_KhuyenMai();
            cbDonViTinh.DataSource = SachBLL.DS_DonViTinh();
            cbTrangThai.DataSource = SachBLL.DS_TrangThai();
            cbMaNCC.DataSource=SachBLL.DS_MaNCC();
        }

        public void LayDS_Sach()
        {
            SachBLL sach = new SachBLL();
            list = sach.DS_Sach();
            dgvSach.DataSource = list;
            
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            dgvSach.DataSource=SachBLL.Tim_DS_sach(txtTimKiem.Text);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LayDS_Sach();
            Xoafind();


        }

        public void Xoafind()
        {
            txtNhaXuatBan.Clear();
            txtMaSach.Clear();
            txtTenSach.Clear();
            txtTimKiem.Clear();
            txtGiaBan.Clear();
            txtGiaNhap.Clear();
            txtHinhAnh.Clear();
            cbMaNCC.SelectedIndex=0;
            cbKM.SelectedIndex = 0;
            cbDonViTinh.SelectedIndex = 0;
            cbTacGia.SelectedIndex = 0;
            cbTheLoai.SelectedIndex = 0;
            cbTrangThai.SelectedIndex = 0;
            nupSoLuong.Value = 0;
            
                }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemSach themSach = new frmThemSach();
            themSach.Show();
            LayDS_Sach();
            Xoafind();

        }

        private void dgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SachDTO sachDTO = new SachDTO();
            if (e.RowIndex >= 0) {
                DataGridViewRow clickedRow = dgvSach.Rows[e.RowIndex];
                sachDTO =clickedRow.DataBoundItem as SachDTO;

            }
            else
            {
                sachDTO = null;

            }
            if (sachDTO != null) {
                txtMaSach.Text = sachDTO.MaSach;
                txtTenSach.Text=sachDTO.TenSach;
                cbTacGia.SelectedItem = sachDTO.TacGia;
                cbTheLoai.SelectedItem=sachDTO.TheLoai;
                txtNhaXuatBan.Text=sachDTO.NhaXuatBan;
                txtGiaNhap.Text = sachDTO.GiaNhap.ToString();
                txtGiaBan.Text=sachDTO?.GiaBan.ToString();
                nupSoLuong.Value=sachDTO.SoLuong;
                cbDonViTinh.SelectedItem =sachDTO.DonViTinh;
                cbMaNCC.SelectedItem=sachDTO.MaNhaCungCap;
                txtHinhAnh.Text = sachDTO?.HinhAnh;
                cbKM.SelectedItem = sachDTO.KhuyenMai.ToString();

                cbTrangThai.SelectedItem = sachDTO.TrangThaiBan;

            }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvSach.CurrentRow != null)
            {
                SachDTO sachDT0 = new SachDTO();
                sachDT0.MaSach = dgvSach.CurrentRow.Cells["MaSach"].Value?.ToString();
                if (SachBLL.XoaSach(sachDT0))
                {
                    MessageBox.Show("Xóa thành công!!", "Thông báo", MessageBoxButtons.OK);
                    LayDS_Sach();
                    Xoafind();
                }
                else {
                    MessageBox.Show("Xóa không thành công!!", "Thông báo", MessageBoxButtons.OK);
                    LayDS_Sach();
                    Xoafind();
                }
                    
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvSach.CurrentRow != null)
            {
                SachDTO sachDT0 = new SachDTO();
                sachDT0.MaSach = dgvSach.CurrentRow.Cells["MaSach"].Value?.ToString();
                sachDT0.TenSach=txtTenSach.Text;
                sachDT0.TacGia=cbTacGia.SelectedItem?.ToString();
                sachDT0.TheLoai=cbTheLoai.SelectedItem?.ToString();
                sachDT0.NhaXuatBan=txtNhaXuatBan.Text;
                sachDT0.GiaNhap=decimal.Parse(txtGiaNhap.Text.ToString());
                sachDT0.GiaBan = decimal.Parse(txtGiaBan.Text.ToString());
                sachDT0.SoLuong=int.Parse(nupSoLuong.Text.ToString());
                sachDT0.DonViTinh=cbDonViTinh.SelectedItem?.ToString();
                sachDT0.MaNhaCungCap=cbMaNCC.SelectedItem?.ToString();
                sachDT0.HinhAnh=txtHinhAnh.Text.ToString();
                sachDT0.KhuyenMai = float.Parse( cbKM.SelectedItem?.ToString());
                sachDT0.TrangThaiBan=cbTrangThai.SelectedItem?.ToString();
                if (SachBLL.SuaSach(sachDT0))
                {
                    MessageBox.Show("Cập nhật thành công!!", "Thông báo", MessageBoxButtons.OK);
                    LayDS_Sach();
                    Xoafind();
                }
                else
                {
                    MessageBox.Show("Cập nhật không thành công!!", "Thông báo", MessageBoxButtons.OK);
                    LayDS_Sach();
                    Xoafind();
                }

            }
        }
    }
}
