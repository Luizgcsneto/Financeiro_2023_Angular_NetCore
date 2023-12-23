using Domain.Interfaces.ISistemaFinanceiro;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorios.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorios
{
    public class RepositorioSistemaFinanceiro : RepositorioGenerics<SistemaFinanceiro>, InterfaceSistemaFinanceiro
    {
        private readonly DbContextOptions<ContextoBase> _optionsBuilder;
        public RepositorioSistemaFinanceiro()
        {
            _optionsBuilder = new DbContextOptions<ContextoBase>();
        }
        public async Task<IList<SistemaFinanceiro>> ListarSistemasUsuario(string emailUsuario)
        {
            using(var banco = new ContextoBase(_optionsBuilder))
            {
                return await
                    (from s in banco.SistemaFinanceiro
                     join us in banco.UsuarioSistemaFinanceiro on s.Id equals us.IdSistema
                     where us.EmailUsuario.Equals(emailUsuario)
                     select s).AsNoTracking().ToListAsync();
            }
        }
    }
}
