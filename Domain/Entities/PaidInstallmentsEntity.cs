using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class PaidInstallmentsEntity : Entity
{
    public PaidInstallmentsEntity()
    {

    }
    public DateTime PaymentDate { get; set; }

    // Relational 
    public int IdExpenses { get; set; }
    
    [NotMapped]
    public ExpensesEntity Expenses { get; set; }
}