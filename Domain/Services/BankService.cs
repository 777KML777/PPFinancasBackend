using Domain.Dtos;
using Domain.Extensions;
using Domain.Interfaces;
using System.Collections.ObjectModel;

namespace Domain.Services;

public class BankService : IBankService
{
    private readonly IBankRepository _repository;
    private readonly IExpenseRepository _expenseRepository;
    public BankService
    (
        IBankRepository repository,
        IExpenseRepository expenseRepository
    )
    {
        _repository = repository;
        _expenseRepository = expenseRepository;
    }

    #region "CRUD OPERATION" 
    public IEnumerable<BankDto> Read()
    {
        ICollection<BankDto> banks = new Collection<BankDto>();

        // TODO: Substituir por um include. 
        // TODO: IList não possui .ForEach (analisar depois)
        List<BankEntity> entities = _repository.Read().ToList();
        entities.ForEach(b =>
        {
            _expenseRepository.GetAllByIdBank(b.Id)
            .ToList()
            .ForEach
            (
                e => b.AddExpensesToBanks(e)
            );

            banks.Add(b.ToDto());
        });

        return banks;
    }

    #endregion 

    #region "COMMOM OPERATIONS"
    public BankDto GetById(int id)
    {
        // TODO: Talvez eu não precisaria enviar o BankDto por já ter lá na WEB.
        // TODO: Codigo de simulação de include está duplicado... 
        // TODO: Distinguir os tipos de movimentações. 


        // TODO: Substituir por um include. 


        BankEntity bank = /* _repository.GetById<BankEntityData>(id).ToEntity() */ new();
        // List<ExpenseEntity> expenses = _expenseRepository.GetAllByIdBank(bank.Id).ToListEntity();

        // if (expenses.Any())
        //     expenses.ForEach(bank.AddExpensesToBanks);

        // Sim o repositório tem que trazer aqui a lista dos pagamentos na própria entidade que representa 
        // // o banco de dados


        // bank.Extratos = _extratoService
        //     .GetExtratosByIdBank(bank.Id);

        // // if (include)
        // // {
        // bank.Expenses = _expenseService.GetExpenseByIdBank(bank.Id);
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
        // List<InstallmentDto> installments = _installmentService.Read();

        // bank.Expenses
        // .ForEach
        // (
        //     expense => installments.Where(i => i.IdExpense == expense.Id).ToList()
        //     .ForEach
        //     (
        //         expense.Installments.Add
        //     )
        // );

        // var xu = _installmentService.Read()
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

        // return bank.ToDto();

        return null;
    }

    //Para ser sincero Serialização tem que ficar aqui
    #endregion

    #region "SPECIFIC OPERATIONS"
    // public List<BankSelect> GetDataList()
    // {
    //     List<BankSelect> BankSelects = new();

    //     // var banks = _repository.ReadAll<BankEntityData>().Select(bank => new { bank.Id, bank.Name }).ToList();
    //     // banks.ForEach(item => BankSelects.Add(new() { Id = item.Id, Name = item.Name }));

    //     return BankSelects;
    // }

    public bool Delete(int identifier)
    {
        throw new NotImplementedException();
    }

    BankDto IService<BankDto, BankEntity>.GetById(int identifier)
    {
        throw new NotImplementedException();
    }

    public BankDto Create(BankDto dto)
    {
        throw new NotImplementedException();
    }

    public BankDto Update(BankDto dto)
    {
        throw new NotImplementedException();
    }

    #endregion

}