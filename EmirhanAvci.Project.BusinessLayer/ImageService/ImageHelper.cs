using EmirhanAvci.Project.BusinessLayer.Abstract;
using EmirhanAvci.Project.DataAccessLayer.Abstract;
using EmirhanAvci.Project.EntityLayer.Dtos.ProductDtos;
using EmirhanAvci.Project.SharedLayer.Utilities.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirhanAvci.Project.BusinessLayer.ImageService
{
    public static class ImageHelper
    {
        //public static async Task<string> ImageUpload(ProductAddDto productAddDto, IWebHostEnvironment)
        //{
        //    string wwwroot = _env.WebRootPath;  //wwwroot folderpath
        //    string fileName2 = Path.GetFileNameWithoutExtension(productAddDto.ImageFile.FileName);
        //    //.png
        //    string fileExtension = Path.GetExtension(productAddDto.ImageFile.FileName);
        //    DateTime dateTime = DateTime.Now;
        //    string fileName = $"{productAddDto.Name}_{dateTime.FullDateAndTimeStringWithUnderScore()}_{fileName2}{fileExtension}";
        //    var path = Path.Combine($"{ wwwroot}/img", fileName);

        //    await using (var stream = new FileStream(path, FileMode.Create))
        //    {
        //        await productAddDto.ImageFile.CopyToAsync(stream);
        //    }
        //    return fileName;
        //}
    }
}
