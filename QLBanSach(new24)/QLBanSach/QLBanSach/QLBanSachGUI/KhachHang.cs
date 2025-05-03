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

    public partial class ucKhachHang : UserControl
    {
        public ucKhachHang()
        {
            InitializeComponent();
            LoadDSKhachHang();
            LoadTrangThaiComboBox();
        }
        private void ucKhachHang_Load(object sender, EventArgs e)
        {
            // Có thể để trống nếu chưa có xử lý gì
        }

        private void LoadDSKhachHang()
        {
            dgvKhachHang.DataSource = KhachHangBLL.LayDSKhachHang();
            dgvKhachHang.ClearSelection();
        }

        private void LoadTrangThaiComboBox()
        {
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("Hoạt động");
            cboTrangThai.Items.Add("Ngưng hoạt động");
            cboTrangThai.SelectedIndex = 0; // Mặc định là "Hoạt động"
        }

        private void LamMoi()
        {
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtTim.Clear();
            cboTrangThai.SelectedIndex = 0;
            dgvKhachHang.ClearSelection();
            LoadDSKhachHang();
        }

        private bool KiemTraHopLe()
        {
            if (string.IsNullOrWhiteSpace(txtMaKH.Text) || string.IsNullOrWhiteSpace(txtTenKH.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ mã và tên khách hàng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private KhachHangDTO TaoKhachHangTuForm()
        {
            return new KhachHangDTO
            {
                MaKH = txtMaKH.Text.Trim(),
                TenKH = txtTenKH.Text.Trim(),
                SDT = txtSDT.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim(),
                TrangThai = cboTrangThai.Text.Trim()
            };
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraHopLe()) return;

            KhachHangDTO kh = TaoKhachHangTuForm();

            if (KhachHangBLL.ThemKhachHang(kh))
            {
                MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoi();
            }
            else
            {
                MessageBox.Show("Thêm thất bại! Mã khách hàng đã tồn tại?", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!KiemTraHopLe()) return;

            KhachHangDTO kh = TaoKhachHangTuForm();

            if (KhachHangBLL.SuaKhachHang(kh))
            {
                MessageBox.Show("Sửa thông tin khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoi();
            }
            else
            {
                MessageBox.Show("Sửa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKH.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa khách hàng này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (KhachHangBLL.XoaKhachHang(txtMaKH.Text.Trim()))
                {
                    MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LamMoi();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTim.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<KhachHangDTO> ds = KhachHangBLL.TimKiem(keyword);
            dgvKhachHang.DataSource = ds;
            dgvKhachHang.ClearSelection();

            if (ds.Count == 0)
            {
                MessageBox.Show("Không tìm thấy khách hàng nào phù hợp!", "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        
        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];
                txtMaKH.Text = row.Cells["MaKH"].Value?.ToString();
                txtTenKH.Text = row.Cells["TenKH"].Value?.ToString();
                txtSDT.Text = row.Cells["SDT"].Value?.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString();
                cboTrangThai.Text = row.Cells["TrangThai"].Value?.ToString();
            }
        }

        private void btnLamMoi_Click_1(object sender, EventArgs e)
        {

        }

        
    }
}