using Application.Inputs;
using Application.Selects;

namespace Application.Apps;

public class ExpenseAppService : IExpenseAppService
{
    private readonly IExpenseService _service;
    private readonly IBankService _bankService;
    public ExpenseAppService
    (
        IBankService bankService,
        IExpenseService service
    )
    {
        _service = service;
        _bankService = bankService;
    }

    public ExpenseAppService()
    {
    }

    public ExpenseDto Update(ExpenseInputModel input)
    {
        // TODO: Validar o banco selecionado. 
        BankDto bank = _bankService.GetById(input.SelectedBank.Id);
        input.Dto.Bank = bank;

        return _service.Update(input.Dto);
    }

    public ExpenseInputModel GetById(int id)
    {

        IEnumerable<BankSelect> selectsBank =
            _bankService.Read()
            .OrderBy(b => b.Name)
            .Select(o => new BankSelect { Id = o.Id, Name = o.Name });

        return new(_service.GetById(id), null, selectsBank);
    }
}