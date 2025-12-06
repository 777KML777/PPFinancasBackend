namespace Services.Base.Interfaces;

public interface IService<TInputModel, TDto, TEntity>
{
    #region RSO - Region specific operation
    #endregion

    #region RCO - Region commom operation
    TInputModel GetById(int identifier);
    #endregion

    #region CRUD 
    public TDto Create(TInputModel input);
    IEnumerable<TDto> Read();
    TInputModel Update(TInputModel input);
    bool Delete(int identifier);
    #endregion
}