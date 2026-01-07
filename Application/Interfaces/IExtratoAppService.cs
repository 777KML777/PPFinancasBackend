using Application.Inputs;

namespace Application.Interfaces;

public interface IExtratoAppService
{
    public IEnumerable<ExtratoDto> Read();
    public ExtratoInputModel GetById();
}