namespace Application;

public class DetailService
{
    private readonly BankService _bankService;

    public DetailService()
    {
        _bankService = new BankService();
    }
    public DetailDto GetAllDetails(int bankId)
    {
        DetailDto detail = new()
        {
            DetailBank = _bankService.GetBankById(bankId)
        };

        detail.DetailBank.Calculate();

        _bankService.GetAllBanks().ForEach(x =>
            detail.AllBanks.Add(new BankDto { Id = x.Id, Name = x.BankName })
        );
        
        return detail;
    }
}
