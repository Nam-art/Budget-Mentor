using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetTracker.Data
{
    public class AppState
    {
        public ExpenseModel Expense { get; private set; }
        public event Action OnChange;

        public void SetAppState(ExpenseModel expense)
        {
            Expense = expense;
            NotifyStateChange();
        }
        private void NotifyStateChange() => OnChange?.Invoke();
    }
}
