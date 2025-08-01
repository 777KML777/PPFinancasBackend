using Domain.Entities.Expense;

namespace Domain.Entities.Installment;

public class InstallmentEntity : Entity
{
    // [Obsolete("Construtor reservado para serialização", error: true)]
    public InstallmentEntity()
    {

    }

    public InstallmentEntity(int number, DateTime? expectedDate)
    {
        Number = number;
        ExpectedDate = expectedDate;

        // Tem que gerar pagamento se for menor que o data de pagamento do banco
        if (Convert.ToDateTime(expectedDate).Date < DateTime.Now.Date)
            PaymentDate = ExpectedDate;
    }
    new public int Id { get; private set; }
    public int Number { get; private set; }
    public bool Inactive { get; private set; }
    public int IdExpense { get; private set; }
    public DateTime? PaymentDate { get; private set; }
    public DateTime? ExpectedDate { get; private set; }
    public ExpenseEntity Expense { get; private set; }
    public void AddPaymentDate()
    {
        if (IdExpense <= 0)
            throw new Exception("Não há despesa para adicionar pagamento!");

        if (Number <= 0)
            throw new Exception($"Não foi possível adicionar pagamento na {Number}ª parcela ");

        // if (PaymentDate is not null)
        //     throw new Exception($"Parcela paga em {PaymentDate}!");

        //  
        PaymentDate = DateTime.Now;
    }

    // public void UpdatePaymentDate(DateTime newDate) =>
    //     UserPaymentDate = newDate; // depois validar se já existe outro pagamento com a data informada. 
    //     // Talvez a validação não fique aqui. 

    public void AlterInstallmentEntity
    (
       int id,
       int idExpense,
       int number,
       DateTime? expectedDate
    )
    {
        Id = id;
        IdExpense = idExpense;
        Number = number;
        ExpectedDate = expectedDate;

        // Tem que gerar pagamento se for menor que o data de pagamento do banco
        if (Convert.ToDateTime(expectedDate).Date < DateTime.Now.Date)
            PaymentDate = ExpectedDate;
    }

    // TODO: Remover esse método
    public void LinkExpense(int idExpense) => 
        IdExpense = idExpense;

}