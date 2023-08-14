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

    public void Create(BankSelectedDto obj)
    {
        _bankRepository.Create(MappingDtoToEntity(obj));
    }
    public List<BankSelectedDto> GetAllBanks()
    {
        var lstBanks = new List<BankSelectedDto>();
        var teste = _bankRepository.ReadAll();

        _bankRepository.ReadAll().ToList().ForEach(x => lstBanks.Add(new BankSelectedDto { Id = x.Id, BankName = x.Name })); // Passaria por parâmetro.
        return lstBanks;

        // public List<BankSelectedDto> GetAllBanks => 
        //     new List<BankSelectedDto>() {  new BankSelectedDto { Id = _bankRepository.ReadAll().Select(x => x.Id).ToList()[0]}};
        // new List<BankSelectedDto>() {  _bankRepository.ReadAll().ToList().ForEach(x => new BankSelectedDto {Id = x.Id}) };
    }

    public BankSelectedDto GetBankById(int id)
    {
        // Vai primeiro pegar o banco 
        BankEntity bankEntity = _bankRepository.GetById(id);

        BankSelectedDto bank = MappingEntityToDto(bankEntity);


        // Irá chamar o serviço de expenses somente para passar a lista já com tudo calculado
        List<ExpenseDto> lstExpensesDto = _expenseServices.GetExpenseByIdBank(bank.Id)
            .OrderBy(x => x.Inactive).ThenBy(x => x.ExpenseName).ToList();

        bank.Expenses = new List<ExpenseDto>();
        lstExpensesDto.ForEach(x => bank.Expenses.Add(x));

        return bank;
    }

    //Para ser sincero Serialização tem que ficar aqui
    public void AddBank(BankSelectedDto bank) =>
        _bankRepository.Create(MappingDtoToEntity(bank));

    public BankSelectedDto MappingEntityToDto(BankEntity obj)
    {
        return new BankSelectedDto
        {
            Id = obj.Id,
            Balance = obj.Balance,
            BankName = obj.Name
        };
    }
    public BankEntity MappingDtoToEntity(BankSelectedDto obj) =>
        new BankEntity { Id = obj.Id, Balance = obj.Balance, Name = obj.BankName };

    // public void UpdateBank(int id) => 
    //     _bankRepository.Update(MappingDtoToEntity())

    public int GetNextId() => 99;


}