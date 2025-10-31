namespace Services.Dtos;

public class FaturaDto
{
    public int IdExpense { get; set; }
    public int NumeroParcela { get; set; }
    public int MesLancamento { get; set; }
    public DateTime DataCompra { get; set; }
    public decimal ValorParcela { get; set; }
    public int QuantidadeTotalParcelas { get; set; }
    public string Nome { get; set; } = string.Empty;
}