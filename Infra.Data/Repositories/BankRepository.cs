
namespace Infra.Data.Repositories;

public class BankRepository : Repository, IBankRepository
{
    public BankRepository
    (
        IGenericRepository context
    ) : base(context)
    {

    }
    
}