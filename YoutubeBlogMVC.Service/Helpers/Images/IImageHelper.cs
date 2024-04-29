using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlogMVC.Entity.Enums;
using YoutubeBlogMVC.Entity.ModelViews.Images;

namespace YoutubeBlogMVC.Service.Helpers.Images
{
    public interface IImageHelper
    {
        Task<ImageUploadedModelView> Upload(string name, IFormFile imageFile, ImageType imagetype, string folderName = null);
        void Delete(string imageName);
    }
}
