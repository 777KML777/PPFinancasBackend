namespace Services.Interfaces;

public interface IExtratoServices : IService<ExtratoInputModel, ExtratoDto, ExtratoEntity, ExtratoEntityData>
{
    public List<ExtratoDto> GetExtratosByIdBank(int idBank); 

}