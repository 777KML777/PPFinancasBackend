using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Services.Dtos;
using Services.Models;
using Services.Bank;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class BankController : ControllerBase
{
    private readonly BankServices _bankServices = new BankServices();

    public BankController()
    {

    }

    [HttpPost]
    public void Create(BankInputModel obj)
    {
        // Posso dar um jeito aqui de retornar o banco. Ver Evento .NET e pegar ensinamentos desse evento 
        // Estou me distanciando muito do Backend - mas nesse momento faz-se um pouco necessário 
        // Futuramente ter a opção de criar o banco já com as despesas 

        _bankServices.Create(obj);
    }

    [HttpPut()]
    public void Update(BankInputModel obj) =>
        _bankServices.Update(obj);

    [HttpGet("{id}")]
    public BankDto Get(int id) =>
        _bankServices.GetById(id);

}