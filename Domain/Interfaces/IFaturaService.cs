using Domain.Dtos;

namespace Domain.Interfaces;

public interface IFaturaService : IService<FaturaDto, ExpenseEntity>
{
    public FaturaDto Generate(BankDto banco); 
}