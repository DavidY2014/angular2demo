using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youtube.AutoUpload.YougGetDownload.Models;

namespace Youtube.AutoUpload.YougGetDownload
{
    public class DownloadService : IDownload
    {
        //public ConfigureFileModel _configure { get; set; }

        public void DownloadVideo(ConfigureFileModel model)
        {
            if (model.Url == string.Empty)
            {
                Console.WriteLine(model.Title + "not exist");
                return;
            }

            var dir = Path.Combine( Directory.GetCurrentDirectory(), DateTime.Now.Year.ToString()+DateTime.Now.Month.ToString()+DateTime.Now.Day.ToString());

            if (Directory.Exists(dir))//如果不存在就创建file文件夹
            {
                Directory.CreateDirectory(dir);
            }


            var strInput = string.Format("you-get {0} -o {1}",model.Url , dir);

            Process p = new Process();
            //设置要启动的应用程序
            p.StartInfo.FileName = "cmd.exe";
            //是否使用操作系统shell启动
            p.StartInfo.UseShellExecute = false;
            // 接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardInput = true;
            //输出信息
            p.StartInfo.RedirectStandardOutput = true;
            // 输出错误
            p.StartInfo.RedirectStandardError = true;
            //不显示程序窗口
            p.StartInfo.CreateNoWindow = false;
            //启动程序
            p.Start();

            //向cmd窗口发送输入信息
            p.StandardInput.WriteLine(strInput + " &exit");

            p.StandardInput.AutoFlush = true;

            //获取输出信息
            string strOuput = p.StandardOutput.ReadToEnd();
            //等待程序执行完退出进程
            p.WaitForExit();
            p.Close();

            Console.WriteLine(strOuput);


        }

        public List<ConfigureFileModel> ReadConfigureFile()
        {
            //文件路径
            string filePath = @"./configure.json";
            try
            {
                if (File.Exists(filePath))
                {
                    byte[] mybyte = Encoding.UTF8.GetBytes(File.ReadAllText(filePath));
                    var jsonStr = Encoding.UTF8.GetString(mybyte);
                    List<ConfigureFileModel> models = JsonConvert.DeserializeObject<List<ConfigureFileModel>>(jsonStr);
                    return models;
                }
                else
                {
                    Console.WriteLine("configure file not exist");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public string SerializeObjectToString(List<ConfigureFileModel> models )
        {
            //var result = new ConfigureFileModel
            //{
            //    Description = "this is test",
            //    Title = "test",
            //    DownloadFilePath = "dasdasdasda",
            //    UpdateTime = DateTime.Now,
            //    Url = "https://www.bilibili.com/video/av49311903/?spm_id_from=333.334.b_63686965665f7265636f6d6d656e64.16"
            //};
            string jsonStr = JsonConvert.SerializeObject(models);
            using (StreamWriter file = new StreamWriter(@"./configure.json", true))
            {
                file.Write(jsonStr);
            }

            return jsonStr;      
        }



    }
}
