using Homy.Application.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homy.Application.Helpers
{
    public class ImageUploadHelper : IImageUploadHelper
    {
        private readonly string _wwwrootpath;
        private readonly long _maxFileSize = 5 * 1024 * 1024;
        private readonly string[] _allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".webp" };

        
        public ImageUploadHelper(IWebHostEnvironment environment)
        {
            _wwwrootpath = environment.WebRootPath;
        }

        public bool DeleteImage(string ImageUrl)
        {
            if (string.IsNullOrEmpty(ImageUrl))
                return false;

            try
            {
                // تحويل الـ URL النسبي لـ Physical Path
                var fileName = ImageUrl.Replace("/", "\\").TrimStart('\\');
                var filePath = Path.Combine(_wwwrootpath, fileName);

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"فشل حذف الصورة: {ImageUrl}. الخطأ: {ex.Message}");
                return false;
            }
        }

        public bool IsValidImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return false;

            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();

            if (!_allowedExtensions.Contains(extension))
                return false;

            // التحقق من الـ MIME Type
            var allowedMimeTypes = new[] { "image/jpeg", "image/jpg", "image/png", "image/gif", "image/webp" };
            if (!allowedMimeTypes.Contains(file.ContentType.ToLower()))
                return false;

            return true;
        }

        public async Task<string> UploadImageAsync(IFormFile ImageFile, string folderName)
        {
            if (ImageFile == null || ImageFile.Length == 0)
                throw new ArgumentException("الملف فارغ");

            if (!IsValidImage(ImageFile))
                throw new ArgumentException("نوع الملف غير مدعوم. الأنواع المسموحة: jpg, jpeg, png, gif, webp");

            if (ImageFile.Length > _maxFileSize)
                throw new ArgumentException($"حجم الملف يتجاوز الحد المسموح ({_maxFileSize / (1024 * 1024)}MB)");

            // إنشاء المسار
            var uploadsFolder = Path.Combine(_wwwrootpath, "images", folderName);

            // التأكد من وجود المجلد
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            // إنشاء اسم فريد للملف
            var uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(ImageFile.FileName)}";
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            // حفظ الملف
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await ImageFile.CopyToAsync(fileStream);
            }

            // إرجاع الـ URL النسبي
            return $"/images/{folderName}/{uniqueFileName}";
        }

        public async Task<List<string>> UploadMultipleImagesAsync(List<IFormFile> ImageFiles, string FolderName)
        {
            var uploadedUrls = new List<string>();

            foreach (var imageFile in ImageFiles)
            {
                try
                {
                    var url = await UploadImageAsync(imageFile, FolderName);
                    uploadedUrls.Add(url);
                }
                catch (Exception ex)
                {
                    // لو فيه صورة فشلت، نكمل باقي الصور
                    Console.WriteLine($"فشل رفع الصورة: {imageFile.FileName}. الخطأ: {ex.Message}");
                }
            }

            return uploadedUrls;
        }
    }
}
