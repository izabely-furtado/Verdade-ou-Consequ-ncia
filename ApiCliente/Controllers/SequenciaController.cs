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
    public class SequenciaController : ApiClienteController
    {
        public SequenciaController(IMapper mapper, IOptions<AppSettings> appSettings, IOptions<TokenSettings> tokenSetting)
           : base(mapper, appSettings, tokenSetting) { }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_mapperResponse.Map<List<SequenciaResponse>>(SequenciaService.Listar()));
        }

        [HttpGet("{id}")]
        public ActionResult<SequenciaResponse> Obter(int id)
        {
            return Ok(_mapperResponse.Map<SequenciaResponse>(SequenciaService.Obter(id)));
        }

        [HttpPost]
        public ActionResult<SequenciaResponse> Salvar([FromBody] SequenciaRequest funcionarioRequest)
        {
            Sequencia pessoa = _mapperRequest.Map<Sequencia>(funcionarioRequest);
            return Ok(_mapperResponse.Map<SequenciaResponse>(SequenciaService.Salvar(pessoa)));
        }

        [HttpDelete("{id}")]
        public ActionResult DeletarSequencia(int id)
        {
            return Ok(SequenciaService.Deletar(id));
        }
        
    }
}
