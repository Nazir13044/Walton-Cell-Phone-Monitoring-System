using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCMS_MAIN.Models
{
    public class DailyProductionModel
    {
        public int TimeHour { get; set; }
        public int HourCount { get; set; }
        public int ProductCount { get; set; }
        public int FunctionalFaultCount { get; set; }
         public int AestheticFaultCount { get; set; }
         public int AgingFaultCount { get; set; }
         public int PackagingFaultCount { get; set; }

        public long? ProjectId { get; set; }
        public long? LineId { get; set; }

        public string ProjectName { get; set; }
        public string LineName { get; set; }
        public string StationName { get; set; }
        
    }


    public class DailyProductionModelDetail
    {
        public string label { get; set; }
        public List<string> data { get; set; }


    }

    public class HourlyLineWiseStation
    {
        public string LineName { get; set; }
        public List<DailyProductionModelDetail> Details { get; set; }


    }

}