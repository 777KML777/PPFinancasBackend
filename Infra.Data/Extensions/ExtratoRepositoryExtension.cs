namespace Infra.Data.Extensions; 

public static class ExtratoRepositoryExtension
{
    public static IEnumerable<ExtratoEntity> ToEntityEnumerable(this IEnumerable<ExtratoEntityData> datas)
    {
        return new List<ExtratoEntity>();
    }
}