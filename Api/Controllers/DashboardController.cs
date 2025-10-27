namespace Api.Controllers; 

[ApiController]
[Route("api/[controller]")]

public class DashboardController : ControllerBase 
{
    private readonly DashboardAppServices _dashboardService;

    public DashboardController() 
    {
        _dashboardService = new DashboardAppServices();
    }

    [HttpGet(Name = "dash-data")]
    public DashboardDto Get () => 
        _dashboardService.DashData(); 

    // {
    //     // Posso dar um jeito aqui de retornar o banco. Ver Evento .NET e pegar ensinamentos desse evento 
    //     // Estou me distanciando muito do Backend - mas nesse momento faz-se um pouco necessário 
    //     // Futuramente ter a opção de criar o banco já com as despesas 

    //     _DashboardService.Create(obj); 
    // }
}