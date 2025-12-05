namespace Infra.Data.Repositories;

public class ExpenseRepository : Repository, IExpenseRepository
{
    public ExpenseRepository
    (
        IGenericRepository context
    ) : base(context)
    {

    }

    public IEnumerable<ExpenseEntity> GetAllByIdBank(int id) =>
        ReadAll<ExpenseEntityData>().Where(x => x.IdBank == id).ToEntityIEnumerable();
}