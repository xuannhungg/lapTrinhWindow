using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_Nhom7
{
    public class CongDanDAO
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.conStr);
        DBConnection dbconnection = new DBConnection();
        public void Them(CongDan cd)
        {
            string sqlStr = string.Format("INSERT INTO CongDan( hoTen , ngayThangNamSinh , gioiTinh , cmnd , danToc , tinhTrangHonNhan , noiDangKiKhaiSinh,queQuan,noiThuongTru,trinhDoHocVan,ngheNghiep, luong,tamTru,noiCapCMND,ngayCap,soLanKetHon,quocTich)  VALUES ('{0}', '{1}','{2}', '{3}','{4}', '{5}','{6}','{7}','{8}','{9}','{10}', '{11}', '{12}', '{13}', '{14}', '{15}','{16}')", cd.HoTen,cd.NgayThangNamSinh,cd.GioiTinh,cd.CMND,cd.DanToc,cd.TinhTrangHonNhan,cd.NoiDangKiKhaiSinh,cd.QueQuan,cd.NoiThuongTru,cd.TrinhDoHocVan,cd.NgheNghiep, cd.Luong,cd.tamTru,cd.noiCapCMND,cd.NgayCap,cd.soLanKetHon,cd.QuocTich);
            dbconnection.XuLy(sqlStr);
        }
        public void Sua(CongDan cd)
        {
            string sqlStr = string.Format("UPDATE CongDan SET hoTen ='{12}',  ngayThangNamSinh = '{0}', gioiTinh= '{1}' , cmnd = '{2}', danToc= '{3}', tinhTrangHonNhan='{4}', noiDangKiKhaiSinh= '{5}', queQuan='{6}', noiThuongTru= '{7}', trinhDoHocVan= '{8}', luong = '{9}', ngheNghiep='{10}', tamTru = '{13}', noiCapCMND = '{14}', ngayCap = '{15}', soLanKetHon = '{16}',quocTich = '{17}' WHERE cmnd = '{11}'",  cd.NgayThangNamSinh, cd.GioiTinh, cd.CMND, cd.DanToc, cd.TinhTrangHonNhan, cd.NoiDangKiKhaiSinh, cd.QueQuan, cd.NoiThuongTru, cd.TrinhDoHocVan, cd.Luong, cd.NgheNghiep,cd.CMND,cd.HoTen,cd.tamTru,cd.noiCapCMND,cd.NgayCap,cd.soLanKetHon,cd.QuocTich);
            dbconnection.XuLy(sqlStr);
        }
        public void Xoa(CongDan cd)
        {
            string mashk = dbconnection.timMaSHK(cd.CMND);
            string sqlStr1 = string.Format("delete from ThanhVienSoHoKhau where CMNDThanhVien ='{0}'", cd.CMND);
            string sqlStr2 = string.Format("delete from QuanHe where CMND1 = '{0}' or CMND2 = '{1}'",cd.CMND,cd.CMND);
            string sqlStr = string.Format("DELETE FROM CongDan WHERE cmnd = '{0}'", cd.CMND);
            string sqlStr3 = string.Format("delete from ThanhVienSoHoKhau where CMNDChuHo ='{0}'", cd.CMND);
            string sqlStr4 = string.Format("delete from SoHoKhau where CMNDChuHo ='{0}'", cd.CMND);
            dbconnection.XuLy(sqlStr1);
            dbconnection.XuLy(sqlStr3);
            dbconnection.XuLy(sqlStr4);
            dbconnection.XuLy(sqlStr2);
            dbconnection.XuLy(sqlStr);
        }
        public DataTable DanhSach()
        {
            string sqlStr ="select * from CongDan";
            return dbconnection.DanhSach(sqlStr);
        }
        public void CapNhatLyHon(CongDan cd)
        {
            string sqlStr = string.Format("UPDATE CongDan SET  tinhTrangHonNhan='Doc Than' WHERE CMND = '{0}'", cd.CMND);
            dbconnection.XuLy(sqlStr);
        }
        public void CapNhatQuanHeLyHon(CongDan a,CongDan b)
        {
            string sqlStr = string.Format("delete from QuanHe where CMND1 ='{0}' and CMND2='{1}'",a.CMND, b.CMND);
            dbconnection.XuLy(sqlStr);
        }
        public void CapNhatTamTru(CongDan cd)
        {
            string n = "";
            string sqlStr = string.Format("Select * from CongDan where cmnd = '" + cd.cmnd + "'");
            n = dbconnection.CapNhatTamTru(sqlStr, n);
            string sqlStr2 = string.Format("UPDATE CongDan SET tamTru = '{0} {1}\n{2}' WHERE CMND ='{3}'", cd.tamTru, cd.ngayCap, n, cd.CMND);
            dbconnection.XuLy(sqlStr2);
        }
        public void CapNhatKetHon(CongDan nam,CongDan nu)
        {
            string sqlStr = string.Format("UPDATE CongDan SET  tinhTrangHonNhan='Da Ket Hon Voi Nguoi Co CMND La " + nu.CMND + "' WHERE CMND = '{0}'", nam.CMND);
            dbconnection.XuLy(sqlStr);
            string sqlStr1 = string.Format("UPDATE CongDan SET  tinhTrangHonNhan='Da Ket Hon Voi Nguoi Co CMND La " + nam.CMND + "' WHERE CMND = '{0}'", nu.CMND);
            dbconnection.XuLy(sqlStr1);
        }
        public DataSet TimCongDanDaKetHon(DataGridView dtgv)
        {
            string sqlStr = "SELECT * from CongDan WHERE tinhTrangHonNhan != 'Doc Than'";
            return dbconnection.TimCongDanDaKetHon(sqlStr, dtgv);
        }
        public DataSet TimCongDanDocThan(DataGridView dtgv)
        {
            string sqlStr = "SELECT * from CongDan WHERE tinhTrangHonNhan = 'Doc Than'";
            return dbconnection.TimCongDanDaKetHon(sqlStr, dtgv);
        }
        public DataSet TimCongDanTheoCCCD(string cccd, DataGridView dtgv)
        {
            string sqlStr = "SELECT * from CongDan WHERE cmnd = '" + cccd + "'";
            return dbconnection.TimCongDanTheoCCCD(sqlStr, dtgv);
        }
    }
}
