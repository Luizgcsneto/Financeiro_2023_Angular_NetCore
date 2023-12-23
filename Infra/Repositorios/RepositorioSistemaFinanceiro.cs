using Domain.Interfaces.ISistemaFinanceiro;
using Entities.Entidades;
using Infra.Repositorios.Generics;

namespace Infra.Repositorios
{
    public class RepositorioSistemaFinanceiro : RepositorioGenerics<SistemaFinanceiro>, InterfaceSistemaFinanceiro
    {
        public Task<IList<SistemaFinanceiro>> ListarSistemasUsuario(string emailUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
