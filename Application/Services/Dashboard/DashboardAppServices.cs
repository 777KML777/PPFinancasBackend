using Services.Dtos;
using Domain.Entities.Bank;
using Domain.Entities.Expense;
using Domain.Entities.Installment;
using Repository.JsonFile;
using Domain.Entities.TempFutureDebit;
using Repository.JsonFile.Repositories.Bank;
using Services.Installment;
using Services.Expense;

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

    IInstallmentServices 
    // ITempFutureDebitsRepository _tempRepo = new TempFutureDebitsRepository();
    // IBankRepository _bankRepo = new BankRepository();
    // IExpenseRepository _expenseRepo = new ExpenseRepository();
    // IInstallmentRepository _installmentRepo = new InstallmentRepository();
    ITempFutureDebitsRepository 


    public DashboardDto DashData()
    {
        // Total de todos os bancos separadamente. 
        DashboardDto dash = new ();

        // Só chamar os respectivos MappingList
        List<BankEntity> lstBanks = _bankServices.Read();
        _bankServices.MappingListEntityDataToListEntity
        (
            _bankRepo.ReadAll<BankEntityData>().ToList()
        );

        List<ExpenseEntity> lstExpenses =
        _expenseServices.MappingListEntityDataToListEntity
        (
            _expenseRepo.ReadAll<ExpenseEntityData>().ToList()

        );

        List<InstallmentEntity> lstInstallments =
        _installmentServices.MappingListEntityDataToListEntity
        (
            _installmentRepo.ReadAll<InstallmentEntityData>().ToList()
        );
        
        List<TempFutureDebitsEntity> lstTemp = _tempRepo.ReadAll<TempFutureDebitsEntity>().ToList();

        // O que acontece se eu tentar passar uma entidade da diferente que tem que ser mapeada? 
        // Trocar o nome de Installments para apenas Installments
        // Por isso é importante criar métodos a ordem que eu chamar aqui pouco importa. O que vai contar vai ser eu chamando o método.
        // O quanto eu evolui de um tempo para outro. 
        // Projeção

        // Totais Gerais
        dash.TotalExpenses = lstTemp.Sum(bank => bank.Amount);

        //Primeiro a realidade
        dash.TotalAvailableBalance = lstBanks.Where(b => b.Available).Sum(bank => bank.Balance);
        dash.AvailableBalance = dash.TotalAvailableBalance - dash.TotalExpenses;

        dash.TotalBalance = lstBanks.Sum(bank => bank.Balance);
        dash.Balance = dash.TotalBalance - dash.TotalExpenses;

        lstExpenses.ForEach(expenseRepo =>
            lstBanks.ForEach(item =>
            {
                if (expenseRepo.IdBank == item.Id)
                    item.AddExpensesToBanks(expenseRepo);

            })
        );

        // Total de cada banco
        lstBanks.ForEach(item =>
            dash.Banks.Add(new BankDto
            {
                Id = item.Id,
                Name = item.Name,
                Balance = item.Balance,
                CountExpenses = item.Expenses.Count(),
                TotalExpenses = item.Expenses.Sum(x => x.Amount * x.CountInstallments),
            })
        );

        dash.Banks.ForEach(item => item.CalculateFinalBalance());

        return dash;
    }
}