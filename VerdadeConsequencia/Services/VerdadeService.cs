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
    public class VerdadeService
    {

        public static Verdade Obter(int uuid)
        {
            using (Repositorio ctx = new Repositorio())
            {
                Verdade verdade = ctx.Verdades
                    .Include(a => a.Pessoa)
                    .Include(a => a.Sequencia)
                    .Where(a => a.id == uuid).FirstOrDefault();
                if (verdade != null)
                {
                    verdade.Tipos = TipoService.ListarTiposVerdade(verdade.id);
                    verdade.Opcoes = OpcaoService.ListarPorVerdade(verdade.id);
                }
                return verdade;
            }
        }

        public static List<Verdade> Listar()
        {
            using (Repositorio ctx = new Repositorio())
            {
                List<Verdade> verdades = ctx.Verdades.Include(a => a.Pessoa).ToList();
                if (verdades != null)
                {
                    foreach (var verdade in verdades)
                    {
                        verdade.Tipos = TipoService.ListarTiposVerdade(verdade.id);
                    }
                }
                return verdades;
            }
        }

        public static Verdade Salvar(Verdade verdade_)
        {
            using (Repositorio ctx = new Repositorio())
            {
                verdade_.Validar();
                RequisicaoHTTP requisicao = new RequisicaoHTTP();

                verdade_.descricao = verdade_.descricao.ToUpper();
                ctx.Verdades.Add(verdade_);
      
                //adicionando opçoes
                foreach (var opcao in verdade_.Opcoes)
                {
                    opcao.id_verdade = verdade_.id;
                    ctx.Opcoes.Add(opcao);
                }

                //adicionando tipos
                foreach (var tipo in verdade_.Tipos) {
                    VerdadeConsequenciaTipo vct = new VerdadeConsequenciaTipo();
                    vct.id_verdade = verdade_.id;
                    vct.id_tipo = tipo.id;
                    ctx.VerdadeConsequenciaTipos.Add(vct);
                }
                ctx.SaveChanges();
                return verdade_;
            }
        }

        public static Verdade Editar(int uuid, Verdade verdade)
        {
            using (Repositorio ctx = new Repositorio())
            {
                Verdade _verdade = ctx.Verdades.Where(x => x.id == uuid).FirstOrDefault();
                if (_verdade == null)
                    throw new ApplicationNotFoundException(ApplicationNotFoundException.VERDADE_NAO_ENCONTRADA);

                verdade.Validar();
                _verdade = verdade;
                _verdade.descricao = verdade.descricao.ToUpper();
                
                //removendo opções
                List<Opcao> opcoes_ = OpcaoService.ListarPorVerdade(uuid);
                foreach (var opcao in opcoes_)
                {
                    ctx.Remove(opcao);
                    ctx.SaveChanges();
                }

                //removendo tipos
                List<VerdadeConsequenciaTipo> tipos_vc = ctx.VerdadeConsequenciaTipos.Where(a => a.id_verdade == uuid).ToList();
                foreach (var tipo_vc in tipos_vc)
                {
                    ctx.Remove(tipo_vc);
                    ctx.SaveChanges();
                }

                //adicionando opçoes
                foreach (var opcao in _verdade.Opcoes)
                {
                    opcao.id_verdade = _verdade.id;
                    opcao.id = 0;
                    ctx.Opcoes.Add(opcao);
                    ctx.SaveChanges();
                }
               
                //adicionando tipos
                foreach (var tipo in _verdade.Tipos)
                {
                    VerdadeConsequenciaTipo vct = new VerdadeConsequenciaTipo();
                    vct.id_verdade = _verdade.id;
                    vct.id_tipo = tipo.id;
                    ctx.VerdadeConsequenciaTipos.Add(vct);
                    ctx.SaveChanges();
                }

                //_verdade.Opcoes = null;
                //_verdade.Tipos = null;
                //ctx.Verdades.Update(_verdade);
                ctx.SaveChanges();
                return _verdade;
            }
        }

        public static bool Deletar(int uuid)
        {
            using (Repositorio ctx = new Repositorio())
            {
                Verdade _verdade = ctx.Verdades
                    .Where(s => s.id == uuid).FirstOrDefault();

                if (_verdade == null)
                    return true;

                //removendo opções
                List<Opcao> opcoes = OpcaoService.ListarPorVerdade(uuid);
                foreach (var opcao in opcoes)
                {
                    ctx.Remove(opcao);
                }

                //removendo tipos vinculados
                List<VerdadeConsequenciaTipo> vcts = ctx.VerdadeConsequenciaTipos.Where(x => x.id_verdade == uuid).ToList();
                foreach (var vct in vcts)
                {
                    ctx.Remove(vct);
                }

                ctx.Remove(_verdade);
                ctx.SaveChanges();

                return true;
            }
        }

        
    }
}