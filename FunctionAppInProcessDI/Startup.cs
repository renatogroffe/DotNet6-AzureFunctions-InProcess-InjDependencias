using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using FunctionAppInProcessDI.Interfaces;
using FunctionAppInProcessDI.Implementations;

[assembly: FunctionsStartup(typeof(FunctionAppInProcessDI.Startup))]
namespace FunctionAppInProcessDI;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        builder.Services.AddSingleton<ITesteA, TesteA>();
        builder.Services.AddTransient<ITesteB, TesteB>();
        builder.Services.AddScoped<TesteC>();
        builder.Services.AddTransient<TesteInjecao>();
    }
}