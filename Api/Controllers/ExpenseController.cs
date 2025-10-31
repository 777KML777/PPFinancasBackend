namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExpenseController : ControllerBase
{
    private readonly IExpenseAppServices _expenseAppServices;

    public ExpenseController()
    {
        _expenseAppServices = new ExpenseAppServices();
    }

    [HttpPut()]
    public ExpenseInputModel Update(int id) =>
        _expenseAppServices.Update(id);

    [HttpGet, Route("get-expense")]
    public ExpenseInputModel GetById(int id) =>
        _expenseAppServices.GetById(id);
}