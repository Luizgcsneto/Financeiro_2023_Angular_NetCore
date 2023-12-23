using Domain.Interfaces.IDespesa;
using Entities.Entidades;
using Infra.Repositorios.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositorios
{
    public class RepositorioDespesa : RepositorioGenerics<Despesa>, InterfaceDespesa
    {
        public Task<IList<Despesa>> ListarDespesasUsuario(string emailUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Despesa>> ListarDespesasUsuarioNaoPagasMesesAnteriores(string emailUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
