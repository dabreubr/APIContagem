using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace APIContagem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContadorController : ControllerBase
    {
        private static readonly Contador _CONTADOR = new Contador();

        private readonly ILogger<ContadorController> _logger;

        public ContadorController(ILogger<ContadorController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public OkObjectResult Get()
        {
            lock (_CONTADOR)
            {
                _CONTADOR.Incrementar();
                _logger.LogInformation($"Contador - Valor atual: {_CONTADOR.ValorAtual}");

                return new OkObjectResult(new
                {
                    _CONTADOR.ValorAtual,
                    _CONTADOR.Local,
                    _CONTADOR.Kernel,
                    _CONTADOR.TargetFramework,
                    MensagemFixa = "Teste local",
                    MensagemVariavel = Environment.GetEnvironmentVariable("MensagemVariavel")
                });
            }
        }

        [HttpPost]
        public ActionResult Adicionar(int input)
        {
            return new OkObjectResult(new
            {
                _CONTADOR.ValorAtual,
                _CONTADOR.Local,
                _CONTADOR.Kernel,
                _CONTADOR.TargetFramework,
                MensagemFixa = "Teste local",
                MensagemVariavel = Environment.GetEnvironmentVariable("MensagemVariavel")
            });
        }
    }
}
