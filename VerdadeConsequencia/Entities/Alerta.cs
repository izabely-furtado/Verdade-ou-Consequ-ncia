using NusaJwt;
using VerdadeConsequencia.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace VerdadeConsequencia.Entities
{
    public class Alerta : Entity
    {
        public string descricao { get; set; }
        public int tipo { get; set; } //--tipo 1-pulo | 2-21+ | 3-parabenizacao
        
        public void Validar()
        {
            if (String.IsNullOrEmpty(this.descricao))
                throw new ApplicationBadRequestException(ApplicationBadRequestException.DESCRICAO_INVALIDO);

            if (this.tipo != 1 && this.tipo != 2 && this.tipo != 3 && this.tipo != 4)
                throw new ApplicationBadRequestException(ApplicationBadRequestException.TIPO_INVALIDO);
        }
    }
}
