using Application.Inputs;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExpenseController : ControllerBase
{
    private readonly IExpenseAppService _app;

    public ExpenseController
    (
        IExpenseAppService app
    )
    {
        _app = app;
    }

    [HttpPut()]
    public ExpenseDto Update(ExpenseInputModel id) =>
        _app.Update(id);

    [HttpGet, Route("get-expense")]
    public ExpenseInputModel GetById(int id) =>
        _app.GetById(id);
}