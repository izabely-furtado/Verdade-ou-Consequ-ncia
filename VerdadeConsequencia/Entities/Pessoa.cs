﻿using NusaJwt;
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
        public string sobrenome { get; set; }
        public string telefone_ddd { get; set; }
        public string telefone_numero { get; set; }
        public string cpf { get; set; }
        public DateTime? data_nascimento { get; set; }
        public string Email { get; set; }

        public virtual List<Endereco> enderecos { get; set; }

        //public string FotoPerfil { get; set; }

        public void Validar()
        {
            if (String.IsNullOrEmpty(this.nome) || String.IsNullOrEmpty(this.sobrenome))
                throw new ApplicationBadRequestException(ApplicationBadRequestException.NOME_INVALIDO);

            if (String.IsNullOrEmpty(this.cpf) || !Documento.ValidarCpf(this.cpf))
                throw new ApplicationBadRequestException(ApplicationBadRequestException.CPF_INVALIDO);

            if (this.data_nascimento <= DateTime.MinValue || this.data_nascimento >= DateTime.MaxValue || this.data_nascimento > DateTime.Now)
                throw new ApplicationBadRequestException(ApplicationBadRequestException.DATA_NASCIMENTO_INVALIDA);

            if(!String.IsNullOrEmpty(this.telefone_ddd))
            {
                if (!Telefone.ValidaDdd(this.telefone_ddd))
                    throw new ApplicationBadRequestException(ApplicationBadRequestException.DDD_TELEFONE_INVALIDO);
            }

            if (!String.IsNullOrEmpty(this.telefone_numero))
            {
                if (!Telefone.ValidaTelefone(this.telefone_numero))
                    throw new ApplicationBadRequestException(ApplicationBadRequestException.TELEFONE_INVALIDO);
                this.telefone_numero = this.telefone_numero.Replace("-", "");
            }

            //if (!String.IsNullOrEmpty(this.Email)) {
            //    if (!Validador.ValidarEmail(this.Email))
            //        throw new ApplicationBadRequestException(ApplicationBadRequestException.EMAIL_INVALIDO);
            //}

            this.cpf = this.cpf.Replace("-", "");
            this.cpf = this.cpf.Replace(".", "");

            if (this.enderecos != null && this.enderecos.Count > 0)
            {
                List<Endereco> lista = new List<Endereco>();
                foreach (var item in this.enderecos)
                {
                    Endereco endereco = lista.Where(x => x.id == item.id).FirstOrDefault();
                    if (endereco == null)
                    {
                        lista.Add(item);
                    }
                }
                this.enderecos = lista;
            }
            this.nome = this.nome.ToUpper().Trim();
            this.sobrenome = this.sobrenome.ToUpper().Trim();
        }
    }
}
