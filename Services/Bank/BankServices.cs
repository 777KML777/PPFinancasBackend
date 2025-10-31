namespace Services.Bank;

public class BankServices : IBankServices
{
    private readonly IBankRepository _repository;
    private readonly IExpenseRepository _expenseRepository;
    public BankServices()
    {
        _repository = new BankRepository();
        _expenseRepository = new ExpenseRepository();
    }

    #region "CRUD OPERATION" 
    public BankDto Create(BankInputModel input)
    {
        throw new NotImplementedException();
    }

    public List<BankDto> Read(bool inactived = false)
    {
        List<BankEntity> banks = _repository.ReadAll<BankEntityData>().ToList().ToListEntity();

        // TODO: Substituir por um include. 
        banks.ForEach(b =>
        {
            _expenseRepository.GetAllByIdBank(b.Id).ForEach(e => b.AddExpensesToBanks(e.ToEntity()));

        });

        return banks.ToListDto();
    }

    public BankDto Update(BankInputModel input)
    {
        BankEntity entity = _repository.GetById<BankEntityData>(input.Banco.Id).ToEntity();

        // Por decisão é interessante retornar o input model e receber. 

        entity.AlterBankEntity
        (
            input.Banco.Id,
            input.Banco.Name,
            input.Banco.Balance,
            10, //input.PaymentDay,
            true, //input.Available,
            (EOperacao)Enum.Parse(typeof(EOperacao), /* input.Operacao */ "")
        );

        // Chamar serviço de criar extrato. 
        var extrato =
            entity.Extrato
                .MaxBy(ext => ext.DataTransacaoSistema);

        //TODO: O ideal é chamar o include 
        //TODO: Ver no teste como que se usa ele
        //TODO: Talvez eu devesso usar async aqui. 

        // if (extrato != null)
        //     _extratoServices.Create
        //     (
        //         new ExtratoInputModel
        //         {
        //             IdBank = extrato.IdBank,
        //             Operacao = extrato.Operacao.ToString(),
        //             SaldoDoDia = extrato.SaldoDoDia,
        //             SaldoAnterior = extrato.SaldoAnterior,
        //             ValorTransacao = extrato.ValorTransacao,
        //             DataUsuarioAlteracao = extrato.DataUsuarioAlteracao,
        //             DataTransacaoSistema = extrato.DataTransacaoSistema,
        //         }
        //     );


        // include no próprio parâmetro, sei lá. 
        // _repository.Update
        // (
        //     MappingEntityToEntityData(entity)

        // ).IncludeRange
        // (
        //     MappingEntityToEntityData(entity),
        //     _extratoServices.MappingListEntityToListEntityData
        //     (
        //         entity.Extrato
        //     )
        // );

        //  _services.MappingEntityToEntityData(entity),
        //             _installmentServices.MappingListEntityToListEntityData(entity.Installments.ToList())

        // Eu teria que retornar um bank dto. A princípio 
        // eu vou fazer por aqui mesmo. 

        throw new NotImplementedException();
    }

    public bool Delete(BankInputModel dto) =>
        throw new NotImplementedException();
    #endregion 

    #region "COMMOM OPERATIONS"
    public BankDto GetById(int id)
    {
        // TODO: Talvez eu não precisaria enviar o BankDto por já ter lá na WEB.
        // TODO: Codigo de simulação de include está duplicado... 
        // TODO: Distinguir os tipos de movimentações. 


        // TODO: Substituir por um include. 


        BankEntity bank = _repository.GetById<BankEntityData>(id).ToEntity();
        List<ExpenseEntity> expenses = _expenseRepository.GetAllByIdBank(bank.Id).ToListEntity();

        if (expenses.Any())
            expenses.ForEach(bank.AddExpensesToBanks);

        // Sim o repositório tem que trazer aqui a lista dos pagamentos na própria entidade que representa 
        // // o banco de dados


        // bank.Extratos = _extratoServices
        //     .GetExtratosByIdBank(bank.Id);

        // // if (include)
        // // {
        // bank.Expenses = _expenseServices.GetExpenseByIdBank(bank.Id);
        // // Aqui para simular o funcionamento correto eu tenho que adicionar essas despesas do banco ao Installment da entidade da linha 
        // // 46 que não existe ainda. Mesmo aqui não sendo um updtate da despesa. 

        // // O cálculo a seguir foi histórico
        // bank.FaturaDoBanco.MenorDataFatura = bank.Expenses.Min(dt => dt.DatePurchase);
        // bank.FaturaDoBanco.MaiorDataFatura = bank.Expenses.Max(dt => dt.DateLastInstallments);

        // var dataTeste = bank.FaturaDoBanco.MenorDataFatura.AddMonths(1);

        // bank.DataPagamento = new DateTime
        // (
        //     bank.FaturaDoBanco.MenorDataFatura.Year,
        //     bank.FaturaDoBanco.MenorDataFatura.Month,
        //     10
        // );

        // // Todo os pagamentos feito antes do dia 10. Vai constar na fatura atual. 
        // // e após? Irá depender da forma de pagamento? Não. 

        // var diferencaAnual = bank.FaturaDoBanco.MaiorDataFatura.Year - bank.FaturaDoBanco.MenorDataFatura.Year;
        // var diferencaMensal = bank.FaturaDoBanco.MaiorDataFatura.Month - bank.FaturaDoBanco.MenorDataFatura.Month;


        // if (diferencaAnual >= 0)
        //     bank.FaturaDoBanco.TotalDeFaturas = (12 * diferencaAnual) + diferencaMensal;
        // else
        //     bank.FaturaDoBanco.TotalDeFaturas = 0;

        // int iteracao = 0;

        // // TODO: Implementar Read Include
        // List<InstallmentDto> installments = _installmentServices.Read();

        // bank.Expenses
        // .ForEach
        // (
        //     expense => installments.Where(i => i.IdExpense == expense.Id).ToList()
        //     .ForEach
        //     (
        //         expense.Installments.Add
        //     )
        // );

        // var xu = _installmentServices.Read()
        //     .Where(e => e.ExpectedDate <= bank.DataPagamento.AddMonths(iteracao))
        //     .ToList();

        // while (iteracao <= bank.FaturaDoBanco.TotalDeFaturas)
        // {

        //     bank.Expenses.ForEach
        //     (
        //         expense =>
        //         {
        //             if (iteracao == 0)
        //             {
        //                 expense.Installments
        //                                        .Where
        //                                        (
        //                                            e => Convert.ToDateTime(e.ExpectedDate).Date <=
        //                                             bank.DataPagamento.AddMonths(iteracao)
        //                                        )
        //                                        .ToList()
        //                                        .ForEach
        //                                        (
        //                                            item => bank.FaturaDoBanco.Faturas.Add
        //                                            (
        //                                                new BankDto.FaturaDto
        //                                                {
        //                                                    IdExpense = expense.Id,
        //                                                    DataCompra = Convert.ToDateTime(item.ExpectedDate),
        //                                                    Nome = expense.Name,
        //                                                    NumeroParcela = item.Number,
        //                                                    QuantidadeTotalParcelas = expense.CountInstallments,
        //                                                    ValorParcela = expense.Amount,
        //                                                    MesLancamento = iteracao + 1
        //                                                }
        //                                            )
        //                                        );
        //             }

        //             else
        //             {
        //                 var dataAnterior = bank.DataPagamento.AddMonths(iteracao - 1);

        //                 expense.Installments
        //                                        .Where
        //                                        (
        //                                            e => Convert.ToDateTime(e.ExpectedDate).Date <= bank.DataPagamento.AddMonths(iteracao).Date && Convert.ToDateTime(e.ExpectedDate).Date >= dataAnterior.Date
        //                                        )
        //                                        .ToList()
        //                                        .ForEach
        //                                        (
        //                                            item => bank.FaturaDoBanco.Faturas.Add
        //                                            (
        //                                                new BankDto.FaturaDto
        //                                                {
        //                                                    IdExpense = expense.Id,
        //                                                    DataCompra = Convert.ToDateTime(item.ExpectedDate),
        //                                                    Nome = expense.Name,
        //                                                    NumeroParcela = item.Number,
        //                                                    QuantidadeTotalParcelas = expense.CountInstallments,
        //                                                    ValorParcela = expense.Amount,
        //                                                    MesLancamento = iteracao + 1
        //                                                }
        //                                            )
        //                                        );
        //             }

        //         }
        //     );

        //     iteracao++;

        // }
        // //     // TODO: Posso mostrar quantos por cento da fatura está paga.
        // //     // TODO: Exibir o número de parcelas restantes? 
        // //     // TODO: Mês anterior ao atual já é em atraso. 
        // //     // TODO: Antes disso e no mesmo mês do ano é em aberto
        // //     // TODO: Passa do dia 10 é fatura em atraso
        // //     // TODO: Desenvolver recursos para o sistema ir se consertando

        // // }

        // bank.CalculaLancamento();

        return bank.ToDto();
    }

    //Para ser sincero Serialização tem que ficar aqui
    #endregion

    #region "SPECIFIC OPERATIONS"
    public List<BankDataList> GetDataList()
    {
        List<BankDataList> bankDataLists = new();

        var banks = _repository.ReadAll<BankEntityData>().Select(bank => new { bank.Id, bank.Name }).ToList();
        banks.ForEach(item => bankDataLists.Add(new() { Id = item.Id, Name = item.Name }));

        return bankDataLists;
    }

    #endregion

}