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
                return ctx.Tipos.OrderBy(a => a.descricao).ToList();
            }
        }

        public static List<Tipo> ListarTiposVerdade(int verdade_id)
        {
            using (Repositorio ctx = new Repositorio())
            {
                List<VerdadeConsequenciaTipo> vct = ctx.VerdadeConsequenciaTipos.Where(a => a.id_verdade == verdade_id).Include(a => a.Tipo).ToList();
                List<Tipo> tipos = new List<Tipo>();
                foreach (var tipo in vct)
                {
                    tipos.Add(tipo.Tipo);
                }
                return tipos;
            }
        }

        public static List<Tipo> ListarTiposConsequencia(int consequencia_id)
        {
            using (Repositorio ctx = new Repositorio())
            {
                List<VerdadeConsequenciaTipo> vct = ctx.VerdadeConsequenciaTipos.Where(a => a.id_consequencia == consequencia_id).Include(a => a.Tipo).ToList();
                List<Tipo> tipos = new List<Tipo>();
                foreach (var tipo in vct)
                {
                    tipos.Add(tipo.Tipo);
                }
                return tipos;
            }
        }

        public static bool DeletarVerdadeConsequenciaTipo(int tipo_id)
        {
            using (Repositorio ctx = new Repositorio())
            {
                List<VerdadeConsequenciaTipo> vct = ctx.VerdadeConsequenciaTipos.Where(a => a.id_tipo == tipo_id).ToList();
                foreach (var consequencia_tipo in vct)
                {
                    ctx.Remove(consequencia_tipo);
                }
                ctx.SaveChanges();
                return true;
            }
        }

        public static Tipo Salvar(Tipo tipo_)
        {
            using (Repositorio ctx = new Repositorio())
            {
                tipo_.Validar();
                tipo_.descricao = tipo_.descricao.ToUpper();
                RequisicaoHTTP requisicao = new RequisicaoHTTP();
                ctx.Tipos.Add(tipo_);
                ctx.SaveChanges();
                return tipo_;
            }
        }

        public static Tipo Editar(int uuid, Tipo tipo)
        {
            using (Repositorio ctx = new Repositorio())
            {
                Tipo _tipo = ctx.Tipos.Where(x => x.id == uuid).FirstOrDefault();
                if (_tipo == null)
                    throw new ApplicationNotFoundException(ApplicationNotFoundException.OPCAO_NAO_ENCONTRADO);

                tipo.Validar();
                _tipo.descricao = tipo.descricao.ToUpper();
                ctx.Tipos.Update(_tipo);
                ctx.SaveChanges();
                return _tipo;
            }
        }

        public static bool Deletar(int uuid)
        {
            using (Repositorio ctx = new Repositorio())
            {
                Tipo _tipo = ctx.Tipos
                    .Where(s => s.id == uuid).FirstOrDefault();

                if (_tipo == null)
                    return true;

                //desasociando todos as verdade e consequencias consequencias a este tipo
                TipoService.DeletarVerdadeConsequenciaTipo(uuid);
                
                ctx.Remove(_tipo);
                ctx.SaveChanges();

                return true;
            }
        }






    }
}