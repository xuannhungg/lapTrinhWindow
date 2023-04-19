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
    public partial class frmDangNhap : Form
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.conStr);
        TaiKhoanDAO tkdao = new TaiKhoanDAO();
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text == "" || txtMatKhau.Text == "")
                MessageBox.Show("Tai khoan hoac mat khau khong duoc de trong");
            else
            {
                TaiKhoan tk = new TaiKhoan(txtTaiKhoan.Text, txtMatKhau.Text);
                tkdao.DangNhap(tk);
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            pnLogin.Visible = false;
            pnSignUp.Visible = true;
            pnSignUp.Dock = DockStyle.Right;
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            pnSignUp.Visible = false;
        }

        private void lblMatKhau_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            pnLogin.Visible = true;
            pnSignUp.Visible = false;
            pnSignUp.Dock = DockStyle.Right;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDangKi_Click(object sender, EventArgs e)
        {
            if (txtUsername_Dk.Text == "" || txtPass_Dk.Text == "")
                MessageBox.Show("Tai khoan hoac mat khau khong duoc de trong");
            else
            {
                if (cbDongY.Checked == true && tkdao.KiemTraTonTai(txtUsername_Dk.Text) == false)
                {
                    TaiKhoan tk = new TaiKhoan(txtUsername_Dk.Text, txtPass_Dk.Text);
                    tkdao.DangKy(tk);
                }
                else
                {
                    MessageBox.Show("That bai! Tai khoan da ton tai, hoac ban chua cam ket!");
                }
            }
        }
    }
}
