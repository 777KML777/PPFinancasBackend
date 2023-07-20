namespace Application;

public class DetailService
{
    private readonly BankService _bankService;

    public DetailService ()
    {
        _bankService = new BankService();
    }
    public DetailDto GetAllDetails (int bankId)
    {
        DetailDto detail = new DetailDto();
        detail.Bank = _bankService.GetBankById(bankId);
        detail.Bank.Calculate();

        return detail;
    }
}
