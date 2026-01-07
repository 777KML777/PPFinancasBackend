using Domain.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Base.Class;

/// <summary>
/// Essa classe base é responsável por simular uma injeção para as classes de extensões. <br/>
///  Classes estáticas de extensões não podem ser injetadas. 
/// </summary>
public static class GetterInjectionServiceExtensionMapper
{
    internal static IBankServiceMapper? _bankServiceMapper;
    internal static IExpenseServiceMapper? _expenseServiceMapper;
    internal static IExtratoServiceMapper? _extratoServiceMapper;
    public static void Constructor(this WebApplication builder)
    {
        using var scope = builder.Services.CreateScope();
        {
            _bankServiceMapper = scope.ServiceProvider.GetRequiredService<IBankServiceMapper>();
            _expenseServiceMapper = scope.ServiceProvider.GetRequiredService<IExpenseServiceMapper>();
            _extratoServiceMapper = scope.ServiceProvider.GetRequiredService<IExtratoServiceMapper>();
        }

    }
}