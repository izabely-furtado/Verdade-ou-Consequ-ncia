namespace ApiCliente.Models.Request
{
    public class VerdadeConsequenciaTipoRequest
    {
        public int tipo_vdd_ou_consequencia { get; set; } //-- 1-vdd 2-consequencia
        public virtual TipoRequest Tipo { get; set; }
        public virtual VerdadeRequest Verdade { get; set; }
        public virtual ConsequenciaRequest Consequencia { get; set; }
    }
}
