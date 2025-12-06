namespace Infra.Data.Extensions; 

public static class ExtratoRepositoryExtension
{
    public static IEnumerable<ExtratoEntity> ToEntityEnumerable(this IEnumerable<ExtratoEntityData> datas)
    {
        return new List<ExtratoEntity>();
    }
    public static ExtratoEntity ToEntity(this ExtratoEntityData data)
    {
        return new();
    }
    public static ExtratoEntityData ToEntityData(this ExtratoEntity entity)
    {
        return new();
    }


}