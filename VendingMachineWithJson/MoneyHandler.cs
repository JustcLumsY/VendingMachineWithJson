namespace VendingMachineWithJson
{
    internal class MoneyHandler
    {
        public static int AmountOfMoney;

        public int SuccessfulPurchase(int price)
        {
            AmountOfMoney -= price;
            return AmountOfMoney;
        }
    }
}
