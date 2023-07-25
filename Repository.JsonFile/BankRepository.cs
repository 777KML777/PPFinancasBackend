using System.Text.Json;
using Domain;

namespace Repository.JsonFile;
public class BankRepository : IBankRepository
{
    #region CRUD OPERATION 
    public void Create(BankEntity obj)
    {
        IList<BankEntity> newCollectionBanks = ReadAll();
        newCollectionBanks.Add(obj);
        File.WriteAllText(MachineExplorer.PegarCaminhoDoArquivo(MachineExplorer.BankFileWindows), JsonSerializer.Serialize(newCollectionBanks));
    }
    public IList<BankEntity> ReadAll()
    {
        string jsonBanks = File.ReadAllText(MachineExplorer.PegarCaminhoDoArquivo(MachineExplorer.BankFileWindows));
        var formatJson = jsonBanks.Replace(@"\", "");

        // List<BankEntity> banks = JsonSerializer.Deserialize<List<BankEntity>>(formatJson);
        List<BankEntity> banks = JsonSerializer.Deserialize<List<BankEntity>>(jsonBanks) ??
            throw new Exception($"Erro na leitura da coleção de bancos.");

        return banks;
    }

    public void Update(BankEntity id)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region COMMOM OPERATON 
    public int GetLastId() =>
                ReadAll().Max(x => x.Id);
    public BankEntity GetById(int id) =>
        ReadAll().SingleOrDefault(x => x.Id == id) ?? throw new Exception($"Nenhum pagamento com o identifcador {id} encontrado...");
    #endregion
}