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
                ctx.Verdades.Add(verdade_);
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
                    throw new ApplicationNotFoundException(ApplicationNotFoundException.FUNCIONARIO_NAO_ENCONTRADO);

                verdade.Validar();
                _verdade.descricao = verdade.descricao.ToUpper();
                _verdade.idade = verdade.idade;
                _verdade.Tipos = verdade.Tipos;
                ctx.Verdades.Update(_verdade);
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

                ctx.Remove(_verdade);
                ctx.SaveChanges();

                return true;
            }
        }
    }
}