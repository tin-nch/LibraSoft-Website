using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librasoft.Infrastructure.Helpers
{
    public class SettingHelper
    {
        //public static void AddOrUpdateAppSetting<T>(string key, T value)
        //{
        //    try
        //    {

        //        var filePath = Path.Combine(AppContext.BaseDirectory, "appsettings.json");
        //        string json = File.ReadAllText(filePath);
        //        dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

        //        SetValueRecursively(key, jsonObj, value);

        //        string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
        //        File.WriteAllText(filePath, output);

        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Error writing app settings");
        //    }
        //}

        //private static void SetValueRecursively<T>(string sectionPathKey, dynamic jsonObj, T value)
        //{
        //    // split the string at the first ':' character
        //    var remainingSections = sectionPathKey.Split(":", 2);

        //    var currentSection = remainingSections[0];
        //    if (remainingSections.Length > 1)
        //    {
        //        // continue with the procress, moving down the tree
        //        var nextSection = remainingSections[1];
        //        SetValueRecursively(nextSection, jsonObj[currentSection], value);
        //    }
        //    else
        //    {
        //        // we've got to the end of the tree, set the value
        //        jsonObj[currentSection] = value;
        //    }
        //}
    }
}
