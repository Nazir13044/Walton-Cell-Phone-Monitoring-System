using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCMS_ENTITY.CustomModelEntity
{
     public class ReworkList
    {

        public long LineId { get; set; }
        public long ProjectId { get; set; }
        public string LineName { get; set; }
        public int? IssueCount { get; set; }
        public string ProjectName { get; set; }
        public string MobileCode { get; set; }
        public string Imei1 { get; set; }
        public string Imei2 { get; set; }
        public string Issues { get; set; }
        public string Status { get; set; }
        public string FailedStation { get; set; }
        public string AddedBy { get; set; }
        public string AddedDate { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public int? IssueCriteriaWiseCount { get; set; }
        public double? IssueCriteriaPercent { get; set; }
        public int? TotalProduction { get; set; }
        public double? TotalFaultRatio { get; set; }

    }
}
