using Domain.Entities.Expense;
using Services.Mappings;

namespace Services.Extensions;

public static class ExpenseExtension
{
    private static ExpenseMapper _mapper = new();
    public static ExpenseEntity ToEntity(this ExpenseEntityData data) =>
        _mapper.ToEntity();
}