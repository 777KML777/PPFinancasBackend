using System.Text.Json;

namespace Repository.Json;

// Retornar a entidade criada e não um boolean
//Caminho para diferentes iniciadores 
public abstract class GenericRepository : IGenericRepository/* <EntityData> */
{
    private string nameInclude = string.Empty;
    public T Create<T>(T entity)
    {

        var id = typeof(T).GetProperty("Id");
        var idIncrementado = GetLastId<T>() + 1;
        // var idIncrementado2 = GetLastId() + 1;

        entity.GetType().GetProperty("Id").SetValue(entity, idIncrementado);

        IList<T> newJsonData = ReadAll<T>();
        newJsonData.Add(entity);

        var nameRepository = entity.GetType().Name;
        File.WriteAllText(MachineExplorer.GetFilePath(nameRepository),
             JsonSerializer.Serialize(newJsonData));

        return GetById<T>(GetLastId<T>());
    }
    // public bool Create<T>(T entity)
    // {

    //     var id = typeof(T).GetProperty("Id");
    //     var idIncrementado = GetLastId<T>() + 1;

    //     entity.GetType().GetProperty("Id").SetValue(entity, idIncrementado);

    //     IList<T> newJsonData = ReadAll<T>();
    //     newJsonData.Add(entity);

    //     var nameRepository = entity.GetType().Name;
    //     File.WriteAllText(MachineExplorer.GetFilePath(nameRepository),
    //          JsonSerializer.Serialize(newJsonData));

    //     // return GetById<T>(GetLastId<T>());
    //     return true;
    // }
    public IList<T> ReadAll<T>()
    {

        var y = typeof(T);
        // var x = reflection.MapType(y.GetType().GetTypeInfo());
        // var j = Environment.SystemDirectory;
        // var xin = AppContext.BaseDirectory; // Caminho base do diretório.
        // var yu = Assembly.GetCallingAssembly().GetName().Name; // substituir por Repository.Json
        // var ydfsa2 = Assembly.GetEntryAssembly().GetName().Name;// substituir por Repository.Json
        // var ydfsa = Assembly.GetExecutingAssembly().GetName().Name;


        var nameRepository = nameInclude == string.Empty ? typeof(T).Name : nameInclude;
        // var file = typeof(T).GetProperties();

        // File.WriteAllText
        // (
        //     "/Users/klebermirandalima/Projetos/PPFinancasBackend/Repository.json/Reflex.cs",
        //      $"/*{file}*/"
        // );

        string jsonObject = File.ReadAllText(MachineExplorer.GetFilePath(nameRepository));

        // Type x = Type.GetType("Reflex");

        // List<> lstJsonData2 = JsonSerializer.Deserialize<List<>>(jsonObject) ??
        // //     throw new Exception($"Erro na leitura da coleção do banco de dados");
        // List<dynamic> lstJsonData2 = JsonSerializer.Deserialize<List<dynamic>>(jsonObject) ??
        //     throw new Exception($"Erro na leitura da coleção do banco de dados");

        // foreach (var item in lstJsonData2.ToList())
        // {
        //     var y = Type.GetType(item);
        //     // typeof().GetProperties()
        //     // typeof(T).GetProperties()
        // }

        // var ipsilon =  (object) lstJsonData2.FirstOrDefault();

        List<T> lstJsonData = JsonSerializer.Deserialize<List<T>>(jsonObject) ??
            throw new Exception($"Erro na leitura da coleção do banco de dados");

        return lstJsonData;
    }
    public T Update<T>(T entity)
    {


        int id = Convert.ToInt32(typeof(T).GetProperty("Id").GetValue(entity));

        IList<T> updatedJsonData = ReadAll<T>();

        int index = 0;
        bool removed = false;

        foreach (T item in ReadAll<T>())
        {
            object idLista = typeof(T).GetProperty("Id").GetValue(item);

            if (Convert.ToInt32(idLista) == id)
            {
                updatedJsonData.RemoveAt(index);
                removed = true;
            }

            index++;
        }

        if (removed)
            updatedJsonData.Add(entity);

        var nameRepository = entity.GetType().Name;
        File.WriteAllText(MachineExplorer.GetFilePath(nameRepository),
             JsonSerializer.Serialize(updatedJsonData));

        return GetById<T>(id);
    }

    // public bool Update<T>(T entity)
    // {


    //     int id = Convert.ToInt32(typeof(T).GetProperty("Id").GetValue(entity));

    //     IList<T> updatedJsonData = ReadAll<T>();

    //     int index = 0;
    //     bool removed = false;

    //     foreach (T item in ReadAll<T>())
    //     {
    //         object idLista = typeof(T).GetProperty("Id").GetValue(item);

    //         if (Convert.ToInt32(idLista) == id)
    //         {
    //             updatedJsonData.RemoveAt(index);
    //             removed = true;
    //         }

    //         index++;
    //     }

    //     if (removed)
    //         updatedJsonData.Add(entity);

    //     var nameRepository = entity.GetType().Name;
    //     File.WriteAllText(MachineExplorer.GetFilePath(nameRepository),
    //          JsonSerializer.Serialize(updatedJsonData));

    //     return true;
    // }
    public bool Delete<T>(T entity)
    {
        int id = Convert.ToInt32(typeof(T).GetProperty("Id").GetValue(entity));

        IList<T> updatedJsonData = ReadAll<T>();

        int index = 0;
        bool removed = false;

        foreach (T item in ReadAll<T>())
        {
            object idLista = typeof(T).GetProperty("Id").GetValue(item);

            if (Convert.ToInt32(idLista) == id)
            {
                updatedJsonData.RemoveAt(index);
                removed = true;
            }

            index++;
        }

        if (removed)
        {
            var nameRepository = entity.GetType().Name;
            File.WriteAllText(MachineExplorer.GetFilePath(nameRepository),
                 JsonSerializer.Serialize(updatedJsonData));
        }

        return removed;
    }
    public int GetLastId<T>() =>
         Convert.ToInt32(ReadAll<T>().Max(item => { return typeof(T).GetProperty("Id").GetValue(item); }));


    public T GetById<T>(int id)
    {
        try
        {

            T obj = new List<T>().FirstOrDefault(); // Gambiarra que funciona. 

            bool found = false;

            foreach (T item in ReadAll<T>())
            {
                object idLista = typeof(T).GetProperty("Id").GetValue(item);

                if (Convert.ToInt32(idLista) == id)
                {
                    obj = item;
                    found = true;
                    break;
                }
            }

            if (found)
            {
                nameInclude = string.Empty;
                return obj;
            }
            else
                throw new Exception($"Nenhuma ocorrência com o identificador {id} foi encontrada.");
        }   
        catch (System.Exception)
        {

            throw new Exception($"Nenhuma ocorrência com o identificador {id} foi encontrada.");

        }

    }

    internal T Include<T, TInclude>(T data, TInclude toInclude, bool repository = false)
    {
        // Não Chamar Include para leituras

        // Teria que ter um GetByIdFather. Como saber o pai corretamente. Id+GetTypeName-Entity
        // -- Por isso que eu deveria ter uma especie de mapping que a propriedade informada eu nomearia da maneira acima. 

        // E se eu realmente quisder criar mas existir ele sempre irá ler. Abordagem errônea.
        // A mais rápida talvez seria criar um GetInclude e mesmo assim ainda teria a questão do GetByIdFather
        // id == 0 e existir, leitura. Para leitura sempre vai vir id == 0
        // id == e não existir cria
        // id > 0 e existir atualiza

        object id = typeof(T).GetProperty("Id").GetValue(toInclude);
        nameInclude = toInclude.GetType().Name;

        if (Convert.ToInt32(id) > 0)
            Update(toInclude);
        else
            Create(toInclude);

        return data;

        // Tem que ser pelo id. 
        // Quando maior que zero atualizar
        // Quando zero ou cria ou lê. Como diferênciar? Pelo IdFather
        // Aprender sobre expressão lambda em .NET
        // O meu include a princípio passaria o objeto atual que seria retornado e o ao incluir. 

        // Abordagem por lista é falha. 
        // E quando não for lista. Pelo id? 
        // --- Eu passo o id negativo? 
        // Quando não for lista. Eu crio uma lista lá dentro. 
        // List<T> generic = new List<T>();

        // E quando for lista eu chamo um IncludeAddRange que na verdade irá chamar 
        // o inlcude normal utilizando de um ForEach

    }
    internal T IncludeRange<T, TInclude>(T data, List<TInclude> toInclude, bool repository = false)
    {
        toInclude.ForEach(item => Include(data, item));
        return data;
    }
}