using System.Collections.Generic;

namespace ApiCliente.Models.Response
{
    public class AlertaResponse
    {
        public string descricao { get; set; }
        public int tipo { get; set; } //--tipo 1-pulo | 2-21+ | 3-parabenizacao
        public int id { get; set; }
    }
}