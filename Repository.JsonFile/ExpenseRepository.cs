using Domain;
using Domain.Entities.Expense;
using Repository.Json;

namespace Repository.JsonFile;

public class ExpenseRepository : GenericRepository, IExpenseRepository
{
    public List<ExpenseEntityData> GetAllByIdBank(int id) =>
            ReadAll<ExpenseEntityData>().Where(x => x.IdBank == id).ToList();
}