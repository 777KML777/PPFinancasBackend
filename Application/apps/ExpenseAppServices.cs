namespace Application.Apps;

public class ExpenseAppServices : IExpenseAppServices
{
    private readonly IBankServices _bankServices;
    private readonly IExpenseServices _expenseServices;
    public ExpenseAppServices
    (
        IBankServices bankServices, 
        IExpenseServices expenseServices
    )
    {
        _bankServices = bankServices;
        _expenseServices = expenseServices;
    }

    public ExpenseInputModel Update(int id)
    {
        throw new NotImplementedException();
    }
    public ExpenseInputModel GetById(int id) =>
        new(null/* _expenseServices.GetById(id) */, _bankServices.GetDataList());

}