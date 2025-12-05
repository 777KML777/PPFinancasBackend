namespace Domain.Interfaces;

public interface IExtratoRepository : IRepository
{
    public IEnumerable<ExtratoEntity> GetExtratosByIdBank(int idBank);
}