namespace Infra.Data.Repositories;

public class BankRepository : Repository, IBankRepository
{
    public BankRepository
    (
        IGenericRepository _context
    ) : base(_context)
    {

    }


    public IEnumerable<BankEntity> Read() => ReadAll<BankEntityData>().ToEntityEnumerable();
    public BankEntity GetById(int identifier) => GetById<BankEntityData>(identifier).ToEntity();
    public BankEntity GetByIdInclude(int identifier)
    {
        BankEntity bank = GetById<BankEntityData>(identifier).ToEntity();

        // TODO: Remover futuramente ou implementar include. 
        // INCLUDES
        if (bank != null)
        {
            var expenses = ReadAll<ExpenseEntityData>()
                .Where(x => x.IdBank == bank.Id)
                .OrderBy(x => !x.Inactive)
                .ToList();
            expenses.ForEach(e => bank.AddExpensesToBanks(e.ToEntity()));

            return bank;
        }

        return new(); // em caso de erro.
    }
}