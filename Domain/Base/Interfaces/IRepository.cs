namespace Domain.Base.Interfaces;

public interface IRepository/* <TEntity> */
{
    #region RSO - Region Specific Operation
    // depends of class will implement
    #endregion

    #region RCO - Region Commom Operation
    public int GetLastId<TEntity>();
    public TEntity GetLast<TEntity>();
    public TEntity GetById<TEntity>(int identifier);
    #endregion

    #region CRUD Operations
    protected TEntity Create<TEntity>(TEntity entity);
    protected IEnumerable<TEntity> ReadAll<TEntity>();
    protected TEntity Update<TEntity>(TEntity entity);
    protected bool Delete(int identifier);

    #endregion
}