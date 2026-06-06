namespace Infra.Data.Mappers;

public class InstallmentRepositoryMapper : IInstallmentRepositoryMapper
{
    #region RMO - Region Mapper Objects
    #endregion

    #region RMC - Region Mapper Collection
    #endregion
    public IEnumerable<InstallmentEntity> MappingEntityDataEnumerableToEntityEnumerable(IEnumerable<InstallmentEntityData> data)
    {
        throw new NotImplementedException();
    }

    public InstallmentEntity MappingEntityDataToEntity(InstallmentEntityData data)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<InstallmentEntityData> MappingEntityEnumerableToEntityDataEnumerable(IEnumerable<InstallmentEntity> entity)
    {
        throw new NotImplementedException();
    }

    public InstallmentEntityData MappingEntityToEntityData(InstallmentEntity entity)
    {
        throw new NotImplementedException();
    }
}