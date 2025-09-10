using Application.Dtos;
using Application.Models;
using Domain;
using Domain.Entities.Installment;
using Repository.JsonFile;

namespace Application.Services;

public class InstallmentServices : IInstallmentServices
{

    // A filosofia é que o de fora sempre valida o de dentro. 
    // Generic Repository criar classes espelhos. Para poder trabalhar eficientemente
    // Com Get e private set; 
    private readonly IInstallmentRepository _installmentRepository = new InstallmentRepository();

    public InstallmentServices()
    {

    }

    // Validar se o IdExpense é maior que zero. 
    // Validar a sequência de número

    public bool Create(InstallmentInputModel obj) => false;
    // obj.IdExpense > 0 ? _installmentRepository.Create(MappingInputModelToEntity(obj)) :
    //     throw new Exception("Parcela precisa estar vinculada a uma despesa.");
    // obj.IdExpenses > 0 && _installmentRepository.Create(MappingInputModelInstallmentInputModelToEntity(obj)); // Sem exception. 

    public List<InstallmentDto> Read()
    {
        List<InstallmentDto> installments = new();
        List<InstallmentEntity> lsEntity = MappingListEntityDataToListEntity(_installmentRepository.ReadAll<InstallmentEntityData>().ToList());
        installments = MappingListEntityToListDto(lsEntity);

        return installments;
    }

    public bool Update(InstallmentInputModel dto, bool remover = true)
    {
        var installment = _installmentRepository
            .GetById<InstallmentEntity>(dto.Id) ?? throw new Exception("Nenhuma parcela encontrada!");

        installment.AddPaymentDate();

        _installmentRepository.Update(installment);

        return true;
    }

    public bool Delete(InstallmentInputModel obj)
    {
        throw new NotImplementedException();
    }

    public List<InstallmentDto> GetAllPaidByIdExpenses(int idExpenses)
    {
        List<InstallmentDto> paidInstallments = new List<InstallmentDto>();
        _installmentRepository
            .GetAllPaidByIdExpenses(idExpenses)
            .Where(i => i.PaymentDate is not null)
            .ToList()
            .ForEach(x => paidInstallments.Add(MappingEntityToDto(x)));

        return paidInstallments;
    }

    public InstallmentEntity MappingInputModelToEntity(InstallmentInputModel dto)
    {
        InstallmentEntity entity = new InstallmentEntity(dto.Number, new DateTime());

        return entity;
    }

    public InstallmentDto MappingEntityToDto(InstallmentEntity entity) =>
        new InstallmentDto(entity.Id, entity.IdExpense, entity.Number, entity.ExpectedDate, entity.PaymentDate);

    public InstallmentDto GetById(int id)
    {
        throw new NotImplementedException();
    }

    public InstallmentEntityData MappingEntityToEntityData(InstallmentEntity obj)
    {
        return new() { Number = obj.Number, IdExpense = obj.IdExpense, PaymentDate = obj.PaymentDate };
    }

    public InstallmentEntity MappingEntityDataToEntity(InstallmentEntityData obj)
    {
        InstallmentEntity entity = new();
        entity.AlterInstallmentEntity
        (
            obj.Id,
            obj.IdExpense,
            obj.Number,
            obj.ExpectedDate
        );

        return entity;
    }

    public List<InstallmentDto> MappingListEntityToListDto(List<InstallmentEntity> obj)
    {
        List<InstallmentDto> lst = new();
        obj.ForEach(item => lst.Add(MappingEntityToDto(item)));
        return lst;
    }
    public List<InstallmentEntityData> MappingListEntityToListEntityData(List<InstallmentEntity> obj)
    {
        List<InstallmentEntityData> lst = new();
        obj.ForEach(item => lst.Add(MappingEntityToEntityData(item)));
        return lst;
    }

    public List<InstallmentEntity> MappingListEntityDataToListEntity(List<InstallmentEntityData> obj)
    {
        List<InstallmentEntity> lst = new();
        obj.ForEach(item => lst.Add(MappingEntityDataToEntity(item)));
        return lst;
    }

    public InstallmentEntity MappingDtoToEntity(InstallmentDto dto)
    {
        throw new NotImplementedException();
    }

    public InstallmentDto Update(InstallmentDto dto)
    {
        throw new NotImplementedException();
    }

    public InstallmentDto GetById(int id, bool remover = true)
    {
        throw new NotImplementedException();
    }

    InstallmentInputModel IService<InstallmentInputModel, InstallmentDto, InstallmentEntity, InstallmentEntityData>.GetById(int id)
    {
        throw new NotImplementedException();
    }

    InstallmentDto IService<InstallmentInputModel, InstallmentDto, InstallmentEntity, InstallmentEntityData>.Create(InstallmentInputModel input)
    {
        throw new NotImplementedException();
    }

    public bool Create(InstallmentInputModel input, bool remover = true)
    {
        throw new NotImplementedException();
    }
}