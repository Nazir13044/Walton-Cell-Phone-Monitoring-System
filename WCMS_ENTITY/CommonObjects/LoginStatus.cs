using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCMS_ENTITY.CommonObjects
{
    class LoginStatus
    {
        public bool IsAllowed { get; set; }
        public string Message { get; set; }

        public Dictionary<string, string> Status = new Dictionary<string, string>();
    }
}
