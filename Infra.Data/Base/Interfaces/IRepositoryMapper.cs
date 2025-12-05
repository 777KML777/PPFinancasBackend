namespace Infra.Data.Base.Interfaces;

public interface IRepositoryMapper<TEntity, TEntityData>
{
    #region RMO - Region Mapper Objects
    /// <summary>
    /// (ID: 2-3) - (Operação: IO2 Create || Update) - (Flow ->).
    /// </summary>
    /// <param name="entity">Entidade de domínio auto validada.</param>
    /// <returns>Dado a ser registrado no repositório.</returns>
    public TEntityData MappingEntityToEntityData(TEntity entity);

    /// <summary>
    /// (ID: 3-2) - (Operação: RO1 Read || GetById) - (Flow <-).
    /// </summary>
    /// <param name="data">Dado fornecido do repositório JSON.</param>
    /// <returns>Entidade de domíno para auto validação.</returns>
    public TEntity MappingEntityDataToEntity(TEntityData data);
    #endregion

    #region RMC - Region Mapper Collection
    public IEnumerable<TEntityData> MappingEntityIEnumerableToEntityDataIEnumerable(IEnumerable<TEntity> entity);
    public IEnumerable<TEntity> MappingEntityDataIEnumerableToEntityIEnumerable(IEnumerable<TEntityData> data);
    #endregion
}