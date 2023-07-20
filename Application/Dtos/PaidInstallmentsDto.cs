namespace Application; 

public class PaidInstallmentsDto
{
    public PaidInstallmentsDto ()
    {

    }

    public int Id { get; set; }
    public DateTime PaymentDate { get; set; }
    public int IdExpenses { get; set; }
    
}