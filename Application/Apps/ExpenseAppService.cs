using Application.Inputs;
using Application.Selects;

namespace Application.Apps;

public class ExpenseAppService : IExpenseAppService
{
    private readonly IBankService _bankService;
    private readonly IExpenseService _expenseService;
    public ExpenseAppService
    (
        IBankService bankService,
        IExpenseService expenseService
    )
    {
        _bankService = bankService;
        _expenseService = expenseService;
    }

    public ExpenseAppService()
    {
    }

    public ExpenseInputModel Update(int id)
    {
        throw new NotImplementedException();
    }
    // public ExpenseEntity MappingInputModelToEntity(ExpenseInputModel obj)
    // {
    // if (obj.Id > 0)
    // {
    //     ExpenseEntity expenseEntity = new();
    //     expenseEntity.AlterExpenseEntity
    //     (
    //         obj.Id,
    //         obj.IdBank,
    //         obj.Name,
    //         obj.Amount,
    //         obj.Describe,
    //         obj.PaymentType,
    //         obj.CountInstallments,
    //         false, // TODO - rever isso aqui
    //         false, // TODO - rever isso aqui
    //         DateTime.Now, // TODO - rever isso aqui,
    //         new List<InstallmentEntity>()
    //     );

    //     return expenseEntity;
    // }
    // else
    // {
    //     ExpenseEntity expenseEntity = new
    //     (
    //         obj.Name,
    //         obj.Amount,
    //         obj.Describe,
    //         obj.PaymentType,
    //         obj.CountInstallments
    //     );

    //     return expenseEntity;
    // }

    //     return new ExpenseEntity();
    // }
    public ExpenseInputModel GetById(int id)
    {
        IEnumerable<BankSelect> selectsBank = _bankService.Read().Select(o => new BankSelect { Id = o.Id, Name = o.Name });

        return new(_expenseService.GetById(id), selectsBank);
    }

    ExpenseInputModel IExpenseAppService.Update(int id)
    {
        throw new NotImplementedException();
    }

    ExpenseInputModel IExpenseAppService.GetById(int id)
    {
        throw new NotImplementedException();
    }
}