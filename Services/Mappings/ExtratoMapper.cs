namespace Services.Mappings;

public class ExtratoMapper : IMappings<ExtratoInputModel, ExtratoDto, ExtratoEntity, ExtratoEntityData>
{
    public ExtratoEntity MappingInputModelToEntity(ExtratoInputModel obj)
    {
        throw new NotImplementedException();
    }
    public ExtratoEntity MappingDtoToEntity(ExtratoDto dto)
    {
        throw new NotImplementedException();
    }

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

    public List<ExtratoEntity> MappingListEntityDataToListEntity(List<ExtratoEntityData> datas)
    {
        List<ExtratoEntity> entities = new();
        datas.ForEach(data => entities
            .Add
            (
                data.ToEntity()
            ));
        return entities;
    }

    public List<ExtratoDto> MappingListEntityToListDto(List<ExtratoEntity> entities)
    {
        List<ExtratoDto> dtos = new();
        entities.ForEach(entity => dtos.Add
        (
            entity.ToDto()
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
                entity.ToEntityData()
            )
        );

        return datas;
    }
}