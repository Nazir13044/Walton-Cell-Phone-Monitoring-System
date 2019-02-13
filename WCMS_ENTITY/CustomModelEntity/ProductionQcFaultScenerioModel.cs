using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCMS_ENTITY.CustomModelEntity
{
   public class ProductionQcFaultScenerioModel
    {
        public long? ProjectId { get; set; }
        public long? LineId { get; set; }

        public string ProjectName { get; set; }
        public string LineName { get; set; }
        public string FaultName { get; set; }

        public int? TotalChecked { get; set; }
        public int? TotalPassed { get; set; }
        public int? Fault { get; set; }
        public double? FaultRatio { get; set; }
        public int? TotalFault { get; set; }

        public double? TotalFaultRatio { get; set; }


       
    }
}
