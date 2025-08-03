public class Transaction
{
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public decimal Amount { get; set; } // Positive for income, negative for expense

    public Transaction(DateTime date, string description, string category, decimal amount)
    {
        Date = date;
        Description = description;
        Category = category;
        Amount = amount;
    }

    public override string ToString()
    {
        return $"{Date.ToShortDateString()} | {Description} | {Category} | {Amount:C}";
    }
}
