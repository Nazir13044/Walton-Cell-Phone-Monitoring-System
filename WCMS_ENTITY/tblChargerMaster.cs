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
    
    public partial class tblChargerMaster
    {
        public long Id { get; set; }
        public Nullable<long> ProjectId { get; set; }
        public string ProjectName { get; set; }
        public Nullable<long> LineId { get; set; }
        public string MobileCode { get; set; }
        public string ChargingBatch { get; set; }
        public string ChargingPassed { get; set; }
        public string ChargingIssue { get; set; }
        public Nullable<bool> Reworked { get; set; }
        public Nullable<long> AddedBy { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}