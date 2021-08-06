using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCMP1005.Data.FileManager
{
    public class FileManager : IFileManager
    {
        private string _imagePath;

        public FileManager(IConfiguration config)
        {
            _imagePath = config["Path:Images"];
        }

        public async Task<string> SaveImage(IFormFile Image)
        {
            var save_path = Path.Combine(_imagePath);
            if(!Directory.Exists(save_path))
            {
                Directory.CreateDirectory(save_path);
            }

            var mime = Image.FileName.Substring(Image.FileName.LastIndexOf("."));

            var fileName = $"img_{DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss")}{mime}";

            // using limit the Idisposable object to the scope

            using (var fileStream = new FileStream(Path.Combine(save_path,fileName),FileMode.Create))
            {
                await Image.CopyToAsync(fileStream);
            }
            return fileName;
        }

        
    }
}
