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

    [HttpPost()]
    public ActionResult Create(ExpenseInputModel id) =>
        Ok(_app.Create(id));

    [HttpGet()]
    public ActionResult Read() =>
        Ok(_app.Read());

    [HttpPut()]
    public ActionResult Update(ExpenseInputModel id) =>
        Ok(_app.Update(id));

    [HttpDelete()]
    public ActionResult Delete(ExpenseInputModel id) =>
        Ok(_app.Update(id));

    [HttpGet("{id}")]
    public ActionResult GetById(int id) =>
        Ok(_app.GetById(id));
}