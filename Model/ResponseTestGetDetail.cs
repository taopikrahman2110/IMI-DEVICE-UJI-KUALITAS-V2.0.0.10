using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRZReader.Model
{
    public class ResponseTestGetDetail
    {
        public string responseStatus { get; set; }
        public List<ResponseObject> responseObject { get; set; }
    }

    public class ResponseObject
    {
        public string halaman { get; set; }
        public string tanggal_terbit { get; set; }
        public string nama_di_paspor { get; set; }
        public string nama_tambahan { get; set; }
        public string kode_permohonan { get; set; }
        public string no_nikim { get; set; }
        public string nama_lengkap { get; set; }
        public string official_status { get; set; }
        public string no_serial_number { get; set; }
        public string id_alokasi { get; set; }
        public string nomor_register { get; set; }
        public string tanggal_masa_berlaku { get; set; }
        public string kewarganegaraan { get; set; }
        public string foto { get; set; }
        public string tempat_lahir { get; set; }
        public string id_paspor { get; set; }
        public string id { get; set; }
        public string tipe_dokumen { get; set; }
        public string jenis_kelamin { get; set; }
        public string tanggal_lahir { get; set; }
        public string status { get; set; }
        public string kode_negara { get; set; }
        public string alamat_baru { get; set; }
        public UnitKerjaIssueCetak unit_kerja_issue_cetak { get; set; }
    }

    public class UnitKerjaIssueCetak
    {
        public string nama_unit_kerja { get; set; }
        public string kode_unit_kerja { get; set; }
        public string id { get; set; }
    }
}
