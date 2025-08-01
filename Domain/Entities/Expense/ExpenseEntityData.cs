using Domain.Entities.Bank;
using Domain.Entities.Installment;
using Repository.Json;

namespace Domain.Entities.Expense;

public class ExpenseEntityData : EntityData
{
    public ExpenseEntityData()
    {

    }

    // public int Id { get; set; }
    public int IdBank { get; set; }
    public string Name { get; set; }
    public bool Inactive { get; set; }
    public bool Separeted { get; set; }
    public decimal Amount { get; set; }
    public string Describe { get; set; }
    public string PaymentType { get; set; }
    public BankEntityData Bank { get; set; }
    public int CountInstallments { get; set; }
    public DateTime DatePurchase { get; set; }
    public DateTime DateLastInstallment { get; set; }
    public DateTime DateFirstInstallment { get; set; }
    public List<InstallmentEntityData> Installments = new();
}
