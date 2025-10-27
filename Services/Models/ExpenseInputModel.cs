namespace Services.Models;
public record class ExpenseInputModel
(
    ExpenseDto Input, 
    List<BankDataList> BankList
);
