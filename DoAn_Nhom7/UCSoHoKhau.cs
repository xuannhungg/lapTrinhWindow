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
    public partial class UCSoHoKhau : UserControl
    {
        SoHoKhauDAO hkdao = new SoHoKhauDAO();
        ThanhVienShkDAO tvDao = new ThanhVienShkDAO();
        DBConnection db = new DBConnection();
        public UCSoHoKhau()
        {
            InitializeComponent();
        }
        public void LayDanhSach()
        {
            this.dtgvSoHoKhau.DataSource = hkdao.DanhSach();
        }
        private void lblCmnd_Tv_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SoHoKhau hk = new SoHoKhau(txtMaSoHoKhau.Text, txtCMND.Text, txtMaKhuVuc.Text, txtXaPhuong.Text, txtQuanHuyen.Text, txtTinhThanhPho.Text, txtDiaChi.Text, dtpNgayLap.Text);
            hkdao.ThemSoHoKhau(hk);
            LayDanhSach();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            SoHoKhau hk = new SoHoKhau(txtMaSoHoKhau.Text, txtCMND.Text, txtMaKhuVuc.Text, txtXaPhuong.Text, txtQuanHuyen.Text, txtTinhThanhPho.Text, txtDiaChi.Text, dtpNgayLap.Text);
            hkdao.XoaSoHoKhau(hk);
            LayDanhSach();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SoHoKhau hk = new SoHoKhau(txtMaSoHoKhau.Text, txtCMND.Text, txtMaKhuVuc.Text, txtXaPhuong.Text, txtQuanHuyen.Text, txtTinhThanhPho.Text, txtDiaChi.Text, dtpNgayLap.Text);
            hkdao.SuaSoHoKhau(hk);
            LayDanhSach();
        }

        private void UCSoHoKhau_Load(object sender, EventArgs e)
        {
            LayDanhSach();
        }

        private void dtgvThanhVienShk_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgvSoHoKhau_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = this.dtgvSoHoKhau.Rows[e.RowIndex];
            txtMaSoHoKhau.Text = row.Cells[0].Value.ToString();
            txtCMND.Text = row.Cells[1].Value.ToString();
            txtMaKhuVuc.Text = row.Cells[2].Value.ToString();
            txtXaPhuong.Text = row.Cells[3].Value.ToString();
            txtQuanHuyen.Text = row.Cells[4].Value.ToString();
            txtTinhThanhPho.Text = row.Cells[5].Value.ToString();
            txtDiaChi.Text = row.Cells[6].Value.ToString();
            dtpNgayLap.Text = row.Cells[7].Value.ToString();
        }
        public void LayDanhSachThanhVien()
        {
            this.dtgvThanhVienShk.DataSource = hkdao.DanhSachThanhVien(txtMaSoHoKhau.Text);
        }
        private void btnXem_Click(object sender, EventArgs e)
        {
            LayDanhSachThanhVien();
        }

        private void btnThemTv_Click(object sender, EventArgs e)
        {
            ThanhVienShk tv = new ThanhVienShk(txtMaShk_tv.Text, txtCmnd_tv.Text, txtQuanHe.Text);
            if (db.KiemTraSHK(txtCmnd_tv.Text))
            {
                tvDao.ThemThanhVien(tv);
                LayDanhSachThanhVien();
            }
            else
                MessageBox.Show("Da co shk");
        }

        private void btnXoaTv_Click(object sender, EventArgs e)
        {
            ThanhVienShk tv = new ThanhVienShk(txtMaShk_tv.Text, txtCmnd_tv.Text, txtQuanHe.Text);
        }

        private void btnSuaTv_Click(object sender, EventArgs e)
        {
            ThanhVienShk tv = new ThanhVienShk(txtMaShk_tv.Text, txtCmnd_tv.Text, txtQuanHe.Text);
            tvDao.SuaThanhVien(tv);
            LayDanhSachThanhVien();
        }

        private void dtgvSoHoKhau_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = this.dtgvSoHoKhau.Rows[e.RowIndex];
            txtMaSoHoKhau.Text = row.Cells[0].Value.ToString();
            txtCMND.Text = row.Cells[1].Value.ToString();
            txtMaKhuVuc.Text = row.Cells[2].Value.ToString();
            txtXaPhuong.Text = row.Cells[3].Value.ToString();
            txtQuanHuyen.Text = row.Cells[4].Value.ToString();
            txtTinhThanhPho.Text = row.Cells[5].Value.ToString();
            txtDiaChi.Text = row.Cells[6].Value.ToString();
            dtpNgayLap.Text = row.Cells[7].Value.ToString();
        }

        private void dtgvThanhVienShk_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = this.dtgvThanhVienShk.Rows[e.RowIndex];
            txtMaShk_tv.Text = row.Cells[0].Value.ToString();
            txtCmnd_tv.Text = row.Cells[1].Value.ToString();
            txtHoTen_tv.Text = row.Cells[2].Value.ToString();
            txtGioiTinh_tv.Text = row.Cells[3].Value.ToString();
            txtQuanHe.Text = row.Cells[4].Value.ToString();
        }
    }
}
