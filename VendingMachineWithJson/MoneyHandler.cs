namespace VendingMachineWithJson
{
    internal class MoneyHandler
    {
        public int AmountOfMoney { get; private set; }

        public MoneyHandler()
        {
            AmountOfMoney = 0;
        }

        public int SuccessfulPurchase(int price)
        {
            AmountOfMoney -= price;
            return AmountOfMoney;
        }

        public void AddAmountOfMoney(int input)
        {
            AmountOfMoney += input;
        }

     
    }
}
