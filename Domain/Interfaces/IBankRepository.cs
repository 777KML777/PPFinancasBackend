namespace Domain.Interfaces;

public interface IBankRepository : IRepository
{
    public IEnumerable<BankEntity> Read();
}