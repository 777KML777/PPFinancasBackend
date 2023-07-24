using Microsoft.AspNetCore.Mvc;
using Application;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExpenseController : ControllerBase
{
    private readonly ExpensesService _expenseService; 

    public ExpenseController()
    {
        _expenseService = new ExpensesService();
    }

    [HttpPut("{id}")]
    public void Update (int id, ExpenseDto expense)
    {
        _expenseService.Update(id, expense);
    }
}