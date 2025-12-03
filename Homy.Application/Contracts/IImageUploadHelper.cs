using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homy.Application.Contracts
{
    public interface IImageUploadHelper
    {
        Task<string> UploadImageAsync(IFormFile ImageFile, string folderName);
        Task<List<string>> UploadMultipleImagesAsync(List<IFormFile> ImageFiles, string FolderName);
        bool DeleteImage(string ImageUrl);
        bool IsValidImage(IFormFile file);
    }
}
