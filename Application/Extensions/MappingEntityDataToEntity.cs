using Domain.Entities.Expense;

namespace Application.Extensions;

public static class MappingEntityDataToEntity
{
    public static ExpenseEntity ToEntity(this ExpenseEntityData entityData)
    {
        return new ExpenseEntity(); 
    }
}