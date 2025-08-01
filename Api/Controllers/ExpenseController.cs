using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.Models;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExpenseController : ControllerBase
{
    private readonly ExpenseServices _expenseServices; 

    public ExpenseController()
    {
        _expenseServices = new ExpenseServices();
    }

    [HttpPut("{id}")]
    public void Update (int id, ExpenseInputModel expense)
    {
        _expenseServices.Update(expense);
    }
}