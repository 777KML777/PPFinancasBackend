namespace Domain.Entities;

public class ExtratoEntity : Entity
{
    public ExtratoEntity (){}
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
        SaldoDoDia = SaldoAnterior + ValorTransacao;

        if (dataUsuarioAlteracao != null)
            DataUsuarioAlteracao = (DateTime)dataUsuarioAlteracao;
        else
            DataUsuarioAlteracao = DataTransacaoSistema;

    }
    public decimal SaldoDoDia { get; private set; }
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