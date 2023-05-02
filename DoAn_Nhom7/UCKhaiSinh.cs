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
    public partial class UCKhaiSinh : UserControl
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.conStr);
        CongDanDAO cdDao = new CongDanDAO();
        DBConnection dbconnection = new DBConnection();
        ThanhVienShkDAO mem = new ThanhVienShkDAO();
        public UCKhaiSinh()
        {
            InitializeComponent();
        }

        private void UCKhaiSinh_Load(object sender, EventArgs e)
        {

        }
        public bool KiemTraHonNhan(string cmnd)
        {
            string sqlStr = "Select * from CongDan where cmnd = '" + cmnd + "'";
            return dbconnection.KiemTraVoChong(sqlStr, txtCMNDCha.Text, txtCMNDMe.Text);
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (KiemTraHonNhan(txtCMNDCha.Text))
            {
                string cmndcon = txtCMNDCha.Text + "-con " + dbconnection.SoLuongThanhVien(txtCMNDCha.Text) + "";
                string GioiTinh;
                if (rDNam.Checked)
                {
                    GioiTinh = "nam";
                }
                else
                {
                    GioiTinh = "nu";
                }

                ThanhVienShk tv = new ThanhVienShk(dbconnection.timMaSHK(txtCMNDCha.Text), txtCMNDCha.Text, cmndcon, "Con");

                CongDan congDan = new CongDan(cmndcon, txtTen.Text, tpNgSinh.Text, GioiTinh, txtDanToc.Text, txtQueQuan.Text, txtNoiSinh.Text);
                cdDao.Them(congDan);
                mem.ThietLapMoiQuanHeBoCon(tv);
                mem.ThemThanhVien(tv);
            }
            else
                MessageBox.Show("2 nguoi chua ket hon");
        }

        private void txtTenCha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dbconnection.KhaiSinh_KeyDown(txtCMNDCha, txtTenCha, txtDanTocCha, txtQuocTichCha);
                txtCMNDMe.Text = dbconnection.CMNDVoChong(txtCMNDCha.Text);
                if (txtCMNDMe.Text != "")
                    dbconnection.KhaiSinh_KeyDown(txtCMNDMe, txtTenMe, txtDanTocMe, txtQuocTichMe);
                else
                    MessageBox.Show("Khong tim thay nguoi yeu");
            }
        }

    }
}
