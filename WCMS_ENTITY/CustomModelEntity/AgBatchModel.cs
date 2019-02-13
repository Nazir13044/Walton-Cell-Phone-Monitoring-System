using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCMS_ENTITY.CustomModelEntity
{
    public class AgBatchModel
    {
        public long? ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string BatchProjectName { get; set; }
        public string LineName { get; set; }
        public string AgingBatch { get; set; }
        public string BatchStatus { get; set; }
        public int BatchCount { get; set; }
        public int AgingPassedCount { get; set; }
        public int AgingFailedCount { get; set; }
        public string CheckedBy { get; set; }
    }
}
