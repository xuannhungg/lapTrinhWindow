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
            string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', '{2}','{3}')", tv.CmndThanhVien, tv.CmndChuHo, "Bo", "Con");
            dbc.XuLy(sqlStr);
            dbc.XuLy(sqlStr1);
        }
        public void ThietLapMoiQuanHeVoChong(ThanhVienShk tv)
        {
            if (dbc.ChuaCoQuanHe(tv.CmndChuHo, tv.CmndThanhVien) && dbc.ChuaCoQuanHe(tv.CmndThanhVien, tv.CmndChuHo))
            {
                string sqlStr = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', '{2}','{3}')", tv.CmndChuHo, tv.CmndThanhVien, "Vo", "Chong");
                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', '{2}','{3}')", tv.CmndThanhVien, tv.CmndChuHo, "Chong", "Vo");
                //string sqlStr1 = string.Format("UPDATE QuanHe SET quanHeVoiCMND1 = 'Vo', quanHeVoiCMND2 = 'Chong' WHERE CMND1 = '{0}' AND CMND2 = '{1}'", tv.CmndChuHo, tv.CmndThanhVien);
                dbc.XuLy(sqlStr);
                dbc.XuLy(sqlStr1);
            }
        }
        public void ThietLapMoiQuanHeBoConDau(ThanhVienShk tv)
        {
            string sqlStr = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', '{2}','{3}')", tv.CmndChuHo, tv.CmndThanhVien, "Con Dau", "Bo Chong");
            string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', '{2}','{3}')",  tv.CmndThanhVien, tv.CmndChuHo, "Bo Chong", "Con Dau");

            //string sqlStr1 = string.Format("UPDATE QuanHe SET quanHeVoiCMND1 = 'Con Dau', quanHeVoiCMND2 = 'Bo Chong' WHERE CMND1 = '{0}' AND CMND2 = '{1}'", tv.CmndChuHo, tv.CmndThanhVien);
            dbc.XuLy(sqlStr);
            dbc.XuLy(sqlStr1);
        }
        public void ThietLapMoiQuanHeOngChau(ThanhVienShk tv)
        {

                string sqlStr = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', '{2}','{3}')", tv.CmndChuHo, tv.CmndThanhVien, "Chau", "Ong");
                string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', '{2}','{3}')", tv.CmndThanhVien, tv.CmndChuHo, "Ong", "Chau");

                //string sqlStr1 = string.Format("UPDATE QuanHe SET quanHeVoiCMND1 = 'Con Dau', quanHeVoiCMND2 = 'Bo Chong' WHERE CMND1 = '{0}' AND CMND2 = '{1}'", tv.CmndChuHo, tv.CmndThanhVien);
                dbc.XuLy(sqlStr);
                dbc.XuLy(sqlStr1);
            
        }
        public void ThietLapQuanHeGiaDinh(ThanhVienShk tv)
        {
            string sqlStr = string.Format("SELECT CMNDThanhVien,quanHeVoiChuHo FROM ThanhVienSoHoKhau WHERE maSoHoKhau = '" + tv.MaShk+ "'");
            if (tv.QuanHe == "Con Dau")
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlStr, conn);
                    SqlDataReader dta = cmd.ExecuteReader();
                    while (dta.Read())
                    {
                        string a = Convert.ToString(dta["CMNDThanhVien"]);
                        string b = Convert.ToString(dta["quanHeVoiChuHo"]);
                        if ((b == "Con Trai" || b=="Con Gai") && dbc.ChuaCoQuanHe(a,tv.CmndThanhVien) && dbc.ChuaCoQuanHe( tv.CmndThanhVien,a))
                        {

                            string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', '{2}','{3}')", a, tv.CmndThanhVien, "Chi Dau", "Em Re");
                            string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', '{2}','{3}')", tv.CmndThanhVien, a, "Em Re", "Chi Dau");
                            dbc.XuLy(sqlStr1);
                            dbc.XuLy(sqlStr2);
                        }
                        else if (b == "Vo" )
                        {
                            string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', '{2}','{3}')", a, tv.CmndThanhVien, "Con Dau", "Me Chong");
                            string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', '{2}','{3}')", tv.CmndThanhVien, a, "Me Chong", "Con Dau");
                            dbc.XuLy(sqlStr1);
                            dbc.XuLy(sqlStr2);
                        }
                        else if (b == "Chau" )
                        {
                            string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', '{2}','{3}')", a, tv.CmndThanhVien, "Mu", "Chau");
                            string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', '{2}','{3}')", tv.CmndThanhVien, a, "Chau", "Mu");
                            dbc.XuLy(sqlStr1);
                            dbc.XuLy(sqlStr2);
                        }

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
            else if (tv.QuanHe == "Chau")
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlStr, conn);
                    SqlDataReader dta = cmd.ExecuteReader();
                    while (dta.Read())
                    {
                        string a = Convert.ToString(dta["CMNDThanhVien"]);
                        string b = Convert.ToString(dta["quanHeVoiChuHo"]);
                        if ((b == "Con Trai" ) && dbc.ChuaCoQuanHe(a, tv.CmndThanhVien) && dbc.ChuaCoQuanHe(tv.CmndThanhVien, a))
                        {

                            string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', '{2}','{3}')", a, tv.CmndThanhVien, "Chau", "Chu");
                            string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', '{2}','{3}')", tv.CmndThanhVien, a, "Chu", "Chau");
                            dbc.XuLy(sqlStr1);
                            dbc.XuLy(sqlStr2);
                        }
                        else if (( b == "Con Gai") && dbc.ChuaCoQuanHe(a, tv.CmndThanhVien) && dbc.ChuaCoQuanHe(tv.CmndThanhVien, a))
                        {

                            string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', '{2}','{3}')", a, tv.CmndThanhVien, "Chau", "Di");
                            string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', '{2}','{3}')", tv.CmndThanhVien, a, "Di", "Chau");
                            dbc.XuLy(sqlStr1);
                            dbc.XuLy(sqlStr2);
                        }
                        else if (b == "Vo")
                        {
                            string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', '{2}','{3}')", a, tv.CmndThanhVien, "Chau", "Ba");
                            string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', '{2}','{3}')", tv.CmndThanhVien, a, "Ba", "Chau");
                            dbc.XuLy(sqlStr1);
                            dbc.XuLy(sqlStr2);
                        }

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
            else if (tv.QuanHe == "Vo")
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlStr, conn);
                    SqlDataReader dta = cmd.ExecuteReader();
                    while (dta.Read())
                    {
                        string a = Convert.ToString(dta["CMNDThanhVien"]);
                        string b = Convert.ToString(dta["quanHeVoiChuHo"]);
                        if ((b == "Bo") )
                        {

                            string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', '{2}','{3}')", a, tv.CmndThanhVien, "Con Dau", "Bo Chong");
                            string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', '{2}','{3}')", tv.CmndThanhVien, a, "Bo Chong", "Con Dau");
                            dbc.XuLy(sqlStr1);
                            dbc.XuLy(sqlStr2);
                        }
                        else if ((b == "Me") && dbc.ChuaCoQuanHe(a, tv.CmndThanhVien) && dbc.ChuaCoQuanHe(tv.CmndThanhVien, a))
                        {

                            string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', '{2}','{3}')", a, tv.CmndThanhVien, "Con Dau", "Me Chong");
                            string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', '{2}','{3}')", tv.CmndThanhVien, a, "Me Chong", "Con Dau");
                            dbc.XuLy(sqlStr1);
                            dbc.XuLy(sqlStr2);
                        }
                        else if (b == "Anh" || b== "Em")
                        {
                            string sqlStr1 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', '{2}','{3}')", a, tv.CmndThanhVien, "Chi Dau", "Em");
                            string sqlStr2 = string.Format("INSERT INTO QuanHe(CMND1, CMND2, quanHeVoiCMND1, quanHeVoiCMND2) VALUES ('{0}', '{1}', '{2}','{3}')", tv.CmndThanhVien, a, "Em", "Chi Dau");
                            dbc.XuLy(sqlStr1);
                            dbc.XuLy(sqlStr2);
                        }

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
        public void ThemThanhVien(ThanhVienShk tv)
        {
            if (tv.QuanHe == "Con")
                ThietLapMoiQuanHeBoCon(tv);
            else if(tv.QuanHe=="Vo")
                ThietLapMoiQuanHeVoChong(tv);
            else if(tv.QuanHe == "Con Dau")
                ThietLapMoiQuanHeBoConDau(tv);
            else if (tv.QuanHe == "Chau")
                ThietLapMoiQuanHeOngChau(tv);
            ThietLapQuanHeGiaDinh(tv);
            string sqlStr = string.Format("INSERT INTO ThanhVienSoHoKhau(maSoHoKhau, CMNDChuHo, CMNDThanhVien, quanHeVoiChuHo) SELECT '{0}', '{1}', '{2}', quanHeVoiCMND1 FROM QuanHe WHERE CMND1 = '{1}' AND CMND2 = '{2}'", tv.MaShk,tv.CmndChuHo, tv.CmndThanhVien);
            dbc.XuLy(sqlStr);
        }
        public void SuaThanhVien(ThanhVienShk tv,string qh1)
        {
           string qh2 = "";
            if (qh1 == "Con")
                qh2 = "Bo";
            else if (qh1 == "Con Dau")
                qh2 = "Bo Chong";
            else
                qh2 = "Chong";
            string sqlStr = string.Format("UPDATE QuanHe SET quanHeVoiCMND1 = '"+qh1+"', quanHeVoiCMND2 = '"+qh2+"' WHERE CMND1 = '{0}' AND CMND2 = '{1}'", tv.CmndChuHo, tv.CmndThanhVien);
            string sqlStr1 = string.Format("UPDATE ThanhVienSoHoKhau SET quanHeVoiChuHo = (SELECT quanHeVoiCMND1 FROM QuanHe WHERE CMND1 = '{1}' AND CMND2 = '{2}') WHERE maSoHoKhau = '{0}' AND CmndChuHo = '{1}' AND CmndThanhVien = '{2}'", tv.MaShk, tv.CmndChuHo, tv.CmndThanhVien);

            dbc.XuLy(sqlStr);
            dbc.XuLy(sqlStr1);
        }
        public void XoaThanhVien(ThanhVienShk tv)
        {
            string sqlStr = string.Format("SELECT CMNDThanhVien,quanHeVoiChuHo FROM ThanhVienSoHoKhau WHERE maSoHoKhau = '" + tv.MaShk + "'");
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                SqlDataReader dta = cmd.ExecuteReader();
                while (dta.Read())
                {
                    string a = Convert.ToString(dta["CMNDThanhVien"]);
                    string b = Convert.ToString(dta["quanHeVoiChuHo"]);
                    string sqlStr1 = string.Format("DELETE FROM QuanHe WHERE CMND1='{0}' AND CMND2 ='{1}' ", a, tv.CmndThanhVien);
                    string sqlStr2 = string.Format("DELETE FROM QuanHe WHERE CMND1='{0}' AND CMND2 ='{1}' ", tv.CmndThanhVien, a);
                    dbc.XuLy(sqlStr1);
                    dbc.XuLy(sqlStr2);
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

            string sqlStr4 = string.Format("delete from QuanHe where CMND1 ='{0}' and CMND2='{1}'",tv.CmndChuHo,tv.CmndThanhVien);
            string sqlStr5 = string.Format("delete from QuanHe where CMND1 ='{0}' and CMND2='{1}'", tv.CmndThanhVien, tv.CmndChuHo);

            string sqlStr3 = string.Format("DELETE FROM ThanhVienSoHoKhau WHERE CMNDThanhVien = '{0}'", tv.CmndThanhVien);
            dbc.XuLy(sqlStr3);
            dbc.XuLy(sqlStr4);
            dbc.XuLy(sqlStr5);

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
