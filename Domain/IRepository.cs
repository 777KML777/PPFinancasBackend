namespace Domain;

public interface IRepository<T>
{
    #region CRUD OPERATION
    void Create(T bank);
    IList<T> ReadAll();
    void Update(T obj);
    void Delete(int id);
    #endregion

    #region COMMOM OPERATION 
    T GetById(int id);
    int GetLastId();
    #endregion

}