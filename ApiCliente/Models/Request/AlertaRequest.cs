namespace ApiCliente.Models.Request
{
    public class AlertaRequest
    {
        public string descricao { get; set; }
        public int tipo { get; set; } //--tipo 1-pulo | 2-21+ | 3-parabenizacao
        public int id { get; set; }
    }
}
