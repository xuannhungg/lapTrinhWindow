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
    public partial class UCKhaiTu : UserControl
    {
        CongDanDAO cdDao = new CongDanDAO();
        ThueDAO thueDao = new ThueDAO();
        KhaiTuDAO ktDao = new KhaiTuDAO();
        public UCKhaiTu()
        {
            InitializeComponent();
        }

        private void btnNop_Click(object sender, EventArgs e)
        {
            if (cbToiDongY.Checked)
            {
                Thue thue = new Thue(txtCCCD.Text);
                thueDao.XoaDoiTuong(thue);
                CongDan cd = new CongDan(txtCCCD.Text);
                cdDao.Xoa(cd);
            }
            else
                MessageBox.Show("Vui long xac nhan!");
        }
        private void txtCCCD_KeyDown(object sender, KeyEventArgs e)
        {
            ktDao.KhaiTu_KeyDown(txtCCCD, txtTen, txtNgaySinh, txtHonNhan, txtThuongTru, txtGioiTinh, txtDanToc, txtQuocTich, txtQueQuan, txtNgheNghiep);
        }

        private void UCKhaiTu_Load(object sender, EventArgs e)
        {

        }
    }
}
