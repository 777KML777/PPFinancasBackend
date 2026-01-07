using Domain.Services;

namespace Infra.Ioc.Base.Class;

public static class NativeInjectorBootStrapper
{
    public static void Register(this IServiceCollection builder)
    {

        #region "AppService
        // AppService 
        builder.AddScoped<IBankAppService, BankAppService>();
        builder.AddScoped<IExpenseAppService, ExpenseAppService>();
        builder.AddScoped<IExtratoAppService, ExtratoAppService>();
        builder.AddScoped<IDashboardAppService, DashboardAppService>();
        builder.AddScoped<IInstallmentAppService, InstallmentAppService>();
        builder.AddScoped<ITempFutureDebitsAppService, TempFutureDebitsAppService>();
        #endregion 

        #region "Service && ServiceMapper"
        // Service 
        builder.AddScoped<IBankService, BankService>();
        builder.AddScoped<IExpenseService, ExpenseService>();
        builder.AddScoped<IExtratoService, ExtratoService>();
        builder.AddScoped<IInstallmentService, InstallmentService>();
        // builder.AddScoped<ITempFutureDebitsService, TempFutureDebitsService>();
        // --- Service Mappers
        builder.AddScoped<IBankServiceMapper, BankServiceMapper>();
        builder.AddScoped<IExtratoServiceMapper, ExtratoServiceMapper>();
        builder.AddScoped<IExpenseServiceMapper, ExpenseServiceMapper>();
        // builder.AddScoped<IInstallmentServiceMapper, InstallmentServiceMapper>();
        // builder.AddScoped<ITempFutureDebitsServiceMapper, TempFutureDebitsServiceMapper>();
        #endregion

        #region "Repositories && RepositoryMappers"
        // Repositories 
        builder.AddScoped<IBankRepository, BankRepository>();
        builder.AddScoped<IExpenseRepository, ExpenseRepository>();
        builder.AddScoped<IExtratoRepository, ExtratoRepository>();
        builder.AddScoped<IInstallmentRepository, InstallmentRepository>();
        builder.AddScoped<ITempFutureDebitsRepository, TempFutureDebitsRepository>();
        // --- Repositories Mappers
        builder.AddScoped<IBankRepositoryMapper, BankRepositoryMapper>();
        builder.AddScoped<IExtratoRepositoryMapper, ExtratoRepositoryMapper>();
        builder.AddScoped<IExpenseRepositoryMapper, ExpenseRepositoryMapper>();
        builder.AddScoped<IInstallmentRepositoryMapper, InstallmentRepositoryMapper>();
        builder.AddScoped<ITempFutureDebitsRepositoryMapper, TempFutureDebitsRepositoryMapper>();
        #endregion 

        #region "Packages"
        // Packages 
        builder.AddScoped<IGenericRepository, GenericRepository>();
        #endregion

    }
}