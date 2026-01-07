using Application.Inputs;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExpenseController : ControllerBase
{
    private readonly IExpenseAppService _expenseAppService;

    public ExpenseController()
    {
        // _expenseAppService = new ExpenseAppService();
    }

    [HttpPut()]
    public ExpenseInputModel Update(int id) =>
        _expenseAppService.Update(id);

    [HttpGet, Route("get-expense")]
    public ExpenseInputModel GetById(int id) =>
        _expenseAppService.GetById(id);
}