namespace Domain.Entities.Bank;
public class BankEntityData : Entity
{
    // [Obsolete("Construtor reservado para serialização", error: true)]
    public BankEntityData() { }
    public string Name { get; set; }
    public int PaymentDay { get; set; }
    public bool Avalaible { get; set; }
    public decimal Balance { get; set; }
}