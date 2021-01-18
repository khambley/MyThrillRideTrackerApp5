using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using MyThrillRideTrackerApp5.Models;

namespace MyThrillRideTrackerApp5.Processors
{
	public static class ImageProcessor
	{
		public static List<string> SaveImageFilesToDrive(List<IFormFile> files)
		{
            List<string> newFileNames = new List<string>();

            if (files != null)
            {
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        //Getting FileName
                        var fileName = Path.GetFileName(file.FileName);

                        //Assigning Unique Filename (Guid)
                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                        //Getting file Extension
                        var fileExtension = Path.GetExtension(fileName);

                        // concatenating  FileName + FileExtension
                        var newFileName = String.Concat(myUniqueFileName, fileExtension);

                        // Combines two strings into a path.
                        var filepath =
                            new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images")).Root + $@"\{newFileName}";

                        using (FileStream fs = System.IO.File.Create(filepath))
                        {
                            file.CopyTo(fs);
                            fs.Flush();
                        }

                        newFileNames.Add(newFileName);
                        
                    }
                }
            }
            return newFileNames;
        }
	}
}
