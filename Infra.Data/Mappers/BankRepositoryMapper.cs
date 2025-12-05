namespace Infra.Data.Mappers;

public class BankRepositoryMapper : IBankRepositoryMapper
{
    #region RMO - Region Mapper Objects
    #endregion

    #region RMC - Region Mapper Collection
    #endregion
    public IEnumerable<BankEntity> MappingEntityDataIEnumerableToEntityIEnumerable(IEnumerable<BankEntityData> data)
    {
        throw new NotImplementedException();
    }

    public BankEntity MappingEntityDataToEntity(BankEntityData data)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<BankEntityData> MappingEntityIEnumerableToEntityDataIEnumerable(IEnumerable<BankEntity> entity)
    {
        throw new NotImplementedException();
    }

    public BankEntityData MappingEntityToEntityData(BankEntity entity)
    {
        throw new NotImplementedException();
    }
}