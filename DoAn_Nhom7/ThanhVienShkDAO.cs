using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_Nhom7
{
    public class ThanhVienShkDAO
    {
        DBConnection dbc = new DBConnection();
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.conStr);

        public void ThietLapMoiQuanHeBoCon(ThanhVienShk tv)
        {
            string sqlStr = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', '{2}','{3}')", tv.CmndChuHo, tv.CmndThanhVien, "Con", "Bo");
            dbc.XuLy(sqlStr);
        }
        public void ThietLapMoiQuanHeVoChong(ThanhVienShk tv)
        {
            string sqlStr = string.Format("UPDATE QuanHe SET quanHeVoiCMND1 = 'Vo', quanHeVoiCMND2 = 'Chong' WHERE CMND1 = '{0}' AND CMND2 = '{1}'", tv.CmndChuHo, tv.CmndThanhVien);
            dbc.XuLy(sqlStr);
        }
        public void ThemThanhVien(ThanhVienShk tv)
        {
            if (tv.QuanHe == "Con")
                ThietLapMoiQuanHeBoCon(tv);
            else
                ThietLapMoiQuanHeVoChong(tv);
            string sqlStr = string.Format("INSERT INTO ThanhVienSoHoKhau(maSoHoKhau, CMNDChuHo, CMNDThanhVien, quanHeVoiChuHo) SELECT '{0}', '{1}', '{2}', quanHeVoiCMND1 FROM QuanHe WHERE CMND1 = '{1}' AND CMND2 = '{2}'", tv.MaShk,tv.CmndChuHo, tv.CmndThanhVien);
            dbc.XuLy(sqlStr);
        }
        public void SuaThanhVien(ThanhVienShk tv,string qh1)
        {
           string qh2 = "";
            if (qh1 == "Con")
                qh2 = "Bo";
            else
                qh2 = "Chong";
            string sqlStr = string.Format("UPDATE QuanHe SET quanHeVoiCMND1 = '"+qh1+"', quanHeVoiCMND2 = '"+qh2+"' WHERE CMND1 = '{0}' AND CMND2 = '{1}'", tv.CmndChuHo, tv.CmndThanhVien);
            string sqlStr1 = string.Format("UPDATE ThanhVienSoHoKhau SET quanHeVoiChuHo = (SELECT quanHeVoiCMND1 FROM QuanHe WHERE CMND1 = '{1}' AND CMND2 = '{2}') WHERE maSoHoKhau = '{0}' AND CmndChuHo = '{1}' AND CmndThanhVien = '{2}'", tv.MaShk, tv.CmndChuHo, tv.CmndThanhVien);

            dbc.XuLy(sqlStr);
            dbc.XuLy(sqlStr1);
        }
        public void XoaThanhVien(ThanhVienShk tv)
        {
            string sqlStr = string.Format("DELETE FROM ThanhVienSoHoKhau WHERE CMNDThanhVien = '{0}'", tv.CmndThanhVien);
            dbc.XuLy(sqlStr);
        }
        public void DienThanhVienSHK(string cmnd, TextBox mashk, TextBox hoten, TextBox gioitinh, TextBox quanhe)
        {
            string sqlStr = string.Format("SELECT SHK.maSoHoKhau, CD.hoTen, CD.gioiTinh, TVSHK.quanHeVoiChuHo FROM CongDan CD INNER JOIN ThanhVienSoHoKhau TVSHK ON CD.cmnd = TVSHK.CMNDThanhVien INNER JOIN SoHoKhau SHK ON SHK.maSoHoKhau = TVSHK.maSoHoKhau AND SHK.CMNDChuHo = TVSHK.CMNDChuHo WHERE CD.cmnd == '{0}'",cmnd);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                SqlDataReader dta = cmd.ExecuteReader();
                while (dta.Read())
                {
                    mashk.Text = Convert.ToString(dta["maSoHoKhau"]);
                    hoten.Text = Convert.ToString(dta["hoTen"]); ;
                    gioitinh.Text = Convert.ToString(dta["gioiTinh"]);
                    quanhe.Text = Convert.ToString(dta["quanHeVoiChuHo"]);
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
