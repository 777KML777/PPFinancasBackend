using Domain;
using Repository.JsonFile;

namespace Application;

public class BankService : IBankService
{
    private readonly IBankRepository _bankRepository;
    private readonly IExpensesService _expenseServices;
    public BankService()
    {
        _bankRepository = new BankRepository();
        _expenseServices = new ExpensesService();
    }

    // public BankService(IBankRepository bankRepository)
    // {
    //     _bankRepository = bankRepository;
    // }


    public List<BankDto> GetAllBanks()
    {
        var lstBanks = new List<BankDto>();
        var teste = _bankRepository.ReadAll();

        _bankRepository.ReadAll().ToList().ForEach(x => lstBanks.Add(new BankDto { Id = x.Id })); // Passaria por parâmetro.
        return lstBanks;

        // public List<BankDto> GetAllBanks => 
        //     new List<BankDto>() {  new BankDto { Id = _bankRepository.ReadAll().Select(x => x.Id).ToList()[0]}};
        // new List<BankDto>() {  _bankRepository.ReadAll().ToList().ForEach(x => new BankDto {Id = x.Id}) };
    }

    public BankDto GetBankById(int id)
    {
        // Vai primeiro pegar o banco 
        BankEntity bankEntity = _bankRepository.GetById(id);

        BankDto bank = MappingEntityToDto(bankEntity);


        // Irá chamar o serviço de expenses somente para passar a lista já com tudo calculado
        List<ExpenseDto> lstExpensesDto = _expenseServices.GetExpenseByIdBank(bank.Id)
            .OrderBy(x => x.Inactive).ThenBy(x => x.ExpenseName).ToList();
        
        bank.Expenses = new List<ExpenseDto>();
        lstExpensesDto.ForEach(x => bank.Expenses.Add(x));

        return bank;
    }

    //Para ser sincero Serialização tem que ficar aqui
    public void AddBank(BankDto bank) =>
        _bankRepository.Create(MappingDtoToEntity(bank));

    public BankDto MappingEntityToDto(BankEntity obj)
    {
        return new BankDto
        {
            Id = obj.Id,
            Balance = obj.Balance,
            BankName = obj.Name
        };
    }
    public BankEntity MappingDtoToEntity(BankDto obj) =>
        new BankEntity(obj.BankName, obj.Balance) { Id = obj.Id };

    // public void UpdateBank(int id) => 
    //     _bankRepository.Update(MappingDtoToEntity())

}