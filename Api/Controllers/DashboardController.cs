namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class DashboardController : ControllerBase
{

    private readonly IDashboardAppService _app;

    public DashboardController
    (
        IDashboardAppService app
    )
    {
        _app = app;
    }

    [HttpGet()]
    public IActionResult Get() =>
        Ok(_app.DashData());
}

// TODO: Dashboard precisa de Service? Visto que ele só irá agrupar funcionalidades de outros serviços? 
// TODO: Anotar necessidade include no pacote ContextStorageJson. 
// TODO: Application não tem que ter acesso ao repositório. 