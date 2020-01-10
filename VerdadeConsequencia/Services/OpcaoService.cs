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
    public class OpcaoService
    {

        public static Opcao Obter(int uuid)
        {
            using (Repositorio ctx = new Repositorio())
            {
                return ctx.Opcoes.Include(a => a.Verdade).Where(a => a.id == uuid).FirstOrDefault();
            }
        }

        public static List<Opcao> Listar()
        {
            using (Repositorio ctx = new Repositorio())
            {
                return ctx.Opcoes.ToList();
            }
        }

        public static List<Opcao> ListarPorVerdade(int id_verdade)
        {
            using (Repositorio ctx = new Repositorio())
            {
                return ctx.Opcoes.Where(a => a.id_verdade == id_verdade).OrderBy(l => l.letra).ToList();
            }
        }

        public static Opcao Salvar(Opcao verdade_)
        {
            using (Repositorio ctx = new Repositorio())
            {
                verdade_.Validar();
                RequisicaoHTTP requisicao = new RequisicaoHTTP();
                ctx.Opcoes.Add(verdade_);
                ctx.SaveChanges();
                return verdade_;
            }
        }

        public static Opcao Editar(int uuid, Opcao opcao)
        {
            using (Repositorio ctx = new Repositorio())
            {
                Opcao _opcao = ctx.Opcoes.Where(x => x.id == uuid).FirstOrDefault();
                if (_opcao == null)
                    throw new ApplicationNotFoundException(ApplicationNotFoundException.OPCAO_NAO_ENCONTRADO);

                opcao.Validar();
                _opcao.descricao = opcao.descricao.ToUpper();
                ctx.Opcoes.Update(_opcao);
                ctx.SaveChanges();
                return _opcao;
            }
        }

        public static bool Deletar(int uuid)
        {
            using (Repositorio ctx = new Repositorio())
            {
                Opcao _verdade = ctx.Opcoes
                    .Where(s => s.id == uuid).FirstOrDefault();

                if (_verdade == null)
                    return true;

                ctx.Remove(_verdade);
                ctx.SaveChanges();

                return true;
            }
        }
    }
}