using ApiCliente.Models;
using ApiCliente.Models.Request;
using ApiCliente.Models.Response;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using VerdadeConsequencia.Entities;
using VerdadeConsequencia.Models;
using VerdadeConsequencia.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCliente.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class ConsequenciaController : ApiClienteController
    {
        public ConsequenciaController(IMapper mapper, IOptions<AppSettings> appSettings, IOptions<TokenSettings> tokenSetting)
           : base(mapper, appSettings, tokenSetting) { }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_mapperResponse.Map<List<ConsequenciaResponse>>(ConsequenciaService.Listar()));
        }

        [HttpGet("{id}")]
        public ActionResult<ConsequenciaResponse> Obter(int uuid)
        {
            return Ok(_mapperResponse.Map<ConsequenciaResponse>(ConsequenciaService.Obter(uuid)));
        }


        [HttpPost]
        public ActionResult<ConsequenciaResponse> Salvar([FromBody] ConsequenciaRequest funcionarioRequest)
        {
            Consequencia consequencia = _mapperRequest.Map<Consequencia>(funcionarioRequest);
            return Ok(_mapperResponse.Map<ConsequenciaResponse>(ConsequenciaService.Salvar(consequencia)));
        }

        [HttpDelete("{id}")]
        public ActionResult DeletarConsequencia(int uuid)
        {
            return Ok(ConsequenciaService.Deletar(uuid));
        }
        
    }
}
