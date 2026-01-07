namespace Application.Apps;

public class DashboardAppService : IDashboardAppService
{
    private readonly IBankService _bankService;
    private readonly IExpenseService _expenseService;
    private readonly IInstallmentService _installmentService;

    // TODO: Remover esse ITempFutureDebitsRepository
    private readonly ITempFutureDebitsRepository _tempRepo; 

    public DashboardAppService
    (
        IBankService bankService,
        IExpenseService expenseService,
        ITempFutureDebitsRepository tempRepo,
        IInstallmentService installmentService
    )
    {
        _bankService = bankService;
        _expenseService = expenseService;
        _installmentService = installmentService;
        _tempRepo = tempRepo;
    }
    public DashboardDto DashData()
    {
        // Total de pagamentos já realizados
        // Quantoas pagamentos são feitas por mês. 
        // Total de todos os bancos separadamente. 

        DashboardDto dash = new();
        IEnumerable<BankDto> lstBanks = _bankService.Read();
        // List<ExpenseDto> lstExpenses = _expenseService.Read();

        dash.Banks = lstBanks.ToList();

        // Despesas ativas são despesas que não tem todos os pagamentos efetuados. 
        // Por padrão as despesas que não tem prazo de validade serão incrementadas com base nos meses restantes do ano. 
        // O que irá auxiliar no cálculo será a DataCriacao. A despesa irá se recalcular com base nessa informação. 
        // Movimentações depende do extrato. 

        // Saldo final tem que desconsiderar os pagamentos efetuados. 

        // E sobre o dinheiro assegurado? 

        // Eu tenho que mostrar o saldo final do banco. 


        // Calculando Totais
        // dash.TotalAvailableBalance = lstBanks.Where(x => x.Available).Sum(x => x.Balance); // Dinheiro que pode ser usado a qq momento.
        // dash.TotalExpenses = lstExpenses.Sum(x => x.TotalExpense);
        // dash.TotalBalance = lstBanks.Sum(x => x.Balance);
        // dash.Balance = dash.TotalBalance - dash.TotalExpenses;
        // dash.AvailableBalance = dash.TotalAvailableBalance - dash.TotalExpenses;

        // List<InstallmentEntity> lstInstallments = _installmentService.Read();

        // List<TempFutureDebitsEntity> lstTemp = _tempRepo.ReadAll<TempFutureDebitsEntity>().ToList();

        // O que acontece se eu tentar passar uma entidade da diferente que tem que ser mapeada? 
        // Trocar o nome de Installments para apenas Installments
        // Por isso é importante criar métodos a ordem que eu chamar aqui pouco importa. O que vai contar vai ser eu chamando o método.
        // O quanto eu evolui de um tempo para outro. 
        // Projeção


        // lstExpenses.ForEach(expenseRepo =>
        //     lstBanks.ForEach(item =>
        //     {
        //         if (expenseRepo.IdBank == item.Id)
        //             item.AddExpensesToBanks(expenseRepo);

        //     })
        // );

        // Total de cada banco

        // dash.Banks.ForEach(item => item.CalculateFinalBalance());

        return dash;
    }
}