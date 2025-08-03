using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using BudgetTrackerWPF.Models;

namespace BudgetTrackerWPF.Data
{
    public static class DataStorage
    {
        private static readonly string filePath = "transactions.json";

        public static void Save(List<Transaction> transactions)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(transactions, options);
            File.WriteAllText(filePath, json);
        }

        public static List<Transaction> Load()
        {
            if (!File.Exists(filePath))
            {
                return new List<Transaction>();
            }

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Transaction>>(json) ?? new List<Transaction>();
        }
    }
}
