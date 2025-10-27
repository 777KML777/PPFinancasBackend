namespace Services.Extensions;

public static class BankExtension
{
    private static readonly BankMapper _mapper = new ();
    public static BankDto ToDto(this BankEntity entity) =>
        _mapper.MappingEntityToDto(entity);

    public static List<BankDto> ToListDto(this List<BankEntity> entities) =>
        _mapper.MappingListEntityToListDto(entities);
}