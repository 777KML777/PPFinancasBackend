using Domain.Entities;
using Domain.Extensions;

namespace Application.Apps;

public class ExpenseAppService : IExpenseAppService
{
    private readonly IExpenseService _service;
    private readonly IBankService _bankService;
    public ExpenseAppService
    (
        IExpenseService service,
        IBankService bankService
    )
    {
        _service = service;
        _bankService = bankService;
    }

    public IEnumerable<ExpenseDto> Read()
    {
        return null;
    }
    public ExpenseDto Create(ExpenseInputModel input)
    {
        return null;
    }
    public ExpenseDto Update(ExpenseInputModel input)
    {
        // TODO: Validar o banco selecionado. 
        BankDto bank = _bankService.GetById(input.SelectedBank.Id);

        if (bank.Id > 0)
            input.Dto.Bank = bank;

        return _service.Update(input.Dto);
    }

    public ExpenseInputModel GetById(int id)
    {
        ExpenseDto dto = id.Equals(0) ? new ExpenseEntity().ToDto() : _service.GetById(id);

        IEnumerable<BankSelect> selectsBank =
            _bankService.Read()
            .OrderBy(b => b.Name)
            .Select(o => new BankSelect { Id = o.Id, Name = o.Name });

        // TODO: Caso exista um banco selecionado passar ele.
        return new(dto, null, selectsBank);
    }
}