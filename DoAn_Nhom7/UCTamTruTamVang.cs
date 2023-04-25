using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DoAn_Nhom7
{
    public partial class UCTamTruTamVang : UserControl
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.conStr);
        DBConnection dbconnection = new DBConnection();
        CongDanDAO cddao = new CongDanDAO();
        public UCTamTruTamVang()
        {
            InitializeComponent();
        }

        private void UCTamTruTamVang_Load(object sender, EventArgs e)
        {

        }

        private void txtCMND_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dbconnection.LapDayThongTinTamTru(txtCMND, txtHoTen, txtNgaySinh, txtCongAn1, txtThuongTru);
            }
        }

        private void txtCongAn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dbconnection.dienGiong(txtCongAn.Text, txtCongAn2, txtCongAn3);
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            CongDan cdA = new CongDan(txtTamTru.Text, txtCMND.Text, dTPNgayBatDau.Text);
            cddao.CapNhatTamTru(cdA);
        }
    }
}
