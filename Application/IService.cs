namespace Application;

public interface IService<TDto, TEntity>
{
    TDto MappingEntityToDto(TEntity obj);
    TEntity MappingDtoToEntity(TDto obj);

}