using Domain.Enums;
using Repository.Json;

namespace Domain.Entities.Extrato;

public class ExtratoEntity : EntityData
{
    public ExtratoEntity
    (
        EOperacao operacao,
        decimal saldoAnterior,
        decimal valorTransacao,
        DateTime? dataUsuarioAlteracao = null
    )
    {
        Operacao = operacao;
        SaldoAnterior = saldoAnterior;
        ValorTransacao = valorTransacao;

        DataTransacaoSistema = DateTime.Now;
        SaldoAtual = SaldoAnterior + ValorTransacao;

        if (dataUsuarioAlteracao != null)
            DataUsuarioAlteracao = (DateTime)dataUsuarioAlteracao;
        else
            DataUsuarioAlteracao = DataTransacaoSistema;

    }
    public decimal SaldoAtual { get; private set; }
    public EOperacao Operacao { get; private set; }
    public decimal SaldoAnterior { get; private set; }
    public decimal ValorTransacao { get; private set; }
    public DateTime DataUsuarioAlteracao { get; private set; }
    public DateTime DataTransacaoSistema { get; private set; }

    // Relational
    public int IdBank { get; private set; }
    public void LinkedIdBank(int id) =>
        IdBank = id;
}