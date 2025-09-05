using Application.Dtos;
using Application.Models;
using Domain.Entities.Extrato;
using Repository.JsonFile.Repositories.Extrato;

namespace Application.Services.Extrato;

public interface IExtratoServices : IService<ExtratoInputModel, ExtratoDto, ExtratoEntity, ExtratoEntityData>
{
    public List<ExtratoDto> GetExtratosByIdBank(int idBank); 

}