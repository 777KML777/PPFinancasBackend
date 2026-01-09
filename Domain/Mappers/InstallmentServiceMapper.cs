
using Domain.Dtos;
using Domain.Interfaces;

namespace Domain.Mappers;

public class InstallmentMapper : IInstallmentService
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
        throw new NotImplementedException();
    }

    public InstallmentDto MappingEntityToDto(InstallmentEntity entity)
    {
        throw new NotImplementedException();
    }

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

    List<InstallmentDto> IInstallmentService.GetAllPaidByIdExpenses(int idExpenses)
    {
        throw new NotImplementedException();
    }

    InstallmentDto IService<InstallmentDto, InstallmentEntity>.GetById(int identifier)
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