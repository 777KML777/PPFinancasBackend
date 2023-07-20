namespace Domain; 

public interface IRepository <T>
{
    // C - R - U - D -- Operations
    void Create (T bank);
    IList<T> ReadAll ();
    void Update (int id); 
    void Delete (int id);

    // Commons Operations
    T GetById (int id);
}