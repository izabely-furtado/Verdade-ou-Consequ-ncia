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
    public class AlertaController : ApiClienteController
    {
        public AlertaController(IMapper mapper, IOptions<AppSettings> appSettings, IOptions<TokenSettings> tokenSetting)
           : base(mapper, appSettings, tokenSetting) { }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_mapperResponse.Map<List<AlertaResponse>>(AlertaService.Listar()));
        }

        [HttpGet("{id}")]
        public ActionResult<AlertaResponse> Obter(int id)
        {
            return Ok(_mapperResponse.Map<AlertaResponse>(AlertaService.Obter(id)));
        }

        [HttpPost]
        public ActionResult<AlertaResponse> Salvar([FromBody] AlertaRequest funcionarioRequest)
        {
            Alerta alerta = _mapperRequest.Map<Alerta>(funcionarioRequest);
            return Ok(_mapperResponse.Map<AlertaResponse>(AlertaService.Salvar(alerta)));
        }

        [HttpDelete("{id}")]
        public ActionResult DeletarAlerta(int id)
        {
            return Ok(AlertaService.Deletar(id));
        }
        
    }
}
