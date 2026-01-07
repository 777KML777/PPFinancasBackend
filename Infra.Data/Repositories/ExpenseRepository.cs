
namespace Infra.Data.Repositories;

public class ExpenseRepository : Repository, IExpenseRepository
{
    public ExpenseRepository
    (
        IGenericRepository _context
    ) : base(_context)
    {

    }

    public ExpenseEntity GetById(int identifier) => GetById<ExpenseEntityData>(identifier).ToEntity();
    public IEnumerable<ExpenseEntity> GetAllByIdBank(int id) => 
        ReadAll<ExpenseEntityData>().Where(e => e.IdBank.Equals(id)).ToEntityEnumerable();
}