namespace Application;

public interface IService<TInputModel, TDto, TEntity, TEntityData>
{
    TDto MappingEntityToDto(TEntity entity);
    TEntity MappingInputModelToEntity(TInputModel input);

    /// <summary>
    /// Usado para operações de inserção. (Create, Update, Patch...)
    /// </summary>
    /// <param name="obj">Entidade do domínio</param>
    /// <returns>Objeto do repositório TEntityData</returns>
    TEntityData MappingEntityToEntityData(TEntity entity);


    /// <summary>
    /// Usado para operações de leituras. (Get, GetById, Read...)
    /// </summary>
    /// <param name="obj">Objeto do repositório JSON</param>
    /// <returns>Entidade de domínio TEntity</returns>
    TEntity MappingEntityDataToEntity(TEntityData data); 

    /// <summary>
    /// Usado para operações de inserção. (Create, Update, Patch...)
    /// </summary>
    /// <param name="obj">Entidade do domínio</param>
    /// <returns>Objeto do repositório TEntityData</returns>
    List<TEntityData> MappingListEntityToListEntityData(List<TEntity> entities);


    /// <summary>
    /// Usado para operações de leituras. (Get, GetById, Read...)
    /// </summary>
    /// <param name="obj">Objeto do repositório JSON</param>
    /// <returns>Entidade de domínio TEntity</returns>
    List<TEntity> MappingListEntityDataToListEntity(List<TEntityData> datas);

    List<TDto> MappingListEntityToListDto(List<TEntity> entities);
    
    bool Create(TInputModel input);
    List<TDto> Read();
    bool Update(TInputModel input);
    bool Delete(TInputModel input);
    TDto GetById(int id);
}