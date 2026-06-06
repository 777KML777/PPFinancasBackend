using Application.Inputs;

namespace Application.Interfaces;

public interface IBankAppService
{
    public BankInputModel GetById(int id);
}