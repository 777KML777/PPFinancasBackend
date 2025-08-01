using System.Text.Json;
using Domain;
using Domain.Entities.Installment;
using Repository.Json;

namespace Repository.JsonFile;

public class InstallmentRepository : GenericRepository, IInstallmentRepository
{
    #region CRUD OPERATION
    public void Create(InstallmentEntity obj)
    {
        IList<InstallmentEntity> newCollectionInstallments = ReadAll<InstallmentEntity>();
        newCollectionInstallments.Add(obj);

        string collectionInstallmentsJson = JsonSerializer.Serialize(newCollectionInstallments);

        // Reescrevo o arquivo
        File.WriteAllText(MachineExplorer.PegarCaminhoDoArquivo(MachineExplorer.InstallmentsFileMac), collectionInstallmentsJson);
    }
    // public IList<InstallmentEntity> ReadAll()
    // {
    //     string collectionInstallmentsJson = File.ReadAllText(MachineExplorer.PegarCaminhoDoArquivo(MachineExplorer.InstallmentsFileMac));
    //     var formatJson = collectionInstallmentsJson.Replace(@"\", "");

    //     List<InstallmentEntity> Installments = JsonSerializer.Deserialize<List<InstallmentEntity>>(formatJson) ??
    //         throw new Exception($"Erro na leitura da coleção de pagamentos.");

    //     return Installments;
    // }

    public void Update(InstallmentEntity id)
    {
        throw new NotImplementedException();
    }
    public void Delete(int id)
    {
        // Observar se não vai ser necessário colocar um Order by Id aqui 
        IList<InstallmentEntity> newCollectionInstallments = ReadAll<InstallmentEntity>();

        int index = newCollectionInstallments[id - 1].Id == id ? (id - 1) :
            throw new Exception($"Não foi possível remover o pagamento com o código {id}.");

        if (index > 0)
            newCollectionInstallments.RemoveAt(index);

        var collectionInstallmentsJson = JsonSerializer.Serialize(newCollectionInstallments.ToList());

        File.WriteAllText(MachineExplorer.PegarCaminhoDoArquivo(MachineExplorer.InstallmentsFileMac), collectionInstallmentsJson.ToString());
    }
    #endregion

    #region COMMOM OPERATION 
    public IList<InstallmentEntity> GetAllPaidByIdExpenses(int idExpenses) =>
            ReadAll<InstallmentEntity>().Where(x => x.IdExpense == idExpenses).ToList();

    // public int GetLastId() =>
    //     ReadAll().Max(x => x.Id);

    // public InstallmentEntity GetById(int id) =>
    //      ReadAll().SingleOrDefault(x => x.Id == id) ?? throw new Exception($"Nenhum pagamento com o identifcador {id} encontrado...");

    #endregion
}