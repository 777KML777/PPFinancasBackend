using Application.Inputs;

namespace Application.Apps;

public class ExtratoAppService : IExtratoAppService
{

    private readonly IExtratoService _Service;

    public ExtratoAppService()
    {
    }

    public ExtratoAppService
    (
        IExtratoService Service
    )
    {
        _Service = Service;
    }

    #region RSO - Region Specific Operation
    #endregion

    #region RCO - Region Commom Operation
    public ExtratoInputModel GetById()
    {
        throw new NotImplementedException();
    }
    #endregion

    #region CRUD Operations
    public IEnumerable<ExtratoDto> Read() =>
        _Service.Read();

    ExtratoInputModel IExtratoAppService.GetById()
    {
        throw new NotImplementedException();
    }
    #endregion

}