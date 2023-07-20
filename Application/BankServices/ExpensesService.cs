using Domain;
using Repository.JsonFile;

namespace Application;

public class ExpensesService : IExpensesService
{
    private readonly IExpensesRepository _expensesRepository;
    private readonly IPaidInstallmentsService _paidInstallmentsService;
    public ExpensesService()
    {
        _expensesRepository = new ExpensesRepository();
        _paidInstallmentsService = new PaidInstallmentsService();
    }
    public List<ExpenseDto> GetExpenseByIdBank(int idBank)
    {
        List<ExpenseDto> lstExpenses = new List<ExpenseDto>();
        _expensesRepository.GetAllByIdBank(idBank).ForEach(x => lstExpenses.Add(MappingEntityToDto(x)));

        lstExpenses.ForEach(x => x.paidInstallments = _paidInstallmentsService.GetAllPaidByIdExpenses(x.Id));

        lstExpenses.ForEach(x => x.SumTotalExpensesItem());
        lstExpenses.ForEach(x => x.SumInstallmentsAndTotalRemaning(x.paidInstallments.Count));


        return lstExpenses;
    }

    public ExpensesEntity MappingDtoToEntity(ExpenseDto obj)
    {
        throw new NotImplementedException();
    }

    public ExpenseDto MappingEntityToDto(ExpensesEntity obj)
    {
        return new ExpenseDto()
        {
            Id = obj.Id,
            Separeted = obj.Separeted,
            Inactive = obj.Inactive,
            DateLastInstallments = obj.DateLastInstallments,
            DateFirstInstallments = obj.DateFirstInstallments,
            Amount = obj.Amount,
            CountInstallments = obj.CountInstallments,
            Describe = obj.Describe,
            ExpenseName = obj.ExpenseName,
            PaymentType = obj.PaymentType,
            TotalExpensesItem = obj.TotalExpensesItem,
            TotalExpensesItemRemaining = obj.TotalExpensesItemRemaining,
            PayedInstallments = obj.PayedInstallments,
            RemainingInstallments = obj.RemainingInstallments,
            // relational maps
            IdBank = obj.IdBank
        };

    }
}