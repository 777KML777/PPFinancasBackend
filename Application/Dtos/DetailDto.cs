namespace Application; 

public class DetailDto 
{
    // Só para ficar registrado aqui poderia e talvez tenha uma lista de bancos. Por enquanto somente 1.
    public List<BankDto> AllBanks { get; set; } = new();
    public BankSelectedDto DetailBank { get; set; }

} 