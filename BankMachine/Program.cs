using System;

namespace BankMachine
{
    class Program
    {
        // Leo F SUT22
        public static void Main(string[] args)
        {
            // 2D arrays to store each user and accounts.
            string[,] allUsers = new string[,] { { "John", "1234" }, { "Roger", "3056" }, { "Jessica", "1010" }, { "Cindy", "0010" }, { "Joe", "5050" } };
            decimal[,] accounts = new decimal[,] { { 13942.44m, 43000.00m }, { 13.45m, 0.0m }, { 8473.99m, 382435.00m }, { 100.99m, 2000.00m }, { 1930.50m, 100000.00m } };
            Login(accounts, allUsers);
        }
        // Login structure let's user try to login 3 times or else the app closes.
        static void Login(decimal[,] accounts, string[,] allUsers)
        {
            int displayTry = 2;
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

                for (int i = 0; i < allUsers.Length / 2; i++)
                {

                    if (allUsers[i, 0] == inputName && allUsers[i, 1] == inputPin)
                    {
                        userNameValid = true;
                        userPinValid = true;
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
                    Console.WriteLine("Error loggin in. You have {0} tries left", displayTry);
                    tries++;
                    displayTry--;
                }
            } while (tries < 3);
            Console.WriteLine("Wrong input too many timees, Please restart the app and try again");
            Environment.Exit(0);
        }
        // Menu selection section.
        static void Menu(string current, decimal[,] accounts, string[,] allUsers)
        {
            Console.Clear();
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
        static void UserMenuChoice(int userInput, string user, decimal[,] accounts, string[,] allUsers, out int error)
        {
            switch (userInput)
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
                    MakeWithdraw(user, allUsers, accounts);
                    error = 0;
                    break;
                case 4:
                    Login(accounts,allUsers);
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
                    currentUser = 0;
                    break;
                case "Roger":
                    first = accounts[1, 0];
                    second = accounts[1, 1];
                    currentUser = 1;
                    break;
                case "Jessica":
                    first = accounts[2, 0];
                    second = accounts[2, 1];
                    currentUser = 2;
                    break;
                case "Cindy":
                    first = accounts[3, 0];
                    second = accounts[3, 1];
                    currentUser = 3;
                    break;
                case "Joe":
                    first = accounts[4, 0];
                    second = accounts[4, 1];
                    currentUser = 4;
                    break;
            }
            return currentUser;
        }
        // Displays all account balances
        static void ViewAcountBalance(string user, decimal[,] accounts, string[,] allUsers)
        {
            UserAccounts(accounts, user, out decimal first, out decimal second);
            Math.Round(first, 2, MidpointRounding.ToEven);
            Math.Round(second, 2, MidpointRounding.ToEven);
            if (user == "Roger")
            {
                Console.WriteLine("Main account: {0:C}", first);
            }
            else if (user == "Jessica")
            {
                Console.WriteLine("Main account: {0:C}", first);
                Console.WriteLine("Salery account: {0:C}", second);
            }
            else
            {
                Console.WriteLine("Main account: {0:C}", first);
                Console.WriteLine("Savings account: {0:C}", second);
            }
            Console.WriteLine("Press enter to return to the menu:");
            Console.ReadKey();
            Console.Clear();
            Menu(user, accounts, allUsers);
        }
        // Method for transfering money between accounts
        static void TransferMoney(string user, decimal[,] accounts, string[,] allUsers)
        {
            if (user == "Roger")
            {
                Console.WriteLine("You only have 1 account and therefore can't transfer between others, Press enter to return to menu");
                Console.ReadKey();
                Menu(user, accounts, allUsers);
            }
            int selectedAccountInput = 0;
            var isValid = false;
            decimal amountToTransfer = 0m;
            Console.WriteLine("From what account do you wish to move money from?");
            ShowCurrentAccount(user, allUsers, accounts);
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
            Console.WriteLine("Now enter to what account you would like to move the money to:");
            int scdSelectedAccountInput = 0;
            while (isValid == false)
            {
                try
                {
                    scdSelectedAccountInput = int.Parse(Console.ReadLine());
                    isValid = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            isValid = false;
            Console.Write("Now enter the amount you wish to move: ");
            while (isValid == false)
            {
                try
                {
                    amountToTransfer = decimal.Parse(Console.ReadLine());
                    isValid = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            int currentUser = UserAccounts(accounts, user, out decimal first, out decimal second);
            if (ValidAmountToTransfer(amountToTransfer, selectedAccountInput, first, second))
            {
                UpdatedNewAmountBalance(currentUser, amountToTransfer, selectedAccountInput, scdSelectedAccountInput, accounts);
            }
            Console.WriteLine("The current account balance is now: ");
            ShowCurrentAccount(user, allUsers, accounts);
            Console.WriteLine("Press enter to return to menu");
            Console.ReadLine();
            Console.Clear();
            Menu(user, accounts, allUsers);
        }
        // Method for withdrawing money.
        static void MakeWithdraw(string cUser, string[,] allUsers, decimal[,] accounts)
        {
            bool isValid = false;
            int user = UserAccounts(accounts, cUser, out decimal first, out decimal second);
            int selectedAccount = 0;
            decimal ammountToWithdraw = 0;
            ShowCurrentAccount(cUser, allUsers, accounts);
            Console.WriteLine("Enter from what account you would like to make the withdraw");
            while (isValid == false)
            {
                try
                {
                    selectedAccount = int.Parse(Console.ReadLine());
                    isValid = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            isValid = false;
            Console.WriteLine("Now enter the amount you would like to withdraw");
            while (isValid == false)
            {
                try
                {
                    ammountToWithdraw = decimal.Parse(Console.ReadLine());
                    isValid = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine("Now enter pincode to accept the withdraw: ");
            string pin = Console.ReadLine();
            if (!PinCodeCheck(pin, allUsers))
            {
                Menu(cUser, accounts, allUsers);
            }
            if (ValidAmountToTransfer(ammountToWithdraw, selectedAccount, first, second))
            {
                for (int i = 0; i < accounts.Length / 2; i++)
                {
                    if (user == i && selectedAccount == 1)
                    {
                        accounts[i, 0] -= ammountToWithdraw;
                        break;
                    }
                    else if (user == i && selectedAccount == 2 && user != 1)
                    {
                        accounts[i, 1] -= ammountToWithdraw;
                        break;
                    }
                }
            }
            Console.WriteLine("The current account balance is now: ");
            ShowCurrentAccount(cUser, allUsers, accounts);
            Console.WriteLine("Press enter to return to menu");
            Console.ReadLine();
            Menu(cUser, accounts, allUsers);
        }
        // Method for handling user accounts seperate with forcing to return to menu like "ViewAccountBalance.
        static void ShowCurrentAccount(string user, string[,] allUsers, decimal[,] accounts)
        {
            for (int i = 0; i < allUsers.Length / 2; i++)
            {
                if (allUsers[i, 0].Contains(user) && user != "Roger")
                {
                    Console.WriteLine("1) Main account: {0:C}", accounts[i, 0]);
                    Console.WriteLine("2) Savings account: {0:C}", accounts[i, 1]);
                    break;
                }
                else if (allUsers[i, 0].Contains(user) && user == "Jessica")
                {
                    Console.WriteLine("1) Main account: {0:C}", accounts[i, 0]);
                    Console.WriteLine("2) Salery account: {0:C}", accounts[i, 1]);
                    break;
                }
                else if (allUsers[i, 0].Contains(user))
                {
                    Console.WriteLine("1) Main account: {0:C}", accounts[i, 0]);
                    break;
                }
            }
        }
        // Method to update account balance.
        static void UpdatedNewAmountBalance(int user, decimal amountToTransfer, int selectedAccount, int scdSelectedAccount, decimal[,] accounts)
        {
            for (int i = 0; i < accounts.Length / 2; i++)
            {
                if (user == i && selectedAccount == 1 && scdSelectedAccount == 2)
                {
                    accounts[i, 0] -= amountToTransfer;
                    accounts[i, 1] += amountToTransfer;
                    break;
                }
                else if (user == i && selectedAccount == 2 && scdSelectedAccount == 1)
                {
                    accounts[i, 1] -= amountToTransfer;
                    accounts[i, 0] += amountToTransfer;
                    break;
                }
            }
        }
        // Method to check if the amount wanted to be transferd is within range of what is on the account.
        static bool ValidAmountToTransfer(decimal amountToTransfer, int selectedAccount, decimal first, decimal second)
        {
            if (amountToTransfer > first && selectedAccount != 2 || amountToTransfer > second && selectedAccount != 1)
            {
                Console.WriteLine("The amount is to great for what exists, Press enter to continue");
                Console.ReadKey();
                return false;
            }
            else if (amountToTransfer <= 0 || amountToTransfer <= 0)
            {
                Console.WriteLine("The amount is to small for what exists, Press enter to continue");
                Console.ReadKey();
                return false;
            }
            else
            {
                return true;
            }
        }
        // Method to check if pin is valid when withdraw is made.
        static bool PinCodeCheck(string pin, string[,] allUsers)
        {
            bool isValid = false;
            for (int i = 0; i < allUsers.Length / 2; i++)
            {
                try
                {
                    if (allUsers[i, 1] == pin)
                    {
                        isValid = true;
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine("Wrong pincode, Press enter to return to menu and try again");
                    Console.ReadLine();
                    break;
                }

            }
            return isValid;
        }
    }
}

