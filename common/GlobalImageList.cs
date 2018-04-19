using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiduImgDemo
{
    class GlobalImageList
    {
        public static GlobalImageList instance;
        static GlobalImageList()
        {
            if (instance == null)
            {
                instance = new GlobalImageList();
            }
        }

        public List<Tuple<string, string>> ImageList = new List<Tuple<string, string>>();
    }
}
