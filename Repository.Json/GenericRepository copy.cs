using System.Text.Json;

namespace Repository.Json;

public static class GenericRepositoryCopy
{
    public static bool Create<T>(T entity)
    {
        IList<T> newJsonData = ReadAll<T>();
        newJsonData.Add(entity);

        var nameRepository = entity.GetType().Name;
        File.WriteAllText(MachineExplorer.GetFilePath(nameRepository),
             JsonSerializer.Serialize(newJsonData));

        return true;
    }
    public static IList<T> ReadAll<T>()
    {
        var nameRepository = typeof(T).Name;
        string jsonObject = File.ReadAllText(MachineExplorer.GetFilePath(nameRepository));

        List<T> lstJsonData = JsonSerializer.Deserialize<List<T>>(jsonObject) ??
            throw new Exception($"Erro na leitura da coleção do banco de dados");

        return lstJsonData;
    }
    public static bool Update<T>(T entity)
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

        return true;
    }
    public static int GetLastId<T>() =>
         Convert.ToInt32(ReadAll<T>().Max(item => { return typeof(T).GetProperty("Id").GetValue(item); }));
    public static T GetById<T>(int id)
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
            return obj;
        else
            throw new Exception($"Nenhuma ocorrência com o identificador {id} foi encontrada.");
    }
    private class Entity
    {
        public int Id { get; set; }
    }
}