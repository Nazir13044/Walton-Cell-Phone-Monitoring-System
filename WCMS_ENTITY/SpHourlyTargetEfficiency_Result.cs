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
    
    public partial class SpHourlyTargetEfficiency_Result
    {
        public Nullable<int> HourCount { get; set; }
        public string TimeRange { get; set; }
        public Nullable<long> ProjectId { get; set; }
        public Nullable<int> QcPassed { get; set; }
        public Nullable<int> TargrtedQ { get; set; }
        public Nullable<int> TotalQcPassed { get; set; }
        public Nullable<int> FunctionalFault { get; set; }
        public Nullable<int> AestheticFault { get; set; }
        public Nullable<int> TotalReworked { get; set; }
        public Nullable<int> TotalReworkPending { get; set; }
    }
}
