using Microsoft.AspNetCore.Mvc; 
using Application; 

namespace Api.Controllers; 

[ApiController]
[Route("api/[controller]")]

public class BankController : ControllerBase 
{
    private readonly BankService _bankService;

    public BankController() 
    {
        _bankService = new BankService();
    }

    [HttpPost]
    public void Create (BankSelectedDto obj)
    {
        // Posso dar um jeito aqui de retornar o banco. Ver Evento .NET e pegar ensinamentos desse evento 
        // Estou me distanciando muito do Backend - mas nesse momento faz-se um pouco necessário 
        // Futuramente ter a opção de criar o banco já com as despesas 

        _bankService.Create(obj); 
    }
}