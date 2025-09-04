using Repository.Json;

namespace Repository.JsonFile.Repositories.Bank;

public class BankEntityData : EntityData
{
    public string Name { get; set; }
    public bool Avalaible { get; set; }
    public int PaymentDay { get; set; }
    public decimal Balance { get; set; }
}