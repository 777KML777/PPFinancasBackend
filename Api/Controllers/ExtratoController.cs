namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExtratoController : ControllerBase
{
    private readonly IExtratoAppServices _appServices;

    public ExtratoController
    (
        IExtratoAppServices appServices
    )
    {
        _appServices = appServices;
    }

    [HttpGet()]
    public IEnumerable<ExtratoDto> Read() =>
        _appServices.Read();

    [HttpGet, Route("get-Extrato")]
    public ExtratoInputModel GetById(int id) =>
        _appServices.GetById();
}