using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBanSachBLL;
using QLBanSachDTO;

namespace QLBanSachGUI
{
    public partial class ucNhanVien : UserControl
    {
        public ucNhanVien()
        {
            InitializeComponent();
            LoadDSNhanVien();
            LoadComboBoxGioiTinh();

        }
        private void LoadDSNhanVien()
        {
            dgvNhanVien.DataSource = NhanVienBLL.LayDSNhanVien();
        }

        private void LamMoi()
        {
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtSDT.Clear();
            txtLuong.Clear();
            txtUser.Clear();
            txtPass.Clear();
            txtDiaChi.Clear();
            txtTim.Clear();
            cboGioiTinh.SelectedIndex = 0;
            dtpNgaySinh.Value = DateTime.Today;
            dgvNhanVien.ClearSelection();
            LoadDSNhanVien(); // Hiển thị lại toàn bộ danh sách
        }
        private bool KiemTraHopLe(out decimal luong)
        {
            luong = 0;
            if (string.IsNullOrWhiteSpace(txtMaNV.Text) ||
                string.IsNullOrWhiteSpace(txtTenNV.Text) ||
                string.IsNullOrWhiteSpace(txtSDT.Text) ||
                string.IsNullOrWhiteSpace(txtLuong.Text) ||
                string.IsNullOrWhiteSpace(txtUser.Text) ||
                string.IsNullOrWhiteSpace(txtPass.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChi.Text) ||
                cboGioiTinh.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(txtLuong.Text, out luong))
            {
                MessageBox.Show("Lương phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void LoadComboBoxGioiTinh()
        {
            cboGioiTinh.Items.Clear();
            cboGioiTinh.Items.Add("Nam");
            cboGioiTinh.Items.Add("Nữ");
            cboGioiTinh.SelectedIndex = 0; // mặc định là "Nam"
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraHopLe(out decimal luong)) return;

            foreach (DataGridViewRow row in dgvNhanVien.Rows)
            {
                if (row.Cells["MaNV"].Value?.ToString() == txtMaNV.Text.Trim())
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            NhanVienDTO nv = TaoNhanVienTuForm(luong);

            if (NhanVienBLL.ThemNhanVien(nv))
            {
                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDSNhanVien();
                LamMoi();
            }
            else
            {
                MessageBox.Show("Thêm nhân viên thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private NhanVienDTO TaoNhanVienTuForm(decimal luong)
        {
            return new NhanVienDTO
            {
                MaNV = txtMaNV.Text.Trim(),
                TenNV = txtTenNV.Text.Trim(),
                GioiTinh = cboGioiTinh.Text,
                SDT = txtSDT.Text.Trim(),
                Luong = luong,
                UserName = txtUser.Text.Trim(),
                Password = txtPass.Text.Trim(),
                TrangThai = "Đang làm",
                NgaySinh = dtpNgaySinh.Value,
                DiaChi = txtDiaChi.Text.Trim()
            };
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!KiemTraHopLe(out decimal luong)) return;

            NhanVienDTO nv = TaoNhanVienTuForm(luong);

            if (NhanVienBLL.SuaNhanVien(nv))
            {
                MessageBox.Show("Sửa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDSNhanVien();
                LamMoi();
            }
            else
            {
                MessageBox.Show("Sửa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc muốn xoá nhân viên này không?", "Xác nhận xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (NhanVienBLL.XoaNhanVien(txtMaNV.Text.Trim()))
                {
                    MessageBox.Show("Đã xoá nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDSNhanVien();
                    LamMoi();
                }
                else
                {
                    MessageBox.Show("Xoá thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];

                txtMaNV.Text = row.Cells["MaNV"].Value?.ToString();
                txtTenNV.Text = row.Cells["TenNV"].Value?.ToString();
                cboGioiTinh.Text = row.Cells["GioiTinh"].Value?.ToString();

                if (DateTime.TryParse(row.Cells["NgaySinh"].Value?.ToString(), out DateTime ngaySinh))
                    dtpNgaySinh.Value = ngaySinh;

                txtSDT.Text = row.Cells["SDT"].Value?.ToString();
                txtLuong.Text = row.Cells["Luong"].Value?.ToString();
                txtUser.Text = row.Cells["UserName"].Value?.ToString();
                txtPass.Text = row.Cells["Password"].Value?.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTim.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<NhanVienDTO> ketQua = NhanVienBLL.TimKiem(keyword);

            if (ketQua.Count == 0)
            {
                MessageBox.Show("Không tìm thấy nhân viên nào phù hợp.", "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvNhanVien.DataSource = null;
            }
            else
            {
                dgvNhanVien.DataSource = ketQua;
            }
        }
    }
}
