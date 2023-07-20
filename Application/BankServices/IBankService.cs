using Domain;

namespace Application;

public interface IBankService : IService<BankDto, BankEntity>
{
    BankDto GetBankById(int id);
}