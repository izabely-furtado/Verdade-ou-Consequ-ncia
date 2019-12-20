using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using VerdadeConsequencia.Util;

namespace VerdadeConsequencia.Entities
{
    public class Tipo : Entity
    {
        public string descricao { get; set; }

        public void Validar()
        {
            if (String.IsNullOrEmpty(this.descricao))
                throw new ApplicationBadRequestException(ApplicationBadRequestException.DESCRICAO_INVALIDO);
        }
    }
}
