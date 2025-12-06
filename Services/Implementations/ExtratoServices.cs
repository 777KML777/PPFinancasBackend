using Infra.Data.Extensions;

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

    #region CRUD OPERATION 
    public ExtratoDto Create(ExtratoInputModel input)
    {
        _repository.Create
        (
            input.ToEntity()
        );

        return new();
    }

    public List<ExtratoDto> Read(bool inactived = false)
    {
        throw new NotImplementedException();
    }

    public ExtratoDto Update(ExtratoInputModel dto)
    {
        throw new NotImplementedException();
    }
    public bool Delete(ExtratoInputModel obj)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region COMMOM OPERATION
    public ExtratoDto GetById(int id)
    {
        throw new NotImplementedException();
    }
    public IEnumerable<ExtratoDto> GetExtratosByIdBank(int idBank) =>
        _repository.GetExtratosByIdBank(idBank).ToDtoIEnumerable();

    ExtratoInputModel IService<ExtratoInputModel, ExtratoDto, ExtratoEntity>.GetById(int identifier)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ExtratoDto> Read()
    {
        throw new NotImplementedException();
    }

    ExtratoInputModel IService<ExtratoInputModel, ExtratoDto, ExtratoEntity>.Update(ExtratoInputModel input)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int identifier)
    {
        throw new NotImplementedException();
    }

    #endregion
}