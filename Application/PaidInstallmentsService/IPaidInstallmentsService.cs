using Domain;

namespace Application; 

public interface IPaidInstallmentsService : IService<PaidInstallmentsDto, PaidInstallmentsEntity>
{
    List<PaidInstallmentsDto> GetAllPaidByIdExpenses(int idExpenses);
}