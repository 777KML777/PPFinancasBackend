namespace Services.Mappings;

public class BankMapper : IMappings<BankInputModel, BankDto, BankEntity, BankEntityData>
{

    #region "OBJECTS" 
    public BankDto MappingEntityToDto(BankEntity entity) =>
        new(entity.Id, entity.Name, entity.Balance, entity.PaymentDay, entity.Expenses.Count, entity.TotalExpenses(), entity.LiquidedBalance());

    #endregion

    public BankEntity MappingDtoToEntity(BankDto dto)
    {
        throw new NotImplementedException();
    }

    public BankEntity MappingEntityDataToEntity(BankEntityData data)
    {
        throw new NotImplementedException();
    }



    public BankEntityData MappingEntityToEntityData(BankEntity entity)
    {
        throw new NotImplementedException();
    }


    #region "COLLECTIONS" 
    public List<BankEntity> MappingListEntityDataToListEntity(List<BankEntityData> datas)
    {
        throw new NotImplementedException();
    }

    public List<BankDto> MappingListEntityToListDto(List<BankEntity> entities)
    {
        List<BankDto> lst = new();
        entities.ForEach(item => lst.Add(item.ToDto()));
        return lst;
    }
    #endregion 
}