namespace Services.Extensions;

public static class ExpenseExtension
{
    private static readonly ExpenseMapper _mapper = new();

    #region "Object" 
    public static ExpenseEntity ToEntity(this ExpenseEntityData data) =>
        _mapper.MappingEntityDataToEntity(data);    

    public static ExpenseDto ToDto(this ExpenseEntity entity) =>
        _mapper.MappingEntityToDto(entity);

    public static ExpenseEntityData ToEntityData(this ExpenseEntity entity) =>
        _mapper.MappingEntityToEntityData(entity);
    #endregion


    #region "Collections" 
    public static List<ExpenseDto> ToListDto(this List<ExpenseEntity> entities) =>
        _mapper.MappingListEntityToListDto(entities);

    public static List<ExpenseEntity> ToListEntity(this List<ExpenseEntityData> datas) =>
        _mapper.MappingListEntityDataToListEntity(datas);
    #endregion 
}