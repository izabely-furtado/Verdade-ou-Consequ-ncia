using ApiCliente.Models;
using ApiCliente.Models.Request;
using ApiCliente.Models.Response;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using VerdadeConsequencia.Entities;

namespace ApiCliente.Controllers
{
    public class ApiClienteController : ControllerBase
    {
        protected readonly AppSettings _appSettings;
        protected readonly TokenSettings _tokenSettings;
        protected IMapper _mapperRequest;
        protected IMapper _mapperResponse;

        public ApiClienteController(IMapper mapper, IOptions<AppSettings> appSettings, IOptions<TokenSettings> tokenSettings)
        {

            var configRequest = new MapperConfiguration(cfg =>
            {
                cfg.SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
                cfg.DestinationMemberNamingConvention = new PascalCaseNamingConvention();

                cfg.CreateMap<AlertaRequest, Alerta>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                cfg.CreateMap<PessoaRequest, Pessoa>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                cfg.CreateMap<ConsequenciaRequest, Consequencia>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                cfg.CreateMap<SequenciaRequest, Sequencia>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                cfg.CreateMap<VerdadeRequest, Verdade>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                cfg.CreateMap<OpcaoRequest, Opcao>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                cfg.CreateMap<TipoRequest, Tipo>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                cfg.CreateMap<VerdadeConsequenciaTipoRequest, VerdadeConsequenciaTipo>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            });

            var configResponse = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AlertaRequest, Alerta>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                cfg.CreateMap<PessoaRequest, Pessoa>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                cfg.CreateMap<ConsequenciaRequest, Consequencia>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                cfg.CreateMap<SequenciaRequest, Sequencia>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                cfg.CreateMap<VerdadeRequest, Verdade>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                cfg.CreateMap<OpcaoRequest, Opcao>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                cfg.CreateMap<TipoRequest, Tipo>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                cfg.CreateMap<VerdadeConsequenciaTipoRequest, VerdadeConsequenciaTipo>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                
            });

            _mapperResponse = new Mapper(configResponse);
            _mapperRequest = new Mapper(configRequest);
            _appSettings = appSettings.Value;
            _tokenSettings = tokenSettings.Value;
        }

        
       
    }
}
