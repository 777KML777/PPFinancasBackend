namespace Domain;

public enum EPaymentType
{
    Boleto = 0,
    Debito = 1,
    DebitoParaClienteCreditoParaVendedor = 2,
    DebitoDescontoAutomaticoPorPeriodo = 3,
    Credito = 4,
    Pix = 5,
}