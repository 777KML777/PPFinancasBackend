namespace Domain.Base.Interfaces;

public interface IRepository
{
    #region RSO - Region Specific Operation
    // depends of class will implement
    #endregion

    #region RCO - Region Commom Operation
    protected int GetLastId<TEntity>();
    protected TEntity GetLast<TEntity>();
    protected TEntity GetById<TEntity>(int identifier);
    #endregion

    #region CRUD Operations 
    protected TEntity Create<TEntity>(TEntity entity);
    protected IEnumerable<TEntity> ReadAll<TEntity>();
    protected TEntity Update<TEntity>(TEntity entity);
    protected bool Delete<TEntity>(int identifier);
    #endregion
}