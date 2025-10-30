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

        dash.Banks = lstBanks;

        // Despesas ativas são despesas que não tem todos os pagamentos efetuados. 
        // Por padrão as despesas que não tem prazo de validade serão incrementadas com base nos meses restantes do ano. 
        // O que irá auxiliar no cálculo será a DataCriacao. A despesa irá se recalcular com base nessa informação. 
        // Movimentações depende do extrato. 
        
        // Saldo final tem que desconsiderar os pagamentos efetuados. 

        // E sobre o dinheiro assegurado? 

        // Eu tenho que mostrar o saldo final do banco. 
        

        // Calculando Totais
        dash.TotalAvailableBalance = lstBanks.Where(x => x.Available).Sum(x => x.Balance); // Dinheiro que pode ser usado a qq momento.
        dash.TotalExpenses = lstExpenses.Sum(x => x.TotalExpense);
        dash.TotalBalance = lstBanks.Sum(x => x.Balance);
        dash.Balance = dash.TotalBalance - dash.TotalExpenses;
        dash.AvailableBalance = dash.TotalAvailableBalance - dash.TotalExpenses;

        // List<InstallmentEntity> lstInstallments = _installmentServices.Read();

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