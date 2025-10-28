namespace Services.Extensions;

public static class BankExtension
{
    private static readonly BankMapper _mapper = new();

    #region "Objects" 
    public static BankDto ToDto(this BankEntity entity) =>
        _mapper.MappingEntityToDto(entity);

    public static BankEntity ToEntity(this BankEntityData data) =>
        _mapper.MappingEntityDataToEntity(data);

    public static BankEntityData ToEntityData(this BankEntity entity) =>
        _mapper.MappingEntityToEntityData(entity);
    #endregion 

    #region "Collections" 
    public static List<BankDto> ToListDto(this List<BankEntity> entities) =>
        _mapper.MappingListEntityToListDto(entities);

    public static List<BankEntity> ToListEntity(this List<BankEntityData> datas) =>
        _mapper.MappingListEntityDataToListEntity(datas);
    #endregion 

}