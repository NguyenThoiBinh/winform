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
        SachBLL SachBLL = new SachBLL();
        private void ucSach_Load(object sender, EventArgs e)
        {
            LayDS_Sach();
        }

        private void LayDS_Sach()
        {
            SachBLL sach = new SachBLL();
            list = sach.DS_Sach();
            dgvSach.DataSource = list;
            
        }
    }
}
