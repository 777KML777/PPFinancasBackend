using Application.Selects;

namespace Application.Inputs;
public record class ExpenseInputModel
(
    ExpenseDto Input, 
    IEnumerable<BankSelect> SelectsBank
);
