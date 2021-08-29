using BudgetTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetTracker.Services
{
    public interface IExpenseService
    {
        Task<IEnumerable<ExpenseModel>> GetAllExpenses();
        ExpenseModel GetExpenseById(int id);
        List<ExpenseModel> SearchExpenses(string searchTerm);
        int Insert(ExpenseModel expense);
        int Delete(ExpenseModel expense);
        int Update(ExpenseModel expense);


    }
}
