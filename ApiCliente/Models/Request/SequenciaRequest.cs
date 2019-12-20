using System;
namespace ApiCliente.Models.Request
{
    public class SequenciaRequest
    {
        public string descricao { get; set; }
        //public ConsequenciaRequest ConsequenciaA { get; set; }
        //public ConsequenciaRequest ConsequenciaB { get; set; }
        //public ConsequenciaRequest ConsequenciaC { get; set; }
        //public ConsequenciaRequest ConsequenciaD { get; set; }
        //public ConsequenciaRequest ConsequenciaE { get; set; }
        public int resultado_a { get; set; }
        public int resultado_b { get; set; }
        public int resultado_c { get; set; }
        public int resultado_d { get; set; }
        public int resultado_e { get; set; }
    }
}
