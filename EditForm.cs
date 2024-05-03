using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRZReader.Model;
using System.Windows.Forms;
using System.Web.Script.Serialization;

namespace MRZReader
{
    public partial class EditForm : Form
    {

        HTTPHelper http = new HTTPHelper();
        string idUji;
        string userId;
        string urlSails;
        string urlLogin;
        string urlUpdateUserId;
        string urlSetStatus;
        string noPermohonan;
        bool isBatal = true;

        public EditForm()
        {
            InitializeComponent();
        }

        public EditForm(string idUji, string userId, string urlSails, string urlLogin, string urlUpdateUserId, string urlSetStatus, string token, string noPermohonan) : this()
        {
            this.idUji = idUji;
            this.userId = userId;
            this.urlSails = urlSails;
            this.urlLogin = urlLogin;
            this.urlUpdateUserId = urlUpdateUserId;
            this.urlSetStatus = urlSetStatus;
            this.noPermohonan = noPermohonan;
            http.token = token;
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            isBatal = true;
            this.Close();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {

                string username = "";
                string password = "";

                if (tbUsername.Text != "" && tbPassword.Text != "")
                {
                    username = tbUsername.Text;
                    password = tbPassword.Text;
                }
                else
                {
                    MessageBox.Show("Username atau password tidak terisi, silahkan diisi dan coba lagi.", "Error");
                    return;
                }

                SentLoginData loginData = new SentLoginData()
                {
                    username = username,
                    password = password,
                    kodePermohonan = noPermohonan
                };

                string responseJson = http.GetHTTPRequest<SentLoginData>(loginData, urlLogin, true);

                if (responseJson != "404")
                {
                    ResponseLogin result = responseJson.ToObj<ResponseLogin>();

                    if (result.flag)
                    {
                        SentUpdateData updateData = new SentUpdateData()
                        {
                            id = idUji,
                            userId = userId
                        };

                        string successSave = http.GetHTTPRequest<SentUpdateData>(updateData, urlUpdateUserId, true);

                        if (successSave != "404")
                        {

                            ResponseTestDokim resultSave = successSave.ToObj<ResponseTestDokim>();

                            if (resultSave.responseStatus == "200")
                            {

                                SentStatus sentstatus = new SentStatus()
                                {
                                    id = idUji,
                                    type = "ujikualitas",
                                    status = "ubah"
                                };

                                string success = http.GetHTTPRequest<SentStatus>(sentstatus, urlSetStatus, true);

                                SentSailsData data = new SentSailsData()
                                {
                                    id = idUji,
                                    type = "ujikualitas",
                                    action = "edit",
                                    kodePermohonan = noPermohonan,
                                    userId = result.userDPRI.id

                                };

                                if (!urlSails.ToUpper().Equals("FALSE"))
                                {
                                    string exchange = http.GetHTTPRequest<SentSailsData>(data, urlSails, false);
                                }
                                isBatal = false;
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Terjadi kesalahan, silahkan coba lagi.", "Error: update user");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Terjadi kesalahan, silahkan coba lagi.", "Error: update user");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Username atau password salah, silahkan coba lagi.", "Error: Login");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Terjadi kesalahan, silahkan coba lagi.", "Error: Login");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
                return;
            }
        }

        private void EditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isBatal)
            {
                this.DialogResult = DialogResult.Cancel;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
