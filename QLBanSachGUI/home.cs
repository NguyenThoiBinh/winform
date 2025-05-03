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
    public partial class home : Form
    {
        private string maNhanVien;
        private string tenNhanVien;
        private string role; // thêm biến role

        public home(string maNV, string tenNV, string role)
        {
            InitializeComponent();
            tabControl1.Dock = DockStyle.Fill;
            this.maNhanVien = maNV;
            this.tenNhanVien = tenNV;
            this.role = role;
            if (role != "admin")
            {
                btnQLNhanVien.BackColor = Color.Gray;
            }
        }
        private Dictionary<int, Rectangle> closeButtonBounds = new Dictionary<int, Rectangle>();


        private void btnBanHang_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count >= 10)
            {
                MessageBox.Show("Chỉ được mở tối đa 10 tab!", "Giới hạn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TabPage newTab = new TabPage("Bán hàng: ");
            ucBanHang uc = new ucBanHang(maNhanVien, tenNhanVien); // ✅ truyền đúng
            uc.Dock = DockStyle.Fill;
            newTab.Controls.Add(uc);

            tabControl1.TabPages.Add(newTab);
            tabControl1.SelectedTab = newTab;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count >= 10)
            {
                MessageBox.Show("Chỉ được mở tối đa 10 tab!", "Giới hạn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo 1 tab mới và nhúng UserControl vào
            TabPage newTab = new TabPage("Thống Kê:");
            ucThongKe ucThongKe = new ucThongKe();
            ucThongKe.Dock = DockStyle.Fill;
            newTab.Controls.Add(ucThongKe);

            // Thêm vào tabControl
            tabControl1.TabPages.Add(newTab);
            tabControl1.SelectedTab = newTab;
        }

        private void btnQLKhachHang_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count >= 10)
            {
                MessageBox.Show("Chỉ được mở tối đa 10 tab!", "Giới hạn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo 1 tab mới và nhúng UserControl vào
            TabPage newTab = new TabPage("Khách hàng");
            ucKhachHang ucKhachHang = new ucKhachHang();
            ucKhachHang.Dock = DockStyle.Fill;
            newTab.Controls.Add(ucKhachHang);

            // Thêm vào tabControl
            tabControl1.TabPages.Add(newTab);
            tabControl1.SelectedTab = newTab;
        }

        private void btnQLNhanVien_Click(object sender, EventArgs e)
        {
            // ✅ Nếu không phải admin thì chặn
            if (role != "admin")
            {               
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tabControl1.TabPages.Count >= 10)
            {
                MessageBox.Show("Chỉ được mở tối đa 10 tab!", "Giới hạn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo 1 tab mới và nhúng UserControl vào
            TabPage newTab = new TabPage("Nhân viên");
            ucNhanVien ucNhanVien = new ucNhanVien();
            ucNhanVien.Dock = DockStyle.Fill;
            newTab.Controls.Add(ucNhanVien);

            // Thêm vào tabControl
            tabControl1.TabPages.Add(newTab);
            tabControl1.SelectedTab = newTab;
        }

        private void btnQLSach_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count >= 10)
            {
                MessageBox.Show("Chỉ được mở tối đa 10 tab!", "Giới hạn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo 1 tab mới và nhúng UserControl vào
            TabPage newTab = new TabPage("QL.Sach");
            ucSach ucSach = new ucSach();
            ucSach.Dock = DockStyle.Fill;
            newTab.Controls.Add(ucSach);

            // Thêm vào tabControl
            tabControl1.TabPages.Add(newTab);
            tabControl1.SelectedTab = newTab;
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            panel2.Visible = false; // Ẩn panel2 khi nhấn nút Đăng Xuất
                                    // Ẩn form home
            this.Hide();
            // Mở lại form đăng nhập
            DangNhap frmDangNhap = new DangNhap();
            frmDangNhap.ShowDialog();

            // Sau khi form đăng nhập đóng, đóng luôn form home
            this.Close();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            // Giới hạn số tab
            if (tabControl1.TabPages.Count >= 10)
            {
                MessageBox.Show("Chỉ được mở tối đa 10 tab!", "Giới hạn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra đã mở tab "Đổi mật khẩu" chưa?
            foreach (TabPage tab in tabControl1.TabPages)
            {
                if (tab.Text == "Đổi mật khẩu")
                {
                    tabControl1.SelectedTab = tab;
                    return;
                }
            }

            // Tạo tab mới
            TabPage newTab = new TabPage("Đổi mật khẩu");
            ucDoiMatKhau ucDoiMK = new ucDoiMatKhau();
            ucDoiMK.Dock = DockStyle.Fill;
            newTab.Controls.Add(ucDoiMK);

            // Thêm vào tabControl
            tabControl1.TabPages.Add(newTab);
            tabControl1.SelectedTab = newTab;
        }

        private void home_Load(object sender, EventArgs e)
        {
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl1.DrawItem += tabControl1_DrawItem;
            tabControl1.MouseDown += tabControl1_MouseDown;

            // Tự động mở trang chủ
            btnHome.PerformClick();
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage tabPage = tabControl1.TabPages[e.Index];
            Rectangle tabRect = tabControl1.GetTabRect(e.Index);

            // Vẽ tiêu đề tab
            TextRenderer.DrawText(e.Graphics, tabPage.Text, this.Font,
                tabRect, Color.Black, TextFormatFlags.Left);

            // Tính vùng chứa nút X
            Rectangle closeRect = new Rectangle(
                tabRect.Right - 15,
                tabRect.Top + 4,
                11, 11
            );

            // Vẽ X
            e.Graphics.DrawString("X", this.Font, Brushes.Red, closeRect);

            // Cập nhật vị trí nút X vào từ điển
            if (closeButtonBounds.ContainsKey(e.Index))
                closeButtonBounds[e.Index] = closeRect;
            else
                closeButtonBounds.Add(e.Index, closeRect);
        }

        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                if (closeButtonBounds.ContainsKey(i))
                {
                    Rectangle closeRect = closeButtonBounds[i];

                    if (closeRect.Contains(e.Location))
                    {
                        // Không cho xoá tab Trang chủ
                        if (tabControl1.TabPages[i].Text == "Trang chủ")
                        {
                            MessageBox.Show("Không thể đóng tab Trang chủ.");
                            return;
                        }

                        // Xoá đúng 1 tab
                        tabControl1.TabPages.RemoveAt(i);
                        closeButtonBounds.Clear(); // reset để tránh lỗi chỉ số sau khi xoá
                        break;
                    }
                }
            }
        }



        private void btnHome_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem tab Trang chủ đã mở chưa
            foreach (TabPage tab in tabControl1.TabPages)
            {
                if (tab.Text == "Trang chủ")
                {
                    tabControl1.SelectedTab = tab;
                    return;
                }
            }

            // Giới hạn số tab
            if (tabControl1.TabPages.Count >= 10)
            {
                MessageBox.Show("Chỉ được mở tối đa 10 tab!", "Giới hạn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo tab mới và thêm ucHome
            TabPage newTab = new TabPage("Trang chủ");
            ucHome uc = new ucHome(); // <-- nhớ đã tạo ucHome.cs
            uc.Dock = DockStyle.Fill;
            newTab.Controls.Add(uc);

            // Thêm vào tabControl
            tabControl1.TabPages.Add(newTab);
            tabControl1.SelectedTab = newTab;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}