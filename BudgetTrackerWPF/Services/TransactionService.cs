using System.Collections.Generic;
using BudgetTrackerApp.Models;
using BudgetTrackerApp.Data;

namespace BudgetTrackerApp.Services
{
    public class TransactionService
    {
        private List<Transaction> _transactions;

        public TransactionService()
        {
            _transactions = DataStorage.Load();
        }

        public void AddTransaction(string description, string category, decimal amount)
        {
            var transaction = new Transaction(description, category, amount);
            _transactions.Add(transaction);
            DataStorage.Save(_transactions);
        }

        public List<Transaction> GetAllTransactions()
        {
            return _transactions;
        }

        public decimal GetBalance()
        {
            decimal balance = 0;
            foreach (var t in _transactions)
            {
                balance += t.Amount;
            }
            return balance;
        }

        public void PrintTransactions()
        {
            if (_transactions.Count == 0)
            {
                Console.WriteLine("No transactions yet.");
                return;
            }

            foreach (var t in _transactions)
            {
                Console.WriteLine(t);
            }
        }
    }
}
