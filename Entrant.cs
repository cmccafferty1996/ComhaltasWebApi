//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ComhaltasWebApi
{
    using System;
    using System.Collections.Generic;
    
    public partial class Entrant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Entrant()
        {
            this.Entries = new HashSet<Entry>();
            this.Entries1 = new HashSet<Entry>();
            this.Entries2 = new HashSet<Entry>();
        }
    
        public short ID { get; set; }
        public string entrant_name { get; set; }
        public byte branch { get; set; }
        public Nullable<System.DateTime> dob { get; set; }
    
        public virtual Branch Branch1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Entry> Entries { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Entry> Entries1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Entry> Entries2 { get; set; }
    }
}
