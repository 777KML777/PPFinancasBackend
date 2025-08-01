using Application.Dtos;
using Application.Models;
using Domain.Entities.Expense;

namespace Application.Services;

public interface IExpenseServices : IService<ExpenseInputModel, ExpenseDto, ExpenseEntity, ExpenseEntityData>
{
    List<ExpenseDto> GetExpenseByIdBank(int idBank);
}