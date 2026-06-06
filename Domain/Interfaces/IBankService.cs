using Domain.Dtos;

namespace Domain.Interfaces;

public interface IBankService : IService<BankDto, BankEntity>
{
    // List<BankSelect> GetDataList();
}