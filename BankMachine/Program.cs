using System;

namespace BankMachine
{
    class Program
    {
        // 2D array to store each user.

        public static void Main(string[] args)
        {
            string[,] allUsers = new string[,] { { "John", "1234" }, { "Roger", "3056" }, { "Jessica", "1010" }, { "Cindy", "0010" }, { "Joe", "5050" } };
            decimal[,] accounts = new decimal[,] { { 13942.44m, 43000.00m }, { 13.45m, 0m }, { 8473.99m, 382435.00m }, { 100.99m, 2000.00m }, { 1930.50m, 100000.00m } };
            Login(accounts, allUsers);
        }
        // Login structure let's user try to login 3 times or else the app closes.
        static void Login(decimal[,] accounts, string[,] allUsers)
        {
            Console.Clear();
            int tries = 0;
            do
            {
                bool userNameValid = false;
                bool userPinValid = false;
                Console.WriteLine("Welcome to the bank");
                Console.WriteLine();
                Console.Write("Username: ");
                var inputName = Console.ReadLine();
                Console.WriteLine();
                Console.Write("PIN-Code: ");
                var inputPin = Console.ReadLine();

                for (int i = 0; i < allUsers.Length; i++)
                {
                    try
                    {
                        if (allUsers[i, 0].Contains(inputName) && allUsers[i, 1].Contains(inputPin))
                        {
                            userNameValid = true;
                            userPinValid = true;
                            break;
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Wrong input type. Enter username and 4 digit PIN");
                        break;
                    }
                }
                if (userNameValid == true && userPinValid == true)
                {
                    Console.WriteLine("Success");
                    Menu(inputName, accounts, allUsers);
                }
                else if (!userNameValid && !userPinValid)
                {
                    Console.WriteLine("Error loggin in.");
                    tries++;
                }
            } while (tries < 3);
            Console.WriteLine("Wrong input too many timees, Please restart the app and try again");
            Environment.Exit(100);
        }
        // Menu selection section.
        static void Menu(string n, decimal[,] accounts, string[,] allUsers)
        {
            Console.Clear();
            string current = n;
            bool isRuning = true;
            int input = 0;
            Console.WriteLine("Welcome {0}", current);
            while (isRuning)
            {
                Console.WriteLine("1) Check account balance.");
                Console.WriteLine("2) Transfer between acounts");
                Console.WriteLine("3) Withdraw");
                Console.WriteLine("4) Logout");
                try
                {
                    int.TryParse(Console.ReadLine(), out input);
                }
                catch (Exception)
                {
                    Console.WriteLine("Wrong input, Choose 1,2,3 or 4");
                }
                UserMenuChoice(input, current, accounts, allUsers, out int e);
                if (e == 0) isRuning = false;
                else if (e == 1) continue;
            }

        }
        static void UserMenuChoice(int x, string user, decimal[,] accounts, string[,] allUsers, out int error)
        {
            switch (x)
            {
                case 1:
                    ViewAcountBalance(user, accounts, allUsers);
                    error = 0;
                    break;
                case 2:
                    TransferMoney(user, accounts, allUsers);
                    error = 0;
                    break;
                case 3:
                    MakeWithdraw();
                    error = 0;
                    break;
                case 4:
                    Logout(accounts, allUsers);
                    error = 0;
                    break;
                default:
                    Console.WriteLine("Wrong input. Type 1,2,3 or 4 and press enter");
                    error = 1;
                    break;
            }
        }
        // Asigns account balance depending on user.
        static int UserAccounts(decimal[,] accounts, string user, out decimal first, out decimal second)
        {
            int currentUser = 0;
            first = 0;
            second = 0;
            switch (user)
            {
                case "John":
                    first = accounts[0, 0];
                    second = accounts[0, 1];
                    currentUser = 1;
                    break;
                case "Roger":
                    first = accounts[1, 0];
                    second = accounts[1, 1];
                    currentUser = 2;
                    break;
                case "Jessica":
                    first = accounts[2, 0];
                    second = accounts[2, 1];
                    currentUser = 3;
                    break;
                case "Cindy":
                    first = accounts[3, 0];
                    second = accounts[3, 1];
                    currentUser = 4;
                    break;
                case "Joe":
                    first = accounts[4, 0];
                    second = accounts[4, 1];
                    currentUser = 5;
                    break;
            }
            return currentUser;
        }
        static void ViewAcountBalance(string user, decimal[,] accounts, string[,] allUsers)
        {
            UserAccounts(accounts, user, out decimal first, out decimal second);
            if (user == "Roger")
            {
                Console.WriteLine("Main account: {0}", first);
            }
            else if (user == "Jessica")
            {
                Console.WriteLine("Main account: {0}", first);
                Console.WriteLine("Salery account: {0}", second);
            }
            else
            {
                Console.WriteLine("Main account: {0}", first);
                Console.WriteLine("Savings account: {0}", second);
            }
            Console.WriteLine("Press enter to return to the menu:");
            Console.ReadKey();
            Console.Clear();
            Menu(user, accounts, allUsers);
        }
        static void TransferMoney(string user, decimal[,] accounts, string[,] allusers)
        {
            int selectedAccountInput = 0;
            var isValid = false;
            decimal amountToTransfer = 0m;
            Console.WriteLine("From what account do you wish to move money from?");
            ViewAcountBalance(user, accounts, allusers);
            while (isValid == false)
            {
                try
                {
                    selectedAccountInput = int.Parse(Console.ReadLine());
                    isValid = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            isValid = false;
            Console.Clear();
            Console.Write("Now enter the amount you wish to move: ");
            while (isValid == false)
            {
                try
                {
                    amountToTransfer = decimal.Parse(Console.ReadLine());
                    isValid = true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            int currentUser = UserAccounts(accounts, user, out decimal first, out decimal second);
            if(ValidAmountToTransfer(amountToTransfer, first, second))
            {
                Console.WriteLine("working");
            }
            Console.Clear();
        }
        static void MakeWithdraw()
        {

        }
        static void Logout(decimal[,] accounts, string[,] allUsers)
        {
            Login(accounts, allUsers);
        }
        static void UpdatedNewAmount(int user, int amountToTransfer, int selectedAccount, decimal[,] accounts)
        {
            
        }
        static bool ValidAmountToTransfer(decimal amountToTransfer, decimal first, decimal second)
        {
            if(amountToTransfer > first || amountToTransfer < first)
            {
                Console.WriteLine("The amount is to great for what exists");
                return false;
            }
            else if(amountToTransfer > second || amountToTransfer < second)
            {
                Console.WriteLine("The amount is to small for what exists");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

