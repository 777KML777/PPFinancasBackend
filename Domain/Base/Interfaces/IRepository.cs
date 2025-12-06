namespace Domain.Base.Interfaces;

public interface IRepository/* <TEntity> */
{
    #region RSO - Region Specific Operation
    // depends of class will implement
    #endregion

    #region RCO - Region Commom Operation
    protected int GetLastId<TEntity>();
    protected TEntity GetLast<TEntity>();
    protected TEntity GetById<TEntity>(int identifier);
    #endregion

    // Se eles não forem públicos eu teria que criar outro. 
    #region CRUD Operations 
    public TEntity Create<TEntity>(TEntity entity);
    protected IEnumerable<TEntity> ReadAll<TEntity>();
    public TEntity Update<TEntity>(TEntity entity);
    public bool Delete(int identifier);
    #endregion
}