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
using static VerdadeConsequencia.Services.PessoaService;

namespace ApiCliente.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class PessoaController : ApiClienteController
    {
        public PessoaController(IMapper mapper, IOptions<AppSettings> appSettings, IOptions<TokenSettings> tokenSetting)
           : base(mapper, appSettings, tokenSetting) { }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_mapperResponse.Map<List<PessoaResponse>>(PessoaService.Listar()));
        }

        [HttpGet("{id}")]
        public ActionResult<PessoaResponse> Obter(int id)
        {
            return Ok(_mapperResponse.Map<PessoaResponse>(PessoaService.Obter(id)));
        }

        [HttpPost]
        public ActionResult<PessoaResponse> Salvar([FromBody] PessoaRequest funcionarioRequest)
        {
            Pessoa pessoa = _mapperRequest.Map<Pessoa>(funcionarioRequest);
            return Ok(_mapperResponse.Map<PessoaResponse>(PessoaService.Salvar(pessoa)));
        }

        [HttpDelete("{id}")]
        public ActionResult DeletarPessoa(int id)
        {
            return Ok(PessoaService.Deletar(id));
        }

        ////// coisas do antigo
        ///[HttpGet]
        //public IActionResult Listar(int? pagina)
        //{
        //    if (pagina != null && pagina > 0)
        //    {
        //        PaginacaoModel _paginacao = PessoaService.ListarPagina((int)pagina);
        //        _paginacao.conteudo = _mapperResponse.Map<List<PessoaResponse>>(_paginacao.conteudo);
        //        return Ok(_paginacao);
        //    }

        //    return Ok(_mapperResponse.Map<List<PessoaResponse>>(PessoaService.Listar()));
        //}

        //[HttpGet("{cpf}")]
        //public ActionResult<PessoaResponse> Obter(string uuid)
        //{
        //    return Ok(_mapperResponse.Map<PessoaResponse>(PessoaService.Obter(uuid)));
        //}

        //[HttpPost]
        //public ActionResult<PessoaResponse> Salvar([FromBody] PessoaRequest pessoaRequest)
        //{
        //    Pessoa1 pessoa = _mapperRequest.Map<Pessoa1>(pessoaRequest);
        //    return Ok(_mapperResponse.Map<PessoaResponse>(PessoaService.Salvar(pessoa)));
        //}

        //[HttpPut("{id}")]
        //public ActionResult<PessoaResponse> Editar(int uuid, [FromBody] PessoaRequest funcionarioRequest)
        //{
        //    Pessoa1 funcionario = _mapperRequest.Map<Pessoa1>(funcionarioRequest);
        //    return Ok(_mapperResponse.Map<PessoaResponse>(PessoaService.Editar(uuid, funcionario)));
        //}

        //[HttpDelete("{cpf}")]
        //public ActionResult DeletarPessoa(string uuid)
        //{
        //    return Ok(PessoaService.Deletar(uuid));
        //}

        ////[HttpPatch("{id}/FotoPerfil")]
        ////public ActionResult PatchFotoPerfil(string uuid, string foto_perfil)
        ////{
        ////    return Ok(PessoaService.PatchFotoPerfil( uuid, foto_perfil));
        ////}

    }
}
