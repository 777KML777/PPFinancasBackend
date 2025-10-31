namespace Services.Extrato;

public class ExtratoServices : IExtratoServices
{

    private readonly IExtratoRepository _repository;

    public ExtratoServices()
    {
        _repository = new ExtratoRepository();
    }

    #region CRUD OPERATION 
    public ExtratoDto Create(ExtratoInputModel input)
    {
        _repository.Create
        (
            input.ToEntity().ToEntityData()
        );

        return null;
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
    public List<ExtratoDto> GetExtratosByIdBank(int idBank) =>
        _repository.ReadAll<ExtratoEntityData>()
            .Where(extrato => extrato.IdBank == idBank)
            .OrderByDescending(extrato => extrato.Id)
                .ToList().ToListEntity().ToListDto();
    #endregion
}