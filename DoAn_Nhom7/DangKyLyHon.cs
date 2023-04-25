using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_Nhom7
{
    public partial class DangKyLyHon : Form
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.conStr);
        CongDanDAO cddao = new CongDanDAO();
        DBConnection dbconnection = new DBConnection();
        HonNhanDAO hnDao = new HonNhanDAO();
        public DangKyLyHon()
        {
            InitializeComponent();
        }


        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (hnDao.ThoaDieuKienLyHon(txtCMNDA.Text, txtCMNDB.Text))
            {
                CongDan cdA = new CongDan(txtCMNDA.Text);
                cddao.CapNhatLyHon(cdA);
                CongDan cdB = new CongDan(txtCMNDB.Text);
                cddao.CapNhatLyHon(cdB);
            }
            else
                MessageBox.Show("Co nguoi dang o tinh trang Doc Than");
        }

        private void txtCMNDA_KeyDown(object sender, KeyEventArgs e)
        {              
            if (e.KeyCode == Keys.Enter)
            {
                hnDao.LapDayThongTin_LyHon(txtCMNDA.Text, txtTenA, txtNamSinhA, txtCuTruA);
                txtCMNDB.Text = dbconnection.CMNDVoChong(txtCMNDA.Text);
                if (txtCMNDB.Text != "")
                    hnDao.LapDayThongTin_LyHon(txtCMNDB.Text, txtTenB, txtNamSinhB, txtCuTruB);
                else
                    MessageBox.Show("Khong co nguoi yeu");
            }
        }
        private void DangKyLyHon_Load(object sender, EventArgs e)
        {

        }
    }
}
