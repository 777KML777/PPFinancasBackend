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
    public TEntity Create<TEntity>(TEntity entity);
    protected IEnumerable<TEntity> ReadAll<TEntity>();
    public TEntity Update<TEntity>(TEntity entity);
    public bool Delete(int identifier);
    #endregion
}