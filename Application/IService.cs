namespace Application;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TInputModel"></typeparam>
/// <typeparam name="TDto"></typeparam>
/// <typeparam name="TEntity"></typeparam>
/// <typeparam name="TEntityData"></typeparam>
public interface IService<TInputModel, TDto, TEntity, TEntityData>
{
    #region CRUD OPERATION
    TDto Create(TInputModel input);
    List<TDto> Read();
    TDto Update(TDto dto);
    bool Delete(TInputModel input);

    #endregion

    #region MAPPING OBJECTS
    /// <summary>
    /// (ID: 1-2) - (Operação: IO1 Create || Update || Patch) - (Flow ->).
    /// </summary>
    /// <param name="dto">Dado fornecido de ou para um sistema externo.</param>
    /// <returns>Entidade de domíno para auto validação.</returns>
    TEntity MappingDtoToEntity(TDto dto);

    /// <summary>
    /// (ID: 2-3) - (Operação: IO2 Create || Update) - (Flow ->).
    /// </summary>
    /// <param name="entity">Entidade de domínio auto validada.</param>
    /// <returns>Dado a ser registrado no repositório.</returns>
    TEntityData MappingEntityToEntityData(TEntity entity);

    /// <summary>
    /// (ID: 3-2) - (Operação: RO1 Read || GetById) - (Flow <-).
    /// </summary>
    /// <param name="data">Dado fornecido do repositório JSON.</param>
    /// <returns>Entidade de domíno para auto validação.</returns>
    TEntity MappingEntityDataToEntity(TEntityData data);

    /// <summary>
    /// (ID: 2-1) - (Operação: RO2 Read || GetById) - (Flow <-).
    /// </summary>
    /// <param name="entity">Entidade de domínio auto validada.</param>
    /// <returns></returns>
    TDto MappingEntityToDto(TEntity entity);
    #endregion

    #region MAPPING LIST OBJECTS
    /// <summary>
    /// Usado para operações de leituras. (Get, GetById, Read...)
    /// </summary>
    /// <param name="obj">Objeto do repositório JSON</param>
    /// <returns>Entidade de domínio TEntity</returns>
    List<TEntity> MappingListEntityDataToListEntity(List<TEntityData> datas);

    /// <summary>
    /// Usado para operações de leituras. (Get, GetById, Read...)
    /// </summary>
    /// <param name="entities">Objeto do repositório JSON</param>
    /// <returns>Entidade de domínio TEntity</returns>
    List<TDto> MappingListEntityToListDto(List<TEntity> entities);

    #endregion

    #region COMMOM OPERATIONS 
    public TInputModel GetById(int id);

    #endregion

    #region REMOVER 
    bool Create(TInputModel input, bool remover = true);
    bool Update(TInputModel input, bool remover = true);
    TDto GetById(int id, bool remover = true);

    [Obsolete("Depreciado.")]
    TEntity MappingInputModelToEntity(TInputModel input);

    /// <summary>
    /// Usado para operações de inserção. (Create, Update, Patch...)
    /// </summary>
    /// <param name="obj">Entidade do domínio</param>
    /// <returns>Objeto do repositório TEntityData</returns>
    List<TEntityData> MappingListEntityToListEntityData(List<TEntity> entities);

    #endregion

}