//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CheckInvalidCodeMeli.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class fostad_head
    {
        public decimal id { get; set; }
        public decimal ocode { get; set; }
        public string azterm { get; set; }
        public Nullable<decimal> os_idresh { get; set; }
        public Nullable<decimal> idgroup { get; set; }
        public Nullable<decimal> idmadrak { get; set; }
        public Nullable<decimal> martabeh { get; set; }
        public Nullable<decimal> nahveh_hamk { get; set; }
        public Nullable<decimal> saat_movazaf { get; set; }
        public string sal_madrak { get; set; }
        public Nullable<decimal> keshvar { get; set; }
        public Nullable<int> type_university { get; set; }
        public Nullable<decimal> university { get; set; }
        public string date_est { get; set; }
        public Nullable<int> vaz_fali { get; set; }
        public Nullable<decimal> type_est { get; set; }
        public Nullable<int> saat_tadris { get; set; }
        public Nullable<byte> semat { get; set; }
        public string payeh { get; set; }
        public Nullable<byte> omomi { get; set; }
        public Nullable<byte> elmi { get; set; }
        public string date_elmi { get; set; }
        public string num_elmi { get; set; }
        public string date_omomi { get; set; }
        public string num_omomi { get; set; }
        public Nullable<byte> TAX { get; set; }
        public Nullable<byte> MASH_BIM { get; set; }
        public Nullable<decimal> MARTABEH_HAGH { get; set; }
    
        public virtual fostad fostad { get; set; }
    }
}
