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
using static VerdadeConsequencia.Services.VerdadeService;

namespace ApiCliente.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class VerdadeController : ApiClienteController
    {
        public VerdadeController(IMapper mapper, IOptions<AppSettings> appSettings, IOptions<TokenSettings> tokenSetting)
           : base(mapper, appSettings, tokenSetting) { }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_mapperResponse.Map<List<VerdadeResponse>>(VerdadeService.Listar()));
        }

        [HttpGet("{id}")]
        public ActionResult<VerdadeResponse> Obter(int uuid)
        {
            return Ok(_mapperResponse.Map<VerdadeResponse>(VerdadeService.Obter(uuid)));
        }

        [HttpPost]
        public ActionResult<VerdadeResponse> Salvar([FromBody] VerdadeRequest funcionarioRequest)
        {
            Verdade pessoa = _mapperRequest.Map<Verdade>(funcionarioRequest);
            return Ok(_mapperResponse.Map<VerdadeResponse>(VerdadeService.Salvar(pessoa)));
        }

        [HttpDelete("{id}")]
        public ActionResult DeletarVerdade(int uuid)
        {
            return Ok(VerdadeService.Deletar(uuid));
        }
        
    }
}
