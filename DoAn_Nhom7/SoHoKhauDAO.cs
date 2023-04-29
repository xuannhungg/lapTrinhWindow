using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            string sqlStr1 = string.Format("select shk.maSoHoKhau,cd.cmnd, cd.hoten ,cd.gioiTinh,'chu ho' AS QuanHe  FROM CongDan cd INNER JOIN SoHoKhau shk ON cd.cmnd = shk.CMND where shk.maSoHoKhau = '" + maShk + "'");
            string sqlStr2 = string.Format("SELECT shk.maSoHoKhau, cd.cmnd, cd.hoTen, cd.gioiTinh, tv.quanHeVoiChuHo FROM ThanhVienSoHoKhau tv, SoHoKhau shk, CongDan cd WHERE tv.maShk = shk.maSoHoKhau and cd.cmnd = tv.cccd_ThanhVien and shk.maSoHoKhau = '" + maShk + "'");
            string sqlStr = sqlStr1 + " UNION " + sqlStr2;
            return dbconnection.DanhSach(sqlStr);
        }
        public void ThemSoHoKhau(SoHoKhau hk)
        {
            string sqlStr = string.Format("INSERT INTO SoHoKhau (maSoHoKhau, cmnd, maKV, xaPhuong, quanHuyen, tinhTP, diaChi,ngayLap)  VALUES ('{0}', '{1}','{2}', '{3}', '{4}', '{5}', '{6}', '{7}')", hk.MaSoHoKhau, hk.CMND, hk.MaKV, hk.XaPhuong, hk.QuanHuyen, hk.TinhThanhPho
            , hk.DiaChi, hk.NgayLap);
            dbconnection.XuLy(sqlStr);
        }
        public void SuaSoHoKhau(SoHoKhau hk)
        {
            string sqlStr = string.Format("UPDATE SoHoKhau SET cmnd='{1}', maKV = '{2}',  xaPhuong = '{3}' , quanHuyen = '{4}', tinhTP = '{5}',diaChi = '{6}', ngayLap = '{7}' WHERE maSoHoKhau = '{0}'", hk.MaSoHoKhau, hk.CMND, hk.MaKV, hk.XaPhuong, hk.QuanHuyen, hk.TinhThanhPho
            , hk.DiaChi, hk.NgayLap);
            dbconnection.XuLy(sqlStr);
        }
        public void XoaSoHoKhau(SoHoKhau hk)
        {
            string sqlStr = string.Format("DELETE FROM SoHoKhau WHERE maSoHoKhau = '{0}'", hk.MaSoHoKhau);
            dbconnection.XuLy(sqlStr);
        }
    }
}
