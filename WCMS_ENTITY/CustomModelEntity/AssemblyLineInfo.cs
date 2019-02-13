using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCMS_ENTITY.CustomModelEntity
{
   public class AssemblyLineInfo
    {

       public long LineId { get; set; }
       public long ProjectId { get; set; }
       public string LineName { get; set; }
       public string LineCriteria { get; set; }
       
       public string ProjectName { get; set; }
       public int? IssuedQuantity { get; set; }
       public int? HourlyTarget { get; set; }
       public int? ManPower { get; set; }
       public int? TotalTarget { get; set; }
       public int? PreviousQuantity { get; set; }

       public int? Pcb { get; set; }
       public int? ScrewDone { get; set; }
       public int? FunctionalQc { get; set; }
       public int? AestheticQc { get; set; }
    }
}
