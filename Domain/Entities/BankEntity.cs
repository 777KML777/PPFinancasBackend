namespace Domain.Entities;

public class BankEntity : Entity
{
    private IList<ExpenseEntity> _expenses = new List<ExpenseEntity>();

    public BankEntity()
    {
        // cadastrar cartão
    }

    public BankEntity
    (
        string name,
        decimal balance,
        int paymentDay,
        bool available = true

    )
    {
        Name = name;
        Balance = balance;
        Available = available;
        PaymentDay = paymentDay;
    }

    public string Name { get; private set; }
    public string Image { get; private set; }
    public int PaymentDay { get; private set; }
    public bool Available { get; private set; }
    public decimal Balance { get; private set; }

    public decimal TotalExpenses() =>
        Expenses.Where(x => !x.Inactive).Sum(x => x.SumTotalExpense());

    // TODO: Passar por parâmetro o PaymentType
    public decimal TotalByPaymentType(EPaymentType ept, bool currentlyMonth = false)
    {
        decimal total = 0;

        if (currentlyMonth)
            total = Expenses.Where(x => !x.Inactive
            && x.PaymentType.Equals(ept.ToString())
            && x.CountRemainingInstallments() > 0) // Talvez seja necessário senão inativar automaticamente. Replicar embaixo.
            .Sum(x => x.Amount);

        else
            total = Expenses.Where(x => !x.Inactive && x.PaymentType.Equals(ept.ToString())).Sum(x => x.SumTotalRemainingExpense());

        return total;
    }


    public decimal LiquidedBalance() =>
        Balance - TotalExpenses();
    public List<ExtratoEntity> Extrato = new();
    public IReadOnlyCollection<ExpenseEntity> Expenses { get { return _expenses.ToArray(); } }

    public void GerarExtrato(EOperacao operacao, decimal valorTransacao)
    {
        ExtratoEntity extrato = new
        (
            operacao,
            Balance,
            valorTransacao
        );
        extrato.LinkedIdBank(Id);

        Extrato.Add(extrato);
    }
    public void AddExpensesToBanks(ExpenseEntity expenses) =>
        _expenses.Add(expenses);

    public void AlterBankEntity
    (
        int id,
        string name,
        decimal balance,
        int paymentDay,
        bool available = true,
        string image = "",
        EOperacao operacao = EOperacao.NENHUMA

    )
    {
        Id = id;
        Name = name;
        Image = image;
        Available = available;
        PaymentDay = paymentDay;

        if (operacao == EOperacao.NENHUMA)
            Balance = balance;
        else
        {
            GerarExtrato(operacao, balance);
            Balance += balance;
        }
    }
}