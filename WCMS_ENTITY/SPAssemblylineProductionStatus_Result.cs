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
    
    public partial class SPAssemblylineProductionStatus_Result
    {
        public Nullable<long> ProjectId { get; set; }
        public string ProjectName { get; set; }
        public Nullable<long> LineId { get; set; }
        public string LineName { get; set; }
        public Nullable<int> IssuedInLine { get; set; }
        public Nullable<int> TotalQcChecked { get; set; }
        public Nullable<int> QcPassed { get; set; }
        public Nullable<int> FunctionalFault { get; set; }
        public Nullable<int> AestheticFault { get; set; }
        public Nullable<int> Reworked { get; set; }
        public Nullable<int> ReworkPending { get; set; }
        public Nullable<int> Nonreparable { get; set; }
        public Nullable<int> TotalFault { get; set; }
    }
}
