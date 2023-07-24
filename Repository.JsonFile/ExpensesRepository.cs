using System.Text.Json;
using Domain;

namespace Repository.JsonFile;

public class ExpensesRepository : IExpensesRepository
{
    public void Create(ExpensesEntity bank)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public List<ExpensesEntity> GetAll()
    {
        throw new NotImplementedException();
    }

    public List<ExpensesEntity> GetAllByIdBank(int id) =>
        ReadAll().Where(x => x.IdBank == id).ToList();

    public ExpensesEntity GetById(int id) =>
        ReadAll().SingleOrDefault(x => x.Id == id);

    public IList<ExpensesEntity> ReadAll()
    {
        string enviroment = Environment.CurrentDirectory;
        string replaceProject = enviroment.Replace("Api", "Repository.JsonFile");
        string fullPath = replaceProject + MachineExplorer.ExpensesFileMac;

        string jsonExpenses = File.ReadAllText(fullPath);
        var formatJson = jsonExpenses.Replace(@"\", "");

        List<ExpensesEntity> expenses = JsonSerializer.Deserialize<List<ExpensesEntity>>(formatJson);
        return expenses;
    }

    public void Update(ExpensesEntity expense)
    {
        var lst = ReadAll();
        var json = JsonSerializer.Serialize<List<ExpensesEntity>>(lst.ToList());
        string enviroment = Environment.CurrentDirectory;
        string replaceProject = enviroment.Replace("Api", "Repository.JsonFile");
        string fullPath = replaceProject + MachineExplorer.ExpensesFileMac;

        File.WriteAllText(fullPath, json.ToString());
    }
}