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
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;


namespace DoAn_Nhom7
{
    public partial class FKhaiSinh : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.conStr);
        CongDanDAO cdDao = new CongDanDAO();
        DBConnection dbconnection = new DBConnection();
        ThanhVienShkDAO mem = new ThanhVienShkDAO();

        public FKhaiSinh()
        {
            InitializeComponent();
        }
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (KiemTraHonNhan(txtCMNDCha.Text))
            {
                string cmndcon = txtCMNDCha.Text + "-con "+dbconnection.SoLuongThanhVien(txtCMNDCha.Text)+"";
                string GioiTinh;
                if (rDNam.Checked)
                {
                    GioiTinh = "Nam";
                }
                else
                {
                    GioiTinh = "Nữ";
                }
                string mashk = dbconnection.timMaSHK(txtCMNDCha.Text);
                string cmndChuHo = dbconnection.timChuHoSHK(mashk);
                string quanhe;
                if (cmndChuHo == txtCMNDCha.Text)
                    quanhe = "Con";
                else
                    quanhe = "Cháu";
                ThanhVienShk tv = new ThanhVienShk(mashk,cmndChuHo, cmndcon, quanhe);

                CongDan congDan = new CongDan(txtTen.Text, tpNgSinh.Text,GioiTinh,cmndcon, txtDanToc.Text,"Doc Than",txtNoiSinh.Text, txtQueQuan.Text, txtQueQuan.Text,txtQuocTich.Text);
                cdDao.Them(congDan);
                cdDao.CapNhatKhaiSinh(txtCMNDCha.Text,txtCMNDMe.Text,cmndcon);
                //mem.ThietLapMoiQuanHeBoCon(tv);
                mem.ThemThanhVien(tv);
               FThongTinCongDancs form = new FThongTinCongDancs();
               form.cmnd = cmndcon;
               form.cmndbo = txtCMNDCha.Text;
               form.cmndme = txtCMNDMe.Text;
               form.ShowDialog();
               Bitmap bitmap = new Bitmap(form.Width, form.Height);
               form.DrawToBitmap(bitmap, new Rectangle(0, 0, form.Width, form.Height));
               foreach (Control control in form.Controls)
               {
                   if (control is Label button)
                   {
                       Point buttonLocation = button.PointToScreen(Point.Empty);
                       Point formLocation = form.PointToScreen(Point.Empty);
                       Point relativeLocation = new Point(buttonLocation.X - formLocation.X, buttonLocation.Y - formLocation.Y);
                       relativeLocation.Y += 34;

                       using (Graphics graphics = Graphics.FromImage(bitmap))
                       {
                           graphics.DrawString(button.Text, button.Font, new SolidBrush(button.ForeColor), relativeLocation);
                       }
                   }
               }
               bitmap.Save(""+cmndcon+".png");
               bitmap.Dispose();
           }
            else
                MessageBox.Show("2 người chưa kết hôn");
            

        }

        private void txtCCCD_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        public bool KiemTraHonNhan(string cmnd)
        {
            string sqlStr = "Select * from CongDan where cmnd = '" + cmnd + "'";
            return dbconnection.KiemTraVoChong(sqlStr,txtCMNDCha.Text,txtCMNDMe.Text);
        }

        private void txtCMNDCha_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                dbconnection.KhaiSinh_KeyDown(txtCMNDCha, txtTenCha, txtDanTocCha,txtQuocTichCha);
                txtCMNDMe.Text = dbconnection.CMNDVoChong(txtCMNDCha.Text);
                if (txtCMNDMe.Text != "")
                    dbconnection.KhaiSinh_KeyDown(txtCMNDMe, txtTenMe, txtDanTocMe,txtQuocTichMe);
                else
                    MessageBox.Show("Khong tim thay nguoi yeu");
            }
        }

        private void txtCMNDMe_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void FKhaiSinh_Load(object sender, EventArgs e)
        {

        }
    }
}
