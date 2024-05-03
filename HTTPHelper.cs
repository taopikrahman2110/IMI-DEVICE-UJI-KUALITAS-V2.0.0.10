using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;

using PassportPrinter.Model;
using System.IO;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace MRZReader
{
    public class HTTPHelper
    {
        public string token;

        public string GetHTTPRequest<T>( T data, string url, bool needToken)
        {
            string requestJson;
            string responseJson;

            try
            {
                requestJson = data.ToJSON();

                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";

                if (needToken)
                {
                    httpWebRequest.Headers.Add("iauth", token);
                }

                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(requestJson);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    responseJson = streamReader.ReadToEnd();
                }

                return responseJson;
            }
            catch (Exception ex)
            {
                if (needToken)
                {
                    MessageBox.Show(ex.Message);
                }
                return "404";
            }
        }

    }
}
