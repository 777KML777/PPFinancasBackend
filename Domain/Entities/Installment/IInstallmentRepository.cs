using Domain.Entities.Installment;
using Repository.Json;

namespace Domain.Entities.Installment; 

public interface IInstallmentRepository : IGenericRepository/* IRepository <InstallmentEntity> */
{
    IList<InstallmentEntity> GetAllPaidByIdExpenses (int idExpenses);
}