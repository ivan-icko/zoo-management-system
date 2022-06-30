using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ZooloskiVrt.Server.Maina
{
    public static class ApiHelper
    {
        public static HttpClient ApiClient { get; set; }//static je zato sto hocemo da imamo jednog apiclienta za celu aplikaciju

        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //trazim da mi se vrati json
        }


    }
}