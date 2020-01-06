using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using VerdadeConsequencia.Util;

namespace VerdadeConsequencia.Entities
{
    public class VerdadeConsequenciaTipo : Entity
    {
        public int tipo_vdd_ou_consequencia { get; set; } //-- 1-vdd 2-consequencia
  
        [ForeignKey("id_tipo")]
        public int id_tipo { get; set; }
        public virtual Tipo Tipo { get; set; }

        [ForeignKey("id_verdade")]
        public int? id_verdade { get; set; }
        public virtual Verdade Verdade { get; set; }

        [ForeignKey("id_consequencia")]
        public int? id_consequencia { get; set; }
        public virtual Consequencia Consequencia { get; set; }

        public void Validar()
        {
            if (id_tipo == 0)
                throw new ApplicationBadRequestException(ApplicationBadRequestException.TIPO_INVALIDO);

            if (id_verdade == 0)
                throw new ApplicationBadRequestException(ApplicationBadRequestException.VERDADE_INVALIDO);

            if (id_consequencia == 0)
                throw new ApplicationBadRequestException(ApplicationBadRequestException.CONSEQUENCIA_INVALIDO);
        }
    }
}
