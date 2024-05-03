using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassportPrinter.Model
{
    public class PassportData
    {
        public string Jenis { get; set; }
        public string KodeNegara { get; set; }
        public string NoPassport { get; set; }
        public string NamaPassport { get; set; }
        public string Kewarganegaraan { get; set; }
        public string TglLahir { get; set; }
        public string JK { get; set; }
        public string TempatLahir { get; set; }
        public string IssuingDate { get; set; }
        public string ExpiryDate { get; set; }
        public string IssuingOffice { get; set; }
        public string NoReg { get; set; }
        public string Nikim { get; set; }
        public string NamaTambahan { get; set; }
        public string AlamatBaru { get; set; }
    }
}
