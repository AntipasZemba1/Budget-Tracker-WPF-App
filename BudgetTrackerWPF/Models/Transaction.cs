using System;

namespace BudgetTrackerWPF.Models
{
    public class Transaction
    {
        public DateTime Date { get; set; } = DateTime.Now;
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Amount { get; set; }

        public Transaction(string description, string category, decimal amount)
        {
            Description = description;
            Category = category;
            Amount = amount;
        }

        public override string ToString()
        {
            return $"{Date.ToShortDateString()} | {Description} | {Category} | {Amount:C}";
        }
    }
}
