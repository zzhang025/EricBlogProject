using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EricBlogProject.Services
{
    public class BasicImageService : IImageService
    {
        public string ContentType(IFormFile file)
        {
            return file?.ContentType;
        }

        public string DecodeImage(byte[] data, string type)
        {
            if (data is null || type is null) return null;
            return $"data:image/{type}:base64,{Convert.ToBase64String(data)}";
        }

        public async Task<byte[]> EncodeImageAsync(IFormFile file)
        {
            if (file is null) return null;
            using var ms = new MemoryStream();
            await file.CopyToAsync(ms);
            return ms.ToArray();
        }

        public async Task<byte[]> EncodeImageAsync(string filename)
        {
            var file = $"{Directory.GetCurrentDirectory()}/wwwroot/image/{filename}";
            return await File.ReadAllBytesAsync(file);
        }

        public int Size(IFormFile file)
        {
            return Convert.ToInt32(file?.Length);
        }
    }
}
