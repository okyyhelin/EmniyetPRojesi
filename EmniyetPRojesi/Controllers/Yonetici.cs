//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmniyetPRojesi.Controllers
{
    using System;
    using System.Collections.Generic;
    
    public partial class Yonetici
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Yonetici()
        {
            this.Icerik = new HashSet<Icerik>();
        }
    
        public int YoneticiID { get; set; }
        public string TC { get; set; }
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string EPosta { get; set; }
        public string Tel { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Icerik> Icerik { get; set; }
    }
}
