using System;

namespace ApiCliente.Models.Response
{
    public class SequenciaResponse
    {
        public string descricao { get; set; }
        public ConsequenciaResponse ConsequenciaA { get; set; }
        public ConsequenciaResponse ConsequenciaB { get; set; }
        public ConsequenciaResponse ConsequenciaC { get; set; }
        public ConsequenciaResponse ConsequenciaD { get; set; }
        public ConsequenciaResponse ConsequenciaE { get; set; }
    }
}
