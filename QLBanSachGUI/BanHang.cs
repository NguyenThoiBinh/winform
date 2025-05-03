using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBanSachDTO;
using System.Data.SqlClient;
using QLBanSachDAL;

namespace QLBanSachGUI
{
    public partial class ucBanHang : UserControl
    {
        private string currentSoHD = "";
        private DataTable dtChiTietHD = new DataTable();
        private string maNV, tenNV;

        public ucBanHang(string maNV, string tenNV)
        {
            InitializeComponent();
            this.maNV = maNV;
            this.tenNV = tenNV;
        }

        private void ucBanHang_Load(object sender, EventArgs e)
        {
            txtMaNV.Text = maNV;
            txtTenNV.Text = tenNV;  

            currentSoHD = SinhMaHoaDon();
            LoadDanhSachSanPham();
            KhoiTaoBangChiTietHD();

            dgvSanPham.CellDoubleClick += dgvSanPham_CellDoubleClick;
            dgvCTHD.EditingControlShowing += dgvCTHD_EditingControlShowing;
            dgvCTHD.CellValueChanged += dgvCTHD_CellValueChanged;

            cboKhuyenMai.Items.AddRange(new object[] { "0%", "5%", "10%", "15%" });
            cboKhuyenMai.SelectedIndex = 0;
        }

        private void LoadDanhSachSanPham()
        {
            SqlConnection conn = DataProvider.KetNoi();
            string sql = "SELECT MaSach, TenSach, GiaBan FROM Sach";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvSanPham.DataSource = dt;
        }

        private string SinhMaHoaDon()
        {
            SqlConnection conn = DataProvider.KetNoi();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 SoHD FROM HoaDon ORDER BY SoHD DESC", conn);
            object result = cmd.ExecuteScalar();
            conn.Close();

            if (result != null)
            {
                string soCu = result.ToString().Substring(2);
                int soMoi = int.Parse(soCu) + 1;
                return "HD" + soMoi.ToString("D3");
            }
            else
            {
                return "HD001";
            }
        }

        private void KhoiTaoBangChiTietHD()
        {
            dtChiTietHD.Columns.Add("SoHD");
            dtChiTietHD.Columns.Add("MaSach");
            dtChiTietHD.Columns.Add("TenSach");
            dtChiTietHD.Columns.Add("SoLuong", typeof(int));
            dtChiTietHD.Columns.Add("DonGia", typeof(decimal));
            dtChiTietHD.Columns.Add("ThanhTien", typeof(decimal));

            dgvCTHD.DataSource = dtChiTietHD;
        }

        private void dgvSanPham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string maSach = dgvSanPham.Rows[e.RowIndex].Cells["MaSach"].Value.ToString();
                string tenSach = dgvSanPham.Rows[e.RowIndex].Cells["TenSach"].Value.ToString();
                decimal donGia = Convert.ToDecimal(dgvSanPham.Rows[e.RowIndex].Cells["GiaBan"].Value);

                DataRow row = dtChiTietHD.Rows.Cast<DataRow>()
                    .FirstOrDefault(r => r["MaSach"].ToString() == maSach);

                if (row != null)
                {
                    int sl = Convert.ToInt32(row["SoLuong"]) + 1;
                    row["SoLuong"] = sl;
                    row["ThanhTien"] = sl * donGia;
                }
                else
                {
                    DataRow newRow = dtChiTietHD.NewRow();
                    newRow["SoHD"] = currentSoHD;
                    newRow["MaSach"] = maSach;
                    newRow["TenSach"] = tenSach;
                    newRow["SoLuong"] = 1;
                    newRow["DonGia"] = donGia;
                    newRow["ThanhTien"] = donGia;
                    dtChiTietHD.Rows.Add(newRow);
                }
            }
        }

        private void dgvCTHD_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvCTHD.CurrentCell.ColumnIndex == dgvCTHD.Columns["SoLuong"].Index)
            {
                System.Windows.Forms.TextBox tb = e.Control as System.Windows.Forms.TextBox;
                if (tb != null)
                {
                    tb.KeyPress -= SoLuong_KeyPress;
                    tb.KeyPress += SoLuong_KeyPress;
                }
            }
        }

        private void SoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void CapNhatTongThanhTien()
        {
            decimal tong = 0;
            foreach (DataGridViewRow row in dgvCTHD.Rows)
            {
                if (row.IsNewRow) continue;
                if (decimal.TryParse(row.Cells["ThanhTien"].Value?.ToString(), out decimal thanhTien))
                {
                    tong += thanhTien;
                }
            }

            txtThanhTien.Text = tong.ToString("N0");
            CapNhatTongTienSauKhuyenMai();
        }

        private void CapNhatTongTienSauKhuyenMai()
        {
            if (!decimal.TryParse(txtThanhTien.Text, out decimal thanhTien))
                return;

            decimal tyLeKM = 0;
            if (cboKhuyenMai.SelectedItem != null)
            {
                string selected = cboKhuyenMai.SelectedItem.ToString().Replace("%", "");
                decimal.TryParse(selected, out tyLeKM);
                tyLeKM /= 100;
            }

            decimal giam = thanhTien * tyLeKM;
            decimal tongSauKM = thanhTien - giam;

            txtKhuyenMai.Text = giam.ToString("N0");
            txtTongTien.Text = tongSauKM.ToString("N0");

            if (decimal.TryParse(txtTienKhachDua.Text, out decimal tienKhach))
            {
                txtConLai.Text = (tienKhach - tongSauKM).ToString("N0");
            }
        }

        private void cboKhuyenMai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtThanhTien.Text))
            {
                CapNhatTongTienSauKhuyenMai();
            }
        }

        private void btnTongTT_Click(object sender, EventArgs e)
        {
            CapNhatTongThanhTien();
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtTienKhachDua.Text, out decimal tienKhach))
            {
                MessageBox.Show("Vui lòng nhập đúng số tiền khách đưa.");
                txtTienKhachDua.Focus();
                return;
            }

            if (!decimal.TryParse(txtTongTien.Text, out decimal tongTien))
            {
                MessageBox.Show("Tổng tiền không hợp lệ.");
                return;
            }

            decimal tienConLai = tienKhach - tongTien;
            txtConLai.Text = tienConLai.ToString("N0");
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTim.Text.Trim();

            SqlConnection conn = DataProvider.KetNoi();
            string sql = "SELECT MaSach, TenSach, TacGia, TheLoai, NhaXuatBan, GiaBan FROM Sach WHERE " +
                         "MaSach LIKE @kw OR TenSach LIKE @kw OR TacGia LIKE @kw OR TheLoai LIKE @kw OR NhaXuatBan LIKE @kw";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@kw", "%" + keyword + "%");

            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvSanPham.DataSource = dt;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTim.Clear();

            dtChiTietHD.Clear();
            dgvCTHD.DataSource = dtChiTietHD;

            LoadDanhSachSanPham();

            txtThanhTien.Text = "0";
            txtKhuyenMai.Text = "0";
            txtTongTien.Text = "0";
            txtTienKhachDua.Clear();
            txtConLai.Text = "0";

            cboKhuyenMai.SelectedIndex = 0;

            currentSoHD = SinhMaHoaDon();
        }

        private void dgvCTHD_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCTHD.Columns[e.ColumnIndex].Name == "SoLuong")
            {
                try
                {
                    var row = dgvCTHD.Rows[e.RowIndex];
                    string maSach = row.Cells["MaSach"].Value.ToString();

                    // Tìm đơn giá tương ứng theo MaSach trong dgvSanPham
                    decimal donGia = 0;
                    foreach (DataGridViewRow spRow in dgvSanPham.Rows)
                    {
                        if (!spRow.IsNewRow && spRow.Cells["MaSach"].Value.ToString() == maSach)
                        {
                            donGia = Convert.ToDecimal(spRow.Cells["GiaBan"].Value);
                            break;
                        }
                    }

                    int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                    decimal thanhTien = soLuong * donGia;

                    row.Cells["DonGia"].Value = donGia;
                    row.Cells["ThanhTien"].Value = thanhTien;
                }
                catch
                {
                    MessageBox.Show("Lỗi khi cập nhật đơn giá/thành tiền!");
                }
            }
        }

   
    }
}
