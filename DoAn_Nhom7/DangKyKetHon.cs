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
    public partial class DangKyKetHon : Form
    {
        CongDanDAO cddao = new CongDanDAO();
        HonNhanDAO hnDao = new HonNhanDAO();
        ThanhVienShkDAO mem = new ThanhVienShkDAO();
        DBConnection dbconnection = new DBConnection();
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
                string maSHKCK = dbconnection.timMaSHK(txtGiayToTuyThanNam.Text);
                string CMNDChuHoCK = dbconnection.timChuHoSHK(maSHKCK);
                string maSHKVK = dbconnection.timMaSHK(txtGiayToTuyThanNu.Text);
                string CMNDChuHoVK = dbconnection.timChuHoSHK(maSHKVK);
                string quanhe;
                if (CMNDChuHoCK == txtGiayToTuyThanNam.Text)
                    quanhe = "Vo";
                else
                    quanhe = "Con Dau";
                ThanhVienShk tv = new ThanhVienShk(maSHKCK, CMNDChuHoCK, txtGiayToTuyThanNu.Text, quanhe);
                ThanhVienShk tv1 = new ThanhVienShk(maSHKVK, CMNDChuHoVK, txtGiayToTuyThanNu.Text, "Con");
                mem.XoaThanhVien(tv1);
                cddao.CapNhatKetHon(cdA, cdB);
                mem.ThemThanhVien(tv);
            }
            else
                MessageBox.Show("Co nguoi chua du dieu kien ket hon (1.chua du tuoi; 2.da ket hon)");
        }
        private void txtGiayToTuyThanNam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (hnDao.GioiTinh(txtGiayToTuyThanNam.Text) == "nam")
                    hnDao.LapDayThongTin_KetHon(txtGiayToTuyThanNam, txtHoTenNam, txtNgaySinhNam, txtDanTocNam, txtQueQuanNam, txtNoiCuTruNam);
                else
                    MessageBox.Show("Sai gioi tinh");
            }
        }

        private void txtGiayToTuyThanNu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (hnDao.GioiTinh(txtGiayToTuyThanNu.Text) == "nu")
                    hnDao.LapDayThongTin_KetHon(txtGiayToTuyThanNu, txtHoTenNu, txtNgaySinhNu,txtDanTocNu, txtQueQuanNu, txtNoiCuTruNu);
                else
                    MessageBox.Show("Sai gioi tinh");
            }
        }

        private void DangKyKetHon_Load(object sender, EventArgs e)
        {

        }

    }
}
