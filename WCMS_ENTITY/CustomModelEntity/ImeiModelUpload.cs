using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCMS_ENTITY.CustomModelEntity
{
    public class ImeiModelUpload
    {
        public DateTime? PrintDate { get; set; }
        public DateTime? PrintDate2 { get; set; }
        public string ProductType { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Barcode { get; set; }
        public string Barcode2 { get; set; }
        public string DeliveredTo { get; set; }
        public string PrintSuccess { get; set; }
        public string AddedBy { get; set; }
        public DateTime DateAdded { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime DateUpdated { get; set; }


        public string WO { get; set; }
        public string Imei1 { get; set; }
        public string Imei2 { get; set; }
    }
}
