//namespace WCMS_MAIN.Models

using System;

namespace WCMS_ENTITY.CustomModelEntity
{
    public class HourlyTargetModel
    {

        public int HourCount { get; set; }
        public string TimeRange { get; set; }
        public string LineName { get; set; }
        public string ProjectName { get; set; }
        public long? ProjectId { get; set; }
        public DateTime? AddedDate { get; set; }

        public int? LineId { get; set; }
        public long? PackagingLineId { get; set; }
        public long? IdLine { get; set; }
        //public long? LineId { get; set; }
        public int QcPassed { get; set; }
        public int TargrtedQ { get; set; }
        public int TotalQcPassed { get; set; }
        public int FunctionalFault { get; set; }
        public double FunctionalFaultRate { get; set; }
        public int AestheticFault { get; set; }
        public double AestheticFaultRate { get; set; }
        public double FaultRate { get; set; }
        public double PackagingFaultRate { get; set; }
        public int AgingFault { get; set; }
        public int PackagingFault { get; set; }
        public int TotalReworked { get; set; }
        public int TotalWastages { get; set; }
        public int TotalReworkPending { get; set; }

        public int AssemblyPassed { get; set; }
        public int Fault { get; set; }  
        
        //line wise station status 
        //line wise station status 
        //line wise station status 


        public int IssuedComponent { get; set; }
        public int FunctionalQC { get; set; }
        public int AestheticQc { get; set; }
        public int AgingQc { get; set; }
        public int PackagingQc { get; set; }
        public int ScrewDone { get; set; }
        public int? CountProjectId { get; set; }
        public int PackagingPass { get; set; }
        public int PackagingIssued { get; set; }
        public double AverageSpeed { get; set; }
        
        public string LineCriteria { get; set; }
        

        //for Logistics Reports
        public string Model { get; set; }
        public string Color { get; set; }
        public string Imei1 { get; set; }
        public string Imei2 { get; set; }
        public int? ProductionCount { get; set; }
        public int? OracleUploadedCount { get; set; }
        public string Uploaded { get; set; }
        public string OracleUploaded { get; set; }
    }
}