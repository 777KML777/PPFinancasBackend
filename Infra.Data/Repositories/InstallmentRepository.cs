using System.Text.Json;

namespace Infra.Data.Repositories;

public class InstallmentRepository : Repository, IInstallmentRepository
{
    public InstallmentRepository(IGenericRepository context) : base(context)
    {
    }
    #region CRUD OPERATION
    public void Create(InstallmentEntity obj)
    {
        IList<InstallmentEntity> newCollectionInstallments = ReadAll<InstallmentEntity>().ToList(); // Remover esse .ToList(), tem que ser IEnumerable.
        newCollectionInstallments.Add(obj);

        string collectionInstallmentsJson = JsonSerializer.Serialize(newCollectionInstallments);

        // Reescrevo o arquivo
        File.WriteAllText(MachineExplorer.PegarCaminhoDoArquivo(MachineExplorer.InstallmentsFileMac), collectionInstallmentsJson);
    }
    // public IList<InstallmentEntity> ReadAll(.ToList())
    // {
    //     string collectionInstallmentsJson = File.ReadAllText(MachineExplorer.PegarCaminhoDoArquivo(MachineExplorer.InstallmentsFileMac)).ToList();
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
        IList<InstallmentEntity> newCollectionInstallments = ReadAll<InstallmentEntity>().ToList();

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
            ReadAll<InstallmentEntity>().Where(x => x.IdExpense == idExpenses).ToList().ToList();

    IEnumerable<InstallmentEntity> IInstallmentRepository.GetAllPaidByIdExpenses(int idExpenses)
    {
        return GetAllPaidByIdExpenses(idExpenses);
    }

    // public int GetLastId() =>
    //     ReadAll().Max(x => x.Id).ToList();

    // public InstallmentEntity GetById(int id) =>
    //      ReadAll().SingleOrDefault(x => x.Id == id) ?? throw new Exception($"Nenhum pagamento com o identifcador {id} encontrado...").ToList();

    #endregion
}