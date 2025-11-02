using Services.Extrato;

namespace Application.Services.Bank;

public class BankAppServices : IBankAppServices
{
    private readonly IBankServices _services;
    private readonly IExtratoServices _extratoServices;
    private readonly IExpenseServices _expenseServices;

    public BankAppServices
    (

    )
    {
        _services = new BankServices();
        _extratoServices = new ExtratoServices();
        _expenseServices = new ExpenseServices();
    }

    public BankInputModel GetById(int id)
    {
        // 50% Feito. Cada objeto restante representa 20%. 
        // Terminando tudo fica 90% os outros 10% são ajustes. 

        BankDto banco = _services.GetById(id);
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