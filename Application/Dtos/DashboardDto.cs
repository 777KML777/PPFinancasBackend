namespace Application.Dtos;

public class DashboardDto
{ 

    public decimal TotalAvailableBalance { get; set; } // Total disponível FGTS não entra aqui. (Valor Atual)
    public decimal AvailableBalance { get; set; } // (Valor Disponível)
    public decimal TotalExpenses { get; set; } // Todas as dívidas (exceto a.aluguel, mãe, contas = 2.300) Incluir geladeira e despesas mercado pago fora os cartões.
    public decimal TotalBalance { get; set; } // FGTS entra aqui (Valor possível)
    public decimal Balance { get; set; } // Diferença entre (Valor possível)
    public decimal TotalCountExpenses { get; set; } // Todas as despesas. Isso isso não conta n de parcelas.

    public List<BankDto> Banks { get; set; } = new List<BankDto>();

}