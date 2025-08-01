namespace Repository.Json;

// Retornar o objeto criado. 

public interface IGenericRepository
{
    public T Create<T>(T entity);
    // public bool Create<T>(T entity);
    public IList<T> ReadAll<T>();
    // public bool Update<T>(T entity);
    public T Update<T>(T entity);
    public bool Delete<T>(T entity);
    // Other commom operations
    public int GetLastId<T>();
    public T GetById<T>(int id);
    // internal T Include<T>(T data, string name)
    // {
    //     // Abordagem por lista é falha. 
    //     // Tem que ser pelo id. 
    //     // Quando maior que zero atualizar
    //     // Quando zero ou cria ou lê. Como diferênciar? Pelo IdFather
    //     // Aprender sobre expressão lambda em .NET
    //     // O meu include a princípio passaria o objeto atual que seria retornado e o ao incluir. 

    //     // E quando não for lista. Pelo id? 
    //     // --- Eu passo o id negativo? 
    //     // Quando não for lista. Eu crio uma lista lá dentro. 
    //     List<T> generic = new List<T>();

    //     // E quando for lista eu chamo um IncludeAddRange que na verdade irá chamar 
    //     // o inlcude normal utilizando de um ForEach

    //     // Se o count == 0 e existir, leitura
    //         // Teria que ter um GetByIdFather. Como saber o pai corretamente. Id+GetTypeName-Entity
    //         // -- Por isso que eu deveria ter uma especie de mapping que a propriedade informada eu nomearia da maneira acima. 
    //     // Se o count > 0 e não existir atualiza
    //     // Se o count > 1 e não existir cria

    //     return data;
    // }
    // internal T IncludeRange<T>(List<T> obj, string name)
    // {
    //     List<T> values = new List<T>(); 
    //     obj.ForEach(i => Include(i, ""));
    //     return values.Last(); 

    // }
}