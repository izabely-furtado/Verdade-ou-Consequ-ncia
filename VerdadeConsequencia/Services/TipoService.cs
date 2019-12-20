using LinqKit;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using VerdadeConsequencia.Entities;
using VerdadeConsequencia.Models;
using VerdadeConsequencia.Persistencia;
using VerdadeConsequencia.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace VerdadeConsequencia.Services
{
    public class TipoService
    {

        public static Tipo Obter(int uuid)
        {
            using (Repositorio ctx = new Repositorio())
            {
                return ctx.Tipos.Where(a => a.id == uuid).FirstOrDefault();
            }
        }

        public static List<Tipo> Listar()
        {
            using (Repositorio ctx = new Repositorio())
            {
                return ctx.Tipos.ToList();
            }
        }

        public static Tipo Salvar(Tipo tipo_)
        {
            using (Repositorio ctx = new Repositorio())
            {
                tipo_.Validar();
                RequisicaoHTTP requisicao = new RequisicaoHTTP();
                ctx.Tipos.Add(tipo_);
                ctx.SaveChanges();
                return tipo_;
            }
        }

        public static bool Deletar(int uuid)
        {
            using (Repositorio ctx = new Repositorio())
            {
                Tipo _endereco = ctx.Tipos
                    .Where(s => s.id == uuid).FirstOrDefault();

                if (_endereco == null)
                    return true;

                ctx.Remove(_endereco);
                ctx.SaveChanges();

                return true;
            }
        }






    }
}