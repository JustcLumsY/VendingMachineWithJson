using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace VendingMachineWithJson
{
    internal class JsonHandler
    {
       private static string path = @"C:\Users\cLuMsY\Desktop\Wares.json";
       private static string text = File.ReadAllText(path);
        public static List<Ware> GetListFromJson()
        {
            var temp = JsonConvert.DeserializeObject<List<Ware>>(text);
            return temp;
        }
        public static void WriteToJson(List<Ware> temp)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(temp));
        }
    }
}
