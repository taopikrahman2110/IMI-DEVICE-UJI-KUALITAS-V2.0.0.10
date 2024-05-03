using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRZReader.Model
{
    public class ResponseLogin
    {
        public bool flag { get; set; }
        public InformasiPengguna informasiPengguna { get; set; }
        public UserDPRI userDPRI { get; set; }
        public Paspor paspor { get; set; }
    }

    public class InformasiPengguna
    {
        public string id { get; set; }
        public object paspor { get; set; }
        public object jenisIdentitas { get; set; }
        public object nik { get; set; }
        public object tanggalDikeluarkanNik { get; set; }
        public object namaLengkap { get; set; }
        public object namaDiPaspor { get; set; }
        public object jenisKelamin { get; set; }
        public object statusSipil { get; set; }
        public object tempatLahir { get; set; }
        public object tanggalLahir { get; set; }
        public object noHandphone { get; set; }
        public object instansi { get; set; }
        public object jabatan { get; set; }
        public object pekerjaan { get; set; }
        public object email { get; set; }
        public object alamat { get; set; }
        public object provinsi { get; set; }
        public object kabupaten { get; set; }
        public object kecamatan { get; set; }
        public object kodePos { get; set; }
        public object alamatDomisili { get; set; }
        public object provinsiDomisili { get; set; }
        public object kabupatenDomisili { get; set; }
        public object kecamatanDomisili { get; set; }
        public object kodePosDomisili { get; set; }
        public object dtmLastUpdate { get; set; }
        public object userDPRI { get; set; }
        public int sequenceNumber { get; set; }
        public object namaBaru { get; set; }
        public object alamatBaru { get; set; }
        public object tanggalDikeluarkanNikStr { get; set; }
        public object tanggalLahirStr { get; set; }
        public bool perubahanNama { get; set; }
        public bool perubahanAlamat { get; set; }
    }

    public class UserDPRI2
    {
        public string id { get; set; }
        public object userId { get; set; }
        public string nama { get; set; }
        public object nip { get; set; }
        public object satuanKerja { get; set; }
        public object departemen { get; set; }
        public object jabatan { get; set; }
        public bool active { get; set; }
        public long dtmLastUpdate { get; set; }
        public object sequenceNumber { get; set; }
        public object group { get; set; }
    }

    public class IndukStrukturStatuanKerja2
    {
        public string id { get; set; }
        public string idStrukturSatuanKerja { get; set; }
        public string nama { get; set; }
        public string deskripsi { get; set; }
        public object indukStrukturStatuanKerja { get; set; }
        public object namaIndukStrukturSatuanKerja { get; set; }
        public bool active { get; set; }
        public UserDPRI2 userDPRI { get; set; }
        public long dtmLastUpdate { get; set; }
    }

    public class UserDPRI3
    {
        public string id { get; set; }
        public object userId { get; set; }
        public string nama { get; set; }
        public object nip { get; set; }
        public object satuanKerja { get; set; }
        public object departemen { get; set; }
        public object jabatan { get; set; }
        public bool active { get; set; }
        public long dtmLastUpdate { get; set; }
        public object sequenceNumber { get; set; }
        public object group { get; set; }
    }

    public class IndukStrukturStatuanKerja
    {
        public string id { get; set; }
        public string idStrukturSatuanKerja { get; set; }
        public string nama { get; set; }
        public string deskripsi { get; set; }
        public IndukStrukturStatuanKerja2 indukStrukturStatuanKerja { get; set; }
        public string namaIndukStrukturSatuanKerja { get; set; }
        public bool active { get; set; }
        public UserDPRI3 userDPRI { get; set; }
        public long dtmLastUpdate { get; set; }
    }

    public class UserDPRI4
    {
        public string id { get; set; }
        public object userId { get; set; }
        public string nama { get; set; }
        public object nip { get; set; }
        public object satuanKerja { get; set; }
        public object departemen { get; set; }
        public object jabatan { get; set; }
        public bool active { get; set; }
        public long dtmLastUpdate { get; set; }
        public object sequenceNumber { get; set; }
        public object group { get; set; }
    }

    public class StrukturSatuanKerja
    {
        public string id { get; set; }
        public string idStrukturSatuanKerja { get; set; }
        public string nama { get; set; }
        public string deskripsi { get; set; }
        public IndukStrukturStatuanKerja indukStrukturStatuanKerja { get; set; }
        public string namaIndukStrukturSatuanKerja { get; set; }
        public bool active { get; set; }
        public UserDPRI4 userDPRI { get; set; }
        public long dtmLastUpdate { get; set; }
    }

    public class UserDPRI5
    {
        public string id { get; set; }
        public object userId { get; set; }
        public string nama { get; set; }
        public object nip { get; set; }
        public object satuanKerja { get; set; }
        public object departemen { get; set; }
        public object jabatan { get; set; }
        public bool active { get; set; }
        public long dtmLastUpdate { get; set; }
        public object sequenceNumber { get; set; }
        public object group { get; set; }
    }

    public class IndukStrukturStatuanKerja3
    {
        public string id { get; set; }
        public string idStrukturSatuanKerja { get; set; }
        public string nama { get; set; }
        public string deskripsi { get; set; }
        public object indukStrukturStatuanKerja { get; set; }
        public object namaIndukStrukturSatuanKerja { get; set; }
        public bool active { get; set; }
        public UserDPRI5 userDPRI { get; set; }
        public long dtmLastUpdate { get; set; }
    }

    public class UserDPRI6
    {
        public string id { get; set; }
        public object userId { get; set; }
        public string nama { get; set; }
        public object nip { get; set; }
        public object satuanKerja { get; set; }
        public object departemen { get; set; }
        public object jabatan { get; set; }
        public bool active { get; set; }
        public long dtmLastUpdate { get; set; }
        public object sequenceNumber { get; set; }
        public object group { get; set; }
    }

    public class StrukturSatuanKerja2
    {
        public string id { get; set; }
        public string idStrukturSatuanKerja { get; set; }
        public string nama { get; set; }
        public string deskripsi { get; set; }
        public IndukStrukturStatuanKerja3 indukStrukturStatuanKerja { get; set; }
        public string namaIndukStrukturSatuanKerja { get; set; }
        public bool active { get; set; }
        public UserDPRI6 userDPRI { get; set; }
        public long dtmLastUpdate { get; set; }
    }

    public class UserDPRI7
    {
        public string id { get; set; }
        public object userId { get; set; }
        public string nama { get; set; }
        public object nip { get; set; }
        public object satuanKerja { get; set; }
        public object departemen { get; set; }
        public object jabatan { get; set; }
        public bool active { get; set; }
        public long dtmLastUpdate { get; set; }
        public object sequenceNumber { get; set; }
        public object group { get; set; }
    }

    public class StrukturSatuanKerja3
    {
        public string id { get; set; }
        public string idStrukturSatuanKerja { get; set; }
        public string nama { get; set; }
        public string deskripsi { get; set; }
        public object indukStrukturStatuanKerja { get; set; }
        public object namaIndukStrukturSatuanKerja { get; set; }
        public bool active { get; set; }
        public UserDPRI7 userDPRI { get; set; }
        public long dtmLastUpdate { get; set; }
    }

    public class IndukSatuanKerja2
    {
        public string id { get; set; }
        public string idSatuanKerja { get; set; }
        public string namaSatuanKerja { get; set; }
        public string deskripsiSatuanKerja { get; set; }
        public string alamat { get; set; }
        public string telepon { get; set; }
        public string fax { get; set; }
        public StrukturSatuanKerja3 strukturSatuanKerja { get; set; }
        public object indukSatuanKerja { get; set; }
        public string kodeUnit { get; set; }
        public string kodeCabang { get; set; }
        public bool active { get; set; }
    }

    public class IndukSatuanKerja
    {
        public string id { get; set; }
        public string idSatuanKerja { get; set; }
        public string namaSatuanKerja { get; set; }
        public string deskripsiSatuanKerja { get; set; }
        public string alamat { get; set; }
        public string telepon { get; set; }
        public string fax { get; set; }
        public StrukturSatuanKerja2 strukturSatuanKerja { get; set; }
        public IndukSatuanKerja2 indukSatuanKerja { get; set; }
        public string kodeUnit { get; set; }
        public string kodeCabang { get; set; }
        public bool active { get; set; }
    }

    public class SatuanKerja
    {
        public string id { get; set; }
        public string idSatuanKerja { get; set; }
        public string namaSatuanKerja { get; set; }
        public string deskripsiSatuanKerja { get; set; }
        public string alamat { get; set; }
        public string telepon { get; set; }
        public string fax { get; set; }
        public StrukturSatuanKerja strukturSatuanKerja { get; set; }
        public IndukSatuanKerja indukSatuanKerja { get; set; }
        public string kodeUnit { get; set; }
        public string kodeCabang { get; set; }
        public bool active { get; set; }
    }

    public class UserDPRI
    {
        public string id { get; set; }
        public object userId { get; set; }
        public string nama { get; set; }
        public string nip { get; set; }
        public SatuanKerja satuanKerja { get; set; }
        public string departemen { get; set; }
        public string jabatan { get; set; }
        public bool active { get; set; }
        public long dtmLastUpdate { get; set; }
        public object sequenceNumber { get; set; }
        public object group { get; set; }
    }

    public class Paspor
    {
        public object kodePermohonan { get; set; }
        public object kodeBilling { get; set; }
        public object satuanKerja { get; set; }
        public object idPaspor { get; set; }
        public object tanggalPermohonan { get; set; }
        public object tanggalDikeluarkan { get; set; }
        public object tanggalMasaBerlaku { get; set; }
        public object jenisPermohonan { get; set; }
        public object alasanDokPerjalanan { get; set; }
        public object jenisPaspor { get; set; }
        public object tujuanDokumenPerjalanan { get; set; }
        public object noBeritaAcara { get; set; }
        public object noPasporLama { get; set; }
        public object noRekomendasiKemenaker { get; set; }
        public object noRekomendasiKemenag { get; set; }
        public object negara { get; set; }
        public object idTempatBiometrik { get; set; }
        public bool active { get; set; }
        public object tahapan { get; set; }
        public object statusKeputusan { get; set; }
        public object pembuatKeputusan { get; set; }
        public object userDPRI { get; set; }
        public object dtmLastUpdate { get; set; }
        public object sequenceNumber { get; set; }
        public object noNikim { get; set; }
        public object jenisDokumen { get; set; }
        public object kodeAntrian { get; set; }
        public bool flagFlowUbah { get; set; }
        public object tanggalPermohonanStr { get; set; }
        public object tanggalDikeluarkanStr { get; set; }
        public object tanggalMasaBerlakuStr { get; set; }
        public object tanggalAkhirStr { get; set; }
        public string activeStr { get; set; }
    }
}
