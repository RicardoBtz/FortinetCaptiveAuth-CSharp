using System;
using System.Collections.Generic;
using System.Windows;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using RestSharp;
using System.Collections.Specialized;

namespace Fortinet
{
    class Autenticacion
    {
        public void Login(string user, string pass)
        {
            var url1 = "http://www.google.co.in";
            var headers = "User-Agent': 'Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.99 Safari/537.36";

            RestClient client = new RestClient(url1);
            RestRequest request = new RestRequest(Method.GET);
            request.AddHeader("header", headers);
            var response = client.Execute(request).Content;

            var magic = response.Substring(1142, 16);
            var Tredir = "http://google.co.in/";
            var username = user;
            var password = pass;

            var url2 = "http://192.168.201.6:1000/";
            using (var client2 = new WebClient())
            {
                var values = new NameValueCollection();
                values["4Tredir"] = Tredir;
                values["magic"] = magic;
                values["username"] = user;
                values["password"] = pass;

                var response2 = client2.UploadValues(url2, values);
                var responseString = Encoding.Default.GetString(response2);
                
                if (responseString == "")
                {
                    MessageBox.Show("Falló en responder \nContacta a Sistemas", "Error", MessageBoxButton.OK);
                    Application.Current.Shutdown();
                }
            }
        }
    }
}