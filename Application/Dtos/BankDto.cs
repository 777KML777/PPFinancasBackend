namespace Application.Dtos;

public class BankDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Balance { get; set; }
    public int DiaPagamento { get; set; }
    public int CountExpenses { get; set; }
    public decimal FinalBalance { get; set; }
    public decimal TotalExpenses { get; set; }
    public DateTime DataPagamento { get; set; }

    public List<ExpenseDto> Expenses { get; set; } = new List<ExpenseDto>();
    public FaturaDoBancoDto FaturaDoBanco { get; set; } = new FaturaDoBancoDto();

    public void CalculateFinalBalance() =>
        FinalBalance = Balance - TotalExpenses;

    public class FaturaDoBancoDto
    {
        public FaturaDoBancoDto()
        {

        }

        public DateTime MenorDataFatura { get; set; }
        public DateTime MaiorDataFatura { get; set; }
        public int TotalDeFaturas { get; set; } // Se tiver 1 parcela com o Tipo TempoIndeterminado somar + 1 aqui com base no valor da parcela que tiver a maior data da última parcela.
        public List<FaturaDto> Faturas { get; set; } = new List<FaturaDto>();
    }

    public class FaturaDto
    {
        public FaturaDto()
        {

        }
        public string Nome { get; set; }
        public int NumeroParcela { get; set; }
        public DateTime DataCompra { get; set; }
        public decimal ValorParcela { get; set; }
        public int QuantidadeTotalParcelas { get; set; }
    }
}