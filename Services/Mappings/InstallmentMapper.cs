
namespace Services.Mappings;

public class InstallmentMapper : IMappings<InstallmentInputModel, InstallmentDto, InstallmentEntity, InstallmentEntityData>
{
    public InstallmentEntity MappingDtoToEntity(InstallmentDto dto)
    {
        throw new NotImplementedException();
    }

    public InstallmentEntity MappingEntityDataToEntity(InstallmentEntityData data)
    {
        throw new NotImplementedException();
    }

    public InstallmentDto MappingEntityToDto(InstallmentEntity entity)
    {
        throw new NotImplementedException();
    }

    public InstallmentEntityData MappingEntityToEntityData(InstallmentEntity entity)
    {
        throw new NotImplementedException();
    }

    public List<InstallmentEntity> MappingListEntityDataToListEntity(List<InstallmentEntityData> datas)
    {
        throw new NotImplementedException();
    }

    public List<InstallmentDto> MappingListEntityToListDto(List<InstallmentEntity> entities)
    {
        throw new NotImplementedException();
    }

    public List<InstallmentEntityData> MappingListEntityToListEntityData(List<InstallmentEntity> obj)
    {
        List<InstallmentEntityData> lst = new();
        obj.ForEach(item => lst.Add(MappingEntityToEntityData(item)));
        return lst;
    }
}