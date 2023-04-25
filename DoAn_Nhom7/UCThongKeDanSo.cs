using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DoAn_Nhom7
{
    public partial class UCThongKeDanSo : UserControl
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.conStr);
        CongDanDAO cddao = new CongDanDAO();
        DBConnection dbconnection = new DBConnection();
        public UCThongKeDanSo()
        {
            InitializeComponent();
        }

        private void UCThongKeDanSo_Load(object sender, EventArgs e)
        {
            conn.Open();
            string sqlStr = "Select gioiTinh, count(*) as soLuong from CongDan group by gioiTinh";
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            chartTyLeNamNu.DataSource = ds;
            chartTyLeNamNu.Series["Tỷ Lệ Nam Nữ"].XValueMember = "gioiTinh";
            chartTyLeNamNu.Series["Tỷ Lệ Nam Nữ"].YValueMembers = "soLuong";
            conn.Close();
        }
    }
}
