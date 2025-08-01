namespace Application.Dtos;

public record class ExpenseDto
(
    int Id,
    int IdBank,
    string Name,
    bool Inactive,
    bool Separeted,
    decimal Amount,
    string Describe,
    string PaymentType,
    decimal TotalExpense,
    int CountInstallments,
    int PayedInstallments,
    int RemainingInstallments,
    decimal TotalExpenseRemaining,
    DateTime DatePurchase,
    DateTime DateLastInstallments,
    DateTime DateFirstInstallments,
    List<InstallmentDto> Installments
)
{
    // List<InstallmentDto> Installments
}
