namespace Domain.Dtos;

public record class ExpenseDto
(
    int Id,
    int IdBank,
    string? Name,
    bool Inactive,
    bool Separeted,
    decimal Amount,
    string? Describe,
    string? PaymentType,
    decimal TotalExpense,
    int CountInstallments,
    int PayedInstallments,
    int RemainingInstallments,
    decimal TotalExpenseRemaining,
    DateTime? DatePurchase,
    DateTime? DateLastInstallments,
    DateTime? DateFirstInstallments,
    List<InstallmentDto>? Installments
)
{
    // TODO: Dando certo eu jogo para cá.
    // fora do record porque eu preciso setar manualmente isso aqui. 
    public BankDto? Bank { get; set; } = null;

    // TODO: Colocar os nullable no formulário também. 

}


// Se preocupar depois com transferência de despesa para outro banco.

// Como passar o banco sendo que aqui é Record. 
// E o banco selecionado está no InputModel.

// Validaria o BankSelect 
// Criar um novo ExpenseDto passando o banco validado e transformado em Dto. 

// Faz sentido. Pode não parecer fazer. Mas assim eu asseguro o código.
// Continuar com a abordagem acima. 