using Application.Dtos;
using Application.Models;
using Domain.Entities.Extrato;
using Repository.JsonFile.Repositories.Extrato;

namespace Application.Services.Extrato;

public class ExtratoServices : IExtratoServices
{

    private readonly IExtratoRepository _repository;

    public ExtratoServices
    (

    )
    {
        _repository = new ExtratoRepository();
    }
    public bool Create(ExtratoInputModel input, bool include = false)
    {
        _repository.Create
        (
            MappingEntityToEntityData
            (
                MappingInputModelToEntity(input)
            )
        );

        return true;
    }

    public bool Delete(ExtratoInputModel obj, bool include = false)
    {
        throw new NotImplementedException();
    }

    public ExtratoDto GetById(int id, bool include = false)
    {
        throw new NotImplementedException();
    }

    public ExtratoEntity MappingEntityDataToEntity(ExtratoEntityData obj)
    {
        throw new NotImplementedException();
    }

    public ExtratoDto MappingEntityToDto(ExtratoEntity obj)
    {
        throw new NotImplementedException();
    }

    public ExtratoEntityData MappingEntityToEntityData(ExtratoEntity entity)
    {
        ExtratoEntityData data = new()
        {
            IdBank = entity.IdBank,
            Operacao = entity.Operacao.ToString(),
            SaldoAtual = entity.SaldoAtual,
            SaldoAnterior = entity.SaldoAnterior,
            ValorTransacao = entity.ValorTransacao,
            DataUsuarioAlteracao = entity.DataUsuarioAlteracao,
            DataTransacaoSistema = entity.DataTransacaoSistema,
        };

        return data;
    }

    public ExtratoEntity MappingInputModelToEntity(ExtratoInputModel obj)
    {
        throw new NotImplementedException();
    }

    public List<ExtratoEntity> MappingListEntityDataToListEntity(List<ExtratoEntityData> obj)
    {
        throw new NotImplementedException();
    }

    public List<ExtratoDto> MappingListEntityToListDto(List<ExtratoEntity> obj)
    {
        throw new NotImplementedException();
    }

    public List<ExtratoEntityData> MappingListEntityToListEntityData(List<ExtratoEntity> entities)
    {
        List<ExtratoEntityData> datas = new();
        entities.ForEach
        (
            entity => datas.Add
            (
                MappingEntityToEntityData
                (
                    entity
                )
            )
        );

        return datas;
    }

    public List<ExtratoDto> Read(bool include = false)
    {
        throw new NotImplementedException();
    }

    public bool Update(ExtratoInputModel obj, bool include = false)
    {
        throw new NotImplementedException();
    }
}