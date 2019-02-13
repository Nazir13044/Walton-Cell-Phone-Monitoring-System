using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCMS_ENTITY.CustomModelEntity
{
    public class AssemblyLineproductionStatusModel
    {

        public DateTime Date { get; set; }
        public string AddedDate { get; set; }
        public long LineId { get; set; }
        public string LineName { get; set; }
        public long ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int? IssuedInLine { get; set; }
        public int? WaitingBeforeQc { get; set; }
        public int? TotalQcChecked { get; set; }
        public int? QcPassed { get; set; }
        
        public int? FunctionalFault { get; set; }
        public int? AestheticFault { get; set; }
        public int? PackagingFault { get; set; }
        public double? FunctionalFaultPercentage { get; set; }
        public double? AestheticFaultFaultPercentage { get; set; }
        public double? PackagingFaultFaultPercentage { get; set; }
        public double? NonReparablePercentage { get; set; }
        public int? TotalFault { get; set; }
        public int? Reworked { get; set; }
        public int? ReworkPending { get; set; }
        public int? Nonreparable { get; set; }
        

    }
}
