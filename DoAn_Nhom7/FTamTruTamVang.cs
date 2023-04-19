using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_Nhom7
{
    public partial class FTamTruTamVang : Form
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.conStr);
        DBConnection dbconnection = new DBConnection();
        CongDanDAO cddao = new CongDanDAO();
        public FTamTruTamVang()
        {
            InitializeComponent();
        }

        private void FTamTruTamVang_Load(object sender, EventArgs e)
        {

        }

        private void txtCMND_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dbconnection.LapDayThongTinTamTru(txtCMND, txtHoTen, txtNgaySinh, txtCongAn1,txtThuongTru);
            }
        }

        private void txtCongAn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dbconnection.dienGiong(txtCongAn.Text,txtCongAn2,txtCongAn3);

            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            CongDan cdA = new CongDan(txtTamTru.Text,txtCMND.Text, dTPNgayBatDau.Text);
            cddao.CapNhatTamTru(cdA);

        }

        private void txtCMND_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
