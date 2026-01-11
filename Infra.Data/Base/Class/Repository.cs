namespace Infra.Data.Base.Class;

public abstract class Repository : IRepository
{
    private readonly IGenericRepository _context;
    public Repository
    (
        IGenericRepository context
    )
    {
        _context = context;
    }
    #region RSO - Region Specific Operation
    // depends of class will implement
    #endregion

    #region RCO - Region Commom Operation
    public TEntity GetById<TEntity>(int identifier) =>
        _context.GetById<TEntity>(identifier);

    public TEntity GetLast<TEntity>()
    {
        throw new NotImplementedException();
    }

    public int GetLastId<TEntity>()
    {
        throw new NotImplementedException();
    }
    #endregion

    #region CRUD Operations
    public TEntity Create<TEntity>(TEntity Tentity) =>
        _context.Create(Tentity);

    public IEnumerable<TEntity> ReadAll<TEntity>() =>
        _context.ReadAll<TEntity>().AsEnumerable();

    public TEntity Update<TEntity>(TEntity Tentity) =>
        _context.Update(Tentity);
    public bool Delete<TEntity>(int identifier)
    {
        throw new NotImplementedException();
    }
    #endregion

}