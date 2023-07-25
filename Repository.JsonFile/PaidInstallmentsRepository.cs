using System.Text.Json;
using Domain;

namespace Repository.JsonFile;

public class PaidInstallmentsRepository : IPaidInstallmentsRepository
{
    #region CRUD OPERATION
    public void Create(PaidInstallmentsEntity obj)
    {
        IList<PaidInstallmentsEntity> newCollectionPaidInstallments = ReadAll();
        newCollectionPaidInstallments.Add(obj);

        string collectionPaidInstallmentsJson = JsonSerializer.Serialize(newCollectionPaidInstallments);

        // Reescrevo o arquivo
        File.WriteAllText(MachineExplorer.PegarCaminhoDoArquivo(MachineExplorer.PaidInstallmentsFileWindows), collectionPaidInstallmentsJson);
    }
    public IList<PaidInstallmentsEntity> ReadAll()
    {
        string collectionPaidInstallmentsJson = File.ReadAllText(MachineExplorer.PegarCaminhoDoArquivo(MachineExplorer.PaidInstallmentsFileWindows));
        var formatJson = collectionPaidInstallmentsJson.Replace(@"\", "");

        List<PaidInstallmentsEntity> paidInstallments = JsonSerializer.Deserialize<List<PaidInstallmentsEntity>>(formatJson) ??
            throw new Exception($"Erro na leitura da coleção de pagamentos.");

        return paidInstallments;
    }

    public void Update(PaidInstallmentsEntity id)
    {
        throw new NotImplementedException();
    }
    public void Delete(int id)
    {
        // Observar se não vai ser necessário colocar um Order by Id aqui 
        IList<PaidInstallmentsEntity> newCollectionPaidInstallments = ReadAll();

        int index = newCollectionPaidInstallments[id - 1].Id == id ? (id - 1) :
            throw new Exception($"Não foi possível remover o pagamento com o código {id}.");

        if (index > 0)
            newCollectionPaidInstallments.RemoveAt(index);

        var collectionPaidInstallmentsJson = JsonSerializer.Serialize(newCollectionPaidInstallments.ToList());

        File.WriteAllText(MachineExplorer.PegarCaminhoDoArquivo(MachineExplorer.PaidInstallmentsFileWindows), collectionPaidInstallmentsJson.ToString());
    }
    #endregion

    #region COMMOM OPERATION 
    public IList<PaidInstallmentsEntity> GetAllPaidByIdExpenses(int idExpenses) =>
            ReadAll().Where(x => x.IdExpenses == idExpenses).ToList();

    public int GetLastId() =>
        ReadAll().Max(x => x.Id);

    public PaidInstallmentsEntity GetById(int id) =>
         ReadAll().SingleOrDefault(x => x.Id == id) ?? throw new Exception($"Nenhum pagamento com o identifcador {id} encontrado...");

    #endregion
}