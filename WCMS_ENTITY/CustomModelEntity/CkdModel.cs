using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCMS_ENTITY.CustomModelEntity
{
   public  class CkdModel
    {
        public int SMTPassed { get; set; }
        public int SMTPFailed { get; set; }
        public int MMIPassed { get; set; }
        public int MMIPFailed { get; set; }
        public int SoftwareLoadPassed { get; set; }
        public int SoftwareLoadPFailed { get; set; }
        public int RfPassed { get; set; }
        public int RfPFailed { get; set; }
       

        public long? LineId { get; set; }
       public string Model { get; set; }

        public DateTime? AddedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
