using Application.Dtos;
using Application.Models;
using Domain.Entities.Installment;

namespace Application.Services; 

public interface IInstallmentServices : IService<InstallmentInputModel, InstallmentDto, InstallmentEntity, InstallmentEntityData>
{
    List<InstallmentDto> GetAllPaidByIdExpenses(int idExpenses);
}