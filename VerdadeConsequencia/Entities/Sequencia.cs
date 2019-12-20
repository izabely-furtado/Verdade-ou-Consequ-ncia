using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using VerdadeConsequencia.Util;

namespace VerdadeConsequencia.Entities
{
    public class Sequencia : Entity
    {
        public string descricao { get; set; }
      
        [ForeignKey("Consequencia")]
        public int? resultado_a { get; set; }
        //public virtual Consequencia Resultado_a { get; set; }

        [ForeignKey("Consequencia")]
        public int? resultado_b { get; set; }
        //public virtual Consequencia Resultado_b { get; set; }

        [ForeignKey("Consequencia")]
        public int? resultado_c { get; set; }
        //public virtual Consequencia Resultado_c { get; set; }

        [ForeignKey("Consequencia")]
        public int? resultado_d { get; set; }
        //public virtual Consequencia Resultado_d { get; set; }

        [ForeignKey("Consequencia")]
        public int? resultado_e { get; set; }
        //public virtual Consequencia Resultado_e { get; set; }

        public void Validar()
        {
            if (String.IsNullOrEmpty(this.descricao))
                throw new ApplicationBadRequestException(ApplicationBadRequestException.DESCRICAO_INVALIDO);

            if (this.resultado_a == 0)
                throw new ApplicationBadRequestException(ApplicationBadRequestException.RESULTADO_INVALIDA + " A");

            if (this.resultado_b == 0)
                throw new ApplicationBadRequestException(ApplicationBadRequestException.RESULTADO_INVALIDA + " B");

            if (this.resultado_c == 0)
                throw new ApplicationBadRequestException(ApplicationBadRequestException.RESULTADO_INVALIDA + " C");

            if (this.resultado_d == 0)
                throw new ApplicationBadRequestException(ApplicationBadRequestException.RESULTADO_INVALIDA + " D");

            if (this.resultado_e == 0)
                throw new ApplicationBadRequestException(ApplicationBadRequestException.RESULTADO_INVALIDA + " E");
        }
    }
}
