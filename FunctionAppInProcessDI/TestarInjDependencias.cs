using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using FunctionAppInProcessDI.Interfaces;
using FunctionAppInProcessDI.Implementations;

namespace FunctionAppInProcessDI;

public class TestarInjDependencias
{
    private readonly TesteInjecao _objTesteInjecao;
    private readonly ITesteA _testeA;
    private readonly ITesteB _testeB;
    private readonly TesteC _testeC;

    public TestarInjDependencias(TesteInjecao objTesteInjecao,
        ITesteA testeA,
        ITesteB testeB,
        TesteC testeC)
    {
        _objTesteInjecao = objTesteInjecao;
        _testeA = testeA;
        _testeB = testeB;
        _testeC = testeC;
    }

    [FunctionName("TestarInjDependencias")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
        ILogger log)
    {
        log.LogInformation(
            $"C# HTTP trigger: executando o método Run da Function {nameof(TestarInjDependencias)}...");
        var resultado = await _objTesteInjecao
                .RetornarValoresInjecao(_testeA, _testeB, _testeC);
        return new OkObjectResult(resultado);
    }
}