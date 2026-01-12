
using System.Collections.ObjectModel;
using Domain.Dtos;
using Domain.Extensions;
using Domain.Interfaces;

namespace Domain.Mappers;

public class InstallmentServiceMapper : IInstallmentServiceMapper
{
    public InstallmentDto Create(InstallmentDto dto)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int identifier)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<InstallmentDto> GetAllPaidByIdExpenses(int idExpenses)
    {
        throw new NotImplementedException();
    }

    public InstallmentEntity MappingDtoToEntity(InstallmentDto dto)
    {
        throw new NotImplementedException();
    }

    // public InstallmentEntity MappingEntityDataToEntity(InstallmentEntityData data)
    // {
    //     throw new NotImplementedException();
    // }

    public IEnumerable<InstallmentDto> MappingEntityEnumerableToDtoEnumerable(IEnumerable<InstallmentEntity> entities)
    {
        ICollection<InstallmentDto> dto = new Collection<InstallmentDto>();
        entities.ToList().ForEach(item => dto.Add(item.ToDto()));
        return dto;
    }

    public InstallmentDto MappingEntityToDto(InstallmentEntity entity) =>
        new(0, entity.IdExpense, entity.Number, entity.ExpectedDate, entity.PaymentDate);

    // public InstallmentEntityData MappingEntityToEntityData(InstallmentEntity entity)
    // {
    //     throw new NotImplementedException();
    // }

    // public IEnumerable<InstallmentEntity> MappingEntityDataEnumerableToEntityEnumerable(IEnumerable<InstallmentEntityData> datas)
    // {
    //     throw new NotImplementedException();
    // }
    public IEnumerable<InstallmentDto> Read()
    {
        throw new NotImplementedException();
    }

    public InstallmentDto Update(InstallmentDto dto)
    {
        throw new NotImplementedException();
    }

    // public IEnumerable<InstallmentEntityData> MappingListEntityToListEntityData(IEnumerable<InstallmentEntity> obj)
    // {
    //     IEnumerable<InstallmentEntityData> lst = new();
    //     obj.ForEach(item => lst.Add(MappingEntityToEntityData(item)));
    //     return lst;
    // }
}