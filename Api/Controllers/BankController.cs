using Application.Inputs;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class BankController : ControllerBase
{
    private readonly IBankAppService _bankService/*  = new BankAppService() */;

    public BankController()
    {
        
    }

    [HttpPost]
    public void Create(BankInputModel obj)
    {
        // Posso dar um jeito aqui de retornar o banco. Ver Evento .NET e pegar ensinamentos desse evento 
        // Estou me distanciando muito do Backend - mas nesse momento faz-se um pouco necessário 
        // Futuramente ter a opção de criar o banco já com as despesas 

        // _bankService.Create(obj);
    }

    [HttpPut()]
    public void Update(BankInputModel obj) => Console.WriteLine("ha");
        // _bankService.Update(obj);

    [HttpGet("{id}")]
    public BankInputModel Get(int id) =>
        _bankService.GetById(id);
}