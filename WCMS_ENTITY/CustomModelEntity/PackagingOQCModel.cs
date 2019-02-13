using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCMS_ENTITY.CustomModelEntity
{
    public class PackagingOQCModel
    {

        public long? ProjectId { get; set; }
        public long? LineId { get; set; }
        public string Model { get; set; }
        public string Project { get; set; }
        public string Color { get; set; }
        public string CheckedImei { get; set; }
        public string Imei1 { get; set; }
        public string Imei2 { get; set; }
        public string Status { get; set; }
        public string Issues { get; set; }
        public int Total { get; set; }
        public int PassedCount { get; set; }
        public int FailedCount { get; set; }
        public DateTime? AddedDate { get; set; }
        public string CheckedBy { get; set; }
    }
}
