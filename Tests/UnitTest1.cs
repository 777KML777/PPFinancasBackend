using System.Diagnostics;
using Application.Services;
using Services.Dtos;
using Domain.Entities.Installment;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Xunit.Abstractions;
using Domain.Entities.Expense;

namespace Tests;

public class UnitTest1
{
    [Fact]
    public void VerifyLatePayment()
    {
        ExpenseServices _services = new ExpenseServices();
        IExpenseRepository repository = new ExpenseRepository();
        ExpenseEntity case1 = _services.MappingEntityDataToEntity
        (
            repository.GetById<ExpenseEntityData>(15)
        );

        IInstallmentRepository _installmentRepository = new InstallmentRepository();
        var Installments = _installmentRepository.GetAllPaidByIdExpenses(15);

        bool isSameName = case1.Name == "Pump 10" ? true : false;
        Assert.False(isSameName, $"{case1.Name}");

        string content = $"Nome: {case1.Name} \n Qtd Total: {case1.CountInstallments} \n Qtd Paga {Installments.Count}";

        Console.Clear();
        Console.WriteLine("TESTANDO ESSA PORRA! É HOJE QUE SAI ESSE SISTEMA");

        File.WriteAllText("/Users/klebermirandalima/Projetos/PPFinancasBackend/Tests/teste.txt", content);


        // Olhar para a última data de pagamento 
        // Olhar para o mês atual 
        // Olha para a data de assinatura e inclusive trocar o DateFirstInstallments do ExpenseEntity para DateSubscription
        // Qual seria o retorno do teste
    }

    [Fact]
    public void Dashboard()
    {
        DashboardServices dashboardService = new();
        DashboardDto dashboard = new();

        dashboard = dashboardService.DashData();

        ImprimirDashboard(dashboard);
    }

    void ImprimirDashboard(DashboardDto dashboard)
    {
        string content = $"TOTAIS GERAIS";
        content = content.Insert(content.Length, "\nREALIDADE:");
        content = content.Insert(content.Length, "\nTotal Disponível: ");
        content = content.Insert(content.Length, $"{dashboard.TotalAvailableBalance}");
        content = content.Insert(content.Length, "\nTotal Despesas: ");
        content = content.Insert(content.Length, $"{dashboard.TotalExpenses}");
        content = content.Insert(content.Length, "\nSaldo Disponível: ");
        content = content.Insert(content.Length, $"{dashboard.AvailableBalance}");
        content = content.Insert(content.Length, "\n==================================================");

        content = content.Insert(content.Length, "\nTotal Não Disponível (FGTS): ");
        content = content.Insert(content.Length, $"{dashboard.TotalBalance}");
        content = content.Insert(content.Length, "\nSaldo Não Disponível (FGTS): ");
        content = content.Insert(content.Length, $"{dashboard.Balance}");
        content = content.Insert(content.Length, "\nQTD Total Despesas: ");
        content = content.Insert(content.Length, $"{dashboard.TotalCountExpenses}");
        content = content.Insert(content.Length, "\n==================================================");

        File.WriteAllText("/Users/klebermirandalima/Projetos/PPFinancasBackend/Tests/dash.txt", content);
    }

    [Fact]
    public void CreateInstallments()
    {
        ExpenseServices _services = new ExpenseServices();
        IExpenseRepository repository = new ExpenseRepository();
        ExpenseEntity case1 = _services.MappingEntityDataToEntity
        (
            repository.GetById<ExpenseEntityData>(15)
        );

        IInstallmentRepository _installmentRepository = new InstallmentRepository();
        var Installments = _installmentRepository.GetAllPaidByIdExpenses(15);

        bool isSameName = case1.Name == "Pump 10" ? true : false;
        Assert.False(isSameName, $"{case1.Name}");

        string content = $"Nome: {case1.Name} \n Qtd Total: {case1.CountInstallments} \n Qtd Paga {Installments.Count}";

        Console.Clear();
        Console.WriteLine("TESTANDO ESSA PORRA! É HOJE QUE SAI ESSE SISTEMA");

        File.WriteAllText("/Users/klebermirandalima/Projetos/PPFinancasBackend/Tests/teste.txt", content);


        // Olhar para a última data de pagamento 
        // Olhar para o mês atual 
        // Olha para a data de assinatura e inclusive trocar o DateFirstInstallments do ExpenseEntity para DateSubscription
        // Qual seria o retorno do teste
    }

}