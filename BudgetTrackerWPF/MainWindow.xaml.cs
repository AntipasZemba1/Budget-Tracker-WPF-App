using System;
using System.Windows;
using BudgetTrackerWPF.Services;

namespace BudgetTrackerWPF
{
    public partial class MainWindow : Window
    {
        private TransactionService _service;

        public MainWindow()
        {
            InitializeComponent();
            _service = new TransactionService();
            RefreshUI();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string desc = DescriptionBox.Text.Trim();
            string cat = CategoryBox.Text.Trim();
            if (!decimal.TryParse(AmountBox.Text.Trim(), out decimal amt))
            {
                MessageBox.Show("Please enter a valid amount.");
                return;
            }

            if (string.IsNullOrWhiteSpace(desc) || string.IsNullOrWhiteSpace(cat))
            {
                MessageBox.Show("Description and Category are required.");
                return;
            }

            _service.AddTransaction(desc, cat, amt);
            ClearInputs();
            RefreshUI();
        }

        private void RefreshUI()
        {
            TransactionList.ItemsSource = null;
            TransactionList.ItemsSource = _service.GetAllTransactions();
            BalanceText.Text = $"Balance: {_service.GetBalance():C}";
        }

        private void ClearInputs()
        {
            DescriptionBox.Text = "";
            CategoryBox.Text = "";
            AmountBox.Text = "";
        }
    }
}
