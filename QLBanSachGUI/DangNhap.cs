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
using QLBanSachBLL;


namespace QLBanSachGUI
{
    public partial class DangNhap : Form
    {
        TK taikhoan = new TK();
        TaiKhoanBLL TKBLL = new TaiKhoanBLL();
        public DangNhap()
        {
            InitializeComponent();
<<<<<<< HEAD
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            taikhoan.UserName = txtTaiKhoan.Text.Trim();
            taikhoan.PassWord = txtMatKhau.Text.Trim();
            string getuser = TKBLL.CheckLogic(taikhoan);

            switch (getuser)
            {
                case "required_taikhoan":
                    MessageBox.Show("Tài khoản không được để trống");
                    return;
                case "required_password":
=======
        }      
        private void btnLogin_Click(object sender, EventArgs e)
        {
            taikhoan.UserName = txtTaiKhoan.Text;
            taikhoan.PassWord = txtMatKhau.Text;
            string getuser = TKBLL.CheckLogic(taikhoan);
            //Check 
            switch (getuser)
            {
                case "requeid_taikhoan":
                    MessageBox.Show("Tài khoản không được để trống");
                    return;
                case "requeid_password":
>>>>>>> cuong/master
                    MessageBox.Show("Mật khẩu không được để trống");
                    return;
                case "Tài khoản hoặc mật khẩu không chính xác!":
                    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!");
                    return;
            }
<<<<<<< HEAD

            // ✅ Lấy thông tin nhân viên
            string maNV = TKBLL.LayMaNV(taikhoan.UserName);
            string tenNV = TKBLL.LayTenNV(taikhoan.UserName);
            string role = TKBLL.LayRole(taikhoan.UserName);

            MessageBox.Show("Đăng nhập thành công");

            this.Hide();
            home frmHome = new home(maNV, tenNV, role); // ✅ truyền role
            frmHome.ShowDialog();
=======
            MessageBox.Show("Đăng nhập thành công");
            // Ẩn form đăng nhập
            this.Hide();

            // Mở form home
            home frmHome = new home();
            frmHome.ShowDialog();

            // Sau khi đóng form home thì thoát
>>>>>>> cuong/master
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            // Hỏi người dùng có muốn thoát không
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit(); // Thoát chương trình
            }
        }

        private void txtTaiKhoan_Click(object sender, EventArgs e)
        {
            txtTaiKhoan.BackColor = Color.White;
            panel3.BackColor = Color.White;
            panel4.BackColor = SystemColors.Control;
            txtMatKhau.BackColor = SystemColors.Control;
        }
        private void txtMatKhau_Click(object sender, EventArgs e)
        {
            txtMatKhau.BackColor = Color.White;
            panel4.BackColor = Color.White;
            txtTaiKhoan.BackColor = SystemColors.Control;
            panel3.BackColor = SystemColors.Control;
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = false; // Hiện mật khẩu
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = true; // Ẩn mật khẩu

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> cuong/master
