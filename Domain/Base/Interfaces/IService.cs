namespace Domain.Base.Interfaces;

public interface IService<TDto, TEntity>
{
    #region RSO - Region specific operation
    // Depends of class will implement
    #endregion

    #region RCO - Region commom operation
    public TDto GetById(int identifier);
    #endregion

    #region CRUD Operations
    public TDto Create(TDto dto);
    public IEnumerable<TDto> Read();
    public TDto Update(TDto dto);
    public bool Delete(int identifier);
    #endregion
}