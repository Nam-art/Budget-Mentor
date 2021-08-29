using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace BudgetTracker.Data
{
    public class BudgetService
    {
        private readonly HttpClient _httpClient;
        private HubConnection _hubConnection;
        public BudgetService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public string NewExpenseName { get; set; }
        public int NewExpenseId { get; set; }
        public event Action OnChange;

        public async Task InitializeSignalR()
        {
            _hubConnection = new HubConnectionBuilder().WithUrl($"{_httpClient.BaseAddress.AbsoluteUri}BudgetApiHub")
                .Build();
            _hubConnection.On<int, string>("NotifyNewExpenseAdded", (expenseId, expenseName) => 
            {
                UpdateUIState(expenseId, expenseName);
            });
            await _hubConnection.StartAsync();
        }
        public void UpdateUIState(int expenseId,string expenseName)
        {
            NewExpenseId = expenseId;
            NewExpenseName = expenseName;
            NotifyStateChange();
        }
        private void NotifyStateChange() => OnChange?.Invoke();
        public async Task<IEnumerable<ExpenseModel>> GetExpensesAsync()
        {
            var response = await _httpClient.GetAsync("api/budget");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var jsonOption = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var data = JsonSerializer.Deserialize<IEnumerable<ExpenseModel>>(json, jsonOption);
            return data;
        }
        public async Task UpdateExpenseAsync(ExpenseModel expense)
        {
            var response = await _httpClient.PutAsJsonAsync("api/budget", expense);
            response.EnsureSuccessStatusCode();
        }
    }
}
