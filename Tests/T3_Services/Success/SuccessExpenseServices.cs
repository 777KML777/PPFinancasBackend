using Domain.Entities.Expense;
using Domain.Interfaces;
using Service.Expense;
using Infra.Data.Repositories.Expense;

namespace Tests.Service.Success;
public class SuccessExpenseService
{
    static IExpenseService _Service = new ExpenseService();

    [Fact]
    public void CreateExpense()
    {
        // ExpenseInputModel expenseSelected = new ExpenseInputModel()
        // {
        //     IdBank = 777,
        //     Name = "Despesa De Teste",
        //     Amount = 150.00M,
        //     Inactive = true,
        //     Separeted = false,
        //     CountInstallments = 10,
        //     PaymentType = "Credito",
        //     Describe = "Despesa criada pela classe de teste SuccessExpenseService."
        // };

        ExpenseService expensesService = new();
        // expensesService.Create(expenseSelected);
    }

    [Fact]
    public void ReadExpenses()
    {
        // ExpenseInputModel expenseSelected = new ExpenseInputModel()
        // {
        //     IdBank = 777,
        //     Name = "Despesa De Teste",
        //     Amount = 150.00M,
        //     Inactive = true,
        //     Separeted = false,
        //     CountInstallments = 10,
        //     PaymentType = "Credito",
        //     Describe = "Despesa criada pela classe de teste SuccessExpenseService."
        // };

        ExpenseRepository expensesService = new();
        var x = expensesService.ReadAll<ExpenseEntityData>();
        Console.WriteLine("Teste");
    }

    // [Theory]
    // [InlineData(_Service.GetById(1))]
    [Fact]
    public void UpdateExpenses()
    {
        // ExpenseService expensesService = new();
        // var x = expensesService.GetById(1);
        // expensesService.Update(x)
        // ExpenseInputModel expenses = new ExpenseInputModel();
        // if (expensesService.Update(expenses)) // É para atualizar o banco junto das despesas?
        // Printer.PrintSuccessUpgradeEntity(new(), expenses);
        // Assert.Null();
        // Console.WriteLine(x);
    }


    [Fact]
    public void Te()
    {
        // Testar todas as propriedades
        // Cada propriedade testar com um possível valor. 
        // Testar conjuntos de propriedades. 
        // Enfim as possibilidades são enormes 
        // Não posso perder tempo com isso. 
        // Terminar logo a fatura e ir testando conforme a demanda
        // Como contabilizar o tanto de teste feito e restantes? 
        // ExpenseService expensesService = new();
        // var x = expensesService.GetById(1);
        // expensesService.Update(x)
        // ExpenseInputModel expenses = new ExpenseInputModel();
        // if (expensesService.Update(expenses)) // É para atualizar o banco junto das despesas?
        // Printer.PrintSuccessUpgradeEntity(new(), expenses);
        // Assert.Null();
        // Console.WriteLine(x);


    }
}