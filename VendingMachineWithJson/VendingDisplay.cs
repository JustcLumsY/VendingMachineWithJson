using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace VendingMachineWithJson
{
    internal class VendingDisplay
    {
       
        public VendingDisplay()
        {

            PrintWareInfo();
        }

        private void PrintWareInfo()
        {
            var path = @"C:\Users\cLuMsY\Desktop\Wares.json";
            var text = File.ReadAllText(path);
            var temp = JsonHandler.GetListFromJson();
            File.WriteAllText(path, JsonConvert.SerializeObject(temp));

            foreach (var ware in temp)
            {
                Console.WriteLine(ware.Name);
                Console.WriteLine($"{ware.Price}Kr");
                Console.WriteLine($"Stock:{ware.Amount}");
                Console.WriteLine("\n");
            }
        }
    }
}
