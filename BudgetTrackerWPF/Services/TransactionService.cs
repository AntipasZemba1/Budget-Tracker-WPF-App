using System.Collections.Generic;
using BudgetTrackerWPF.Models;
using BudgetTrackerWPF.Data;

namespace BudgetTrackerWPF.Services
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

        public void DeleteTransaction(Transaction transaction)
        {
            _transactions.Remove(transaction);
            DataStorage.Save(_transactions);
        }

        public List<Transaction> GetAllTransactions() => _transactions;

        public decimal GetBalance()
        {
            decimal balance = 0;
            foreach (var t in _transactions)
            {
                balance += t.Amount;
            }
            return balance;
        }
    }
}
