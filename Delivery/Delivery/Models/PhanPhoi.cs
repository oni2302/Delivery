//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Delivery.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PhanPhoi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhanPhoi()
        {
            this.DonHangCanVanChuyens = new HashSet<DonHangCanVanChuyen>();
        }
    
        public int MaDonHang { get; set; }
        public Nullable<int> NhanVienThucHien { get; set; }
        public Nullable<System.DateTime> ThoiGianPhanPhoi { get; set; }
        public Nullable<int> MaPhanPhoi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHangCanVanChuyen> DonHangCanVanChuyens { get; set; }
        public virtual NhanDon NhanDon { get; set; }
        public virtual NhanVien NhanVien { get; set; }
    }
}