using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCMS_ENTITY.CustomModelEntity
{
    public class LogisticModel
    {
        public long LineId { get; set; }
        public long ProjectId { get; set; }
        public string Model { get; set; }

        
        public string Imei1 { get; set; }
        public string Imei2 { get; set; }
       


    }
}
