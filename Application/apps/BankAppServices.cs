namespace Application.Apps;

public class BankAppServices : IBankAppServices
{
    private readonly IBankServices _services;
    private readonly IExtratoServices _extratoServices;
    private readonly IExpenseServices _expenseServices;

    public BankAppServices
    (
        IBankServices services,
        IExpenseServices expenseServices,
        IExtratoServices extratoServices
    )
    {
        _services = services;
        _extratoServices = extratoServices;
        _expenseServices = expenseServices;
    }

    public BankInputModel GetById(int id)
    {
        // 50% Feito. Cada objeto restante representa 20%. 
        // Terminando tudo fica 90% os outros 10% são ajustes. 

        BankDto banco = /* _services.GetById(id) */ null;
        BankInputModel input = new(banco)
        {
            Extratos = _extratoServices.GetExtratosByIdBank(banco.Id),
            Expenses = _expenseServices.GetExpenseByIdBank(banco.Id)
        };

        // input.FaturaDoBanco = 
        // input.Lancamentos = 

        // input.Operacao = 
        // input.DataPagamento = 

        return input;
    }
}