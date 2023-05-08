using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_Nhom7
{
    internal class SoHoKhauDAO
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.conStr);
        DBConnection dbconnection = new DBConnection();
        public DataTable DanhSach()
        {
            string sqlStr = string.Format("SELECT *FROM SoHoKhau ");
            return dbconnection.DanhSach(sqlStr);
        }
        public DataTable DanhSachThanhVien(string maShk)
        {
            string sqlStr = string.Format("SELECT maSoHoKhau,CMNDThanhVien,quanHeVoiChuHo FROM ThanhVienSoHoKhau WHERE maSoHoKhau = '" + maShk + "'");
            return dbconnection.DanhSach(sqlStr);
        }
        public void ThemSoHoKhau(SoHoKhau hk)
        {
            string sqlStr = string.Format("INSERT INTO SoHoKhau (maSoHoKhau, CMNDChuHo, maKV, xaPhuong, quanHuyen, tinhTP, diaChi,ngayLap)  VALUES ('{0}', '{1}','{2}', '{3}', '{4}', '{5}', '{6}', '{7}')", hk.MaSoHoKhau, hk.CMND, hk.MaKV, hk.XaPhuong, hk.QuanHuyen, hk.TinhThanhPho
            , hk.DiaChi, hk.NgayLap);
            dbconnection.XuLy(sqlStr);
        }
        public void SuaSoHoKhau(SoHoKhau hk)
        {
            //Tạo bảng ảo
            string maSHKMoi = hk.MaSoHoKhau + "*";
            string sqlStr = string.Format("INSERT INTO SoHoKhau (maSoHoKhau, CMNDChuHo, maKV, xaPhuong, quanHuyen, tinhTP, diaChi, ngayLap) SELECT '"+maSHKMoi+"', '"+hk.CMND+"', maKV, xaPhuong, quanHuyen, tinhTP, diaChi, ngayLap FROM SoHoKhau WHERE maSoHoKhau = '"+hk.MaSoHoKhau+"'");
            string sqlStr1 = string.Format("INSERT INTO ThanhVienSoHoKhau(maSoHoKhau, CMNDChuHo, CMNDThanhVien, quanHeVoiChuHo) SELECT '"+maSHKMoi+"', '"+hk.CMND+ "', CMNDThanhVien, quanHeVoiCMND1 FROM ThanhVienSoHoKhau INNER JOIN QuanHe ON QuanHe.CMND2 = ThanhVienSoHoKhau.CMNDThanhVien WHERE ThanhVienSoHoKhau.maSoHoKhau = '"+hk.MaSoHoKhau+"' AND QuanHe.CMND1 = '"+hk.CMND+"'");
            string sqlStr5 = string.Format("INSERT INTO ThanhVienSoHoKhau(maSoHoKhau, CMNDChuHo, CMNDThanhVien, quanHeVoiChuHo) SELECT '"+maSHKMoi+"', '" + hk.CMND + "', CMNDChuHo, quanHeVoiCMND1 FROM SoHoKhau INNER JOIN QuanHe ON QuanHe.CMND2 = SoHoKhau.CMNDChuHo WHERE SoHoKhau.maSoHoKhau = '" + hk.MaSoHoKhau + "' AND QuanHe.CMND1 = '" + hk.CMND + "'");
            string sqlStr3 = string.Format("DELETE FROM ThanhVienSoHoKhau WHERE maSoHoKhau = '{0}'", hk.MaSoHoKhau);
           // Cập nhật
            string sqlStr2 = string.Format("DELETE FROM SoHoKhau WHERE maSoHoKhau = '{0}'",hk.MaSoHoKhau);
            string sqlStr7 = string.Format("INSERT INTO SoHoKhau (maSoHoKhau, CMNDChuHo, maKV, xaPhuong, quanHuyen, tinhTP, diaChi, ngayLap) SELECT '" + hk.MaSoHoKhau + "', '" + hk.CMND + "', maKV, xaPhuong, quanHuyen, tinhTP, diaChi, ngayLap FROM SoHoKhau WHERE maSoHoKhau = '" + maSHKMoi + "'");
            string sqlStr8 = string.Format("INSERT INTO ThanhVienSoHoKhau(maSoHoKhau, CMNDChuHo, CMNDThanhVien, quanHeVoiChuHo) SELECT '" + hk.MaSoHoKhau + "', '" + hk.CMND + "', CMNDThanhVien, quanHeVoiCMND1 FROM ThanhVienSoHoKhau INNER JOIN QuanHe ON QuanHe.CMND2 = ThanhVienSoHoKhau.CMNDThanhVien WHERE ThanhVienSoHoKhau.maSoHoKhau = '" + maSHKMoi + "' AND QuanHe.CMND1 = '" + hk.CMND + "'");
            string sqlStr9 = string.Format("INSERT INTO ThanhVienSoHoKhau(maSoHoKhau, CMNDChuHo, CMNDThanhVien, quanHeVoiChuHo) SELECT '" + hk.MaSoHoKhau + "', '" + hk.CMND + "', CMNDChuHo, quanHeVoiCMND1 FROM SoHoKhau INNER JOIN QuanHe ON QuanHe.CMND2 = SoHoKhau.CMNDChuHo WHERE SoHoKhau.maSoHoKhau = '" + maSHKMoi + "' AND QuanHe.CMND1 = '" + hk.CMND + "'");
            string sqlStr10 = string.Format("DELETE FROM ThanhVienSoHoKhau WHERE maSoHoKhau = '{0}'", maSHKMoi);
            string sqlStr11 = string.Format("DELETE FROM SoHoKhau WHERE maSoHoKhau = '{0}'", maSHKMoi);

            dbconnection.XuLy(sqlStr);
            dbconnection.XuLy(sqlStr1);
            dbconnection.XuLy(sqlStr5);
            dbconnection.XuLy(sqlStr3);
            dbconnection.XuLy(sqlStr2);
//
            dbconnection.XuLy(sqlStr7);
            dbconnection.XuLy(sqlStr8);
            dbconnection.XuLy(sqlStr9);
            dbconnection.XuLy(sqlStr10);
            dbconnection.XuLy(sqlStr11);
        }
        public void XoaSoHoKhau(SoHoKhau hk)
        {
            string sqlStr1 = string.Format("DELETE FROM ThanhVienSoHoKhau WHERE maSoHoKhau = '{0}'", hk.MaSoHoKhau);
            string sqlStr = string.Format("DELETE FROM SoHoKhau WHERE maSoHoKhau = '{0}'", hk.MaSoHoKhau);
            dbconnection.XuLy(sqlStr1);
            dbconnection.XuLy(sqlStr);
        }
        public void LapSoHoKhau(TextBox txtMaSoHoKhau,TextBox txtCMND, TextBox txtMaKhuVuc,TextBox txtXaPhuong,TextBox txtQuanHuyen,TextBox txtTinhThanhPho,TextBox txtDiaChi,DateTimePicker dtpNgayLap)
        {
                string sqlStr = string.Format("SELECT * FROM SoHoKhau WHERE maSoHoKhau = '" + txtMaSoHoKhau.Text + "'");
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlStr, conn);
                    SqlDataReader dta = cmd.ExecuteReader();
                    while (dta.Read())
                    {
                        txtCMND.Text = Convert.ToString(dta["CMNDChuHo"]);
                        txtMaKhuVuc.Text = Convert.ToString(dta["maKV"]);
                        txtXaPhuong.Text = Convert.ToString(dta["xaPhuong"]);
                        txtQuanHuyen.Text = Convert.ToString(dta["quanHuyen"]);
                        txtTinhThanhPho.Text = Convert.ToString(dta["tinhTP"]);
                        txtDiaChi.Text = Convert.ToString(dta["diaChi"]);
                        dtpNgayLap.Text = Convert.ToString(dta["ngayLap"]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
        }
        public void LapTVSoHoKhau(TextBox txtCMND,TextBox txtCmnd_tv,TextBox txtMaShk_tv,TextBox txtMaSoHoKhau,TextBox txtHoTen_tv,TextBox txtGioiTinh_tv,TextBox txtQuanHe)
        {
            string sqlStr = string.Format("SELECT CongDan.hoTen, CongDan.gioiTinh , QuanHe.quanHeVoiCMND1 FROM QuanHe JOIN CongDan ON CongDan.CMND = QuanHe.CMND2 WHERE QuanHe.CMND1 = '" + txtCMND.Text + "' AND QuanHe.CMND2 = '" + txtCmnd_tv.Text + "' ");
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlStr, conn);
                    SqlDataReader dta = cmd.ExecuteReader();
                    if (dta.Read())
                    {
                        txtMaShk_tv.Text = txtMaSoHoKhau.Text;
                        txtHoTen_tv.Text = Convert.ToString(dta["hoTen"]); ;
                        txtGioiTinh_tv.Text = Convert.ToString(dta["gioiTinh"]);
                        txtQuanHe.Text = Convert.ToString(dta["quanHeVoiCMND1"]);
                    }
                    else
                    {
                        txtMaShk_tv.Text = "";
                        txtHoTen_tv.Text = "" ;
                        txtGioiTinh_tv.Text = "";
                        txtQuanHe.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public void LapThongTin(TextBox txtCmnd_tv,TextBox txtHoTen_tv, TextBox txtGioiTinh_tv)
        {
            string sqlStr = string.Format("SELECT hoTen,gioiTinh FROM CongDan WHERE cmnd = '" + txtCmnd_tv.Text + "' ");
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlStr, conn);
                    SqlDataReader dta = cmd.ExecuteReader();
                    if (dta.Read())
                    {
                        txtHoTen_tv.Text = Convert.ToString(dta["hoTen"]); ;
                        txtGioiTinh_tv.Text = Convert.ToString(dta["gioiTinh"]);
                    }
                    else
                    {
                        txtHoTen_tv.Text = "";
                        txtGioiTinh_tv.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

    }
}
