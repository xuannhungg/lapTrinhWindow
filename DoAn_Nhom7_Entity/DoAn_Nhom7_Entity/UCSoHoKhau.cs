using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_Nhom7_Entity
{
    public partial class UCSoHoKhau : UserControl
    {
        QuanLiCongDanEntities db = new QuanLiCongDanEntities();
        public UCSoHoKhau()
        {
            InitializeComponent();
        }
        public void LayDanhSach()
        {
            var result = from c in db.SoHoKhaus
                         select new
                         {
                             maSoHoKhau = c.maSoHoKhau,
                             CMNDChuHo = c.CMNDChuHo,
                             maKV = c.maKV,
                             xaPhuong = c.xaPhuong,
                             quanHuyen = c.quanHuyen,
                             tinhTP = c.tinhTP,
                             diaChi = c.diaChi,
                             ngayLap = c.ngayLap
                         };
            this.dtgvSoHoKhau.DataSource = result.ToList();
        }
        public void LayDanhSachThanhVien()
        {
            var result = from c in db.ThanhVienSoHoKhaus
                         where c.maSoHoKhau == txtMaSoHoKhau.Text
                         select new
                         {
                             maSoHoKhau = c.maSoHoKhau,
                             CMNDThanhVien = c.CMNDThanhVien,
                             quanHeVoiChuHo = c.quanHeVoiChuHo
                         };
            this.dtgvThanhVienShk.DataSource = result.ToList();
        }
        private void UCSoHoKhau_Load(object sender, EventArgs e)
        {
            LayDanhSach();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
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
        private void btnThem_Click(object sender, EventArgs e)
        {
            
        }

        private void dtgvThanhVienShk_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = this.dtgvThanhVienShk.Rows[e.RowIndex];
            txtCmnd_tv.Text = row.Cells[1].Value.ToString();

            string cmnd = txtCmnd_tv.Text;
            var query = from cd in db.CongDans
                        join tvshk in db.ThanhVienSoHoKhaus on cd.cmnd equals tvshk.CMNDThanhVien
                        join shk in db.SoHoKhaus on new { tvshk.maSoHoKhau, tvshk.CMNDChuHo } equals new { shk.maSoHoKhau, shk.CMNDChuHo }
                        where cd.cmnd == cmnd
                        select new
                        {
                            shk.maSoHoKhau,
                            cd.hoTen,
                            cd.gioiTinh,
                            tvshk.quanHeVoiChuHo
                        };
            var result = query.FirstOrDefault();
            if (result != null)
            {
                txtMaShk_tv.Text = result.maSoHoKhau;
                txtHoTen_tv.Text = result.hoTen;
                txtGioiTinh_tv.Text = result.gioiTinh;
                txtQuanHe.Text = result.quanHeVoiChuHo;
            }
        }
    }
}
