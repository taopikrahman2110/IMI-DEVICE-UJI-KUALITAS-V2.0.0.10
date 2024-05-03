using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRZReader.Model
{
    public class SentSailsData
    {
        public string id;
        public string type;
        public string action;
        public string kodePermohonan;
        public string userId;
    }

    public class SentStatus: SentSailsData
    {
        public string status;
    }
}
