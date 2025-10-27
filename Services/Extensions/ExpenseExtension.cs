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
    
    #endregion
}