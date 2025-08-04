using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;

namespace BudgetTrackerWPF
{
    public partial class MainWindow : Window
    {
        private List<Transaction> transactions = new List<Transaction>();

        public MainWindow()
        {
            InitializeComponent();
            RefreshUI();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(AmountBox.Text, out decimal amount))
            {
                var transaction = new Transaction
                {
                    Description = DescriptionBox.Text,
                    Category = CategoryBox.Text,
                    Amount = amount,
                    Date = DateTime.Now
                };
                transactions.Add(transaction);
                RefreshUI();
            }
            else
            {
                MessageBox.Show("Invalid amount");
            }
        }

        private void RefreshUI()
        {
            TransactionList.ItemsSource = null;
            TransactionList.ItemsSource = transactions.Select(t => $"{t.Date.ToShortDateString()} - {t.Description} ({t.Category}): {t.Amount:C}");

            decimal balance = transactions.Sum(t => t.Amount);
            BalanceText.Text = $"Balance: {balance:C}";

            var grouped = transactions
                .GroupBy(t => t.Category)
                .Select(g => new PieSeries<decimal>
                {
                    Name = g.Key,
                    Values = new decimal[] { g.Sum(t => t.Amount) }
                })
                .ToArray();

            CategoryPieChart.Series = grouped;
        }
    }

    public class Transaction
    {
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
