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