namespace Infra.Data.Extensions;

public static class ExpenseRepositoryExtension
{
    private readonly static IExpenseRepositoryMapper _mapper =
        GetterInjectionRepositoryExtensionMapper._expenseRepositoryMapper ?? throw new("DI - ExpenseRepositoryMapper - Failed.");

    #region REO - Region Extension Objects
    public static ExpenseEntityData ToEntityData(this ExpenseEntity entity) =>
        _mapper.MappingEntityToEntityData(entity);
    public static ExpenseEntity ToEntity(this ExpenseEntityData data) =>
        _mapper.MappingEntityDataToEntity(data);
    #endregion

    #region REC - Region Extension Collection
    public static IEnumerable<ExpenseEntity> ToEntityEnumerable(this IEnumerable<ExpenseEntityData> data) =>
        _mapper.MappingEntityDataEnumerableToEntityEnumerable(data);
    #endregion

}