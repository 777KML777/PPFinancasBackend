namespace Services.Implementations;

public class ExtratoServices : IExtratoServices
{
    private readonly IExtratoRepository _repository;
    public ExtratoServices
    (
        IExtratoRepository repository
    )
    {
        _repository = repository;
    }

    #region RSO - Region Specific Operation
    public IEnumerable<ExtratoDto> GetExtratosByIdBank(int idBank)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region RCO - Region Commom Operation
    public ExtratoInputModel GetById(int identifier)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region CRUD Operations
    public ExtratoDto Create(ExtratoInputModel input)
    {
        _repository.Create
        (
            input.ToEntity()
        );

        return new();
    }
    public IEnumerable<ExtratoDto> Read() => _repository.Read().ToDtoIEnumerable();

    public ExtratoInputModel Update(ExtratoInputModel input)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int identifier)
    {
        throw new NotImplementedException();
    }
    #endregion
}