namespace Infra.Data.Repositories;

public class ExtratoRepository : Repository, IExtratoRepository
{
    public ExtratoRepository
    (
        IGenericRepository context
    ) : base(context)
    {
        
    }

    public IEnumerable<ExtratoEntity> Read() => ReadAll<ExtratoEntityData>().ToEntityEnumerable();


    public IEnumerable<ExtratoEntity> GetExtratosByIdBank(int idBank) =>
        ReadAll<ExtratoEntityData>()
        .Where(e => e.IdBank == idBank)
        .OrderByDescending(e => e.Id)
        .ToEntityEnumerable();
}