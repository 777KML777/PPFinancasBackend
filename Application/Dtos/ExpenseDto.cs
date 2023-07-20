namespace Application;

public class ExpenseDto
{
    public int Id { get; set; }
    public bool Separeted { get; set; }
    public bool Inactive { get; set; }
    public DateTime DateLastInstallments { get; set; }
    public DateTime DateFirstInstallments { get; set; }
    public decimal Amount { get; set; }
    public int CountInstallments { get; set; }
    public string Describe { get; set; }
    public string ExpenseName { get; set; }
    public string PaymentType { get; set; }
    public decimal TotalExpensesItem { get; set; }
    public decimal TotalExpensesItemRemaining { get; set; }
    public int PayedInstallments { get; set; }
    public int RemainingInstallments { get; set; }

    // relational maps
    public int IdBank { get; set; }
    public List<PaidInstallmentsDto> paidInstallments { get; set; }
    // public void AddPaymentsToInstallments(PaidInstallmentsModel PaidInstallments)
    // {
    //     _paidInstallments.Add(PaidInstallments);
    // }

    public void SumTotalExpensesItem() =>
         TotalExpensesItem = Inactive == false ? Amount * CountInstallments : 0;

    public void SumInstallmentsAndTotalRemaning(int payedInstallments)
    {
        PayedInstallments = payedInstallments;
        RemainingInstallments = PayedInstallments > 0 ? CountInstallments - PayedInstallments : 0;

        if (!Inactive)
            TotalExpensesItemRemaining = RemainingInstallments > 0 ? TotalExpensesItem - (Amount * PayedInstallments) : TotalExpensesItem;
    }
}