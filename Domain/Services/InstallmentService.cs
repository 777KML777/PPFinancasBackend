using Domain.Dtos;
using Domain.Interfaces;

namespace Domain.Services;

public class InstallmentService : IInstallmentService
{

    // A filosofia é que o de fora sempre valida o de dentro. 
    // Generic Repository criar classes espelhos. Para poder trabalhar eficientemente
    // Com Get e private set; 
    private readonly IInstallmentRepository _installmentRepository;

    public InstallmentService()
    {

    }

    public InstallmentDto Create(InstallmentDto dto)
    {
        throw new NotImplementedException();
    }

    // Validar se o IdExpense é maior que zero. 
    // Validar a sequência de número


    // public InstallmentEntityData MappingEntityToEntityData(InstallmentEntity obj)
    // {
    //     return new() { Number = obj.Number, IdExpense = obj.IdExpense, PaymentDate = obj.PaymentDate };
    // }

    // public InstallmentEntity MappingEntityDataToEntity(InstallmentEntityData obj)
    // {
    //     InstallmentEntity entity = new();
    //     entity.AlterInstallmentEntity
    //     (
    //         obj.Id,
    //         obj.IdExpense,
    //         obj.Number,
    //         obj.ExpectedDate
    //     );

    //     return entity;
    // }

    // public List<InstallmentEntity> MappingEntityDataEnumerableToEntityEnumerable(List<InstallmentEntityData> obj)
    // {
    //     List<InstallmentEntity> lst = new();
    //     obj.ForEach(item => lst.Add(MappingEntityDataToEntity(item)));
    //     return lst;
    // }

    // InstallmentDto IService<InstallmentInputModel, InstallmentDto, InstallmentEntity>.Create(InstallmentInputModel input)
    // {
    //     throw new NotImplementedException();
    // }

    public bool Delete(int identifier)
    {
        throw new NotImplementedException();
    }

    public List<InstallmentDto> GetAllPaidByIdExpenses(int idExpenses)
    {
        throw new NotImplementedException();
    }

    public InstallmentDto GetById(int identifier)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<InstallmentDto> Read()
    {
        throw new NotImplementedException();
    }

    public InstallmentDto Update(InstallmentDto dto)
    {
        throw new NotImplementedException();
    }

    List<InstallmentDto> IInstallmentService.GetAllPaidByIdExpenses(int idExpenses)
    {
        throw new NotImplementedException();
    }
}