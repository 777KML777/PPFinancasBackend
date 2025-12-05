namespace Infra.Data.Repositories;

public class TempFutureDebitsRepository : Repository, ITempFutureDebitsRepository
{
    public TempFutureDebitsRepository(IGenericRepository context) : base(context)
    {
    }
}