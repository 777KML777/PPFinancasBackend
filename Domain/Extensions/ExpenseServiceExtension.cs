using Domain.Dtos;
using Domain.Mappers;

namespace Domain.Extensions;

public static class ExpenseExtension
{
    private static readonly ExpenseServiceMapper _mapper = new();

    #region "Object" 
    public static ExpenseEntity ToEntity(this ExpenseDto dto) =>
        _mapper.MappingDtoToEntity(dto);
    public static ExpenseDto ToDto(this ExpenseEntity entity) =>
        _mapper.MappingEntityToDto(entity);
    #endregion

    #region "Collections" 
    public static IEnumerable<ExpenseDto> ToDtoEnumerable(this IEnumerable<ExpenseEntity> entities) =>
        _mapper.MappingEntityEnumerableToDtoEnumerable(entities);
    // public static IEnumerable<ExpenseDto> ToDtoEnumerable(this IReadOnlyCollection<ExpenseEntity> entities) =>
    //     _mapper.MappingEntityEnumerableToDtoEnumerable(entities);
    #endregion 
}