using Domain.Entities.Expense;
using Repository.Json;

namespace Domain.Entities.Expense;

public interface IExpenseRepository : IGenericRepository
{
    List<ExpenseEntityData> GetAllByIdBank(int id);
}