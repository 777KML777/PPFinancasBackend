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
            // Nessa action aqui eu posso pensar em colocar o retorno de todos os bancos, mas isso ainda tem que ser pensando em tela antes
            var x = "Já posso pensar em trazer um relatório completo!!!";
            return "Agora sim. Este é o pequeno passo para alguém mas um grande salto para mim!!!";
        }

        [HttpGet("{id}")]
        public DetailDto Detail(int id) =>
            _detailService.GetAllDetails(id);

    }
}