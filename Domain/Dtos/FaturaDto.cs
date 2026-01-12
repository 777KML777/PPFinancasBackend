namespace Domain.Dtos;

public class FaturaDto
{
    // public int IdExpense { get; set; }
    // public int NumeroParcela { get; set; }
    // public DateTime DataCompra { get; set; }
    // public decimal ValorParcela { get; set; }
    // public int QuantidadeTotalParcelas { get; set; }
    // public string Nome { get; set; } = string.Empty;

    public List<Lancamento> Lancamentos { get; set; } = new();
}

public class Lancamento
{
    public string Nome { get; set; }
    public decimal Valor { get; set; }
    public int ParcelaAtual { get; set; }
    public int TotalParcelas { get; set; }
    public DateTime DataLancamento { get; set; }
}