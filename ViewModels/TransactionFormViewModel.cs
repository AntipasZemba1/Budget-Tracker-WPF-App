using BudgetTracker.Models;
using BudgetTracker.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace BudgetTracker.ViewModels
{
    public partial class TransactionFormViewModel : BaseViewModel
    {
        private readonly BudgetContext _context;

        public ObservableCollection<Category> Categories { get; set; }

        [ObservableProperty]
        private string description;

        [ObservableProperty]
        private decimal amount;

        [ObservableProperty]
        private TransactionType selectedType;

        [ObservableProperty]
        private Category selectedCategory;

        public TransactionFormViewModel()
        {
            _context = new BudgetContext();

            Categories = new ObservableCollection<Category>(_context.Categories.ToList());
            SelectedType = TransactionType.Expense;
        }

        [RelayCommand]
        private void Save()
        {
            if (string.IsNullOrWhiteSpace(Description) || SelectedCategory == null || Amount <= 0)
                return;

            var transaction = new Transaction
            {
                Description = Description,
                Amount = Amount,
                Type = SelectedType,
                Date = DateTime.Now,
                CategoryId = SelectedCategory.Id
            };

            _context.Transactions.Add(transaction);
            _context.SaveChanges();

            // Optionally clear form
            Description = string.Empty;
            Amount = 0;
            SelectedType = TransactionType.Expense;
        }
    }
}
