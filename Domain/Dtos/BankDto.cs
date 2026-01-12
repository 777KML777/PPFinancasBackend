namespace Domain.Dtos;

public record class BankDto
(
     int Id,
     string Name,
     bool Available,
     decimal Balance,
     int DiaPagamento,
     int CountExpenses,
     decimal TotalExpenses,
     decimal LiquidedBalance,
     string Image,
     decimal TotalCurrentlyCC,
     decimal TotalCurrentlyPIX,
     decimal TotalCC,
     decimal TotalPIX, // A partir daqui
     IEnumerable<ExpenseDto> Expenses // Até aqui
)
{
     public decimal CreditoAVencer { get; set; } = TotalCC - TotalCurrentlyCC;
     public decimal PixAVencer { get; set; } = TotalPIX - TotalCurrentlyPIX;
     public decimal TotalAVencer { get; set; } = 0;
     public decimal SumMensal { get; set; } = TotalCurrentlyCC + TotalCurrentlyPIX;
     public decimal SumAVencer { get; set; } = TotalCC - TotalCurrentlyCC + (TotalPIX - TotalCurrentlyPIX);
     public decimal SumTotal { get; set; } = TotalCC + TotalPIX;
};

// Quantidade de pagamentos realizados. 
// Pagamentos pendentes 
// Pagamentos no Total
// Despesas concluidas
// Assegurado? h

// Cartões / Menus. 

// Movimentações AtualizadoEm

// codusr faz parte da chave composta. 