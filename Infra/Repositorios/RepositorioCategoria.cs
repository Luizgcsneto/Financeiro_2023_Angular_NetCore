using Domain.Interfaces.ICategoria;
using Entities.Entidades;
using Infra.Repositorios.Generics;

namespace Infra.Repositorios
{
    public class RepositorioCategoria : RepositorioGenerics<Categoria>, InterfaceCategoria
    {
    }
}
