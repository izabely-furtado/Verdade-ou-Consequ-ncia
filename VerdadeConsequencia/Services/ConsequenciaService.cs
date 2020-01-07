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

        public static Consequencia Editar(int uuid, Consequencia consequencia)
        {
            using (Repositorio ctx = new Repositorio())
            {
                Consequencia _consequencia = ctx.Consequencias.Where(x => x.id == uuid).FirstOrDefault();
                if (_consequencia == null)
                    throw new ApplicationNotFoundException(ApplicationNotFoundException.CONSEQUENCIA_NAO_ENCONTRADA);

                consequencia.Validar();
                _consequencia.descricao = consequencia.descricao.ToUpper();
                _consequencia.idade = consequencia.idade;
                _consequencia.Tipos = consequencia.Tipos;
                ctx.Consequencias.Update(_consequencia);
                ctx.SaveChanges();
                return _consequencia;
            }
        }

        public static bool Deletar(int uuid)
        {
            using (Repositorio ctx = new Repositorio())
            {
                Consequencia _consequencia = ctx.Consequencias
                    .Where(s => s.id == uuid).FirstOrDefault();

                if (_consequencia == null)
                    return true;

                ctx.Remove(_consequencia);
                ctx.SaveChanges();

                return true;
            }
        }
    }
}