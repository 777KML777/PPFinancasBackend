namespace Domain.Interfaces;

public interface IInstallmentRepository : IRepository
{
    IEnumerable<InstallmentEntity> GetAllPaidByIdExpenses (int idExpenses);
}