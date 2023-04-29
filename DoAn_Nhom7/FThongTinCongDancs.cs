using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_Nhom7
{
    public partial class FThongTinCongDancs : Form
    {
        public string cmnd;
        DBConnection db = new DBConnection();
        public FThongTinCongDancs(string Cmnd)
        {
            InitializeComponent();
            this.cmnd = db.timMaSHK(Cmnd);
            MessageBox.Show(Cmnd);
        }

        private void FThongTinCongDancs_Load(object sender, EventArgs e)

        {
            string cmndBo = db.timCMNDBo(cmnd);
            db.LapDayThongTinKhaiSinhBoMe(cmndBo, lblHoTenBo, lblNamSinhBo, lblDanTocBo, lblQuocTichBo, lblQueQuanBo);
            db.LapDayThongTinKhaiSinhBoMe("2", lblHoTenMe, lblNamSinhMe, lblDanTocMe, lblQuocTichMe, lblQueQuanMe);
        }

        private void FThongTinCongDancs_Scroll(object sender, ScrollEventArgs e)
        {
        }
    }
}
