using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Newtonsoft.Json;

namespace VendingMachineWithJson
{
    internal class VendingMachine
    {
        VendingDisplay vendingDisplay = new VendingDisplay();
        MoneyHandler moneyHandler = new MoneyHandler();
        
        public void ChooseWare()
        {
            var temp = GetListFromJson();
            Console.WriteLine("Choose a product name");
            var userInputString = Console.ReadLine();
            var userChoice = temp.FirstOrDefault(x => x.Name.ToLower() == userInputString.ToLower());
            InsertAmountOfMoney(userChoice);
            WriteToJson(temp);
        }

        private void InsertAmountOfMoney(Ware userchoice)
        {
            var temp = GetListFromJson();
            Console.Clear();
            CheckStorage(userchoice.Amount);
            userchoice.Amount--;
            WriteToJson(temp);
            Console.WriteLine($" {userchoice.Name} ");
            Console.WriteLine($"Insert {userchoice.Price}Kr");
            var userInputInt = Convert.ToInt32(Console.ReadLine());
            MoneyHandler.AmountOfMoney = userInputInt;

            while (userInputInt < userchoice.Price)
            {
                Console.WriteLine("Not enough money");
                userInputInt = Convert.ToInt32(Console.ReadLine());
                MoneyHandler.AmountOfMoney += userInputInt;
            }
            if (MoneyHandler.AmountOfMoney >= userchoice.Price)
            {
                moneyHandler.SuccessfulPurchase(userchoice.Price);
                Console.Clear();
                Console.WriteLine($"Thanks for buying {userchoice.Name}");
                Console.WriteLine($"Money back: {MoneyHandler.AmountOfMoney}Kr");
            }
        }
        private List<Ware> GetListFromJson()
        {
            var path = @"C:\Users\cLuMsY\Desktop\Wares.json";
            var text = File.ReadAllText(path);
            var temp = JsonConvert.DeserializeObject<List<Ware>>(text);
            return temp;
        }
        private static void WriteToJson(List<Ware> temp)
        {
            var path = @"C:\Users\cLuMsY\Desktop\Wares.json";
            var text = File.ReadAllText(path);
            //var temp = JsonConvert.DeserializeObject<List<Ware>>(text);
            File.WriteAllText(path, JsonConvert.SerializeObject(temp));
        }

        private void CheckStorage(int amount)
        {
            Console.Clear();
            if (amount > 0) return;
            Console.WriteLine("Out of stock");
            amount = 0;
            Thread.Sleep(1500);
            vendingDisplay = new VendingDisplay();
            ChooseWare();
        }
    }
}
