namespace Services.Interfaces;

public interface IExtratoServices : IService<ExtratoInputModel, ExtratoDto, ExtratoEntity>
{
    public IEnumerable<ExtratoDto> GetExtratosByIdBank(int idBank); 

}