namespace Application.Interfaces;

public interface IExtratoAppServices
{
    public IEnumerable<ExtratoDto> Read();
    public ExtratoInputModel GetById();
}