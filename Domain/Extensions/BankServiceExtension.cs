using Domain.Dtos;
using Domain.Mappers;

namespace Domain.Extensions;

public static class BankExtension
{
    private static readonly BankServiceMapper _mapper = new();

    #region "Objects" 
    public static BankDto ToDto(this BankEntity entity) =>
        _mapper.MappingEntityToDto(entity);
    #endregion 

    #region "Collections" 
    public static IEnumerable<BankDto> ToDtoEnumerable(this IEnumerable<BankEntity> entities) =>
        _mapper.MappingEntityEnumerableToDtoEnumerable(entities);
    #endregion 

}