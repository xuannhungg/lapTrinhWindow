using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_Nhom7
{
    public class ThanhVienShkDAO
    {
        DBConnection dbc = new DBConnection();
        public void ThemThanhVien(ThanhVienShk tv)
        {
            string sqlStr = string.Format("INSERT INTO ThanhVienSoHoKhau(maShk, cccd_ThanhVien, quanHeVoiChuHo) Values ('{0}','{1}','{2}')", tv.MaShk, tv.Cmnd, tv.QuanHe);
            dbc.XuLy(sqlStr);
        }
        public void SuaThanhVien(ThanhVienShk tv)
        {
            string sqlStr = string.Format("UPDATE ThanhVienSoHoKhau SET maShk ='{1}' , quanHeVoiChuHo = '{2}' WHERE cccd_ThanhVien = '{0}'", tv.Cmnd, tv.MaShk, tv.QuanHe);
            dbc.XuLy(sqlStr);
        }
        public void XoaThanhVien(ThanhVienShk tv)
        {
            string sqlStr = string.Format("DELETE FROM ThanhVienSoHoKhau WHERE cccd_ThanhVien = '{0}'", tv.Cmnd);
            dbc.XuLy(sqlStr);
        }
    }
}
