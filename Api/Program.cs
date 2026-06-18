using Domain.Base.Class;
using Domain.Exceptions.Base;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add Service to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
   .AllowAnyMethod()
   .AllowAnyHeader();
}));

NativeInjectorBootStrapper.Register(builder.Services);

var app = builder.Build();

// *** Getters Injections *** // 

GetterInjectionServiceExtensionMapper.Constructor(app);
GetterInjectionRepositoryExtensionMapper.Constructor(app);

// *** Getters Injections *** // 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MyPolicy");

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var exception = context.Features
            .Get<IExceptionHandlerFeature>()?
            .Error;

        context.Response.ContentType = "application/json";

        if (exception is DomainException domainEx)
        {
            context.Response.StatusCode = StatusCodes.Status409Conflict;

            var problem = new ProblemDetails
            {
                Status = StatusCodes.Status409Conflict,
                Title = "Business rule violation",
                Detail = domainEx.Message,
                Extensions =
                {
                    ["code"] = domainEx.Code
                }
            };

            await context.Response.WriteAsJsonAsync(problem);
            return;
        }

        // fallback
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
    });
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
// app.Run("http://0.0.0.0:5002");