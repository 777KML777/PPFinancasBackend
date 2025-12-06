namespace Services.Mappers;

public class BankServicesMapper : IBankServicesMapper
{

    #region "OBJECTS" 
    public BankDto MappingEntityToDto(BankEntity entity) =>
        new(entity.Id, entity.Name, entity.Available, entity.Balance, entity.PaymentDay, entity.Expenses.Count, entity.TotalExpenses(), entity.LiquidedBalance());

    #endregion

    public BankEntity MappingDtoToEntity(BankDto dto)
    {
        throw new NotImplementedException();
    }

    // public BankEntity MappingEntityDataToEntity(BankEntityData data)
    // {
    //     BankEntity entity = new();
    //     entity.AlterBankEntity
    //     (
    //         data.Id,
    //         data.Name,
    //         data.Balance,
    //         data.PaymentDay,
    //         data.Avalaible
    //     );
    //     return entity;
    // }
    // public BankEntityData MappingEntityToEntityData(BankEntity entity)
    // {
    //     return new BankEntityData
    //     {
    //         Id = entity.Id,
    //         Balance = entity.Balance,
    //         Name = entity.Name
    //     };
    // }

    #region "COLLECTIONS" 
    // public List<BankEntity> MappingListEntityDataToListEntity(List<BankEntityData> obj)
    // {
    //     List<BankEntity> lst = new();
    //     obj.ForEach(item => lst.Add(MappingEntityDataToEntity(item)));
    //     return lst;
    // }
    public List<BankDto> MappingListEntityToListDto(List<BankEntity> entities)
    {
        List<BankDto> lst = new();
        entities.ForEach(item => lst.Add(item.ToDto()));
        return lst;
    }

    public BankEntity MappingInputModelToEntity(BankInputModel input)
    {
        throw new NotImplementedException();
    }

    public List<BankDto> MappingEntityListToDtoList(List<BankEntity> entities)
    {
        throw new NotImplementedException();
    }
    #endregion
}