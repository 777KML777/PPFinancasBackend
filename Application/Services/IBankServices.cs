using Application.Dtos;
using Application.Models;
using Domain.Entities.Bank;

namespace Application.Services;

public interface IBankServices : IService<BankInputModel, BankDto, BankEntity, BankEntityData>
{
    
}