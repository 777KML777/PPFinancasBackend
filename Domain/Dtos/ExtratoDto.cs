namespace Domain.Dtos;

public record class ExtratoDto
(
    int Id,
    int IdBank,
    decimal SaldoDoDia,
    decimal SaldoAnterior,
    decimal ValorTransacao,
    DateTime DataUsuarioAlteracao,
    DateTime DataTransacaoSistema,
    string Operacao
);