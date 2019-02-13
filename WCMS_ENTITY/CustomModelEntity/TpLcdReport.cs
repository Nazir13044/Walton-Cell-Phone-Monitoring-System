using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCMS_ENTITY.CustomModelEntity
{
    public class TpLcdReport
    {
        public string ProjectName { get; set; }
        public long? ProjectId { get; set; }
        public int? ProductionCount { get; set; }
        public int? IssuesCount { get; set; }
        public string Issues { get; set; }
        public long? AddedBy { get; set; }
        public string AddedName { get; set; }
        public string Status { get; set; }
        public int? Passed { get; set; }
        public int? Fault { get; set; }
        /////new for overall
        public DateTime AddedDate { get; set; }
        public string Date { get; set; }
        public int? Worked { get; set; }
        public int? QcPass { get; set; }
        public int? QcFail { get; set; }
        public double FaultPercent { get; set; }
        public int? Reworked { get; set; }
        public int? ReworkPending { get; set; }
        public int? NonReparable { get; set; }
        public double NonReparablePercent { get; set; }
    }
}
