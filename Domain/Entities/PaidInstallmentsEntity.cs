namespace Domain;

public class PaidInstallmentsEntity : Entity
{
    public PaidInstallmentsEntity()
    {

    }

    public DateTime PaymentDate { get; set; }

    // Relational 
    public int IdExpenses { get; set; }
    public ExpensesEntity Expenses { get; set; }
}