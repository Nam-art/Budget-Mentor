using BudgetAPI.Models;
using BudgetTracker.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetTracker.Pages
{
    public partial class ExpensesOverview
    {
        [Inject]
        public IExpenseService ExpenseService { get; set; }
        public IEnumerable<ExpenseModel> Expenses { get; set; }

        protected async Task OnInitializeAsync()
        {
            Expenses = (IEnumerable<ExpenseModel>)(await ExpenseService.GetAllExpenses()).ToList();
        }
    }
}
