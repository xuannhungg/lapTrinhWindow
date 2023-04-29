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
    public partial class DangKyKetHon : Form
    {
        CongDanDAO cddao = new CongDanDAO();
        HonNhanDAO hnDao = new HonNhanDAO();
        public DangKyKetHon()
        {
            InitializeComponent();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (hnDao.ThoaDieuKienKetHon(txtGiayToTuyThanNam.Text, txtGiayToTuyThanNu.Text) == true)
            {
                CongDan cdA = new CongDan(txtGiayToTuyThanNam.Text, txtHoTenNam.Text);
                CongDan cdB = new CongDan(txtGiayToTuyThanNu.Text, txtHoTenNu.Text);
                cddao.CapNhatKetHon(cdA, cdB);
            }
            else
                MessageBox.Show("Co nguoi chua du dieu kien ket hon (1.chua du tuoi; 2.da ket hon)");
        }
        private void txtGiayToTuyThanNam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                hnDao.LapDayThongTin_KetHon(txtGiayToTuyThanNam, txtHoTenNam, txtNgaySinhNam, txtDanTocNam, txtQueQuanNam, txtNoiCuTruNam);
            }
        }

        private void txtGiayToTuyThanNu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                hnDao.LapDayThongTin_KetHon(txtGiayToTuyThanNu, txtHoTenNu, txtNgaySinhNu,txtDanTocNu, txtQueQuanNu, txtNoiCuTruNu);
            }
        }

        private void DangKyKetHon_Load(object sender, EventArgs e)
        {

        }

    }
}
