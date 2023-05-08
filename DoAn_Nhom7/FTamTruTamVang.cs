using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_Nhom7
{
    public partial class FTamTruTamVang : Form
    {
        public string Data { get; set; }
        TamTruTamVangDAO tttvDao = new TamTruTamVangDAO();
        private TextBox txtCMND;

        public FTamTruTamVang()
        {
            InitializeComponent();
        }
        public void FillDataFromUCTamTruTamVang(string cmnd)
        {
            txtCMND.Text = cmnd;
        }
        private void FTamTruTamVang_Load(object sender, EventArgs e)
        {
            
        }

        private void ucTamTruTamVang1_Load(object sender, EventArgs e)
        {

        }
    }
}
