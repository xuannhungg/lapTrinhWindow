using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DoAn_Nhom7
{
    public class DBConnection
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.conStr);
        public void XuLy(string sqlStr)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                if (cmd.ExecuteNonQuery() > 0)
                    MessageBox.Show("thanh cong");
            }
            catch (Exception ex)
            {
                MessageBox.Show("That bai" + ex);
            }
            finally
            {
                conn.Close();
            }
        }
        public DataTable DanhSach(string sqlStr)
        {
            DataTable dtds = new DataTable();
            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
                adapter.Fill(dtds);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn.Close();
            }
            return dtds;
        }
        public DataSet timCongDanTheoCCCD(string sqlStr, Thue thue)
        {
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
            DataSet dts = new DataSet();
            adapter.Fill(dts, "CCCD");
            conn.Close();
            return dts;
        }
        public void LapDayThongTin(string sqlStr, TextBox cmnd, TextBox hoTen, TextBox ngaySinh, TextBox danToc, TextBox queQuan, TextBox thuongTru)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            SqlDataReader dta = cmd.ExecuteReader();
            while (dta.Read())
            {
                hoTen.Text = Convert.ToString(dta["hoTen"]);
                ngaySinh.Text = Convert.ToString(dta["ngayThangNamSinh"]); ;
                danToc.Text = Convert.ToString(dta["danToc"]);
                queQuan.Text = Convert.ToString(dta["queQuan"]);
                thuongTru.Text = Convert.ToString(dta["noiThuongTru"]);
            }
            conn.Close();
        }
        public void LapDayThongTinTamTru(string sqlStr, TextBox cmnd, TextBox hoTen, TextBox ngaySinh, TextBox queQuan, TextBox thuongTru)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                SqlDataReader dta = cmd.ExecuteReader();
                while (dta.Read())
                {
                    hoTen.Text = Convert.ToString(dta["hoTen"]);
                    ngaySinh.Text = Convert.ToString(dta["ngayThangNamSinh"]); ;
                    queQuan.Text = Convert.ToString(dta["queQuan"]);
                    thuongTru.Text = Convert.ToString(dta["noiThuongTru"]);
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
        public string CapNhatTamTru(string sqlStr, string n)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                SqlDataReader dta = cmd.ExecuteReader();
                while (dta.Read())
                {
                    n = n + Convert.ToString(dta["tamTru"]);
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
            return n;
        }
        public void LapDayThongTinCD(TextBox cmnd, TextBox a, DateTimePicker dt, RadioButton b,RadioButton b1, TextBox d, TextBox f, TextBox g, TextBox j, TextBox k, TextBox x, TextBox y, TextBox z, TextBox i, TextBox t, TextBox n, DateTimePicker m,TextBox p)
        {
            conn.Open();
            string sqlStr = "Select * from CongDan where cmnd = '" + cmnd.Text + "'";
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            SqlDataReader dta = cmd.ExecuteReader();
            while (dta.Read())
            {
                a.Text = Convert.ToString(dta["hoTen"]);
                dt.Text = Convert.ToString(dta["ngayThangNamSinh"]);
                if (Convert.ToString(dta["gioiTinh"]) == "nu")
                    b.Checked=true;
                else
                    b1.Checked=true;
                d.Text = Convert.ToString(dta["danToc"]);
                f.Text = Convert.ToString(dta["tinhTrangHonNhan"]);
                g.Text = Convert.ToString(dta["noiDangKiKhaiSinh"]);
                j.Text = Convert.ToString(dta["queQuan"]);
                k.Text = Convert.ToString(dta["noiThuongTru"]);
                x.Text = Convert.ToString(dta["trinhDoHocVan"]);
                y.Text = Convert.ToString(dta["ngheNghiep"]);
                z.Text = Convert.ToString(dta["luong"]);
                i.Text = Convert.ToString(dta["soLanKetHon"]);
                t.Text = Convert.ToString(dta["tamTru"]);
                n.Text = Convert.ToString(dta["noiCapCMND"]);
                m.Text = Convert.ToString(dta["ngayCap"]);
                p.Text = Convert.ToString(dta["QuocTich"]);
            }
            conn.Close();
        }
        public string CMNDVoChong(string cmnd)
        {
            conn.Open();
            string a = "";
            string sqlStr = "Select * from CongDan where cmnd = '" + cmnd + "'";
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            SqlDataReader dta = cmd.ExecuteReader();
            if (dta.Read())
            {
                a = Convert.ToString(dta["tinhTrangHonNhan"]);
                if (a != "Doc Than")
                    a = a.Substring(32);
                else a = "";
            }
            conn.Close();
            return a;
        }
        public bool KiemTraHonNhan(string sqlStr)
        {
            conn.Open();
            //string sqlStr = "Select * from CongDan where cmnd = '" + cmnd + "'";
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string a = Convert.ToString(dr["tinhTrangHonNhan"]);
                if (a == "chua ket hon")
                {
                    conn.Close();
                    return true;
                }
            }
            conn.Close();
            return false;
        }
        public bool KiemTraVoChong(string sqlStr, string a, string b)
        {
            conn.Open();
            //string sqlStr = "Select * from CongDan where cmnd = '" + cmnd + "'";
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                a = Convert.ToString(dr["tinhTrangHonNhan"]);
                string cmnd = a.Substring(32);
                if (cmnd == b)
                {
                    conn.Close();
                    return true;
                }
            }
            conn.Close();
            return false;
        }
        public int SoLuongThanhVien(string cmnd)
        {
            string a = timMaSHK(cmnd);
            conn.Open();
            string sqlStr = "SELECT COUNT(*) FROM ThanhVienSoHoKhau WHERE maSoHoKhau = '" + a + "'";
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            int k = (int)cmd.ExecuteScalar();
            MessageBox.Show("a" + k);
            conn.Close();
            return k;
        }
        public void LapDayThongTinLyHon(string sqlStr, string cmnd, TextBox hoTen, TextBox ngaySinh, TextBox thuongTru)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                SqlDataReader dta = cmd.ExecuteReader();
                while (dta.Read())
                {
                    hoTen.Text = Convert.ToString(dta["hoTen"]);
                    ngaySinh.Text = Convert.ToString(dta["ngayThangNamSinh"]);
                    thuongTru.Text = Convert.ToString(dta["noiThuongTru"]);
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
        public DataSet TimCongDanDaKetHon(string sqlStr, DataGridView dtgv)
        {
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlStr, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "tinhTrangHonNhan");
            if (ds.Tables["tinhTrangHonNhan"].Rows.Count > 0)
            {
                dtgv.DataSource = ds.Tables["hoTen"];
            }
            else
            {
                MessageBox.Show("Không tìm thấy!");
            }
            conn.Close();
            return ds;
        }
        public DataSet TimCongDanTheoCCCD(string sqlStr, DataGridView dtgv)
        {
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlStr, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "cmnd");
            if (ds.Tables["cmnd"].Rows.Count > 0)
            {
                dtgv.DataSource = ds.Tables["cmnd"];
            }
            else
            {
                MessageBox.Show("Không tìm thấy ai có CMND này!");
            }
            conn.Close();
            return ds;
        }
        public int TinhTuoi(string sqlStr)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            int tuoi = 0;
            if (dr.Read())
            {
                tuoi = Convert.ToInt32(dr["Tuoi"].ToString());
                MessageBox.Show("Tinh tuoi thanh cong");
            }
            conn.Close();
            return tuoi;
        }
        public void KhaiTu_KeyDown(string sqlStr, TextBox cmnd, TextBox ten, TextBox ngsinh, TextBox honNhan, TextBox noiThuongTru, TextBox gioiTinh, TextBox danToc, TextBox quocTich, TextBox queQuan, TextBox ngheNghiep)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            SqlDataReader dta = cmd.ExecuteReader();
            while (dta.Read())
            {
                ten.Text = Convert.ToString(dta["hoTen"]);
                ngsinh.Text = Convert.ToString(dta["ngayThangNamSinh"]);
                gioiTinh.Text = Convert.ToString(dta["gioiTinh"]);
                danToc.Text = Convert.ToString(dta["danToc"]);
                honNhan.Text = Convert.ToString(dta["tinhTrangHonNhan"]);
                quocTich.Text = "hhh";
                queQuan.Text = Convert.ToString(dta["queQuan"]);
                noiThuongTru.Text = Convert.ToString(dta["noiThuongTru"]);
                ngheNghiep.Text = Convert.ToString(dta["ngheNghiep"]);
            }
            conn.Close();
        }
        public void KhaiSinh_KeyDown(TextBox cmnd, TextBox ten, TextBox danToc,TextBox quocTich)
        {
            conn.Open();
            string sqlStr = "Select * from CongDan where cmnd = '" + cmnd.Text + "'";
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            SqlDataReader dta = cmd.ExecuteReader();
            while (dta.Read())
            {
                ten.Text = Convert.ToString(dta["hoTen"]);
                danToc.Text = Convert.ToString(dta["danToc"]);
                quocTich.Text = Convert.ToString(dta["quocTich"]);
            }
            conn.Close();
        }
        public string timMaSHK(string cmnd)
        {
            conn.Open();
            string sqlStr = "SELECT maSoHoKhau FROM SoHoKhau WHERE CMNDChuHo = '" + cmnd + "'";

            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            SqlDataReader dta = cmd.ExecuteReader();
            while (dta.Read())
            {

                string a = Convert.ToString(dta["maSoHoKhau"]);
                conn.Close();
                return a;
            }
            conn.Close();
            return null;
        }

        public bool KiemTraTaiKhoanTonTai(string input)
        {
            conn.Open();
            string sqlStr = string.Format("SELECT * FROM TaiKhoan WHERE TaiKhoan = '{0}'", input);
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader["TaiKhoan"].ToString() == input)
                    return true;
            }
            conn.Close();
            return false;
        }
        public bool KiemTraSHK(string cmnd)
        {
            conn.Open();
            //string sqlStr = "Select * from CongDan where cmnd = '" + cmnd + "'";
            //string sqlStr = " SELECT maSoHoKhau FROM ThanhVienSoHoKhau WHERE CMNDThanhVien= '" + cmnd + "'";
            string sqlStr = " SELECT maSoHoKhau FROM SoHoKhau WHERE CMNDChuHo= '" + cmnd + "'";
            //string sqlStr = sqlStr2 + "UNION" + sqlStr1;
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string a = Convert.ToString(dr["maSoHoKhau"]);
                if (a != null)
                {
                    conn.Close();
                    return false;
                }
            }
            conn.Close();
            return true;
        }
        public bool KiemTraTVSHK(string cmnd)
        {
            conn.Open();
            //string sqlStr = "Select * from CongDan where cmnd = '" + cmnd + "'";
            string sqlStr = " SELECT maSoHoKhau FROM ThanhVienSoHoKhau WHERE CMNDThanhVien= '" + cmnd + "'";
            //string sqlStr2 = " SELECT maSoHoKhau FROM SoHoKhau WHERE CMNDChuHo= '" + cmnd1 + "'";
            //string sqlStr = sqlStr2 + "UNION" + sqlStr1;
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string a = Convert.ToString(dr["maSoHoKhau"]);
                if (a != null)
                {
                    conn.Close();
                    return false;
                }
            }
            conn.Close();
            return true;
        }
        public void LapDayThongTinKhaiSinhBoMe(string cmnd, Label a1, Label a2, Label a3, Label a4, Label a5)
        {
            conn.Open();
            string sqlStr = "Select * from CongDan where cmnd = '" + cmnd + "'";
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            SqlDataReader dta = cmd.ExecuteReader();
            while (dta.Read())
            {
                a1.Text = Convert.ToString(dta["hoTen"]);
                a2.Text = Convert.ToString(dta["ngayThangNamSinh"]); ;
                a3.Text = Convert.ToString(dta["danToc"]);
                a4.Text = Convert.ToString(dta["queQuan"]);
                a5.Text = Convert.ToString(dta["noiThuongTru"]);
            }
            conn.Close();
        }
        public string timCMNDBo(string maSHK)
        {
            conn.Open();
            string sqlStr = string.Format("select shk.maSoHoKhau,cd.cmnd, cd.hoten ,cd.gioiTinh,'chu ho' AS QuanHe  FROM CongDan cd INNER JOIN SoHoKhau shk ON cd.cmnd = shk.CMNDChuHo where shk.maSoHoKhau = '" + maSHK + "'");
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            SqlDataReader dta = cmd.ExecuteReader();
            while (dta.Read())
            {
                string a = Convert.ToString(dta["cd.cmnd"]);
                conn.Close();
                return a;
            }
            conn.Close();
            return null;
        }
            //thue
        public void LayThongTinCongDan_Thue(string sqlStr, DataGridView dtgv, TextBox luong, TextBox ten, TextBox nghe)
        {
            try
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(sqlStr, conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "CCCD");
                if (ds.Tables["CCCD"].Rows.Count > 0)
                    dtgv.DataSource = ds.Tables["CCCD"];

                luong.Text = ds.Tables["CCCD"].Rows[0][11].ToString();
                ten.Text = ds.Tables["CCCD"].Rows[0][0].ToString();
                nghe.Text = ds.Tables["CCCD"].Rows[0][10].ToString();
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
        public void XuLyThongKeDanSo(string sqlStr, Chart chartTyLeNamNu)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                chartTyLeNamNu.DataSource = ds;
                chartTyLeNamNu.Series["Tỷ Lệ Nam Nữ"].XValueMember = "gioiTinh";
                chartTyLeNamNu.Series["Tỷ Lệ Nam Nữ"].YValueMembers = "soLuong";
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
