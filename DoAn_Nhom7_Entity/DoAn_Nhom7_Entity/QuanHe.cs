//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DoAn_Nhom7_Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class QuanHe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QuanHe()
        {
            this.ThanhVienSoHoKhaus = new HashSet<ThanhVienSoHoKhau>();
        }
    
        public string CMND1 { get; set; }
        public string CMND2 { get; set; }
        public string quanHeVoiCMND1 { get; set; }
        public string quanHeVoiCMND2 { get; set; }
    
        public virtual CongDan CongDan { get; set; }
        public virtual CongDan CongDan1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThanhVienSoHoKhau> ThanhVienSoHoKhaus { get; set; }
    }
}
