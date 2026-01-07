
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
}