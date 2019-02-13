using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCMS_ENTITY.CustomModelEntity
{
    public class AgingChargingModel
    {

        public long? ProjectId { get; set; }
        public long? LineId { get; set; }
        public string ProjectName { get; set; }
        public string BatchProjectName { get; set; }
        public string LineName { get; set; }
        public string MobileCode { get; set; }      
        public string ChargerBatch { get; set; }
        public string BatchStatus { get; set; }
        public int BatchCount { get; set; }
        public int ChargerPassedCount { get; set; }
        public int ChargerFailedCount { get; set; }
        public string ChargingPass { get; set; }
        public string ChargingIssue { get; set; }
     
        public string ChargingReworked { get; set; }
        public DateTime AddedDate { get; set; }
        public string CheckedBy { get; set; }
    }
}
