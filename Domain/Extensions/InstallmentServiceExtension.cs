using Domain.Dtos;
using Domain.Mappers;

namespace Domain.Extensions;

public static class InstallmentExtension
{
    private static readonly InstallmentServiceMapper _mapper = new();

    public static InstallmentDto ToDto(this InstallmentEntity entity) =>
        _mapper.MappingEntityToDto(entity);
    public static IEnumerable<InstallmentDto> ToDtoEnumerable(this IEnumerable<InstallmentEntity> entities) =>
        _mapper.MappingEntityEnumerableToDtoEnumerable(entities);
}