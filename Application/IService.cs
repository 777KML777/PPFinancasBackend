namespace Application;

public interface IService<TInputModel, TDto, TEntity, TEntityData>
{
    TDto MappingEntityToDto(TEntity obj);
    TEntity MappingInputModelToEntity(TInputModel obj);

    /// <summary>
    /// Usado para operações de inserção. (Create, Update, Patch...)
    /// </summary>
    /// <param name="obj">Entidade do domínio</param>
    /// <returns>Objeto do repositório TEntityData</returns>
    TEntityData MappingEntityToEntityData(TEntity obj);


    /// <summary>
    /// Usado para operações de leituras. (Get, GetById, Read...)
    /// </summary>
    /// <param name="obj">Objeto do repositório JSON</param>
    /// <returns>Entidade de domínio TEntity</returns>
    TEntity MappingEntityDataToEntity(TEntityData obj); 

    /// <summary>
    /// Usado para operações de inserção. (Create, Update, Patch...)
    /// </summary>
    /// <param name="obj">Entidade do domínio</param>
    /// <returns>Objeto do repositório TEntityData</returns>
    List<TEntityData> MappingListEntityToListEntityData(List<TEntity> obj);


    /// <summary>
    /// Usado para operações de leituras. (Get, GetById, Read...)
    /// </summary>
    /// <param name="obj">Objeto do repositório JSON</param>
    /// <returns>Entidade de domínio TEntity</returns>
    List<TEntity> MappingListEntityDataToListEntity(List<TEntityData> obj);

    List<TDto> MappingListEntityToListDto(List<TEntity> obj);
    
    bool Create(TInputModel obj, bool include = false);
    List<TDto> Read(bool include = false);
    bool Update(TInputModel obj, bool include = false);
    bool Delete(TInputModel obj, bool include = false);
    TDto GetById(int id, bool include = false);
}