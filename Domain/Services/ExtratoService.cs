using Domain.Dtos;
using Domain.Extensions;
using Domain.Interfaces;

namespace Domain.Services;

public class ExtratoService : IExtratoService
{
    private readonly IExtratoRepository _repository;
    public ExtratoService
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

    #endregion

    #region CRUD Operations
    // public ExtratoDto Create(ExtratoInputModel input)
    // {
    //     _repository.Create
    //     (
    //         input.ToEntity()
    //     );

    //     return new();
    // }
    public IEnumerable<ExtratoDto> Read() => _repository.Read().ToDtoIEnumerable();

    public bool Delete(int identifier)
    {
        throw new NotImplementedException();
    }

    IEnumerable<ExtratoDto> IExtratoService.GetExtratosByIdBank(int idBank)
    {
        throw new NotImplementedException();
    }

    public ExtratoDto GetById(int identifier)
    {
        throw new NotImplementedException();
    }

    public ExtratoDto Create(ExtratoDto dto)
    {
        throw new NotImplementedException();
    }

    public ExtratoDto Update(ExtratoDto dto)
    {
        throw new NotImplementedException();
    }

    #endregion
}