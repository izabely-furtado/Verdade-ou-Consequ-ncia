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
    public class AlertaService
    {

        public static Alerta Obter(int uuid)
        {
            using (Repositorio ctx = new Repositorio())
            {
                return ctx.Alertas.Where(a => a.id == uuid).FirstOrDefault();
            }
        }

        public static List<Alerta> Listar()
        {
            using (Repositorio ctx = new Repositorio())
            {
                return ctx.Alertas.ToList();
            }
        }

        public static Alerta Salvar(Alerta alerta_)
        {
            using (Repositorio ctx = new Repositorio())
            {
                alerta_.Validar();
                RequisicaoHTTP requisicao = new RequisicaoHTTP();
                ctx.Alertas.Add(alerta_);
                ctx.SaveChanges();
                return alerta_;
            }
        }

        public static bool Deletar(int uuid)
        {
            using (Repositorio ctx = new Repositorio())
            {
                Alerta _alerta = ctx.Alertas
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