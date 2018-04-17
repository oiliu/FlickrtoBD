using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiduImgDemo
{
    class LoadDataCommon
    {
        //const string URL = "http://image.baidu.com/channel/listjson?pn=0&rn=10&tag1={0}&tag2=全部&ie=utf8";
        const string URL = "http://image.baidu.com/channel/listjson?pn={0}&rn={1}&tag1={2}&tag2=全部&ie=utf8";

        static int pageIndex = 0;
        static int pageCount = 10;
        static string tag1 = "";

        public static void InitData(int pn = 0, int rn = 10, string t1 = "")
        {
            pageIndex = pn;
            pageCount = rn;
            tag1 = t1;

        }

        public static async Task<totalClass> LoadData()
        {
            string result = "";
            string url = string.Format(URL, pageIndex, pageCount, tag1);
            result = await GetGo.GetAsyncData(url);
            totalClass t = JsonConvert.DeserializeObject<totalClass>(result);
            return t;
        }
    }
}
