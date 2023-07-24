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
        ExpensesEntity expenseEntity = new ExpensesEntity
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

        obj.paidInstallments.ForEach(x =>
            expenseEntity.AddPaymentsToInstallments(_paidInstallmentsService.MappingDtoToEntity(x)));

        return expenseEntity;
    }

    public int GetNextId() => 5;
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

    public void Update(int id, ExpenseDto expense)
    {
        // Por enquanto o update do expenses entity consiste em criar um novo pagamento
        if (expense.AddPayment)
        {
            expense.paidInstallments.Add(new PaidInstallmentsDto
            {
                Id = _paidInstallmentsService.GetNextId(),
                PaymentDate = DateTime.Now,
                IdExpenses = expense.Id
            });

            _paidInstallmentsService.Create(expense.paidInstallments.Last());

            // _expensesRepository.Update(MappingDtoToEntity(expense));
        }
        else 
        {
            // _expensesRepository.Update(MappingDtoToEntity(expense));
        }
    }
}