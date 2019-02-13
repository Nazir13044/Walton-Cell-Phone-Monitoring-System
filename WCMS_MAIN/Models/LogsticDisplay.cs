using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCMS_MAIN.Models
{
    public class LogsticDisplay
    {

        public string Model { get; set; }
        public int? LogisticReceived { get; set; }
        public int? LogisticSent { get; set; }
        public int? WarehouseReceived { get; set; }
        public string LogisticsLastSent { get; set; }
        public string WarehouseLastReceived { get; set; }
    }
}