using Domain.Dtos;
using Domain.Mappers;

namespace Domain.Extensions;

public static class ExpenseExtension
{
    private static readonly ExpenseServiceMapper _mapper = new();

    #region "Object" 
    public static ExpenseDto ToDto(this ExpenseEntity entity) =>
        _mapper.MappingEntityToDto(entity);
    #endregion

    #region "Collections" 
    public static IEnumerable<ExpenseDto> ToListDto(this IEnumerable<ExpenseEntity> entities) =>
        _mapper.MappingEntityEnumerableToDtoEnumerable(entities);
    #endregion 
}