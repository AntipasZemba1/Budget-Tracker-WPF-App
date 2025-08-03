using System;

namespace BudgetTracker.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public TransactionType Type { get; set; } // Income or Expense

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }

    public enum TransactionType
    {
        Income,
        Expense
    }
}
