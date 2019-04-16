using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtube.AutoUpload.YougGetDownload.Models
{
    public class ConfigureFileModel
    {
        public string Url { get; set; }

        public string DownloadFilePath { get; set; }

        public DateTime UpdateTime { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
