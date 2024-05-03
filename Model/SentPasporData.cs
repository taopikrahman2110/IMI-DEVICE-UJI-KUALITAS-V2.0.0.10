using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRZReader.Model
{
    public class SentPasporData
    {
        public Paspor paspor { get; set; }
        public string id { get; set; }
        public string dokumenPaspor { get; set; }
        public string dokumenPasporBase64 { get; set; }
    }
}
