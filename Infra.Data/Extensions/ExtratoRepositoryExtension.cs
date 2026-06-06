using System.Collections.ObjectModel;

namespace Infra.Data.Extensions;

internal static class ExtratoRepositoryExtension
{
    internal static IEnumerable<ExtratoEntity> ToEntityEnumerable(this IEnumerable<ExtratoEntityData> datas)
    {
        ICollection<ExtratoEntity> entities = new Collection<ExtratoEntity>();
        datas.ToList()
        .ForEach
        (
            item => entities.Add(item.ToEntity())
        );

        return entities.AsEnumerable();
    }

    internal static ExtratoEntity ToEntity(this ExtratoEntityData data)
    {
        ExtratoEntity entity = new
        (
            (EOperacao)Enum.Parse(typeof(EOperacao), data.Operacao),
            data.SaldoAnterior,
            data.ValorTransacao, 
            data.SaldoDoDia, 
            data.DataUsuarioAlteracao,
            data.DataTransacaoSistema,
            data.IdBank
        );
        return entity;
    }
    internal static ExtratoEntityData ToEntityData(this ExtratoEntity entity)
    {
        return new();
    }
}