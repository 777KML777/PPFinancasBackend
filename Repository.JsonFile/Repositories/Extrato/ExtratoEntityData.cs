using Repository.Json;

namespace Repository.JsonFile.Repositories.Extrato;

public class ExtratoEntityData : EntityData
{
    public int IdBank { get; set; }
    public string Operacao { get; set; }
    public decimal SaldoDoDia { get; set; }
    public decimal SaldoAnterior { get; set; }
    public decimal ValorTransacao { get; set; }
    public DateTime DataUsuarioAlteracao { get; set; }
    public DateTime DataTransacaoSistema { get; set; }

}