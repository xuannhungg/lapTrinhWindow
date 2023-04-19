using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_Nhom7
{
    public partial class FKhaiSinh : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.conStr);
        CongDanDAO cdDao = new CongDanDAO();
        DBConnection dbconnection = new DBConnection();

        public FKhaiSinh()
        {
            InitializeComponent();
        }
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            CongDan congDan = new CongDan(txtTen.Text,tpNgSinh.Text,txtGioiTinh.Text,txtDanToc.Text);
            cdDao.Them(congDan);
        }
        private void txtCCCD_KeyDown(object sender, KeyEventArgs e)
        {
            dbconnection.KhaiSinh_KeyDown(txtCMNDCha,txtTenCha,txtDanTocCha);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
