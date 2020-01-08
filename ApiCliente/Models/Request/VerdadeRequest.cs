using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace ApiCliente.Models.Request
{
    public class VerdadeRequest
    {
        public string descricao { get; set; }
        public int idade { get; set; }
        public PessoaRequest Pessoa { get; set; }
        public SequenciaRequest sequencia { get; set; }
        public List<TipoRequest> Tipos { get; set; }
        public List<OpcaoRequest> Opcoes { get; set; }
        public int id { get; set; }
    }
}
