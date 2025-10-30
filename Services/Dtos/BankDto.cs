namespace Services.Dtos;

public record class BankDto
(
     int Id,
     string Name,
     bool Available,
     decimal Balance,
     int DiaPagamento,
     int CountExpenses,
     decimal TotalExpenses,
     decimal LiquidedBalance
);

// Quantidade de pagamentos realizados. 
// Pagamentos pendentes 
// Pagamentos no Total
// Despesas concluidas
// Assegurado? 

// Cartões / Menus. 

// Movimentações AtualizadoEm

// codusr faz parte da chave composta. 