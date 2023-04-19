﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_Nhom7
{
    public class HonNhanDAO
    {
        DBConnection dbc = new DBConnection();
        public bool KiemTraHonNhan(string cmnd)
        {
            string sqlStr = "Select * from CongDan where cmnd = '" + cmnd + "'";
            return dbc.KiemTraHonNhan(sqlStr);
        }
        public bool ThoaDieuKienKetHon(string cmndNam, string cmndNu)
        {
            if (Tuoi(cmndNam) >= 20 && Tuoi(cmndNu) >= 18 && KiemTraHonNhan(cmndNam) == true && KiemTraHonNhan(cmndNu) == true)
                return true;
            else return false;
        }
        public int Tuoi(string cmnd)
        {
            string sqlStr = string.Format("SELECT DATEDIFF(year, cast(ngayThangNamSinh as datetime), getdate()) AS  Tuoi from CongDan Where cmnd = '" + cmnd + "'");
            return dbc.TinhTuoi(sqlStr);
        }
        public bool ThoaDieuKienLyHon(string cmndNam, string cmndNu)
        {
            if (KiemTraHonNhan(cmndNam) == false && KiemTraHonNhan(cmndNu) == false)
                return true;
            else return false;
        }
    }
}
