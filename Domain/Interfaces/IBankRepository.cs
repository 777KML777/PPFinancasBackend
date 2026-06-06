namespace Domain.Interfaces;

public interface IBankRepository : IRepository
{
    public IEnumerable<BankEntity> Read();
    public BankEntity GetById(int identifier);
    public BankEntity GetByIdInclude(int identifier);
}