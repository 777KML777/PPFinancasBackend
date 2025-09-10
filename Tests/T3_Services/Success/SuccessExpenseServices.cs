using Application.Models;
using Application.Services;
using Domain.Entities.Expense;

namespace Tests.Services.Success;
public class SuccessExpenseServices
{
    static IExpenseServices _services = new ExpenseServices();

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
        //     Describe = "Despesa criada pela classe de teste SuccessExpenseServices."
        // };

        ExpenseServices expensesService = new();
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
        //     Describe = "Despesa criada pela classe de teste SuccessExpenseServices."
        // };

        ExpenseRepository expensesService = new();
        var x = expensesService.ReadAll<ExpenseEntityData>();
        Console.WriteLine("Teste");
    }

    // [Theory]
    // [InlineData(_services.GetById(1))]
    [Fact]
    public void UpdateExpenses()
    {
        // ExpenseServices expensesService = new();
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
        // ExpenseServices expensesService = new();
        // var x = expensesService.GetById(1);
        // expensesService.Update(x)
        // ExpenseInputModel expenses = new ExpenseInputModel();
        // if (expensesService.Update(expenses)) // É para atualizar o banco junto das despesas?
        // Printer.PrintSuccessUpgradeEntity(new(), expenses);
        // Assert.Null();
        // Console.WriteLine(x);


    }
}