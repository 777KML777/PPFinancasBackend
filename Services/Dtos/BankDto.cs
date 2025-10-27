namespace Services.Dtos;

public record class BankDto
(
     int Id,
     string Name,
     decimal Balance,
     int DiaPagamento,
     int CountExpenses,
     decimal TotalExpenses,
     decimal LiquidedBalance
);