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
    public class OpcaoController : ApiClienteController
    {
        public OpcaoController(IMapper mapper, IOptions<AppSettings> appSettings, IOptions<TokenSettings> tokenSetting)
           : base(mapper, appSettings, tokenSetting) { }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_mapperResponse.Map<List<OpcaoResponse>>(OpcaoService.Listar()));
        }

        [HttpGet("{id}")]
        public ActionResult<OpcaoResponse> Obter(int id)
        {
            return Ok(_mapperResponse.Map<OpcaoResponse>(OpcaoService.Obter(id)));
        }

        [HttpPost]
        public ActionResult<OpcaoResponse> Salvar([FromBody] OpcaoRequest funcionarioRequest)
        {
            Opcao alerta = _mapperRequest.Map<Opcao>(funcionarioRequest);
            return Ok(_mapperResponse.Map<OpcaoResponse>(OpcaoService.Salvar(alerta)));
        }

        [HttpDelete("{id}")]
        public ActionResult DeletarOpcao(int id)
        {
            return Ok(OpcaoService.Deletar(id));
        }
        
    }
}
