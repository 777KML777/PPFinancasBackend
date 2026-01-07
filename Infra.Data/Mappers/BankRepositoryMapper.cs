namespace Infra.Data.Mappers;

public class BankRepositoryMapper : IBankRepositoryMapper
{
    #region RMO - Region Mapper Objects

    public BankEntity MappingEntityDataToEntity(BankEntityData data)
    {
        BankEntity entity = new();
        entity.AlterBankEntity
        (
            data.Id,
            data.Name,
            data.Balance,
            data.PaymentDay,
            data.Avalaible
        );
        return entity;
    }
    public BankEntityData MappingEntityToEntityData(BankEntity entity)
    {
        return new BankEntityData
        {
            Id = entity.Id,
            Balance = entity.Balance,
            Name = entity.Name
        };
    }
    #endregion

    #region RMC - Region Mapper Collection
    public IEnumerable<BankEntity> MappingEntityDataEnumerableToEntityEnumerable(IEnumerable<BankEntityData> data)
    {
        List<BankEntity> lst = new();
        data.ToList().ForEach(item => lst.Add(item.ToEntity()));
        return lst;
    }

    // TODO: Em caso de salvar coleções 
    public IEnumerable<BankEntityData> MappingEntityEnumerableToEntityDataEnumerable(IEnumerable<BankEntity> entity) =>
        throw new NotImplementedException();
    #endregion
}