using Domain.Entities.Extrato;
using Domain.Enums;
using Repository.JsonFile.Repositories.Extrato;

namespace Services.Extrato;

public class ExtratoServices : IExtratoServices
{

    private readonly IExtratoRepository _repository;

    public ExtratoServices()
    {
        _repository = new ExtratoRepository();
    }

    #region CRUD OPERATION 
    public bool Create(ExtratoInputModel input)
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

    public List<ExtratoDto> Read()
    {
        throw new NotImplementedException();
    }

    public bool Update(ExtratoInputModel obj, bool remover = true)
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
        MappingListEntityToListDto
        (
            MappingListEntityDataToListEntity
            (
                _repository.ReadAll<ExtratoEntityData>()
                    .Where(extrato => extrato.IdBank == idBank)
                    .OrderByDescending(extrato => extrato.Id)
                        .ToList()
            )
        );
    #endregion

    #region MAPPING OBJECTS 
    public ExtratoEntity MappingEntityDataToEntity(ExtratoEntityData data)
    {
        ExtratoEntity entity = new
        (
            (EOperacao)Enum.Parse(typeof(EOperacao), data.Operacao),
            data.SaldoAnterior,
            data.ValorTransacao
        );
        entity.LinkedIdBank(data.IdBank);

        return entity;
    }

    public ExtratoDto MappingEntityToDto(ExtratoEntity entity)
    {
        ExtratoDto dto = new()
        {
            IdBank = entity.IdBank,
            Operacao = entity.Operacao.ToString(),
            SaldoDoDia = entity.SaldoDoDia,
            SaldoAnterior = entity.SaldoAnterior,
            ValorTransacao = entity.ValorTransacao,
            DataUsuarioAlteracao = entity.DataUsuarioAlteracao,
            DataTransacaoSistema = entity.DataTransacaoSistema,
        };

        return dto;
    }

    public ExtratoEntityData MappingEntityToEntityData(ExtratoEntity entity)
    {
        ExtratoEntityData data = new()
        {
            IdBank = entity.IdBank,
            Operacao = entity.Operacao.ToString(),
            SaldoDoDia = entity.SaldoDoDia,
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
    #endregion

    #region MAPPING LIST OBJECTS
    public List<ExtratoEntity> MappingListEntityDataToListEntity(List<ExtratoEntityData> datas)
    {
        List<ExtratoEntity> entities = new();
        datas.ForEach(data => entities
            .Add
            (
                MappingEntityDataToEntity
                (
                    data
                )
            ));
        return entities;
    }

    public List<ExtratoDto> MappingListEntityToListDto(List<ExtratoEntity> entities)
    {
        List<ExtratoDto> dtos = new();
        entities.ForEach(entity => dtos.Add
        (
            MappingEntityToDto
            (
                entity
            )
        ));

        return dtos;
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

    ExtratoDto IService<ExtratoInputModel, ExtratoDto, ExtratoEntity, ExtratoEntityData>.Create(ExtratoInputModel input)
    {
        throw new NotImplementedException();
    }

    public ExtratoDto Update(ExtratoDto dto)
    {
        throw new NotImplementedException();
    }

    public ExtratoEntity MappingDtoToEntity(ExtratoDto dto)
    {
        throw new NotImplementedException();
    }

    public bool Create(ExtratoInputModel input, bool remover = true)
    {
        throw new NotImplementedException();
    }

    public ExtratoDto GetById(int id, bool remover = true)
    {
        throw new NotImplementedException();
    }

    ExpenseDto IService<ExtratoInputModel, ExtratoDto, ExtratoEntity, ExtratoEntityData>.GetById(int id)
    {
        throw new NotImplementedException();
    }

    public List<ExtratoDto> Read(bool inactived = false)
    {
        throw new NotImplementedException();
    }

    #endregion
}