using Domain.Dtos;

namespace Domain.Interfaces;

public interface IExtratoService : IService<ExtratoDto, ExtratoEntity>
{
    public IEnumerable<ExtratoDto> GetExtratosByIdBank(int idBank); 

}