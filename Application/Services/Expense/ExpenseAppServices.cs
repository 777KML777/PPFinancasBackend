

namespace Application.Services.Expense;

public class ExpenseAppServices : IExpenseAppServices
{
    private readonly IBankServices _bankServices;
    private readonly IExpenseServices _expenseServices;
    public ExpenseAppServices()
    {
        _bankServices = new BankServices();
        _expenseServices = new ExpenseServices();
    }

    public ExpenseInputModel Update(int id)
    {
        throw new NotImplementedException();
    }
    public ExpenseInputModel GetById(int id) =>
        new(_expenseServices.GetById(id), _bankServices.GetDataList());

}