using Application.Dtos;
using Application.Selects;

namespace Application.Models;

public record class ExpenseInputModel
(
    ExpenseDto Input, 
    List<BankDataList> BankList
);
