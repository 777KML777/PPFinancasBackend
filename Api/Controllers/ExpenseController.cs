using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.Models;
using Application.Dtos;

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

    [HttpPut()]
    public ExpenseDto Update(ExpenseDto expense) =>
        _expenseServices.Update(expense);

    [HttpGet, Route("get-expense")]
    public ExpenseInputModel GetById(int id) =>
        _expenseServices.GetById(id);
}