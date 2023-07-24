using System.Text.Json;
using Domain;

namespace Repository.JsonFile;

public class PaidInstallmentsRepository : IPaidInstallmentsRepository
{
    public void Create(PaidInstallmentsEntity bank)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public IList<PaidInstallmentsEntity> GetAllPaidByIdExpenses(int idExpenses) =>
        ReadAll().Where(x => x.IdExpenses == idExpenses).ToList();

    public PaidInstallmentsEntity GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IList<PaidInstallmentsEntity> ReadAll()
    {
        // string paidInstallmentsJsonOrigin = File.ReadAllText($"C:\\Users\\KleberM2\\Videos\\Captures\\JsonPaidInstallments.json");

        string enviroment = Environment.CurrentDirectory; // "C:\\Projects\\PessoalFinancasBackend\\Api"
        string secondTest = enviroment.Replace("Api", "Repository.JsonFile");
        // Mudando para Windows
        // string x = secondTest + @"\JsonPaidInstallments.json";
        // Mudando para MAC
        string x = secondTest + @"/JsonPaidInstallments.json";
        string paidInstallmentsJson = File.ReadAllText(x);

        var teste = paidInstallmentsJson.Replace(@"\", "");


        List<PaidInstallmentsEntity> paidInstallments = JsonSerializer.Deserialize<List<PaidInstallmentsEntity>>(teste);
        return paidInstallments;
    }

    public void Update(PaidInstallmentsEntity id)
    {
        throw new NotImplementedException();
    }
}