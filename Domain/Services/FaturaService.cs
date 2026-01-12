using Domain.Dtos;
using Domain.Interfaces;

namespace Domain.Services;

public class FaturaService : IFaturaService
{
    public FaturaDto Create(FaturaDto dto)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int identifier)
    {
        throw new NotImplementedException();
    }

    public FaturaDto Generate(BankDto banco)
    {
        FaturaDto dto = new();
        var teste = EPaymentType.Credito.ToString();
        var despesas = banco.Expenses.Where(e => e.PaymentType.Equals(EPaymentType.Credito.ToString())).ToList();

        foreach (var item in despesas)
        {
            IEnumerable<InstallmentDto> parcelas;

            if (item.Installments != null)
                parcelas = item.Installments.Where(x => x.ExpectedDate > DateTime.Now.Date).ToList();
            else
                parcelas = new List<InstallmentDto>();

            foreach (var item2 in parcelas)
            {
                dto.Lancamentos.Add
                (
                    new()
                    {
                        Nome = item.Name ?? "",
                        Valor = item.Amount,
                        ParcelaAtual = item.PayedInstallments + 1,
                        TotalParcelas = item.CountInstallments,
                        DataLancamento = item2.ExpectedDate != null ? (DateTime)item2.ExpectedDate : DateTime.Now
                    }
                );
            }

        }

        return dto;
    }

    public FaturaDto GetById(int identifier)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<FaturaDto> GetFaturasByIdBank(int idBank)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<FaturaDto> Read()
    {
        throw new NotImplementedException();
    }

    public FaturaDto Update(FaturaDto dto)
    {
        throw new NotImplementedException();
    }
}