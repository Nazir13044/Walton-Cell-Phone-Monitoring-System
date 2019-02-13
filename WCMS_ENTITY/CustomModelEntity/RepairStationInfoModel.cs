using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCMS_ENTITY.CustomModelEntity
{
    public class RepairStationInfoModel
    {
        public long LineId { get; set; }
        public long ProjectId { get; set; }
        public string LineName { get; set; }
        public string ProjectName { get; set; }
        public string MobileCode { get; set; }
        public string QcIssue { get; set; }
        public string FailedStation { get; set; }
        public string IsFaulty { get; set; }
        public string RepairIssue { get; set; }
        public string MaterialFault { get; set; }
        public string ProcessFault { get; set; }
        public string RepairRemarks { get; set; }
        public string UsedComponents { get; set; }
        public string UsedQuantity { get; set; }
        public string WasteQuantity { get; set; }
        public string ComponentsRemarks { get; set; }
        public string DoneBy { get; set; }
        public long? FinishedBy { get; set; }
    }
}
