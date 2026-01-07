using Application.Inputs;

namespace Application.Apps;

public class BankAppService : IBankAppService
{
    private readonly IBankService _service;
    private readonly IExtratoService _extratoService;
    private readonly IExpenseService _expenseService;

    public BankAppService
    (
        IBankService service,
        IExpenseService expenseService,
        IExtratoService extratoService
    )
    {
        _service = service;
        _extratoService = extratoService;
        _expenseService = expenseService;
    }

    public BankInputModel GetById(int id)
    {
        // 50% Feito. Cada objeto restante representa 20%. 
        // Terminando tudo fica 90% os outros 10% são ajustes. 

        BankDto banco = /* _service.GetById(id) */ null;
        BankInputModel input = new(banco)
        {
            Extratos = _extratoService.GetExtratosByIdBank(banco.Id),
            Expenses = _expenseService.GetExpenseByIdBank(banco.Id)
        };

        // input.FaturaDoBanco = 
        // input.Lancamentos = 

        // input.Operacao = 
        // input.DataPagamento = 

        return input;
    }
}