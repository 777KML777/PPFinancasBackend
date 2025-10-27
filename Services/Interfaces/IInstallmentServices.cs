namespace Services; 

public interface IInstallmentServices : IService<InstallmentInputModel, InstallmentDto, InstallmentEntity, InstallmentEntityData>
{
    List<InstallmentDto> GetAllPaidByIdExpenses(int idExpenses);
}