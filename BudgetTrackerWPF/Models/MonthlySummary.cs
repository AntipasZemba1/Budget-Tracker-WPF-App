using System;

namespace BudgetTrackerWPF.Models
{
    public class MonthlySummary
    {
        public string Month { get; set; }
        public decimal Income { get; set; }
        public decimal Expenses { get; set; }
        public decimal Net => Income + Expenses; // Expenses are negative

        public override string ToString()
        {
            return $"{Month}: Income {Income:C}, Expenses {Expenses:C}, Net {Net:C}";
        }
    }
}
