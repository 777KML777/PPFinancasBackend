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
        return new()
        {
            Id = entity.Id,
            IdBank = entity.IdBank,
            Name = entity.Name,
            Inactive = entity.Inactive,
            Separeted = entity.Separeted,
            Amount = entity.Amount,
            Describe = entity.Describe,
            PaymentType = entity.PaymentType,
            CountInstallments = entity.CountInstallments,
            DateLastInstallment = entity.DateLastInstallment,
            DatePurchase = entity.DatePurchase,
            DateFirstInstallment = entity.DateFirstInstallment,
            Installments = new List<InstallmentEntityData>()
        };
    }
    #endregion

    #region RMC - Region Mapper Collection
    public IEnumerable<ExpenseEntity> MappingEntityDataEnumerableToEntityEnumerable(IEnumerable<ExpenseEntityData> obj)
    {
        List<ExpenseEntity> lst = new();
        obj.ToList().ForEach(item => lst.Add(item.ToEntity()));
        return lst;
    }
    public IEnumerable<ExpenseEntityData> MappingEntityEnumerableToEntityDataEnumerable(IEnumerable<ExpenseEntity> entity)
    {
        throw new NotImplementedException();
    }

    #endregion
}