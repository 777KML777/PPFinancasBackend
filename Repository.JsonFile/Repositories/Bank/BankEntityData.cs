using Repository.Json;

namespace Repository.JsonFile.Repositories.Bank;

public class BankEntityData : EntityData
{
    public bool Avalaible { get; set; }
    public int PaymentDay { get; set; }
    public decimal Balance { get; set; }
    public string Name { get; set; } = string.Empty;
}