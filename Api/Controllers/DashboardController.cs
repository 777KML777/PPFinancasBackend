namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class DashboardController : ControllerBase
{

    private readonly IDashboardAppServices _services;

    public DashboardController
    (
        IDashboardAppServices services
    )
    {
        _services = services;
    }

    [HttpGet()]
    public DashboardDto Get() =>
        _services.DashData();

}

// TODO: Dashboard precisa de Services? Visto que ele só irá agrupar funcionalidades de outros serviços? 
// TODO: Anotar necessidade include no pacote ContextStorageJson. 
// TODO: Application não tem que ter acesso ao repositório. 
