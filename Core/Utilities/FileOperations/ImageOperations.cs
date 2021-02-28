using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
namespace Core.Utilities.FileOperations
{
    public class ImageOperations
    {
        public static void CheckIsExıstsDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public static void CreateImageFile(string path,IFormFile imageFile)
        {
            using (FileStream fs = File.Create(path))
            {
                imageFile.CopyTo(fs);
                fs.Flush();
            }
        }

        public static IResult DeleteImageFile(string path)
        {
            if (File.Exists(path.Replace("/", "\\")))
            {
                File.Delete(path.Replace("/", "\\"));
                return new SuccessResult("Resim silindi");
            }
            return new ErrorResult("Resim mevcut değil");
        }

        public static IResult CheckImageFileExtension(string fileExtension)
        {
            if (fileExtension != ".jpeg" && fileExtension != ".png" && fileExtension != ".jpg")
            {
                return new ErrorResult("Sadece .jpeg , .jpg ve .png uzantılı dosyalar ekleyebilirsini");
            }

            return new SuccessResult();
        }

    }
}
