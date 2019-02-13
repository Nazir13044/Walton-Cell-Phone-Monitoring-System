using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCMS_ENTITY.CustomModelEntity
{
    public class OracleUploadEntity
    {
        public long SequenceId { get; set; }
        public int OrganizationId { get; set; }
        public String TranscationDate { get; set; }
        public int EbsItemId { get; set; }
        public string ItemModel { get; set; }
        public string DataSource { get; set; }
        public string ItemColor { get; set; }
        public string ItemVersion { get; set; }
        public int? JobId { get; set; }
        public string SeriaNo { get; set; }
        public int? ImpFlag { get; set; }
        public int? ImpReference { get; set; }
        public string CreatedBy { get; set; }

        public DateTime CreationDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastDateUpdatedDate { get; set; }
        public string Remarks { get; set; }
    }
}
