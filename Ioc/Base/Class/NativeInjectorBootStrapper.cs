namespace Ioc.Base.Class;

public static class NativeInjectorBootStrapper
{
    public static void Register(this IServiceCollection builder)
    {

        #region "AppServices
        // AppServices 
        builder.AddScoped<IBankAppServices, BankAppServices>();
        builder.AddScoped<IExpenseAppServices, ExpenseAppServices>();
        builder.AddScoped<IExtratoAppServices, ExtratoAppServices>();
        builder.AddScoped<IInstallmentAppServices, InstallmentAppServices>();
        builder.AddScoped<ITempFutureDebitsAppServices, TempFutureDebitsAppServices>();
        #endregion 

        #region "Services && ServicesMapper"
        // Services 
        builder.AddScoped<IBankServices, BankServices>();
        builder.AddScoped<IExpenseServices, ExpenseServices>();
        builder.AddScoped<IExtratoServices, ExtratoServices>();
        builder.AddScoped<IInstallmentServices, InstallmentServices>();
        // builder.AddScoped<ITempFutureDebitsServices, TempFutureDebitsServices>();
        // --- Services Mappers
        builder.AddScoped<IBankServicesMapper, BankServicesMapper>();
        builder.AddScoped<IExtratoServicesMapper, ExtratoServicesMapper>();
        builder.AddScoped<IExpenseServicesMapper, ExpenseServicesMapper>();
        // builder.AddScoped<IInstallmentServicesMapper, InstallmentServicesMapper>();
        // builder.AddScoped<ITempFutureDebitsServicesMapper, TempFutureDebitsServicesMapper>();
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