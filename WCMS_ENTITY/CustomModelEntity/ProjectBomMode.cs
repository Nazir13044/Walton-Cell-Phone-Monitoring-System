using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCMS_ENTITY.CustomModelEntity
{
   public class ProjectBomMode
    {
       public string ASSEMBLY { get; set; }
        public string ITEM_CODE { get; set; }

        public string DESCRIPTION { get; set; }
        public string Component { get; set; }
        public string Quantity { get; set; }

        //public DateTime? FromDate { get; set; }
        //public DateTime? ToDate { get; set; }
       
        public string SPARE_ITEM_CODE { get; set; }
        public string SPARE_DESCRIPTION { get; set; }


    }
}
