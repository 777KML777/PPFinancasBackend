using Application.Inputs;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class BankController : ControllerBase
{
    private readonly IBankAppService _app/*  = new BankAppService() */;

    public BankController
    (
        IBankAppService app 
    )
    {
        _app = app;
    }

    [HttpPost]
    public void Create(BankInputModel obj)
    {
        // Posso dar um jeito aqui de retornar o banco. Ver Evento .NET e pegar ensinamentos desse evento 
        // Estou me distanciando muito do Backend - mas nesse momento faz-se um pouco necessário 
        // Futuramente ter a opção de criar o banco já com as despesas 

        // _app.Create(obj);
    }

    [HttpPut()]
    public void Update(BankInputModel obj) => Console.WriteLine("ha");
        // _app.Update(obj);

    [HttpGet("{id}")]
    public BankInputModel Get(int id) =>
        _app.GetById(id);
}