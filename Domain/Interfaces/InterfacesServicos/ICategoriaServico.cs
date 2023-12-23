using Entities.Entidades;

namespace Domain.Interfaces.InterfacesServicos
{
    public interface ICategoriaServico
    {
        Task AdicionarCategoria(Categoria categoria);
        Task AtualizarCategoria(Categoria categoria);
    }
}
