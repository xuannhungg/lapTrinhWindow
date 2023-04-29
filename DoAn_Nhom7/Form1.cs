using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_Nhom7
{

    public partial class FTrangChu : Form
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.conStr);
        CongDanDAO congdandao = new CongDanDAO();
        public FTrangChu()
        {
            InitializeComponent();        }
        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            frmDangNhap form3 = new frmDangNhap();
            form3.Show();
        }
        public void LayDanhSach()
        {
            this.dGVDanhSach.DataSource = congdandao.DanhSach();

            if (rdbDaKetHon.Checked == true)
                TimNguoiDaKetHon();
            else if (rdbChuaKetHon.Checked == true)
                TimNguoiChuaKetHon();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LayDanhSach();
            dGVDanhSach.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            frmDangNhap formdn = new frmDangNhap();
            formdn.ShowDialog();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataSet dts = congdandao.TimCongDanTheoCCCD(txtCCCD.Text, dGVDanhSach);
            this.dGVDanhSach.DataSource = dts.Tables["cmnd"];
        }
        private void button17_Click(object sender, EventArgs e)
        {
            FCongDan form1 = new FCongDan();
            form1.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            LayDanhSach();
            txtCCCD.Text = "";
            KiemTraTamTruTamVang();
        }
        public void TimNguoiDaKetHon()
        {
            DataSet dts = congdandao.TimCongDanDaKetHon(dGVDanhSach);
            this.dGVDanhSach.DataSource = dts.Tables["tinhTrangHonNhan"];
        }
        public void TimNguoiChuaKetHon()
        {
            DataSet dts = congdandao.TimCongDanDocThan(dGVDanhSach);
            this.dGVDanhSach.DataSource = dts.Tables["tinhTrangHonNhan"];
        }
        private void dGVDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void KiemTraTamTruTamVang()
        {
           foreach (DataGridViewRow row  in dGVDanhSach.Rows)
            {
                if (!row.IsNewRow)
                {                
                    string date = (string)row.Cells["tamTru"].Value;
                    if (date.Length >11 )
                    { string[] lines = date.Split('\n');
                        string dateStart = lines[0].Substring(lines[0].Length - 10);
                        DateTime dateTime = DateTime.ParseExact(dateStart, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        DateTime toDate = DateTime.Now;
                        TimeSpan duration = toDate.Subtract(dateTime);
                        int months = (int)duration.TotalDays / 30;
                        if (months > 24)
                        {
                            DataGridViewCell cell = row.Cells[13];
                            cell.ErrorText = "Số tháng tạm trú vượt quá 24 : " + months;
                            row.ErrorText = "Có lỗi về ngày tạm trú";

                        } 
                    }
                }
            }

        }


        private void cmbTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dv = cmbTimKiem.Text;
            switch (dv)
            {
                case "Can cuoc cong dan":
                    FCongDan formCCCD = new FCongDan();
                    formCCCD.Show();
                    break;
                case "Thue":
                    FThue fThue = new FThue();
                    fThue.Show();
                    break;
                case "So ho khau":
                    FSoHoKhau fShk = new FSoHoKhau();
                    fShk.ShowDialog();
                    break;
                case "Tam tru, tam vang":
                    FTamTruTamVang fTttv = new FTamTruTamVang();
                    fTttv.ShowDialog();
                    break;
                case "Thong ke dan so":
                    FThongKe fTkds = new FThongKe();
                    fTkds.ShowDialog();
                    break;
                case "Hon nhan va gia dinh":
                    HonNhanVaGiaDinh fHnvgd = new HonNhanVaGiaDinh();
                    fHnvgd.ShowDialog();
                    break;
                case "Khai sinh":
                    FKhaiSinh fKs = new FKhaiSinh();
                    fKs.Show();
                    break;
                case "Khai tu":
                    FKhaiTu fKt = new FKhaiTu();
                    fKt.Show();
                    break;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCCCD_Click(object sender, EventArgs e)
        {
            UCCanCuoc uc = new UCCanCuoc();
            uc.Dock = DockStyle.Fill;
            pnHienThi.Controls.Clear();
            pnHienThi.Controls.Add(uc);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UCThue uc = new UCThue();
            uc.Dock = DockStyle.Fill;
            pnHienThi.Controls.Clear();
            pnHienThi.Controls.Add(uc);
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void rdbDaKetHon_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnSoHoKhau_Click(object sender, EventArgs e)
        {
            UCSoHoKhau uc = new UCSoHoKhau();
            uc.Dock= DockStyle.Fill;
            pnHienThi.Controls.Clear();
            pnHienThi.Controls.Add(uc);
        }

        private void btnTamTru_Click(object sender, EventArgs e)
        {
            UCTamTruTamVang uc = new UCTamTruTamVang();
            uc.Dock = DockStyle.Fill;
            pnHienThi.Controls.Clear();
            pnHienThi.Controls.Add(uc);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            UCThongKeDanSo uc = new UCThongKeDanSo();
            uc.Dock = DockStyle.Fill;
            pnHienThi.Controls.Clear();
            pnHienThi.Controls.Add(uc);
        }

        private void btnHonNhan_Click(object sender, EventArgs e)
        {
            UCHonNhan uc = new UCHonNhan();
            uc.Dock = DockStyle.Fill;
            pnHienThi.Controls.Clear();
            pnHienThi.Controls.Add(uc);
        }

        private void btnKhaiTu_Click(object sender, EventArgs e)
        {
            UCKhaiTu uc = new UCKhaiTu();
            uc.Dock = DockStyle.Fill;
            pnHienThi.Controls.Clear();
            pnHienThi.Controls.Add(uc);
        }


        private void dGVDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string cmnd = dGVDanhSach.Rows[e.RowIndex].Cells["cmnd"].Value.ToString();

            // Tạo và hiển thị form mới với thông tin từ cell click
            Form hi = new FThongTinCongDancs(cmnd);
            hi.ShowDialog();
        }

    }
}
