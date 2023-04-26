﻿using System;
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
                ThanhVienShk tv = new ThanhVienShk(dbconnection.timMaSHK(txtCMNDCha.Text), cmndcon, "con " + GioiTinh(txtGioiTinh.Text));
                CongDan congDan = new CongDan(cmndcon, txtTen.Text, tpNgSinh.Text, txtGioiTinh.Text, txtDanToc.Text, txtQueQuan.Text, txtNoiSinh.Text);
                cdDao.Them(congDan);
                mem.ThemThanhVien(tv);
            }
            else
                MessageBox.Show("2 nguoi chua ket hon");
        }
        public string GioiTinh(string gioiTinh)
        {
            if (gioiTinh == "nu")
                return "gai";
            else
                return "nam";
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
                dbconnection.KhaiSinh_KeyDown(txtCMNDCha, txtTenCha, txtDanTocCha);
                txtCMNDMe.Text = dbconnection.CMNDVoChong(txtCMNDCha.Text);
                if (txtCMNDMe.Text != "")
                    dbconnection.KhaiSinh_KeyDown(txtCMNDMe, txtTenMe, txtDanTocMe);
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
