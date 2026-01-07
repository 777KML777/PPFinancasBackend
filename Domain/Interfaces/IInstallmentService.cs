using Domain.Dtos;

namespace Domain.Interfaces; 

public interface IInstallmentService : IService<InstallmentDto, InstallmentEntity>
{
    List<InstallmentDto> GetAllPaidByIdExpenses(int idExpenses);
}