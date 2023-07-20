using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class ExpensesEntity : Entity
{
    private IList<PaidInstallmentsEntity> _paidInstallments;
    public ExpensesEntity()
    {
        _paidInstallments = new List<PaidInstallmentsEntity>();
        //AddPaymentsToInstallments();
    }

    public bool Separeted { get; set; }
    public bool Inactive { get; set; }
    public DateTime DateLastInstallments { get; set; }
    public DateTime DateFirstInstallments { get; set; }
    public decimal Amount { get; set; }
    public int CountInstallments { get; set; }
    public string Describe { get; set; }
    public string ExpenseName { get; set; }
    public string PaymentType { get; set; }

    public IReadOnlyCollection<PaidInstallmentsEntity> PaidInstallments { get { return _paidInstallments.ToArray(); } }
    // Not Mapped Properties

    [NotMapped]
    public decimal TotalExpensesItem { get; set; }
    [NotMapped]
    public decimal TotalExpensesItemRemaining { get; set; }
    [NotMapped]
    public int PayedInstallments { get; set; }
    [NotMapped]
    public int RemainingInstallments { get; set; }

    // relational maps
    public int IdBank { get; set; }
    public BankEntity Bank { get; set; }


    // Methods
    public void AddPaymentsToInstallments(PaidInstallmentsEntity PaidInstallments)
    {
        _paidInstallments.Add(PaidInstallments);
    }

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