using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youtube.AutoUpload.YougGetDownload.Models;

namespace Youtube.AutoUpload.YougGetDownload
{
    public interface IDownload
    {
        List<ConfigureFileModel> ReadConfigureFile();

        void DownloadVideo(ConfigureFileModel model);


    }


}
