using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCMS_ENTITY.CustomModelEntity
{
    public class AgingQcStationModel
    {
        public long?  ProjectId { get; set; }
        public long? LineId { get; set; }
        public string ProjectName { get; set; }
        public string BatchProjectName { get; set; }
        public string LineName { get; set; }
        public string MobileCode { get; set; }
        public string AgingBatch { get; set; }       
        public string AgingPass { get; set; }
        public string BatchStatus { get; set; }
        public int BatchCount { get; set; }
        public int AgingPassedCount { get; set; }
        public int AgingFailedCount { get; set; }       
        public string AgingIssue { get; set; }
        public string ChargingIssue { get; set; }
        public string AgingReworked { get; set; }
        public DateTime AddedDate { get; set; }
        public string CheckedBy { get; set; }


    }
}
