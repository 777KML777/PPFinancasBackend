using Application.Selects;

namespace Application.Inputs;
public record class ExpenseInputModel
(
    ExpenseDto Dto, 
    BankSelect SelectedBank,
    IEnumerable<BankSelect> SelectsBank
);
