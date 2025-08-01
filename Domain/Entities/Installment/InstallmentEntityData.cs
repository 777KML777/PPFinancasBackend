using Domain.Entities.Expense;
using Repository.Json;

namespace Domain.Entities.Installment;

public class InstallmentEntityData : EntityData
{
    // [Obsolete("Construtor reservado para serialização", error: true)]
    public InstallmentEntityData()
    {

    }

    public int Number { get; set; }
    public int IdExpense { get; set; }
    public bool Inactive { get; set; }
    public ExpenseEntity Expense { get; set; }
    public DateTime? PaymentDate { get; set; }
    public DateTime? ExpectedDate { get; set; }
    public void AddPaymentDate()
    {
        if (IdExpense <= 0)
            throw new Exception("Não há despesa para adicionar pagamento!");

        if (Number <= 0)
            throw new Exception($"Não foi possível adicionar pagamento na {Number}ª parcela ");

        if (PaymentDate is not null)
            throw new Exception($"Parcela paga em {PaymentDate}!");

        PaymentDate = DateTime.Now;
    }

    // public void UpdatePaymentDate(DateTime newDate) =>
    //     DatePurchase = newDate; // depois validar se já existe outro pagamento com a data informada. 
    //     // Talvez a validação não fique aqui. 

    public void LinkExpense(int expenseId) =>
        IdExpense = expenseId;

}