
namespace Domain.Interfaces;

public interface IExtratoRepository : IRepository
{
    public IEnumerable<ExtratoEntity> GetExtratosByIdBank(int idBank);
    public ExtratoEntity Create(ExtratoEntity entity);
}