namespace Services.Objects.Models;
public record class ExpenseInputModel
(
    ExpenseDto Input, 
    List<BankDataList> BankList
);
