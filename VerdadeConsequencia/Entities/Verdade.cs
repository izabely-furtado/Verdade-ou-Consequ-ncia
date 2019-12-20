using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using VerdadeConsequencia.Util;

namespace VerdadeConsequencia.Entities
{
    public class Verdade : Entity
    {
        public string descricao { get; set; }
        public int idade { get; set; }
      
        [ForeignKey("Pessoa")]
        public int? id_pessoa { get; set; }
        public virtual Pessoa Pessoa { get; set; }

        [ForeignKey("Sequencia")]
        public int? id_sequencia { get; set; }
        public virtual Sequencia Sequencia { get; set; }

        public void Validar()
        {
            if (String.IsNullOrEmpty(this.descricao))
                throw new ApplicationBadRequestException(ApplicationBadRequestException.DESCRICAO_INVALIDO);

            if (this.idade > 21)
                throw new ApplicationBadRequestException(ApplicationBadRequestException.IDADE_INVALIDA);
        }
    }
}
