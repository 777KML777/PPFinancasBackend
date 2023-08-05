using Microsoft.AspNetCore.Mvc;
using Application;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DetailController : ControllerBase
    {

        private readonly DetailService _detailService;
        public DetailController()
        {
            _detailService = new DetailService();
        }

        [HttpGet]
        public string Get()
        {
            var x = "Já posso pensar em trazer um relatório completo!!!";
            return "Agora sim. Este é o pequeno passo para alguém mas um grande salto para mim!!!";
        }

        [HttpGet("{id}")]
        public DetailDto Detail(int id) =>
            _detailService.GetAllDetails(id);

    }
}