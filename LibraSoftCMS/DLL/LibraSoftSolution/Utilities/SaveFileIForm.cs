using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraSoftSolution.API.Utilities
{
    public class SaveFileIForm
    {
        public async static Task<List<string>> UploadFile(IFormFile file, string emailFolder)
        {
            List<string> res = new List<string>();  
            DateTime now = DateTime.Now;
            var baseDate = new DateTime(1970, 1, 1, 1, 1, 0, 0);
            var toDate = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, now.Millisecond);
            Int32 dateId = (int)toDate.Subtract(baseDate).TotalSeconds;

            string currentPath = Directory.GetCurrentDirectory() + @"\Upload\Images\" + emailFolder;

            try
            {
                if (file.Length > 0)
                {

                    string editName = "CV_" + Path.GetFileNameWithoutExtension(file.FileName) + "_" + dateId.ToString() + Path.GetExtension(file.FileName);

                    // If directory does not exist, create it
                    if (!Directory.Exists(currentPath))
                    {
                        Directory.CreateDirectory(currentPath);
                    }

                    res.Add(editName);
                    res.Add(currentPath);

                    using (var filestream = new FileStream(Path.Combine(currentPath, editName), FileMode.Create))
                    {
                        await file.CopyToAsync(filestream);
                    }
                    return res;
                }
                return null;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
