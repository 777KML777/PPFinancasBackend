namespace Application.Dtos;
public record class InstallmentDto(int Id, int IdExpense, int Number, DateTime? ExpectedDate, DateTime? PaymentDate);
