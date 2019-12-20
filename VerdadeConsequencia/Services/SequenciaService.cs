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
    public class SequenciaService
    {

        public static Sequencia Obter(int uuid)
        {
            using (Repositorio ctx = new Repositorio())
            {
                return ctx.Sequencias
                    //.Include(a => a.ConsequenciaA)
                    //.Include(a => a.ConsequenciaB)
                    //.Include(a => a.ConsequenciaC)
                    //.Include(a => a.ConsequenciaD)
                    //.Include(a => a.ConsequenciaE)
                    .Where(a => a.id == uuid).FirstOrDefault();
            }
        }

        public static List<Sequencia> Listar()
        {
            using (Repositorio ctx = new Repositorio())
            {
                return ctx.Sequencias.ToList();
            }
        }

        public static Sequencia Salvar(Sequencia sequencia_)
        {
            using (Repositorio ctx = new Repositorio())
            {
                sequencia_.Validar();
                RequisicaoHTTP requisicao = new RequisicaoHTTP();
                ctx.Sequencias.Add(sequencia_);
                ctx.SaveChanges();
                return sequencia_;
            }
        }

        public static bool Deletar(int uuid)
        {
            using (Repositorio ctx = new Repositorio())
            {
                Sequencia _sequencia = ctx.Sequencias
                    .Where(s => s.id == uuid).FirstOrDefault();

                if (_sequencia == null)
                    return true;

                ctx.Remove(_sequencia);
                ctx.SaveChanges();

                return true;
            }
        }
    }
}