using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRZReader.Model
{
    public class ResponseTestReAlloc
    {
        public string responseStatus { get; set; }
        public string responseMessage { get; set; }
        public ResponseReAllocObject responseObject { get; set; }
    }

    public class ResponseReAllocObject
    {
        public string id { get; set; }
        public string kodePermohonan { get; set; }
        public string nama_pemohon { get; set; }
        public string nama_pemohon_di_paspor { get; set; }
        public string tanggal_lahir { get; set; }
        public string jenis_permohonan { get; set; }
        public string jenis_paspor { get; set; }
        public List<ListDetailPembayaran> listDetailPembayaran { get; set; }
        public string total_biaya { get; set; }
        public string kode_pembayaran { get; set; }
        public string ntpn { get; set; }
        public string ntb { get; set; }
        public string no_paspor { get; set; }
    }

    public class ListDetailPembayaran
    {
        public string nama { get; set; }
        public string biaya { get; set; }
    }


}
