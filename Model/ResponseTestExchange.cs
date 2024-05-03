using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRZReader.Model
{
    class ResponseTestExchange
    {
        public string responseStatus { get; set; }
        public ResponseTestExchangeObject responseObject { get; set; }
    }

    class ResponseTestExchangeObject
    {
        public string no_paspor { get; set; }
    }
}
