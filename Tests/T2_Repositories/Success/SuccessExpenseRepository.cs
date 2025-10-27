using Domain.Entities.Expense;
using Domain.Entities.Installment;
using Services.Interfaces;
using Services.Expense;
using Repository.JsonFile.Repositories.Expense;
using Services.Installment;
using Services;
using Services.Extensions;

namespace Tests.T2_Repositories.Success;

public class SuccessExpenseRepository
{
    static IExpenseServices _services = new ExpenseServices();
    static IExpenseRepository _repository = new ExpenseRepository();
    static IInstallmentRepository _installmentRepository = new InstallmentRepository();
    static IInstallmentServices _installmentServices = new InstallmentServices();

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
    public void Repository_UpdateExpense_DatePurchase()
    {
        // To See: A primeira vez que é executado parece não estar atualizando o arquivo corretamente. 

        // Informar ao usuário: 
        // Atualizar a Data De assinatura irá reprocessar as datas de pagamentos. Deseja continuar? O que é isso? 
        DateTime datePurchase = new DateTime(2025, 07, 19);
        // DateTime datePurchase = DateTime.Now;

        // TODO: O próprio sistema de tempos em tempos verificar a autenticidade dos dados

        // Atualizar apenas pelo repositório não irá recalcular tudo corretamente. 
        // Criar include no repositório. Por enquanto fica no serviço.
        // E se foi lista de pagamentos de fora? Conflitando com a que foi gerada ou a existente salva no banco. 

        // Validação para a data de pagamento não ser menor que a data da assinatura. 
        // Como perceber se o usuário desejar atualizar os pagamentos também? 
        // Talvez seria interessante receber a listadepagamentos sim. Se for null entaõ eu chamado o addpayment.

        ExpenseEntity entity = _repository.GetById<ExpenseEntityData>(14).ToEntity();
        // id 9 = Asus Celular Manuntenção.

        entity.AlterExpenseEntity
        (
            entity.Id,
            entity.IdBank,
            entity.Name + " Atualizado",
            entity.Amount,
            entity.Describe,
            entity.PaymentType,
            entity.CountInstallments,
            entity.Inactive,
            entity.Separeted,
            datePurchase,
            entity.Installments.ToList()
        );

        ExpenseEntity entityUpdated; // Ao obter o retorno as listas não vêm porque não há includes genéricos. 
        entityUpdated = _repository.Update
        (
           (ExpenseEntityData) entity.ToEntityData()
            .IncludeRange
            (
                entity.ToEntityData(),
                entity.Installments.ToList().ToListEntityData()
            )
        )
        .ToEntity();

        // pegar as leituras e testar com o pessoal da expedição. 

        // entity.ToEntityData().IncludeRange
        // (
        //    entity.ToEntityData(),
        //    entity.Installments.ToList().ToListEntityData()
        // );

        // Adicionar em Kleus. 
        // Remover _installmentRepository daqui. 
        // Remover _installmentServices daqui. 
        // Calcular a cobertura de testes. 
        // E em caso de rollback em update como é que ficaria? 

        // entity.Installments.ToList().ForEach
        // (
        //     // atualizar o que que não existe? 
        //     // Neither nenhum dos dois. 
        //     installment => _installmentRepository
        //     .Update
        //     (
        //         _installmentServices
        //         .MappingEntityToEntityData
        //         (installment)
        //     )

        // );

        // Printer.PrinterSuccessExpenseServices.UpgradeEntity(entity, new ExpenseInputModel());
        Assert.NotNull(entityUpdated);
    }
}