using Domain.Dtos;
using Domain.Extensions;
using Domain.Interfaces;

namespace Domain.Mappers;

public class ExtratoServiceMapper : IExtratoServiceMapper
{
    // public ExtratoEntity MappingInputModelToEntity(ExtratoInputModel obj)
    // {
    //     throw new NotImplementedException();
    // }
    public ExtratoEntity MappingDtoToEntity(ExtratoDto dto)
    {
        throw new NotImplementedException();
    }

    // public ExtratoEntity MappingEntityDataToEntity(ExtratoEntityData data)
    // {
    //     ExtratoEntity entity = new
    //     (
    //         (EOperacao)Enum.Parse(typeof(EOperacao), data.Operacao),
    //         data.SaldoAnterior,
    //         data.ValorTransacao
    //     );
    //     entity.LinkedIdBank(data.IdBank);

    //     return entity;
    // }

    public ExtratoDto MappingEntityToDto(ExtratoEntity entity)
    {
        ExtratoDto dto = new
        (
            entity.Id,
            entity.IdBank,
            entity.SaldoDoDia,
            entity.SaldoAnterior,
            entity.ValorTransacao,
            entity.DataUsuarioAlteracao,
            entity.DataTransacaoSistema,
            entity.Operacao.ToString()
        );

        return dto;
    }

    // public ExtratoEntityData MappingEntityToEntityData(ExtratoEntity entity)
    // {
    //     ExtratoEntityData data = new()
    //     {
    //         IdBank = entity.IdBank,
    //         Operacao = entity.Operacao.ToString(),
    //         SaldoDoDia = entity.SaldoDoDia,
    //         SaldoAnterior = entity.SaldoAnterior,
    //         ValorTransacao = entity.ValorTransacao,
    //         DataUsuarioAlteracao = entity.DataUsuarioAlteracao,
    //         DataTransacaoSistema = entity.DataTransacaoSistema,
    //     };

    //     return data;
    // }

    // public List<ExtratoEntity> MappingEntityDataEnumerableToEntityEnumerable(List<ExtratoEntityData> datas)
    // {
    //     List<ExtratoEntity> entities = new();
    //     datas.ForEach(data => entities
    //         .Add
    //         (
    //             data.ToEntity()
    //         ));
    //     return entities;
    // }

    public IEnumerable<ExtratoDto> MappingEntityEnumerableToDtoEnumerable(IEnumerable<ExtratoEntity> entities)
    {
        List<ExtratoDto> dtos = new();
        entities
        .ToList()
        .ForEach(entity => dtos.Add
        (
            entity.ToDto()
        ));

        return dtos;
    }

    // public List<ExtratoEntityData> MappingEntityEnumerableToDtoEnumerable(List<ExtratoEntity> entities)
    // {
    //     List<ExtratoEntityData> datas = new();
    //     entities.ForEach
    //     (
    //         entity => datas.Add
    //         (
    //             entity.ToEntityData()
    //         )
    //     );

    //     return datas;
    // }

    public List<ExtratoDto> MappingEntityEnumerableToDtoEnumerable(List<ExtratoEntity> entities)
    {
        throw new NotImplementedException();
    }

    // public IEnumerable<ExtratoDto> MappingEntityEnumerableToDtoEnumerable(IEnumerable<ExtratoEntity> entities)
    // {
    //     throw new NotImplementedException();
    // }
}