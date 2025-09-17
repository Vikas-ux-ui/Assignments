using System;
using System.Collections.Generic;
namespace Assignment05BankAccountSystem
{
    internal class Program
    {

        static void Main(string[] args)
        {
            List<BankAccount> accounts = new List<BankAccount>()
             {
                 new BankAccount("Viaks","11111",5000.0),
                 new BankAccount("Vinay","22222",6000.0),
                 new BankAccount("Kishan","33333",7000),
                 new BankAccount("Jagriti","44444",6000),
                 new BankAccount("Simran","55555",5000),
             };
            BankAccount dummy = new BankAccount();
            Console.WriteLine($"{"Name",-10}{"AcountNumber",10} {"Balance",10}");
            foreach (BankAccount account in accounts)
            {
                Console.WriteLine($"{account.Name,-10}{account.AccountNumber,10}{account.Balance,10}");
            }
            while (true)
            {
                Console.WriteLine("Enter 1 to Deposite ");
                Console.WriteLine("Enter 2 to Withdraw ");
                Console.WriteLine("Enter 3 to Transfer ");
                Console.WriteLine("Enter 4 to Exit ");
                Console.WriteLine("Enter your Choice : ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        {
                            dummy.Deposite(accounts);
                            break;
                        }
                    case "2":
                        {
                            dummy.Withdraw(accounts);

                            break;
                        }
                    case "3":
                        {
                            dummy.Transfer(accounts);
                            break;
                        }
                    case "4":
                        {
                            dummy.ShowDetails(accounts);
                            break;
                        }

                    case "5":
                        {
                            return;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Enter valid input");
                            break;
                        }
                }
            }






            Console.ReadLine();
        }
    }
}