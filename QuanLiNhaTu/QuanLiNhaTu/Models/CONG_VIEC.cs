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
    
    public partial class CONG_VIEC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CONG_VIEC()
        {
            this.CAN_BO = new HashSet<CAN_BO>();
        }
    
        public string Ma_CV { get; set; }
        public string Ten_CV { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CAN_BO> CAN_BO { get; set; }
    }
}
