

using System;

namespace VendingMachineWithJson
{
    static class UserInput
    {
        public static string userInput = null;
        public static int userInputInt;
        public static void UserInputs()
        {
            userInput = Console.ReadLine();
        }
        public static void UserInputInt()
        {
            userInputInt = Convert.ToInt32(Console.ReadLine());
        }

    }

}
