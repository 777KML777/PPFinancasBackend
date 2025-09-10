namespace Domain.Enums;

public enum EPaymentType
{
    Pix,
    Debito,
    Credito,
    Boleto,
    ComeceAPagarAPartir, 
    DebitoAssinaturaRecorrente,
    
    [Obsolete("Não lembro um exemplo.")]
    DebitoParaClienteCreditoParaVendedor
}