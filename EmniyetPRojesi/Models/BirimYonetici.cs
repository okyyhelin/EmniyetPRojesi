//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmniyetPRojesi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BirimYonetici
    {
        public int BirimYoneticiID { get; set; }
        public Nullable<int> BirimID { get; set; }
        public Nullable<int> YoneticiID { get; set; }
    
        public virtual Birimler Birimler { get; set; }
        public virtual Yonetici Yonetici { get; set; }
    }
}
