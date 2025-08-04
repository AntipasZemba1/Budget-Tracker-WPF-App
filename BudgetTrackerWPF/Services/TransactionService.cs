using System.Collections.Generic;
using BudgetTrackerWPF.Models;
using BudgetTrackerWPF.Data;
using System.Globalization;
using System.Linq;
using BudgetTrackerWPF.Models;

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

        public List<MonthlySummary> GetMonthlySummaries()
        {
            return _transactions
                .GroupBy(t => t.Date.ToString("yyyy MMM"))
                .OrderByDescending(g => g.Key)
                .Select(g =>
                {
                    var income = g.Where(t => t.Amount > 0).Sum(t => t.Amount);
                    var expenses = g.Where(t => t.Amount < 0).Sum(t => t.Amount);
                    return new MonthlySummary
                    {
                        Month = g.Key,
                        Income = income,
                        Expenses = expenses
                    };
                })
                .ToList();
        }

    }

}
