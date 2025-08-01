namespace Repository.Json;

public class EntityData : GenericRepository
{
    public int Id { get; set; }
    public EntityData Include<T>(EntityData data, T dataInclude) =>
        Include(data, dataInclude, false);
    public EntityData IncludeRange<T>(EntityData data, List<T> dataInclude) =>
         IncludeRange(data, dataInclude, false);
}