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

        BankDto banco = _service.GetById(id); 
        BankInputModel input = new(banco)
        {
            // Extratos = _extratoService.GetExtratosByIdBank(banco.Id),
        };

        // input.FaturaDoBanco = 
        // input.Lancamentos = 

        // input.Operacao = 
        // input.DataPagamento = 

        return input;
    }

    // public BankDto Update(BankInputModel input)
    // {
    //     BankEntity entity = /* _repository.GetById<BankEntityData>(input.Banco.Id).ToEntity() */ new();

    //     // Por decisão é interessante retornar o input model e receber. 

    //     entity.AlterBankEntity
    //     (
    //         input.Banco.Id,
    //         input.Banco.Name,
    //         input.Banco.Balance,
    //         10, //input.PaymentDay,
    //         true, //input.Available,
    //         (EOperacao)Enum.Parse(typeof(EOperacao), /* input.Operacao */ "")
    //     );

    //     // Chamar serviço de criar extrato. 
    //     var extrato =
    //         entity.Extrato
    //             .MaxBy(ext => ext.DataTransacaoSistema);

    //     //TODO: O ideal é chamar o include 
    //     //TODO: Ver no teste como que se usa ele
    //     //TODO: Talvez eu devesso usar async aqui. 

    //     // if (extrato != null)
    //     //     _extratoService.Create
    //     //     (
    //     //         new ExtratoInputModel
    //     //         {
    //     //             IdBank = extrato.IdBank,
    //     //             Operacao = extrato.Operacao.ToString(),
    //     //             SaldoDoDia = extrato.SaldoDoDia,
    //     //             SaldoAnterior = extrato.SaldoAnterior,
    //     //             ValorTransacao = extrato.ValorTransacao,
    //     //             DataUsuarioAlteracao = extrato.DataUsuarioAlteracao,
    //     //             DataTransacaoSistema = extrato.DataTransacaoSistema,
    //     //         }
    //     //     );


    //     // include no próprio parâmetro, sei lá. 
    //     // _repository.Update
    //     // (
    //     //     MappingEntityToEntityData(entity)

    //     // ).IncludeRange
    //     // (
    //     //     MappingEntityToEntityData(entity),
    //     //     _extratoService.MappingListEntityToListEntityData
    //     //     (
    //     //         entity.Extrato
    //     //     )
    //     // );

    //     //  _Service.MappingEntityToEntityData(entity),
    //     //             _installmentService.MappingListEntityToListEntityData(entity.Installments.ToList())

    //     // Eu teria que retornar um bank dto. A princípio 
    //     // eu vou fazer por aqui mesmo. 

    //     throw new NotImplementedException();
    // }

}