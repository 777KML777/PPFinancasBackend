using Application.Dtos;
using Application.Models;
using Domain.Entities.Bank;
using Repository.JsonFile;

namespace Application.Services;

public class BankServices : IBankServices
{
    private readonly IBankRepository _bankRepository;
    private readonly IExpenseServices _expenseServices;
    private readonly IInstallmentServices _installmentServices;
    public BankServices()
    {
        _bankRepository = new BankRepository();
        _expenseServices = new ExpenseServices();
        _installmentServices = new InstallmentService();
    }

    public bool Create(BankInputModel obj, bool include = false) => false;
    // _bankRepository.Create(MappingInputModelToEntity(obj));
    public List<BankDto> Read(bool include = false)
    {
        var lstBanks = new List<BankDto>();
        var teste = _bankRepository.ReadAll<BankEntity>();

        _bankRepository.ReadAll<BankEntity>()
            .ToList()
            .ForEach(x => lstBanks.Add(
                new BankDto { Id = x.Id, Name = x.Name }
            )); // Passaria por parâmetro.

        return lstBanks;

        // public List<BankInputModel> GetAllBanks => 
        //     new List<BankInputModel>() {  new BankInputModel { Id = _bankRepository.ReadAll().Select(x => x.Id).ToList()[0]}};
        // new List<BankInputModel>() {  _bankRepository.ReadAll().ToList().ForEach(x => new BankInputModel {Id = x.Id}) };
    }

    public BankDto GetById(int id, bool include = false)
    {
        // Sim o repositório tem que trazer aqui a lista dos pagamentos na própria entidade que representa 
        // o banco de dados
        BankDto bank = MappingEntityToDto
        (
            MappingEntityDataToEntity
            (
                _bankRepository.GetById<BankEntityData>(id)
            )
        ) ?? throw new Exception($"Nenhum banco com o Id {id} encontrado!");
        
        if (include)
        {
            bank.Expenses = _expenseServices.GetExpenseByIdBank(bank.Id);
            // Aqui para simular o funcionamento correto eu tenho que adicionar essas despesas do banco ao Installment da entidade da linha 
            // 46 que não existe ainda. Mesmo aqui não sendo um updtate da despesa. 

            // O cálculo a seguir foi histórico
            bank.FaturaDoBanco.MenorDataFatura = bank.Expenses.Min(dt => dt.DatePurchase);
            bank.FaturaDoBanco.MaiorDataFatura = bank.Expenses.Max(dt => dt.DateLastInstallments);

            var dataTeste = bank.FaturaDoBanco.MenorDataFatura.AddMonths(1);

            bank.DataPagamento = new DateTime
            (
                bank.FaturaDoBanco.MenorDataFatura.Year,
                bank.FaturaDoBanco.MenorDataFatura.Month,
                10
            );

            // Todo os pagamentos feito antes do dia 10. Vai constar na fatura atual. 
            // e após? Irá depender da forma de pagamento? Não. 

            var diferencaAnual = bank.FaturaDoBanco.MaiorDataFatura.Year - bank.FaturaDoBanco.MenorDataFatura.Year;
            var diferencaMensal = bank.FaturaDoBanco.MaiorDataFatura.Month - bank.FaturaDoBanco.MenorDataFatura.Month;


            if (diferencaAnual >= 0)
                bank.FaturaDoBanco.TotalDeFaturas = (12 * diferencaAnual) + diferencaMensal;
            else
                bank.FaturaDoBanco.TotalDeFaturas = 0;

            int iteracao = 0;

            // TODO: Implementar Read Include
            List<InstallmentDto> installments = _installmentServices.Read();

            bank.Expenses
            .ForEach
            (
                expense => installments.Where(i => i.IdExpense == expense.Id).ToList()
                .ForEach
                (
                    expense.Installments.Add
                )
            );

            var xu = _installmentServices.Read()
                .Where(e => e.ExpectedDate <= bank.DataPagamento.AddMonths(iteracao))
                .ToList();

            while (iteracao <= bank.FaturaDoBanco.TotalDeFaturas)
            {

                bank.Expenses.ForEach
                (
                    expense =>
                    {
                        if (iteracao == 0)
                        {
                            expense.Installments
                                                   .Where
                                                   (
                                                       e => Convert.ToDateTime(e.ExpectedDate).Date <=
                                                        bank.DataPagamento.AddMonths(iteracao)
                                                   )
                                                   .ToList()
                                                   .ForEach
                                                   (
                                                       item => bank.FaturaDoBanco.Faturas.Add
                                                       (
                                                           new BankDto.FaturaDto
                                                           {
                                                               DataCompra = Convert.ToDateTime(item.ExpectedDate),
                                                               Nome = expense.Name,
                                                               NumeroParcela = item.Number,
                                                               QuantidadeTotalParcelas = expense.CountInstallments,
                                                               ValorParcela = expense.Amount
                                                           }
                                                       )
                                                   );
                        }

                        else
                        {
                                var dataAnterior = bank.DataPagamento.AddMonths(iteracao - 1);
                            
                            expense.Installments
                                                   .Where
                                                   (
                                                       e => Convert.ToDateTime(e.ExpectedDate).Date  <= bank.DataPagamento.AddMonths(iteracao).Date && Convert.ToDateTime(e.ExpectedDate).Date >= dataAnterior.Date
                                                   )
                                                   .ToList()
                                                   .ForEach
                                                   (
                                                       item => bank.FaturaDoBanco.Faturas.Add
                                                       (
                                                           new BankDto.FaturaDto
                                                           {
                                                               DataCompra = Convert.ToDateTime(item.ExpectedDate),
                                                               Nome = expense.Name,
                                                               NumeroParcela = item.Number,
                                                               QuantidadeTotalParcelas = expense.CountInstallments,
                                                               ValorParcela = expense.Amount
                                                           }
                                                       )
                                                   );
                        }

                    }
                );

                iteracao++;

            }
            //     // TODO: Posso mostrar quantos por cento da fatura está paga.
            //     // TODO: Exibir o número de parcelas restantes? 
            //     // TODO: Mês anterior ao atual já é em atraso. 
            //     // TODO: Antes disso e no mesmo mês do ano é em aberto
            //     // TODO: Passa do dia 10 é fatura em atraso
            //     // TODO: Desenvolver recursos para o sistema ir se consertando

        }
        return bank;
    }

    //Para ser sincero Serialização tem que ficar aqui
    public void AddBank(BankInputModel bank) =>
        _bankRepository.Create(MappingInputModelToEntity(bank));

    public bool Update(BankInputModel dto, bool include = false)
    {
        BankEntity banco = _bankRepository.GetById<BankEntity>(dto.Id) ??
            throw new Exception($"Não existe um banco com o id {dto.Id}");

        // if (dto.Expenses.Count != 0)

        banco = MappingInputModelToEntity(dto);

        _bankRepository.Update(banco);
        return true;
    }

    public bool Delete(BankInputModel dto, bool include = false) =>
        throw new NotImplementedException();

    public BankEntityData MappingEntityToEntityData(BankEntity obj)
    {
        return new BankEntityData
        {
            Id = obj.Id,
            Balance = obj.Balance,
            Name = obj.Name
        };
    }

    public BankEntity MappingEntityDataToEntity(BankEntityData obj)
    {
        BankEntity entity = new();
        entity.AlterBankEntity(obj.Id, obj.Name, obj.Balance, obj.PaymentDay);
        return entity;
    }

    public BankDto MappingEntityToDto(BankEntity obj)
    {
        return new BankDto
        {
            Id = obj.Id,
            Balance = obj.Balance,
            Name = obj.Name
        };
    }
    public BankEntity MappingInputModelToEntity(BankInputModel obj) =>
        new BankEntity();

    public List<BankEntityData> MappingListEntityToListEntityData(List<BankEntity> obj)
    {
        throw new NotImplementedException();
    }

    public List<BankEntity> MappingListEntityDataToListEntity(List<BankEntityData> obj)
    {
        throw new NotImplementedException();
    }

}