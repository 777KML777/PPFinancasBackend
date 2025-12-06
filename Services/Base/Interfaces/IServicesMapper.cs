namespace Services.Base.Interfaces;

public interface IServicesMapper<TInputModel, TDto, TEntity>
{
    #region RMO - Region Mapper Objects
    TDto MappingEntityToDto(TEntity entity);
    TEntity MappingInputModelToEntity(TInputModel input);
    #endregion

    #region RMC - Region Mapper Collection
    List<TDto> MappingEntityListToDtoList(List<TEntity> entities);
    #endregion
}