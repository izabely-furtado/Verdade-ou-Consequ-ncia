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
    public class ConsequenciaService
    {

        public static Consequencia Obter(int uuid)
        {
            using (Repositorio ctx = new Repositorio())
            {
                return ctx.Consequencias.Include(a => a.Pessoa).Where(a => a.id == uuid).FirstOrDefault();
            }
        }

        public static List<Consequencia> Listar()
        {
            using (Repositorio ctx = new Repositorio())
            {
                return ctx.Consequencias.ToList();
            }
        }

        public static Consequencia Salvar(Consequencia consequencia_)
        {
            using (Repositorio ctx = new Repositorio())
            {
                consequencia_.Validar();
                RequisicaoHTTP requisicao = new RequisicaoHTTP();
                ctx.Consequencias.Add(consequencia_);
                ctx.SaveChanges();
                return consequencia_;
            }
        }

        public static bool Deletar(int uuid)
        {
            using (Repositorio ctx = new Repositorio())
            {
                Consequencia _alerta = ctx.Consequencias
                    .Where(s => s.id == uuid).FirstOrDefault();

                if (_alerta == null)
                    return true;

                ctx.Remove(_alerta);
                ctx.SaveChanges();

                return true;
            }
        }
    }
}