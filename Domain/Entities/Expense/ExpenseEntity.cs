using Domain.Entities.Installment;
using Domain.Entities.Bank;

namespace Domain.Entities.Expense;

/* 
    Parcelas: 
    --- ValorTotal / QtdDeParcelas 
    --- [Abordagem atual]  ValorDaParcela * QtdDeParcelas 
*/

// Na hora da criação eu posso passar os pagamentos?
public class ExpenseEntity : Entity
{
    private readonly IList<InstallmentEntity> _installments;

    public ExpenseEntity()
    {
        _installments = new List<InstallmentEntity>();
    }

    public ExpenseEntity
    (
        string name,
        decimal amount,
        string describe,
        string paymentType,
        int countInstallments,
        bool inactive = false,
        bool separated = false
    )
    {
        Name = name;
        Amount = amount;
        Inactive = inactive;
        Describe = describe;
        Separeted = separated;
        PaymentType = paymentType;
        CountInstallments = countInstallments;

        DatePurchase = DateTime.Now;

        AddInstallments();
        // Inativar automaticamente com base nas parcelas pagas. 
    }

    new public int Id { get; private set; }
    public int IdBank { get; private set; } // Método
    public string Name { get; private set; } // Passado no construtor
    public bool Inactive { get; private set; } // Passado no construtor
    public bool Separeted { get; private set; } // Passado no construtor
    public decimal Amount { get; private set; } // Passado no construtor
    public string Describe { get; private set; } // Passado no construtor
    public BankEntity Bank { get; private set; } // Entity
    public string PaymentType { get; private set; } // Passado no construtor
    public int CountInstallments { get; private set; } // Passado no construtor
    public DateTime DateLastInstallment { get; private set; } // Calculado
    public DateTime DatePurchase { get; private set; } // Usuário que atualiza
    public DateTime DateFirstInstallment { get; private set; } // Calculado
    public IReadOnlyCollection<InstallmentEntity> Installments { get { return _installments.ToArray(); } }

    private void AddInstallments()
    {
        int number = 1;
        while (number <= CountInstallments)
        {
            InstallmentEntity installment;

            if (CountInstallments > 1)
                installment = new InstallmentEntity(number, DatePurchase.AddMonths(number));
            else
                installment = new InstallmentEntity(number, DatePurchase);

            installment.LinkExpense(Id);
            _installments.Add(installment);
            number++;
        }

    }
    public decimal SumTotalExpense() =>
        Inactive == false ? Amount * CountInstallments : 0;
    public int SumPaidInstallments() =>
        Installments.Where(i => i.PaymentDate != null).Count();
    public int SumRemainingInstallments() =>
        CountInstallments - SumPaidInstallments();

    public void AlterExpenseEntity
    (
        int id,
        int idBank,
        string name,
        decimal amount,
        string describe,
        string paymentType,
        int countInstallments,
        bool inactive,
        bool separated,
        DateTime datePurchase,
        List<InstallmentEntity> installments
    )
    {
        Id = id;
        Name = name;
        IdBank = idBank;
        Amount = amount;
        Inactive = inactive;
        Describe = describe;
        Separeted = separated;
        PaymentType = paymentType;
        CountInstallments = countInstallments;
        DatePurchase = datePurchase;

        // Criar um método aqui talvez para usar isso também no construtor.
        DateFirstInstallment = CountInstallments > 1 ?
            DatePurchase.AddMonths(1) : DatePurchase;

        DateLastInstallment = CountInstallments > 1 ?
            DatePurchase.AddMonths(CountInstallments) : DatePurchase;

        // Isso aqui existe para já calcular automaticamente as parcelas
        // As parcelas existem mas vem como zero. 
        // e se eu alterei como vai funcionar? 

        // MappingEntityDataToEntity esse cara não precisa instanciar a lista. 
        // Enquanto o ReadInclude não estiver pronto eu vou ter que associar pelo serviço.
        if (installments.Count == 0)
            AddInstallments();
        // else 
        // {
        //     if (installments.Count >= Installments.Count)
        //         installments.ForEach
        //         (
        //             item =>
        //             // Installments.FirstOrDefault(x => x.Id == item.Id).Num    ber = item.Number
        //         );
        // }

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