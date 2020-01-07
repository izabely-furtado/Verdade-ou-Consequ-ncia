using System;
namespace ApiCliente.Models.Request
{
    public class SequenciaRequest
    {
        public string descricao { get; set; }
        public ConsequenciaRequest Resultado_A { get; set; }
        public ConsequenciaRequest Resultado_B { get; set; }
        public ConsequenciaRequest Resultado_C { get; set; }
        public ConsequenciaRequest Resultado_D { get; set; }
        public ConsequenciaRequest Resultado_E { get; set; }
        //public int resultado_a { get; set; }
        //public int resultado_b { get; set; }
        //public int resultado_c { get; set; }
        //public int resultado_d { get; set; }
        //public int resultado_e { get; set; }
        public int id { get; set; }
    }
}
