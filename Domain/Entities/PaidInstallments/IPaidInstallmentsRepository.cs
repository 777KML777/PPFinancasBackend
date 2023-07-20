namespace Domain; 

public interface IPaidInstallmentsRepository : IRepository <PaidInstallmentsEntity>
{
    IList<PaidInstallmentsEntity> GetAllPaidByIdExpenses (int idExpenses);
}