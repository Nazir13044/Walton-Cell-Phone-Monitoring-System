using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCMS_MAIN.Models
{
    public class HourlyTargetModel
    {

        public int HourCount { get; set; }
        public string TimeRange { get; set; }

        public int ProjectId { get; set; }

        public decimal FunctionalFaultRate { get; set; }
        public decimal AestheticFaultRate { get; set; }
        public int QcPassed { get; set; }
        public int TargetedQ { get; set; }
        public int TotalQcPassed { get; set; }
        public int FunctionalFault { get; set; }
        public int AestheticFault { get; set; }
        public int TotalReworked { get; set; }
        public int TotalReworkPending { get; set; }
        
    }
}