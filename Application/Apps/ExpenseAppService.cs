using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
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

    private BankDto BankValidate(int id) => _bankService.GetById(id);
    public ExpenseDto Create(ExpenseInputModel input)
    {
        input.Dto.Bank = BankValidate(input.SelectedBank.Id);
        return _service.Create(input.Dto);
    }
    public ExpenseDto Update(ExpenseInputModel input)
    {
        input.Dto.Bank = BankValidate(input.SelectedBank.Id);
        return _service.Update(input.Dto);
    }

    public ExpenseInputModel GetById(int id)
    {
        ExpenseDto dto = id.Equals(0) ? new ExpenseEntity().ToDto() : _service.GetById(id);

        // Banks
        IEnumerable<BankSelect> selectsBank =
            _bankService.Read()
            .OrderBy(b => b.Name)
            .Select(o => new BankSelect { Id = o.Id, Name = o.Name });
        BankSelect? bankSelected = selectsBank.FirstOrDefault(b => b.Id.Equals(dto.IdBank));

        // Payments
        IEnumerable<string> paymentTypes = new List<string>()
        {
            EPaymentType.Boleto.ToString(),
            EPaymentType.Credito.ToString(),
            EPaymentType.Debito.ToString(),
            EPaymentType.Pix.ToString()
        };
        string selectedPaymentType = dto.PaymentType?.ToString() ?? "";

        return new(dto, bankSelected ?? new(), selectsBank, paymentTypes);
    }
}