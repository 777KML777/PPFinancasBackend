using System.Text.Json;
using Domain;

namespace Repository.JsonFile;

public class PaidInstallmentsRepository : IPaidInstallmentsRepository
{
    public void Create(PaidInstallmentsEntity obj)
    {
        //Leio todos 
        var lst = ReadAll(); 
        
        // Insiro um novo 
        lst.Add(obj); 

        // Pegando o caminho e Serializando
        string enviroment = Environment.CurrentDirectory;
        string replaceProject = enviroment.Replace("Api", "Repository.JsonFile");
        string fullPath = replaceProject + MachineExplorer.PaidInstallmentsFileWindows;

        
        string paidInstallmentsJson = JsonSerializer.Serialize(lst);

        // E salvo "atualizando"
        File.WriteAllText(fullPath, paidInstallmentsJson);
    }
    public IList<PaidInstallmentsEntity> ReadAll()
    {
        string enviroment = Environment.CurrentDirectory;
        string replaceProject = enviroment.Replace("Api", "Repository.JsonFile");
        string fullPath = replaceProject + MachineExplorer.PaidInstallmentsFileWindows;

        string paidInstallmentsJson = File.ReadAllText(fullPath);
        var formatJson = paidInstallmentsJson.Replace(@"\", "");


        List<PaidInstallmentsEntity> paidInstallments = JsonSerializer.Deserialize<List<PaidInstallmentsEntity>>(formatJson);
        return paidInstallments;
    }

    public void Update(PaidInstallmentsEntity id)
    {
        throw new NotImplementedException();
    }
    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public IList<PaidInstallmentsEntity> GetAllPaidByIdExpenses(int idExpenses) =>
        ReadAll().Where(x => x.IdExpenses == idExpenses).ToList();

    public int GetLastId() =>
        ReadAll().Max(x => x.Id);

    public PaidInstallmentsEntity GetById(int id)
    {
        throw new NotImplementedException();
    }

}