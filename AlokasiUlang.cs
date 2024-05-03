using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MRZReader.Model;
using System.Web.Script.Serialization;

namespace MRZReader
{
    public partial class AlokasiUlang : Form
    {
        Dictionary<string, string> dicAlasanGanti = new Dictionary<string, string>();
        private string id_old;
        private string id_new;
        private string oldStatus;
        private string oldStatusDetail;
        private string idUji;
        private string userId;
        private string cancelReallocate;
        private string exchangeURL;
        private string saveReallocURL;
        private string updateUserIdURL;
        private string setStatus;
        private bool saveRealloc;
        private HTTPHelper http = new HTTPHelper();

        public AlokasiUlang()
        {
            InitializeComponent();
            SetcbAlasanValue();
            //http = new HTTPHelper();
            saveRealloc = false;
        }

        public AlokasiUlang(string noPermohonan, string noPassportLama, string noPassportBaru, string id_old, string id_new, string idUji, string userId, string cancelReallocate, string exchangeURL, string saveReallocURL, string updateUserIdURL, string setStatus, string token, string oldStatus, string oldStatusDetail) : this()
        {
            if (noPermohonan != "")
            {
                tbNoPermohonan.Text = noPermohonan;
            }

            if (noPassportLama != "")
            {
                tbNoPassportLama.Text = noPassportLama;
            }

            if (noPassportBaru != "")
            {
                tbNoPassportBaru.Text = noPassportBaru;
            }

            this.id_old = id_old;
            this.id_new = id_new;
            this.oldStatus = oldStatus;
            this.oldStatusDetail = oldStatusDetail;
            this.idUji = idUji;
            this.userId = userId;
            this.cancelReallocate = cancelReallocate;
            this.exchangeURL = exchangeURL;
            this.saveReallocURL = saveReallocURL;
            this.updateUserIdURL = updateUserIdURL;
            this.setStatus = setStatus;
            http.token = token;

            SentUpdateData updateData = new SentUpdateData()
            {
                id = idUji,
                userId = userId
            };

            string successSave = http.GetHTTPRequest<SentUpdateData>(updateData, updateUserIdURL, true);

            if (successSave != "404")
            {
                ResponseTestDokim resultSave = successSave.ToObj<ResponseTestDokim>();

                if (resultSave.responseStatus != "200")
                {
                    MessageBox.Show("Terjadi kesalahan, silahkan coba lagi.", "Error: update user");
                }
            }
            else
            {
                MessageBox.Show("Terjadi kesalahan, silahkan coba lagi.", "Error: update user");
            }
        }

        private void SetcbAlasanValue()
        {
            dicAlasanGanti.Add("GAGAL_CETAK", "Gagal Cetak");
            dicAlasanGanti.Add("GAGAL_UJI", "Gagal Uji");
            dicAlasanGanti.Add("CACAT_PRODUKSI", "Cacat Produksi");

            cbAlasan.DataSource = new BindingSource(dicAlasanGanti, null);
            cbAlasan.DisplayMember = "Value";
            cbAlasan.ValueMember = "Key";
        }

        private void btnGantiNo_Click(object sender, EventArgs e)
        {
            SentTestData data = new SentTestData
            {
                id = id_new
            };

            string exchange = http.GetHTTPRequest<SentTestData>(data, exchangeURL, true);


            ResponseTestExchange exchangeResponse = exchange.ToObj<ResponseTestExchange>();

            if (!exchangeResponse.responseStatus.Equals("200"))
            {
                MessageBox.Show("Pengambilan nomor baru tidak berhasil");
                return;
            }

            tbNoPassportBaru.Text = exchangeResponse.responseObject.no_paspor;
        }

        private void AlokasiUlang_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !saveRealloc)
            {
                DialogResult result = MessageBox.Show("Apakah anda mau membatalkan alokasi?", "Peringatan", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    SentTestCancelData cancelData = new SentTestCancelData
                    {
                        id_old = this.id_old,
                        id_new = this.id_new,
                        old_status = this.oldStatus,
                        old_status_detail = this.oldStatusDetail
                    };

                    string cancel = http.GetHTTPRequest<SentTestCancelData>(cancelData, cancelReallocate, true);
                    ResponseTestDokim cancelResponse = cancel.ToObj<ResponseTestDokim>();

                    if (!cancelResponse.responseStatus.Equals("200"))
                    {
                        MessageBox.Show("Cancel Realokasi Gagal");
                    }
                    else
                    {
                        MessageBox.Show("Cancel Realokasi Berhasil");
                    }
                    this.DialogResult = DialogResult.Cancel;

                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SentTestSaveReAllocData data = new SentTestSaveReAllocData
                {
                    id_old = this.id_old,
                    id_new = this.id_new,
                    status_detail = cbAlasan.SelectedValue.ToString()
                };
                string success = http.GetHTTPRequest<SentTestSaveReAllocData>(data, saveReallocURL, true);
                ResponseTestDokim successResponse = success.ToObj<ResponseTestDokim>();

                if (successResponse.responseStatus.Equals("200"))
                {

                    SentStatus sentstatus = new SentStatus()
                    {
                        id = idUji,
                        type = "ujikualitas",
                        status = "gagal"
                    };

                    success = http.GetHTTPRequest<SentStatus>(sentstatus, setStatus, true);

                    if (success == "404")
                    {
                        MessageBox.Show("Terjadi kesalahan, silahkan cek koneksi komputer anda", "Error: Set Failed");
                        return;
                    }

                    MessageBox.Show("Penyimpanan berhasil");
                    saveRealloc = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Penyimpanan belum berhasil, mohon lakukan lagi");
                }

            }
            catch (Exception ex)
            {
                string msg = ex.InnerException.Message;
                MessageBox.Show(msg);
            }
        }
    }
}
