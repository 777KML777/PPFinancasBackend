using System.Diagnostics;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Xunit.Abstractions;

namespace Tests;

public class UnitTest1
{
    [Fact]
    public void VerifyLatePayment()
    {
        IExpensesRepository repository = new ExpensesRepository();
        ExpensesEntity case1 = repository.GetById(15);

        IPaidInstallmentsRepository _paidInstallmentsRepository = new PaidInstallmentsRepository(); 
        var paidInstallments = _paidInstallmentsRepository.GetAllPaidByIdExpenses(15);

        bool isSameName = case1.ExpenseName == "Pump 10" ? true : false;
        Assert.False(isSameName, $"{case1.ExpenseName}");

        string content = $"Nome: {case1.ExpenseName} \n Qtd Total: {case1.CountInstallments} \n Qtd Paga {paidInstallments.Count}";

        File.WriteAllText("/Users/klebermirandalima/Projetos/teste.txt", content);

        // Olhar para a última data de pagamento 
        // Olhar para o mês atual 
        // Olha para a data de assinatura e inclusive trocar o DateFirstInstallments do ExpenseEntity para DateSubscription
        // Qual seria o retorno do teste
    }
}