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
        SoHoKhauDAO hkdao = new SoHoKhauDAO();
        ThanhVienShkDAO tvDao = new ThanhVienShkDAO();
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
                string mashk = TimMaSHK(txtCMNDA.Text);
                string CMNDChuHo = TimChuHoSHK(mashk);
                string quanhe;
                if (CMNDChuHo == txtCMNDA.Text)
                    quanhe = "Vo";
                else
                    quanhe = "Con Dau";
                ThanhVienShk tv = new ThanhVienShk(mashk, CMNDChuHo, txtCMNDB.Text,quanhe);
                tvDao.XoaThanhVien(tv);
                cddao.CapNhatQuanHeLyHon(cdA, cdB);
            }
            else
                MessageBox.Show("Có người đang ở tình trạng độc thân");
        }
        public string TimMaSHK(string cmnd)
        {
            string sqlStr = "SELECT maSoHoKhau FROM ThanhVienSoHoKhau WHERE CMNDChuHo = '" + cmnd + "' or CMNDThanhVien= '" + cmnd + "'";
            return dbconnection.TimMaSHK(cmnd, sqlStr);
        }
        public string TimChuHoSHK(string mashk)
        {
            string sqlStr = "SELECT CMNDChuHo FROM SoHoKhau WHERE maSoHoKhau = '" + mashk + "'";
            return dbconnection.TimChuHoSHK(mashk, sqlStr);
        }
        private void txtCMNDA_KeyDown(object sender, KeyEventArgs e)
        {              
            if (e.KeyCode == Keys.Enter)
            {
                hnDao.LapDayThongTin_LyHon(txtCMNDA.Text, txtTenA, txtNamSinhA, txtCuTruA);
                txtCMNDB.Text = CMNDVoChong(txtCMNDA.Text);
                if (txtCMNDB.Text != "")
                    hnDao.LapDayThongTin_LyHon(txtCMNDB.Text, txtTenB, txtNamSinhB, txtCuTruB);
                else
                    MessageBox.Show("Không tìm thấy vợ");
            }
        }
        public string CMNDVoChong(string cmnd)
        {
            string sqlStr = "Select * from CongDan where cmnd = '" + cmnd + "'";
            return dbconnection.CMNDVoChong(cmnd, sqlStr);
        }
        private void DangKyLyHon_Load(object sender, EventArgs e)
        {

        }
    }
}
