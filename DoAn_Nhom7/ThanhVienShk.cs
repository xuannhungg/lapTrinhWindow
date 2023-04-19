using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_Nhom7
{
    public class ThanhVienShk
    {
        private string maShk;
        private string cmnd;
        private string quanHe;
        public string MaShk { get => maShk; set => maShk = value; }
        public string Cmnd { get => cmnd; set => cmnd = value; }
        public string QuanHe { get => quanHe; set => quanHe = value; }
        public ThanhVienShk()
        {

        }
        public ThanhVienShk(string maShk, string cmnd, string quanHe)
        {
            MaShk = maShk;
            Cmnd = cmnd;
            QuanHe = quanHe;
        }
        ~ThanhVienShk()
        {

        }
    }
}
