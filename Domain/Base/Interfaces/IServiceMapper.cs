namespace Domain.Base.Interfaces;

public interface IServiceMapper<TDto, TEntity>
{
    #region RMO - Region Mapper Objects
    public TEntity MappingDtoToEntity(TDto dto);
    public TDto MappingEntityToDto(TEntity entity);

    #endregion

    #region RMC - Region Mapper Collection
    public IEnumerable<TDto> MappingEntityEnumerableToDtoEnumerable(IEnumerable<TEntity> entities);
    #endregion
}