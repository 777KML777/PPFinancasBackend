using Application.Inputs;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExtratoController : ControllerBase
{
    private readonly IExtratoAppService _AppService;

    public ExtratoController
    (
        IExtratoAppService AppService
    )
    {
        _AppService = AppService;
    }

    [HttpGet()]
    public IEnumerable<ExtratoDto> Read() =>
        _AppService.Read();

    [HttpGet, Route("get-Extrato")]
    public ExtratoInputModel GetById(int id) =>
        _AppService.GetById();
}