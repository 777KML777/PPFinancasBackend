namespace Application.Apps;

public class ExtratoAppServices : IExtratoAppServices
{

    private readonly IExtratoServices _services;
    public ExtratoAppServices
    (
        IExtratoServices services
    )
    {
        _services = services;
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
        _services.Read();
    #endregion

}