using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment05BankAccountSystem
{
    public class BankAccount
    {
        private BankAccount Check(List<BankAccount> accounts,string accountToCheck)
        {
            foreach (BankAccount account in accounts)
            {
                if(account.AccountNumber== accountToCheck)
                {
                    return account;
                }
            }
            return null;
        }
       



        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public double Balance { get; set; }

        public BankAccount() { }

        public BankAccount(string name, string accountNumber, double balance)
        {
            Name = name;
            AccountNumber = accountNumber;
            Balance = balance;
        }

        public void Deposite(List<BankAccount> accounts)
        {
            Console.WriteLine("Enter the account Number of user: ");
            string accountNumber = Console.ReadLine();
            var account=Check(accounts,accountNumber);
                if (!(account == null))
                {
                    Console.WriteLine("Enter the Amount to deposit: ");
                    double.TryParse(Console.ReadLine(), out double depositAmount);

                    if (depositAmount < 0)
                    {
                        Console.WriteLine("Invalid Amount");
                    }
                    else
                    {
                        account.Balance += depositAmount;
                        Console.WriteLine($"Amount deposited successfully. New Balance: {account.Balance}");
                    }
                    return;
                }
            
            Console.WriteLine("Account not found.");
            RetryFeature("deposit", accounts);
        }

        public void Withdraw(List<BankAccount> accounts)
        {
            Console.WriteLine("Enter the account Number of user: ");
            string accountNumber = Console.ReadLine();
           
                var account = Check(accounts, accountNumber);
            if (!(account == null))
            {
                Console.WriteLine("Enter the amount you want to withdraw: ");
                double.TryParse(Console.ReadLine(), out double withdrawAmount);

                if (account.Balance >= withdrawAmount)
                {
                    account.Balance -= withdrawAmount;
                    Console.WriteLine($"Amount withdrawn successfully. New Balance: {account.Balance}");
                }
                else
                {
                    Console.WriteLine("Insufficient funds.");
                }
                return;
            }
            
            Console.WriteLine("Account not found.");
            RetryFeature("withdraw", accounts);
        }

        public void Transfer(List<BankAccount> accounts)
        {
            Console.WriteLine("Enter the account number from which transfer: ");
            string debitAccountNumber = Console.ReadLine();
            BankAccount debitAccount = Check(accounts, debitAccountNumber);

            if (debitAccount == null)
            {
                Console.WriteLine("Account not found.");
                RetryFeature("transfer", accounts);
                return;
            }

            Console.WriteLine("Enter the account number to transfer to: ");
            string toAccountNumber = Console.ReadLine();
            BankAccount toAccount = Check(accounts, toAccountNumber);

            if (toAccount == null)
            {
                Console.WriteLine("Account not found.");
                RetryFeature("transfer", accounts);
                return;
            }

            Console.WriteLine("Enter the amount to transfer: ");
            double.TryParse(Console.ReadLine(), out double creditAccount);

            if (creditAccount <= 0)
            {
                Console.WriteLine("Invalid amount.");
                RetryFeature("transfer", accounts);
                return;
            }

            if (debitAccount.Balance >= creditAccount)
            {
                debitAccount.Balance -= creditAccount;
                toAccount.Balance += creditAccount;
                Console.WriteLine($"Successfully transferred {creditAccount} from account {debitAccount.AccountNumber} to account {toAccount.AccountNumber}");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Insufficient funds");
            }
        }

        private void RetryFeature(string feature, List<BankAccount> accounts)
        {
            Console.WriteLine($"Enter 'Yes' if you want to try again with {feature}");
            string decision = Console.ReadLine();

            if (decision.ToLower() == "yes")
            {
                switch (feature)
                {
                    case "deposit":
                        Deposite(accounts);
                        break;
                    case "withdraw":
                        Withdraw(accounts);
                        break;
                    case "transfer":
                        Transfer(accounts);
                        break;
                    case "details":
                        ShowDetails(accounts);
                        break;
                }
            }
        }

        public void ShowDetails(List<BankAccount> accounts)
        {
            Console.WriteLine("Enter the account number");
            string accountNumber= Console.ReadLine();

            BankAccount account=Check(accounts, accountNumber);
            if (account != null)
            {
                Console.WriteLine($"{"Name",-10}{"AccountNumber",10}{"Balace",10}");
                Console.WriteLine($"{account.Name,-10}{account.AccountNumber,10}{account.Balance,10}");
            }
            else
            {
                RetryFeature("details", accounts);
            }
        }
    }
}
