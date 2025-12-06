namespace Services.Base.Interfaces;

public interface IService<TInputModel, TDto, TEntity>
{
    #region RSO - Region specific operation
    #endregion

    #region RCO - Region commom operation
    public TInputModel GetById(int identifier);
    #endregion

    #region CRUD 
    public TDto Create(TInputModel input);
    public IEnumerable<TDto> Read();
    public TInputModel Update(TInputModel input);
    public bool Delete(int identifier);
    #endregion
}