using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.VisualBasic;

namespace Domain;

public class ExpensesEntity : Entity
{
    private IList<PaidInstallmentsEntity> _paidInstallments;
    public ExpensesEntity()
    {
        _paidInstallments = new List<PaidInstallmentsEntity>();
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

/* 
    Os pagamentos em atraso após a confirmação de pagamento serão sistematizados com a data do último pagamento por padrão. 
    O usuário se quiser depois poderá atualizar a data para ficar correto. PaymentDate, SystemPaymentDate, ter um UpdatePaymentDate? 

    Quem deve verificar quantos pagamentos faltam? Entidade, repositório ou serviço?
        Se for a entidade ela terá que ser puxada com include, por conta dos pagamentos serem outra entidade.
         Caso o include não seja realizado, será impossível saber a última data de pagamento. 

    Afinal, fazer uma consulta no banco e buscar tudo de uma única vez. Ou ir por etapas? 
    Afinal, inserir no banco tudo de uma vez ou ir em parcela? Para esta eu acredito que inserir tudo de uma vez é a melhor 
     opção. 
*/