namespace Services.Extensions;

public static class InstallmentExtension
{
    private static readonly InstallmentMapper _mapper = new();

    public static List<InstallmentEntityData> ToListEntityData(this List<InstallmentEntity> entities) =>
        _mapper.MappingListEntityToListEntityData(entities);
}