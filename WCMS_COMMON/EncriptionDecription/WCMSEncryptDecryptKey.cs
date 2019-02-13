using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCMS_COMMON.EncriptionDecription
{
    internal class WCMSEncryptDecryptKey
    {
        private int _KeyIndex;
        private string _KeyValue;

        public int KeyIndex
        {
            get{return _KeyIndex;}
            set{_KeyIndex = value;}
        }

        public string KeyValue
        {
            get{return _KeyValue;}
            set{_KeyValue = value;}
        }
    }
}
