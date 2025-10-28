namespace Application.Services.Dashboard;

public class DashboardAppServices
{
    private readonly IBankServices _bankServices;
    private readonly IExpenseServices _expenseServices;
    private readonly IInstallmentServices _installmentServices;
    private readonly ITempFutureDebitsRepository _tempRepo; // Remover isso aqui

    public DashboardAppServices ()
    {
        _bankServices = new BankServices();
        _expenseServices = new ExpenseServices();
        _installmentServices = new InstallmentServices();
        _tempRepo = new TempFutureDebitsRepository();
    }

    // ITempFutureDebitsRepository _tempRepo = new TempFutureDebitsRepository();
    // IBankRepository _bankRepo = new BankRepository();
    // IExpenseRepository _expenseRepo = new ExpenseRepository();
    // IInstallmentRepository _installmentRepo = new InstallmentRepository();

    public DashboardDto DashData()
    {
        // Total de pagamentos já realizados
        // Total de todos os bancos separadamente. 
        DashboardDto dash = new ();
        List<BankDto> lstBanks = _bankServices.Read();
        List<ExpenseDto> lstExpenses = _expenseServices.Read();

        // Calculando Totais
        dash.TotalAvailableBalance = lstBanks.Sum(x => x.Balance); // Dinheiro que pode ser usado a qq momento.

        // List<InstallmentEntity> lstInstallments = _installmentServices.Read();

        // List<TempFutureDebitsEntity> lstTemp = _tempRepo.ReadAll<TempFutureDebitsEntity>().ToList();

        // O que acontece se eu tentar passar uma entidade da diferente que tem que ser mapeada? 
        // Trocar o nome de Installments para apenas Installments
        // Por isso é importante criar métodos a ordem que eu chamar aqui pouco importa. O que vai contar vai ser eu chamando o método.
        // O quanto eu evolui de um tempo para outro. 
        // Projeção

        // Totais Gerais
        // dash.TotalExpenses = lstTemp.Sum(bank => bank.Amount);

        // //Primeiro a realidade
        // dash.TotalAvailableBalance = lstBanks.Where(b => b.Available).Sum(bank => bank.Balance);
        // dash.AvailableBalance = dash.TotalAvailableBalance - dash.TotalExpenses;

        // dash.TotalBalance = lstBanks.Sum(bank => bank.Balance);
        // dash.Balance = dash.TotalBalance - dash.TotalExpenses;

        // lstExpenses.ForEach(expenseRepo =>
        //     lstBanks.ForEach(item =>
        //     {
        //         if (expenseRepo.IdBank == item.Id)
        //             item.AddExpensesToBanks(expenseRepo);

        //     })
        // );

        // Total de cada banco
        dash.Banks = lstBanks;

        // dash.Banks.ForEach(item => item.CalculateFinalBalance());

        return dash;
    }
}