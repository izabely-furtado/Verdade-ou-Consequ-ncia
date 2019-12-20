using NusaJwt;
using VerdadeConsequencia.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace VerdadeConsequencia.Entities
{
    public class Pessoa : Entity
    {
        public string nome { get; set; }
        public int sexo { get; set; } //-- 1-masculino | 2-feminino | 3-ambos
        public Boolean gosto_feminino { get; set; }
        public Boolean gosto_masculino { get; set; }

        public void Validar()
        {
            if (String.IsNullOrEmpty(this.nome))
                throw new ApplicationBadRequestException(ApplicationBadRequestException.NOME_INVALIDO);

            if (this.sexo != 1 || this.sexo != 2 || this.sexo != 3)
                throw new ApplicationBadRequestException(ApplicationBadRequestException.SEXO_INVALIDO);
        }
    }
}
