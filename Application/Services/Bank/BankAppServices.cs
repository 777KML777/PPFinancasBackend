namespace Application.Services.Bank;

public class BankAppServices : IBankAppServices
{
    private readonly IBankServices _services;
    private readonly IExtratoServices _extratoServices; 

    public BankAppServices
    (

    )
    {
        _services = new BankServices(); 
    }

    public BankInputModel GetById(int id)
    {
        BankDto banco = _services.GetById(id);
        BankInputModel input = new(banco);

        input.Extratos = _extratoServices.GetExtratosByIdBank(banco.Id);
        // input.Expenses = 
        // input.FaturaDoBanco = 
        // input.Lancamentos = 

        // input.Operacao = 
        // input.DataPagamento = 

        return input;
    }
}