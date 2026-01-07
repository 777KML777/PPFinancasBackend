namespace Infra.Data.Extensions;

public static class BankRepositoryExtension
{
    private readonly static IBankRepositoryMapper _mapper =
        GetterInjectionRepositoryExtensionMapper._bankRepositoryMapper ?? throw new("DI - BankRepositoryMapper - Failed.");

    #region REO - Region Extension Objects
    public static BankEntityData ToEntityData(this BankEntity entity) =>
        _mapper.MappingEntityToEntityData(entity);
    public static BankEntity ToEntity(this BankEntityData data) =>
        _mapper.MappingEntityDataToEntity(data);
    #endregion

    #region REC - Region Extension Collection
    public static IEnumerable<BankEntity> ToEntityEnumerable(this IEnumerable<BankEntityData> data) =>
        _mapper.MappingEntityDataEnumerableToEntityEnumerable(data);
    #endregion

}