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
    public partial class UCThue : UserControl
    {
        ThueDAO thueDao = new ThueDAO();
        public UCThue()
        {
            InitializeComponent();
        }
        private void UCThue_Load(object sender, EventArgs e)
        {
            LayDanhSach();
        }
        public void LayDanhSach()
        {
            this.dGVThue.DataSource = thueDao.DanhSach();
            this.dGVChinhSuaDanhSach.DataSource = thueDao.DanhSach();
        }
        public void LayThongTinCongDan() //lay thong tin de truyen vao datagridview (dGVCongDan)
        {
            thueDao.LayThongTinCongDan(txtCCCD.Text, this.dGVCongDan, txtLuong, txtTen, txtNgheNghiep);
        }
        private void tinhSoTienCanDong()
        {
            if (cbChuaDong.Checked == true)
            {
                Thue thue = new Thue(txtCCCD.Text, txtLoaiThue.Text, Convert.ToDouble(txtMucThue.Text), cbChuaDong.Text);
                DataSet dts = thueDao.timCongDanTheoCCCD(thue);
                double luong = Convert.ToDouble(dts.Tables[0].Rows[0][11].ToString());
                double mucThue = Convert.ToDouble(txtMucThue.Text);
                double soTien = (luong * mucThue) / 100;
                txtSoTienCanDong.Text = Convert.ToString(soTien);
                cbDaDong.Checked = false;
            }
            else
            {
                cbDaDong.Checked = true;
                txtSoTienCanDong.Text = "0";
            }
        }
        private void btnDongTien_Click(object sender, EventArgs e)
        {
            if (cbDaDong.Checked == true)
                MessageBox.Show("Ban da dong tien roi!");
            else
            {
                Thue thue = new Thue(txtCCCD.Text, txtLoaiThue.Text, Convert.ToDouble(txtMucThue.Text), cbDaDong.Text);
                thueDao.DongTien(thue);
                cbChuaDong.Checked = false;
                cbDaDong.Checked = true;
                txtSoTienCanDong.Text = "0";
                LayDanhSach();
            }
        }
        private void btnThemDoiTuong_Click(object sender, EventArgs e)
        {
            Thue thue = new Thue(txtCCCD2.Text, txtLoaiThue2.Text, Convert.ToDouble(txtMucThue2.Text), txtTinhTrang2.Text);
            thueDao.ThemDoiTuong(thue);
            LayDanhSach();
        }
        private void btnSuaDoiTuong_Click(object sender, EventArgs e)
        {
            Thue thue = new Thue(txtCCCD2.Text, txtLoaiThue2.Text, Convert.ToDouble(txtMucThue2.Text), txtTinhTrang2.Text);
            thueDao.SuaDoiTuong(thue);
            LayDanhSach();
        }
        private void btnXoaDoiTuong_Click(object sender, EventArgs e)
        {
            Thue thue = new Thue(txtCCCD2.Text, txtLoaiThue2.Text, Convert.ToDouble(txtMucThue2.Text), txtTinhTrang2.Text);
            thueDao.XoaDoiTuong(thue);
            LayDanhSach();
        }
        private void dGVThue_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dGVThue.Rows[e.RowIndex];
            txtCCCD.Text = row.Cells[0].Value.ToString();
            txtLoaiThue.Text = row.Cells[1].Value.ToString();
            txtMucThue.Text = row.Cells[2].Value.ToString();
            if (row.Cells[3].Value.ToString() == "Chua dong")
            {
                cbChuaDong.Checked = true;
                cbDaDong.Checked = false;
            }
            else if (row.Cells[3].Value.ToString() == "Da dong")
            {
                cbDaDong.Checked = true;
                cbChuaDong.Checked = false;
            }
            tinhSoTienCanDong();
            LayThongTinCongDan();
        }
        private void dGVChinhSuaDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dGVThue.Rows[e.RowIndex];
            txtCCCD2.Text = row.Cells[0].Value.ToString();
            txtLoaiThue2.Text = row.Cells[1].Value.ToString();
            txtMucThue2.Text = row.Cells[2].Value.ToString();
            txtTinhTrang2.Text = row.Cells[3].Value.ToString();
        }
    }
}
