using BudgetTracker.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace BudgetTracker.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        [ObservableProperty]
        private ObservableCollection<Transaction> transactions;

        [ObservableProperty]
        private decimal totalIncome;

        [ObservableProperty]
        private decimal totalExpense;

        public MainViewModel()
        {
            Transactions = new ObservableCollection<Transaction>();
            LoadSampleData(); // Replace with DB call later
        }

        private void LoadSampleData()
        {
            Transactions.Add(new Transaction { Description = "Salary", Amount = 5000, Type = TransactionType.Income });
            Transactions.Add(new Transaction { Description = "Groceries", Amount = 120, Type = TransactionType.Expense });
            UpdateTotals();
        }

        private void UpdateTotals()
        {
            TotalIncome = Transactions
                .Where(t => t.Type == TransactionType.Income)
                .Sum(t => t.Amount);

            TotalExpense = Transactions
                .Where(t => t.Type == TransactionType.Expense)
                .Sum(t => t.Amount);
        }
    }
}
