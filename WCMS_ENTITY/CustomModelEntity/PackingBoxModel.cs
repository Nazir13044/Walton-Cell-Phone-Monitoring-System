using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCMS_ENTITY.CustomModelEntity
{
    public class PackingBoxModel
    {
        public string Imei1 { get; set; }
        public string Imei2 { get; set; }
        public string Project { get; set; }
        public string Imei3 { get; set; }
        public string WoId { get; set; }
        public string Sn { get; set; }
        public string Barcode { get; set; }
        public string BoxId { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int? ProductionCount { get; set; }
    }
}
