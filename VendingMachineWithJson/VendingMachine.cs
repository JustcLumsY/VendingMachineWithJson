using System;
using System.Linq;
using System.Threading;

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
            UserInput.UserInputs();
            var userChoice = temp.FirstOrDefault(x => x.Name.ToLower() == UserInput.userInput.ToLower());
            InsertAmountOfMoney(userChoice);
            JsonHandler.WriteToJson(temp);
        }

        private void InsertAmountOfMoney(Ware userchoice)
        {
            var temp = JsonHandler.GetListFromJson();
            Console.Clear();
            CheckStorage(userchoice.Amount, userchoice);
            JsonHandler.WriteToJson(temp);
            Console.WriteLine($" {userchoice.Name} ");
            Console.WriteLine($"Insert {userchoice.Price}Kr");
            UserInput.UserInputInt();
            moneyHandler.AddAmountOfMoney(UserInput.userInputInt);
            CheckIfEnoughMoney(userchoice);
            HaveEnoughMoneyAndMoneyBack(userchoice);
        }

        private void HaveEnoughMoneyAndMoneyBack(Ware userchoice)
        {
            if (moneyHandler.AmountOfMoney >= userchoice.Price)
            {
                moneyHandler.SuccessfulPurchase(userchoice.Price);
                Console.Clear();
                Console.WriteLine($"Thanks for buying {userchoice.Name}");
                Console.WriteLine($"Money back: {moneyHandler.AmountOfMoney}Kr");
            }
        }

        private void CheckIfEnoughMoney(Ware userchoice)
        {
            while (UserInput.userInputInt < userchoice.Price)
            {
                Console.WriteLine("Not enough money");
                UserInput.UserInputInt();
                moneyHandler.AddAmountOfMoney(UserInput.userInputInt);
            }
        }

        private void CheckStorage(int amount, Ware userchoice)
        {
            Console.Clear();
            if (amount > 0) { userchoice.Amount--; }
            else
            {
                Console.WriteLine("Out of stock");
                Thread.Sleep(1500);
                vendingDisplay = new VendingDisplay();
                ChooseWare();
            }
        }
    }
}
