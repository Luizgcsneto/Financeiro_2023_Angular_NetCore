using Domain.Interfaces.IUsuarioSistemaFinanceiro;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorios.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorios
{
    public class RepositorioUsuarioSistemaFinanceiro : RepositorioGenerics<UsuarioSistemaFinanceiro>, InterfaceUsuarioSistemaFinanceiro
    {
        private readonly DbContextOptions<ContextoBase> _optionsBuilder;
        public RepositorioUsuarioSistemaFinanceiro()
        {
            _optionsBuilder = new DbContextOptions<ContextoBase>();
        }
        public async Task<IList<UsuarioSistemaFinanceiro>> ListarUsuarioSistemas(int idSistema)
        {
            using (var banco = new ContextoBase(_optionsBuilder))
            {
                return await banco.UsuarioSistemaFinanceiro.Where(
                    s => s.IdSistema == idSistema).AsNoTracking().ToListAsync();

            }
        }

        public async Task<UsuarioSistemaFinanceiro> ObterUsuarioPorEmail(string emailUsuario)
        {
            using(var banco = new ContextoBase(_optionsBuilder))
            {
                return await banco.UsuarioSistemaFinanceiro
                    .AsNoTracking().FirstOrDefaultAsync(x => x.EmailUsuario.Equals(emailUsuario));
            }
        }

        public async Task RemoverUsuarios(List<UsuarioSistemaFinanceiro> usuarios)
        {
            using(var banco =new ContextoBase(_optionsBuilder))
            {
                banco.UsuarioSistemaFinanceiro.RemoveRange(usuarios);

                await banco.SaveChangesAsync();
            }
        }
    }
}
