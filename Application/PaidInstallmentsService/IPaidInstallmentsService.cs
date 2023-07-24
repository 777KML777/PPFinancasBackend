using Domain;

namespace Application; 

public interface IPaidInstallmentsService : IService<PaidInstallmentsDto, PaidInstallmentsEntity>
{
    void Create (PaidInstallmentsDto obj);
    List<PaidInstallmentsDto> GetAllPaidByIdExpenses(int idExpenses);
}