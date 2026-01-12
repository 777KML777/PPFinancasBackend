namespace Application.Apps;

public class BankAppService : IBankAppService
{
    private readonly IBankService _service;
    private readonly IExtratoService _extratoService;
    private readonly IFaturaService _faturaService;
    private readonly IExpenseService _expenseService;

    public BankAppService
    (
        IBankService service,
        IExpenseService expenseService,
        IFaturaService faturaService,
        IExtratoService extratoService
    )
    {
        _service = service;
        _faturaService = faturaService;
        _extratoService = extratoService;
        _expenseService = expenseService;
    }

    public BankInputModel GetById(int id)
    {
        BankDto banco = _service.GetById(id);
        BankInputModel input = new(banco)
        {
            Fatura = _faturaService.Generate(banco)
        };

        List<Lancamento> lancamentos = new();
        List<decimal> lancamentosMensal = new();

        var testes = input.Fatura.Lancamentos.GroupBy(x => x.DataLancamento.Month);

        foreach (var agrupado in testes)
        {
            lancamentosMensal.Add(agrupado.Sum(x => x.Valor));
            // foreach (var item in agrupado)
            // {
            // }
        }

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