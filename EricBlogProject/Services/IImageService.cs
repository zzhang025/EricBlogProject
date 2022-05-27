using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Collections.Generic;

namespace EricBlogProject.Services
{
    public interface IImageService
    {
        Task<byte[]> EncodeImageAsync(IFormFile file);

        Task<byte[]> EncodeImageAsync(string filename);

        string DecodeImage(byte[] data, string type);

        string ContentType(IFormFile file);

        int Size(IFormFile file);

    }
}
