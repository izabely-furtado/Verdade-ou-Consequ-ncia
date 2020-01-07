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
                Consequencia consequencia = ctx.Consequencias.Include(a => a.Pessoa).Where(a => a.id == uuid).FirstOrDefault();
                if (consequencia != null)
                {
                    consequencia.Tipos = TipoService.ListarTiposConsequencia(consequencia.id);
                }
                return consequencia;
            }
        }

        public static List<Consequencia> Listar()
        {
            using (Repositorio ctx = new Repositorio())
            {
                List<Consequencia> consequencias = ctx.Consequencias.Include(a => a.Pessoa).ToList();
                if (consequencias != null)
                {
                    foreach (var consequencia in consequencias)
                    {
                        consequencia.Tipos = TipoService.ListarTiposConsequencia(consequencia.id);
                    }
                }
                return consequencias;
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