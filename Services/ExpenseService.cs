using BudgetTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BudgetTracker.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly HttpClient _httpClient;
        public ExpenseService(HttpClient httpClient)
        {
           _httpClient = httpClient;
        }

        public int Delete(ExpenseModel expense)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ExpenseModel>> GetAllExpenses()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<ExpenseModel>>(
                await _httpClient.GetStreamAsync($"api/budget"), new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });
        }

        public ExpenseModel GetExpenseById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(ExpenseModel expense)
        {
            throw new NotImplementedException();
        }

        public List<ExpenseModel> SearchExpenses(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public int Update(ExpenseModel expense)
        {
            throw new NotImplementedException();
        }
    }
}
