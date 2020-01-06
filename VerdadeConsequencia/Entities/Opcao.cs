using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using VerdadeConsequencia.Util;

namespace VerdadeConsequencia.Entities
{
    public class Opcao : Entity
    {
	    public string descricao { get; set; }
        public char letra { get; set; } ///A, B, C, D, E
      
        [ForeignKey("Verdade")]
        public int id_verdade { get; set; }
        public virtual Verdade Verdade { get; set; }
        
        public void Validar()
        {
            if (String.IsNullOrEmpty(this.descricao))
                throw new ApplicationBadRequestException(ApplicationBadRequestException.DESCRICAO_INVALIDO);

            if (this.letra != 'A' && this.letra != 'B' && this.letra != 'C' && this.letra != 'D' && this.letra != 'E')
                throw new ApplicationBadRequestException(ApplicationBadRequestException.LETRA_INVALIDO);

            if (this.id_verdade == 0)
                throw new ApplicationBadRequestException(ApplicationBadRequestException.VERDADE_INVALIDO);
        }
    }
}
