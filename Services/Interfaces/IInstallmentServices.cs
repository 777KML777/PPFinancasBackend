namespace Services.Interfaces; 

public interface IInstallmentServices : IService<InstallmentInputModel, InstallmentDto, InstallmentEntity>
{
    List<InstallmentDto> GetAllPaidByIdExpenses(int idExpenses);
}