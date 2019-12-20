using System;

namespace ApiCliente.Models.Response
{
    public class VerdadeConsequenciaTipoResponse
    {
        public int tipo_vdd_ou_consequencia { get; set; } //-- 1-vdd 2-consequencia
        public virtual TipoResponse Tipo { get; set; }
        public virtual VerdadeResponse Verdade { get; set; }
        public virtual ConsequenciaResponse Consequencia { get; set; }
    }
}
