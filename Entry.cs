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
    
    public partial class Entry
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Entry()
        {
            this.Results = new HashSet<Result>();
            this.Results1 = new HashSet<Result>();
            this.Results2 = new HashSet<Result>();
            this.Results3 = new HashSet<Result>();
        }
    
        public short ID { get; set; }
        public short entrant { get; set; }
        public short competition { get; set; }
        public bool registered { get; set; }
        public Nullable<byte> instrument1 { get; set; }
        public Nullable<short> entrant2 { get; set; }
        public Nullable<byte> instrument2 { get; set; }
        public Nullable<short> entrant3 { get; set; }
        public Nullable<byte> instrument3 { get; set; }
    
        public virtual Competition Competition1 { get; set; }
        public virtual Entrant Entrant1 { get; set; }
        public virtual Entrant Entrant4 { get; set; }
        public virtual Entrant Entrant5 { get; set; }
        public virtual Instrument Instrument { get; set; }
        public virtual Instrument Instrument4 { get; set; }
        public virtual Instrument Instrument5 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Result> Results { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Result> Results1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Result> Results2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Result> Results3 { get; set; }
    }
}
