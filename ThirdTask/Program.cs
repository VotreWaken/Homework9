using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreditCard Profile =
            new CreditCard("2241 1523 1258 1923", "Egor Nikitenko",
            new DateTime(2023, 5, 4), 552, 500, 1000);

            Profile.SpendMoney += IventMoney;
            Profile.AddValue += IventMoney;
            Profile.CreditLimit += IventMoney;
            Profile.СhangePIN += IventMoney;

            while (true)
            {
                Console.WriteLine("1. Replenishment Amount");
                Console.WriteLine("2. Spending Money");
                Console.WriteLine("3. Spending of Credit Money");
                Console.WriteLine("4. Change PIN");
                Console.WriteLine("5. Account Info");
                Console.WriteLine("6. Exit");
                int UserChoice = Int32.Parse(Console.ReadLine());
                switch (UserChoice)
                {
                    case 1:
                        Profile.Appendbalance();
                        break;
                    case 2:
                        Profile.SpendBalance();
                        break;
                    case 3:
                        Profile.SpendСategories();
                        break;
                    case 4:
                        Profile.ChangePin();
                        break;
                    case 5:
                        Profile.Show();
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Error: Choose Number Between 1 and 6 \n");
                        break;
                }
            }
        }
        public static void IventMoney(string message)
            => Console.WriteLine(message);
        class CreditCard
        {


            public string numCard { get; set; }
            public string ownerFIO { get; set; }
            public DateTime? expiryDate { get; set; }
            public short? ownerPIN { get; set; }
            public int? creditLimit { get; set; }
            public int? balance { get; set; }

            public CreditCard(string numCard, string ownerFIO,
                              DateTime expiryData, short ownerPIN,
                              int creditLimit, int money)
            {
                this.numCard = numCard;
                this.ownerFIO = ownerFIO;
                this.expiryDate = expiryData;
                this.ownerPIN = ownerPIN;
                this.creditLimit = creditLimit;
                this.balance = money;
            }

            public void Show()
            {
                Console.WriteLine("Card Number: " + numCard);
                Console.WriteLine("Card Owner: " + ownerFIO);
                Console.WriteLine("Expiry Date: " + expiryDate);
                Console.WriteLine("Owner PIN: " + ownerPIN);
                Console.WriteLine("Credit Limit: " + creditLimit + "$");
                Console.WriteLine("Money: " + balance + "$");
            }
            public void Appendbalance()
            {
                do
                {
                    Console.WriteLine($"Balance: {balance}$");
                    Console.Write("Enter Spending: ");
                    int? temp_money = int.Parse(Console.ReadLine());
                    if (temp_money != 0)
                    {
                        balance += temp_money;
                        Console.WriteLine($"Successful" +
                                $"\nBalance: {balance}$");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Error: " +
                            $" Balance to Spend: {temp_money}$");
                        continue;
                    }
                } while (true);

            }
            public void SpendBalance()
            {
                do
                {
                    Console.WriteLine($"Balance: {balance}$");
                    Console.Write("Enter Spending: ");
                    int? temp_money = int.Parse(Console.ReadLine());
                    if (temp_money < balance)
                    {
                        balance -= temp_money;
                        Console.WriteLine($"Successful" +
                                $"\nBalance: {balance}$");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Error: " +
                            $" Not Enought Money, Your Balance: {balance}$");
                        continue;
                    }
                } while (true);

            }
            public void Use_credit_money()
            {
                do
                {
                    Console.WriteLine($"Credit Limit: {creditLimit}$");

                    Console.Write("Enter Spending: ");
                    int? temp_money = int.Parse(Console.ReadLine());
                    if (temp_money < balance)
                    {
                        balance -= temp_money;
                        SpendMoney?.Invoke($"Successful" +
                                $"\nBalance: {balance}$");
                        break;
                    }
                    else
                    {
                        SpendMoney?.Invoke("Error: " +
                            $" Not Enought Money, Your Balance:  {balance}$");
                        continue;
                    }
                } while (true);
            }
            public void SpendСategories()
            {
                do
                {
                    Console.WriteLine("1 - Product");
                    Console.WriteLine("2 - Transport");
                    Console.WriteLine("3 - Public Utilities");
                    Console.WriteLine("4 - Entertainment");
                    Console.WriteLine("5 - Exit");
                    int categoryChoice = int.Parse(Console.ReadLine());
                    int? categories_spend;
                    if (creditLimit != 0)
                    {
                        switch (categoryChoice)
                        {
                            case 1:
                                Console.WriteLine("Enter Spend Amount: ");
                                categories_spend = int.Parse(Console.ReadLine());
                                Console.WriteLine($"Credit Limit:" +
                                    $" {creditLimit - categories_spend}");
                                break;
                            case 2:
                                Console.WriteLine("Enter Spend Amount: ");
                                categories_spend = int.Parse(Console.ReadLine());
                                Console.WriteLine($"Credit Limit:" +
                                    $" {creditLimit - categories_spend}");
                                Console.WriteLine();
                                break;
                            case 3:
                                Console.WriteLine("Enter Spend Amount: ");
                                categories_spend = int.Parse(Console.ReadLine());
                                Console.WriteLine($"Credit Limit:" +
                                    $" {creditLimit - categories_spend}");
                                Console.WriteLine();
                                break;
                            case 4:
                                Console.WriteLine("Enter Spend Amount: ");
                                categories_spend = int.Parse(Console.ReadLine());
                                Console.WriteLine($"Credit Limit:" +
                                    $" {creditLimit - categories_spend}");
                                Console.WriteLine();
                                break;
                            case 5:
                                Console.WriteLine("Exit");
                                Console.ResetColor();
                                return;
                            default:
                                Console.WriteLine("\nError: Choose between 1 and 5 \n");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Error {ownerFIO}" +
                        $" Your Credit Limit: {creditLimit}");
                        CreditLimit?.Invoke($"Error {ownerFIO}" +
                        $" Using Credit Value : {creditLimit}");
                    }

                } while (true);
            }
            public void ChangePin()
            {
                short? temp_pin = ownerPIN;
                Console.WriteLine($"Your PIN : {ownerPIN}");
                Console.Write($"Enter New PIN: ");
                ownerPIN = short.Parse(Console.ReadLine());
                СhangePIN?.Invoke($"{ownerFIO} Change PIN: {temp_pin} To New Pin:  {ownerPIN} ");
                Console.WriteLine($"Successful" +
                                $"\nPIN New : {ownerPIN}$");
            }

            public event Action<string> AddValue;

            public event Action<string> SpendMoney;

            public event Action<string> CreditLimit;

            public event Action<string> СhangePIN;
        }
    }
}
