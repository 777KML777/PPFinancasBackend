using Application.Dtos;
using Domain.Entities.Bank;
using Domain.Entities.Expense;
using Domain.Entities.Installment;
using Repository.JsonFile;
using Domain.Entities.TempFutureDebit;

namespace Application.Services;

public class DashboardServices
{

    IBankRepository _bankRepo = new BankRepository();
    IExpenseRepository _expenseRepo = new ExpenseRepository();
    IInstallmentRepository _installmentsRepo = new InstallmentRepository();
    ITempFutureDebitsRepository _tempRepo = new TempFutureDebitsRepository();
    public DashboardDto DashData()
    {
        // Total de todos os bancos separadamente. 
        DashboardDto dash = new DashboardDto();

        List<BankEntity> lstBanks = _bankRepo.ReadAll<BankEntity>().ToList();
        List<ExpenseEntity> lstExpenses = _expenseRepo.ReadAll<ExpenseEntity>().ToList();
        List<InstallmentEntity> lstInstallments = _installmentsRepo.ReadAll<InstallmentEntity>().ToList();
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