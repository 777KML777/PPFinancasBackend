namespace Services.Extensions;

public static class ExtatoExtension
{
    private static readonly ExtratoMapper _mapper = new();

    #region 'OBJECTS'
    public static ExtratoEntity ToEntity(this ExtratoInputModel input) =>
        _mapper.MappingInputModelToEntity(input);

    public static ExtratoEntityData ToEntityData(this ExtratoEntity entity) =>
        _mapper.MappingEntityToEntityData(entity);

    public static ExtratoEntity ToEntity(this ExtratoEntityData data) =>
        _mapper.MappingEntityDataToEntity(data);

    public static ExtratoDto ToDto(this ExtratoEntity entity) =>
        _mapper.MappingEntityToDto(entity);
    #endregion

    #region "COLLECTIONS" 
    public static List<ExtratoDto> ToListDto(this List<ExtratoEntity> entities) =>
    _mapper.MappingListEntityToListDto(entities);
    public static List<ExtratoEntityData> ToListEntityData(this List<ExtratoEntity> entities) =>
           _mapper.MappingListEntityToListEntityData(entities);

    public static List<ExtratoEntity> ToListEntity(this List<ExtratoEntityData> datas) =>
      _mapper.MappingListEntityDataToListEntity(datas);
    #endregion 
}