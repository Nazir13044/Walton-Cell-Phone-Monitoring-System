//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCMS_ENTITY
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblOqcCheckedItems
    {
        public long Id { get; set; }
        public Nullable<long> ProjectId { get; set; }
        public string Imei1 { get; set; }
        public string Imei2 { get; set; }
        public string OqcStatus { get; set; }
        public string Issues { get; set; }
        public string Remarks { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> AddedBy { get; set; }
    }
}