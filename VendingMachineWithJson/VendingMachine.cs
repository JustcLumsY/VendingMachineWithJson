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
            var temp = JsonHandler.GetListFromJson();
            Console.WriteLine("Choose a product name");
            var userInputString = Console.ReadLine();
            var userChoice = temp.FirstOrDefault(x => x.Name.ToLower() == userInputString.ToLower());
            InsertAmountOfMoney(userChoice);
            JsonHandler.WriteToJson(temp);
        }

        private void InsertAmountOfMoney(Ware userchoice)
        {
            var temp = JsonHandler.GetListFromJson();
            Console.Clear();
            CheckStorage(userchoice.Amount);
            userchoice.Amount--;
            JsonHandler.WriteToJson(temp);
            Console.WriteLine($" {userchoice.Name} ");
            Console.WriteLine($"Insert {userchoice.Price}Kr");
            var userInputInt = Convert.ToInt32(Console.ReadLine());
            moneyHandler.AddAmountOfMoney(userInputInt);

            while (userInputInt < userchoice.Price)
            {
                Console.WriteLine("Not enough money");
                userInputInt = Convert.ToInt32(Console.ReadLine());
                moneyHandler.AddAmountOfMoney(userInputInt);
            }

            if (moneyHandler.AmountOfMoney >= userchoice.Price)
            {
                moneyHandler.SuccessfulPurchase(userchoice.Price);
                Console.Clear();
                Console.WriteLine($"Thanks for buying {userchoice.Name}");
                Console.WriteLine($"Money back: {moneyHandler.AmountOfMoney}Kr");
            }
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
