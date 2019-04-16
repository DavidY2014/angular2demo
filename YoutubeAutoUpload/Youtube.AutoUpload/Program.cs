using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youtube.AutoUpload.YougGetDownload;
using Youtube.AutoUpload.YougGetDownload.Models;

namespace Youtube.AutoUpload
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine(@"
********
*
*Acfun2Youtube
*            by david  on 20190416              
*************
1 下载视频
2 生成url
");
            var _service = new DownloadService();
            var choice  = Console.ReadLine();
            if (choice.Equals("1"))
            {
               
                var models = _service.ReadConfigureFile();
                foreach (var model in models)
                {
                    _service.DownloadVideo(model);
                }
            }
            if (choice.Equals("2"))
            {
                var _crawl = new CrawlUrl();
                Console.WriteLine("请输入Acfun的UP主页地址");
                var uphostHomePageUrl = Console.ReadLine();
                var models = _crawl.ExtractUrlFromHtml("http://www.acfun.cn/u/12892608.aspx");
                _service.SerializeObjectToString(models);
            }


        }
    }
}
