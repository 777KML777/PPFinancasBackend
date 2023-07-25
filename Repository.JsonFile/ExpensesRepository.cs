using System.Text.Json;
using Domain;

namespace Repository.JsonFile;

public class ExpensesRepository : IExpensesRepository
{
    #region CRUD OPERATION 
    public void Create(ExpensesEntity bank)
    {
        throw new NotImplementedException();
    }

    public IList<ExpensesEntity> ReadAll()
    {
        string jsonExpenses = File.ReadAllText(MachineExplorer.PegarCaminhoDoArquivo(MachineExplorer.ExpensesFileWindows));
        var formatJson = jsonExpenses.Replace(@"\", "");

        List<ExpensesEntity> expenses = JsonSerializer.Deserialize<List<ExpensesEntity>>(formatJson) ??
            throw new Exception($"Erro na leitura da coleção de despesas.");

        return expenses;
    }

    public void Update(ExpensesEntity expense)
    {
        IList<ExpensesEntity> newCollectionExpenses = ReadAll();
        
        newCollectionExpenses[expense.Id - 1] = 
            newCollectionExpenses[expense.Id - 1].Id == expense.Id ? expense :
             throw new Exception($"Não foi possível atualizar a despesa {expense.ExpenseName}.");

        var collectionExpensesJson = JsonSerializer.Serialize(newCollectionExpenses.ToList());

        File.WriteAllText(MachineExplorer.PegarCaminhoDoArquivo(MachineExplorer.ExpensesFileWindows), collectionExpensesJson.ToString());
    }
    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region COMMOM OPERATION 
    public List<ExpensesEntity> GetAllByIdBank(int id) =>
            ReadAll().Where(x => x.IdBank == id).ToList();

    public int GetLastId() =>
            ReadAll().Max(x => x.Id);
    public ExpensesEntity GetById(int id) =>
        ReadAll().SingleOrDefault(x => x.Id == id) ?? throw new Exception($"Nenhuma despesa com o identifcador {id} encontrado...");
    #endregion
}