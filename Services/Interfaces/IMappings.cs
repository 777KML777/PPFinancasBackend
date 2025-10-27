namespace Services;

public interface IMappings<TInputModel, TDto, TEntity, TEntityData>
{
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
}