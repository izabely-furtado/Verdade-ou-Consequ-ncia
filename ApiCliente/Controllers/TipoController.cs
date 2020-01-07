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
using static VerdadeConsequencia.Services.TipoService;

namespace ApiCliente.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class TipoController : ApiClienteController
    {
        public TipoController(IMapper mapper, IOptions<AppSettings> appSettings, IOptions<TokenSettings> tokenSetting)
           : base(mapper, appSettings, tokenSetting) { }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_mapperResponse.Map<List<TipoResponse>>(TipoService.Listar()));
        }

        [HttpGet("{id}")]
        public ActionResult<TipoResponse> Obter(int id)
        {
            return Ok(_mapperResponse.Map<TipoResponse>(TipoService.Obter(id)));
        }

        [HttpPost]
        public ActionResult<TipoResponse> Salvar([FromBody] TipoRequest funcionarioRequest)
        {
            Tipo pessoa = _mapperRequest.Map<Tipo>(funcionarioRequest);
            return Ok(_mapperResponse.Map<TipoResponse>(TipoService.Salvar(pessoa)));
        }

        [HttpPut("{id}")]
        public ActionResult<TipoResponse> Editar(int id, [FromBody] TipoRequest tipoRequest)
        {
            Tipo tipo = _mapperRequest.Map<Tipo>(tipoRequest);
            return Ok(_mapperResponse.Map<TipoResponse>(TipoService.Editar(id, tipo)));
        }

        [HttpDelete("{id}")]
        public ActionResult DeletarTipo(int id)
        {
            return Ok(TipoService.Deletar(id));
        }
        
    }
}
