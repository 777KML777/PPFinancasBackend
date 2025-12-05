namespace Infra.Data.Mappers;

public class ExpenseRepositoryMapper : IExpenseRepositoryMapper
{
    #region RMO - Region Mapper Objects
    public ExpenseEntity MappingEntityDataToEntity(ExpenseEntityData data)
    {
        throw new NotImplementedException();
    }
    public ExpenseEntityData MappingEntityToEntityData(ExpenseEntity entity)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region RMC - Region Mapper Collection
    public IEnumerable<ExpenseEntity> MappingEntityDataIEnumerableToEntityIEnumerable(IEnumerable<ExpenseEntityData> data)
    {
        throw new NotImplementedException();
    }
    public IEnumerable<ExpenseEntityData> MappingEntityIEnumerableToEntityDataIEnumerable(IEnumerable<ExpenseEntity> entity)
    {
        throw new NotImplementedException();
    }
    #endregion
}