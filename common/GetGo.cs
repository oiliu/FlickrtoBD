using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BaiduImgDemo
{
    class GetGo
    {
        public static async Task<string> GetAsyncData(string url)
        {
            string result = "";
            HttpClient httpCLient = new HttpClient();
            HttpResponseMessage response = null;
            response = await httpCLient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Response Status Code:" + response.StatusCode
                    + " " + response.ReasonPhrase);
                string responseBodyAsText = response
                    .Content
                    .ReadAsStringAsync()
                    .Result;
                result = responseBodyAsText;
            }
            return result;
        }
    }
}
