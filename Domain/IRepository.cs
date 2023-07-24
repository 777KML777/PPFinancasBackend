namespace Domain; 

public interface IRepository <T>
{
    // C - R - U - D -- Operations
    void Create (T bank);
    IList<T> ReadAll ();
    
    // Antes tava o Id
    void Update (T obj); 
    void Delete (int id);

    // Commons Operations
    T GetById (int id);
    int GetLastId();
}