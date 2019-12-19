﻿using ApiCliente.Models;
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
    public class PessoasController : ApiClienteController
    {
        public PessoasController(IMapper mapper, IOptions<AppSettings> appSettings, IOptions<TokenSettings> tokenSetting)
           : base(mapper, appSettings, tokenSetting) { }

        [HttpGet]
        public IActionResult Listar(int? pagina)
        {
            if (pagina != null && pagina > 0)
            {
                PaginacaoModel _paginacao = PessoaService.ListarPagina((int)pagina);
                _paginacao.conteudo = _mapperResponse.Map<List<PessoaResponse>>(_paginacao.conteudo);
                return Ok(_paginacao);
            }

            return Ok(_mapperResponse.Map<List<PessoaResponse>>(PessoaService.Listar()));
        }

        [HttpGet("{cpf}")]
        public ActionResult<PessoaResponse> Obter(string uuid)
        {
            return Ok(_mapperResponse.Map<PessoaResponse>(PessoaService.Obter(uuid)));
        }

        [HttpPost]
        public ActionResult<PessoaResponse> Salvar([FromBody] PessoaRequest pessoaRequest)
        {
            Pessoa pessoa = _mapperRequest.Map<Pessoa>(pessoaRequest);
            return Ok(_mapperResponse.Map<PessoaResponse>(PessoaService.Salvar(pessoa)));
        }

        [HttpPut("{id}")]
        public ActionResult<PessoaResponse> Editar(int uuid, [FromBody] PessoaRequest funcionarioRequest)
        {
            Pessoa funcionario = _mapperRequest.Map<Pessoa>(funcionarioRequest);
            return Ok(_mapperResponse.Map<PessoaResponse>(PessoaService.Editar(uuid, funcionario)));
        }

        [HttpDelete("{cpf}")]
        public ActionResult DeletarPessoa(string uuid)
        {
            return Ok(PessoaService.Deletar(uuid));
        }

        //[HttpPatch("{id}/FotoPerfil")]
        //public ActionResult PatchFotoPerfil(string uuid, string foto_perfil)
        //{
        //    return Ok(PessoaService.PatchFotoPerfil( uuid, foto_perfil));
        //}

    }
}
