//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLiNhaTu.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CA_TRUC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CA_TRUC()
        {
            this.BO_PHAN = new HashSet<BO_PHAN>();
        }
    
        public int Ngay_Trong_Tuan { get; set; }
        public System.TimeSpan Bat_Dau { get; set; }
        public System.TimeSpan Ket_Thuc { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BO_PHAN> BO_PHAN { get; set; }
    }
}
