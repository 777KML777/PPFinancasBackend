using Domain;

namespace Application;

public interface IBankService : IService<BankSelectedDto, BankEntity>
{
    void Create (BankSelectedDto obj);
    BankSelectedDto GetBankById(int id);
}