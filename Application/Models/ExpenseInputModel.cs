namespace Application.Models;

public class ExpenseInputModel
{
    public ExpenseInputModel()
    {

    }

    public int Id { get; set; }
    public int IdBank { get; set; }
    public string Name { get; set; }
    public bool Inactive { get; set; }
    public bool Separeted { get; set; }
    public decimal Amount { get; set; }
    public string Describe { get; set; }
    public string PaymentType { get; set; }
    public int CountInstallments { get; set; }
    public List<InstallmentInputModel> Installments { get; set; }
}