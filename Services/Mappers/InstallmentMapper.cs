
namespace Services.Mappers;

public class InstallmentMapper : IInstallmentServices
{
    public InstallmentDto Create(InstallmentInputModel input)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int identifier)
    {
        throw new NotImplementedException();
    }

    public List<InstallmentDto> GetAllPaidByIdExpenses(int idExpenses)
    {
        throw new NotImplementedException();
    }

    public InstallmentInputModel GetById(int identifier)
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

    public List<InstallmentDto> MappingEntityListToDtoList(List<InstallmentEntity> entities)
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

    public InstallmentEntity MappingInputModelToEntity(InstallmentInputModel input)
    {
        throw new NotImplementedException();
    }

    // public List<InstallmentEntity> MappingListEntityDataToListEntity(List<InstallmentEntityData> datas)
    // {
    //     throw new NotImplementedException();
    // }

    public List<InstallmentDto> MappingListEntityToListDto(List<InstallmentEntity> entities)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<InstallmentDto> Read()
    {
        throw new NotImplementedException();
    }

    public InstallmentInputModel Update(InstallmentInputModel input)
    {
        throw new NotImplementedException();
    }

    // public List<InstallmentEntityData> MappingListEntityToListEntityData(List<InstallmentEntity> obj)
    // {
    //     List<InstallmentEntityData> lst = new();
    //     obj.ForEach(item => lst.Add(MappingEntityToEntityData(item)));
    //     return lst;
    // }
}