// // See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
using System;
using System.Collections.Generic;

class Program
{
    static List<Transaction> transactions = new List<Transaction>();

    static void Main()
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("=== Budget Tracker ===");
            Console.WriteLine("1. Add Transaction");
            Console.WriteLine("2. View All Transactions");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    AddTransaction();
                    break;
                case "2":
                    ViewTransactions();
                    break;
                case "3":
                    ShowBalance();
                    break;
                case "4":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Press Enter to try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void AddTransaction()
    {
        Console.Clear();
        Console.Write("Enter description: ");
        string description = Console.ReadLine();

        Console.Write("Enter category: ");
        string category = Console.ReadLine();

        Console.Write("Enter amount (positive for income, negative for expense): ");
        decimal amount = decimal.Parse(Console.ReadLine());

        transactions.Add(new Transaction(DateTime.Now, description, category, amount));
        Console.WriteLine("Transaction added. Press Enter to return to menu.");
        Console.ReadLine();
    }

    static void ViewTransactions()
    {
        Console.Clear();
        Console.WriteLine("=== Transactions ===");

        foreach (var t in transactions)
        {
            Console.WriteLine(t);
        }

        Console.WriteLine("\nPress Enter to return to menu.");
        Console.ReadLine();
    }

    static void ShowBalance()
    {
        Console.Clear();
        decimal balance = 0;
        foreach (var t in transactions)
        {
            balance += t.Amount;
        }

        Console.WriteLine($"Current Balance: {balance:C}");
        Console.WriteLine("\nPress Enter to return to menu.");
        Console.ReadLine();
    }
}
