﻿using Domain.Interfaces.ICategoria;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorios.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorios
{
    public class RepositorioCategoria : RepositorioGenerics<Categoria>, InterfaceCategoria
    {
        private readonly DbContextOptions<ContextoBase> _optionsBuilder;
        public RepositorioCategoria()
        {
            _optionsBuilder = new DbContextOptions<ContextoBase>();
        }
        public async Task<IList<Categoria>> ListarCategoriasUsuario(string emailUsuario)
        {
            using(var banco = new ContextoBase(_optionsBuilder))
            {
                return await 
                    (from s in banco.SistemaFinanceiro
                     join c in banco.Categoria on s.Id equals c.IdSistema
                     join us in banco.UsuarioSistemaFinanceiro on s.Id equals us.IdSistema
                     where us.EmailUsuario.Equals(emailUsuario) && us.SistemaAtual
                     select c).AsNoTracking().ToListAsync();
            }
        }
    }
}
