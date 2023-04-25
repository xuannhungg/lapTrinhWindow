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
    public partial class UCCanCuoc : UserControl
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.conStr);
        DBConnection dbconnection = new DBConnection();
        CongDanDAO cddao = new CongDanDAO();
        public UCCanCuoc()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            CongDan cd = new CongDan(txtHoTen.Text, dTPNgaySinh.Text, txtGioiTinh.Text, txtCMND.Text, txtDanToc.Text, txtHonNhan.Text, txtKhaiSinh.Text, txtQueQuan.Text, txtThuongTru.Text, txtHocVan.Text, txtNgheNghiep.Text, txtLuong.Text, txtSoLanKetHon.Text, txtTamTru.Text, txtNoiCapCMND.Text, dTPNgayCap.Text);
            cddao.Them(cd);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            CongDan cd = new CongDan(txtHoTen.Text, dTPNgaySinh.Text, txtGioiTinh.Text, txtCMND.Text, txtDanToc.Text, txtHonNhan.Text, txtKhaiSinh.Text, txtQueQuan.Text, txtThuongTru.Text, txtHocVan.Text, txtNgheNghiep.Text, txtLuong.Text, txtSoLanKetHon.Text, txtTamTru.Text, txtNoiCapCMND.Text, dTPNgayCap.Text);
            cddao.Xoa(cd);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            CongDan cd = new CongDan(txtHoTen.Text, dTPNgaySinh.Text, txtGioiTinh.Text, txtCMND.Text, txtDanToc.Text, txtHonNhan.Text, txtKhaiSinh.Text, txtQueQuan.Text, txtThuongTru.Text, txtHocVan.Text, txtNgheNghiep.Text, txtLuong.Text, txtSoLanKetHon.Text, txtTamTru.Text, txtNoiCapCMND.Text, dTPNgayCap.Text);
            cddao.Sua(cd);
        }

        private void txtCMND_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dbconnection.LapDayThongTinCD(txtCMND, txtHoTen, dTPNgaySinh, txtGioiTinh, txtDanToc, txtHonNhan, txtKhaiSinh, txtQueQuan, txtThuongTru, txtHocVan, txtNgheNghiep, txtLuong, txtSoLanKetHon, txtTamTru, txtNoiCapCMND, dTPNgayCap);
            }
        }

        private void UCCanCuoc_Load(object sender, EventArgs e)
        {

        }
    }
}
